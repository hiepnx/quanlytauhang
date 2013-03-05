using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;
using ETrains.Utilities.Enums;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Reflection;

namespace ETrains.Train
{
    public partial class frmBBBG : Form
    {
        private short _type; //0: xuat canh, 1 nhap canh
        private short _mode; //0: addnew, 1: edit
        private UserInfo _userInfo;
        private List<tblToaTau> listToaTau = new List<tblToaTau>();
        private tblHandover _handover;

        public frmBBBG()
        {
            InitializeComponent();
        }
        public frmBBBG(UserInfo userInfo, short type, short mode = (short)0)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
        }

        public frmBBBG(UserInfo userInfo, short type, tblHandover handover, short mode = (short)1)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
            _handover = handover;
        }

        private void frmBBBG_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao tau hang " + (_type == 0 ? "xuat canh" : "nhap canh") + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            if (_type == 0)
            {
                lblHeader.Text = "Cập nhật Biên bản bàn giao, chuyển đến";
                lblCodeGaDenDi.Text = "Mã HQ ga đi";
                lblGaDenDi.Text = "Tên HQ ga đi";
            }
            else if (_type == 1)
            {
                lblHeader.Text = "Cập nhật Biên bản bàn giao, hồi báo";
                lblCodeGaDenDi.Text = "Mã HQ ga đến";
                lblGaDenDi.Text = "Tên HQ ga đến";
            }
            
            ////init ma cua khau
            var listHQ = CustomsFacory.getAll();
            var listStation = new List<tblCustom>();
            listStation.AddRange(listHQ);
            listStation.Insert(0, new tblCustom
            {
                CustomsName = "Tên HQ Cửa khẩu",
                CustomsCode = ""
            });
            ddlCuaKhau.DataSource = listStation.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            ddlCuaKhau.ValueMember = "CustomsCode";
            ddlCuaKhau.DisplayMember = "CustomsName";
            ddlCuaKhau.SelectedIndex = 0;
            //init ma ga den di
            var listGaDenDi = new List<tblCustom>();
            listGaDenDi.AddRange(listHQ);
            listGaDenDi.Insert(0, new tblCustom
            {
                CustomsName = lblGaDenDi.Text,
                CustomsCode = ""
            });
            ddlGaDenDi.DataSource = listGaDenDi.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            ddlGaDenDi.ValueMember = "CustomsCode";
            ddlGaDenDi.DisplayMember = "CustomsName";
            ddlGaDenDi.SelectedIndex = 0;

            //grid Toa tau
            grdToaTau.AutoGenerateColumns = false;

            //mode
            if (_mode == 0)
            {
                btnUpdate.Enabled = btnDelete.Enabled = false;
                btnPrintBBBG.Visible = false;
            }
            else
            {
                btnAddNew.Enabled = false;
                btnPrintBBBG.Visible = true;
                InitData();
            }
        }

        private void InitData()
        {
            if (_handover == null) return;
            _handover = TrainFactory.FindHandoverByID(_handover.ID);
            txtNumberHandover.Text = _handover.NumberHandover;
            dtpHandover.Value = (DateTime) _handover.DateHandover;
            txtCodeCuaKhau.Text = _handover.CodeStation;
            ddlCuaKhau.SelectedValue = _handover.CodeStation; 
            txtCodeGaDenDi.Text = _handover.CodeStationFromTo;
            ddlGaDenDi.SelectedValue = _handover.CodeStationFromTo;
            txtStatusGood.Text = _handover.StatusGoods;
            txtStatusVehicle.Text = _handover.StatusVehicle;
            txtNumberTrain.Text = _handover.Ma_Chuyen_Tau;
            txtNumberTrain.ReadOnly = true;

            if (!_handover.tblHandoverResources.IsLoaded) _handover.tblHandoverResources.Load();
            foreach(var resource in _handover.tblHandoverResources)
            {
                resource.tblToaTauReference.Load();
                listToaTau.Add(resource.tblToaTau);
            }
            BindToaTau();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validate()
        {
            return techlinkErrorProvider1.Validate(this);
        }

        private void Reset()
        {
            txtNumberHandover.Text = txtCodeCuaKhau.Text = txtCodeGaDenDi.Text = txtStatusVehicle.Text = txtStatusGood.Text = txtNumberTrain.Text = string.Empty;
            dtpHandover.Value = DateTime.Now;
            ddlCuaKhau.SelectedIndex = ddlGaDenDi.SelectedIndex = 0;
            grdToaTau.DataSource = null;
            btnUpdate.Enabled = btnDelete.Enabled = false;
            btnAddNew.Enabled = true;
            listToaTau.Clear();
        }
        
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                var train = TrainFactory.GetByCode(txtNumberTrain.Text.Trim());
                if (train == null)
                {
                    MessageBox.Show("Số hiệu đoàn tàu không tồn tại!");
                    txtNumberTrain.Focus();
                    return;
                }
                if (grdToaTau.RowCount == 0)
                {
                    MessageBox.Show("Bạn phải chọn ít nhất một toa tàu!");
                    return;    
                } 
                var handOver = new tblHandover
                                   {
                                       tblChuyenTau = train,
                                       NumberHandover = txtNumberHandover.Text.Trim(),
                                       DateHandover = dtpHandover.Value,
                                       CodeStation = txtCodeCuaKhau.Text.Trim(),
                                       CodeStationFromTo = txtCodeGaDenDi.Text.Trim(),
                                       StatusGoods = txtStatusGood.Text.Trim(),
                                       StatusVehicle = txtStatusVehicle.Text.Trim(),
                                       CreatedBy = _userInfo.UserID,
                                       CreatedDate = CommonFactory.GetCurrentDate()
                                   };
                foreach (var toaTau in listToaTau)
                {
                    var handOverResource = new tblHandoverResource
                                               {
                                                   tblToaTau = toaTau
                                               };
                    handOver.tblHandoverResources.Add(handOverResource);
                }

                var result = TrainFactory.InsertBBBG(handOver);
                if (result > 0)
                {
                    if (cbPrint.Checked == true)
                    {
                        MessageBox.Show("Thêm mới Biên bản bàn giao thành công. Bạn hãy tắt hộp thoại này để xem bản in");
                        _handover = TrainFactory.FindHandoverByID(handOver.ID);
                        printBBBG(); 
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới Biên bản bàn giao thành công!");
                        Reset();
                    }
                }
                else MessageBox.Show("Thêm mới Biên bản bàn không thành công!");
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        public void BindToaTau()
        {
            grdToaTau.DataSource = null;
            grdToaTau.AutoGenerateColumns = false;
            var source = new List<tblToaTau>();
            source.AddRange(listToaTau);
            grdToaTau.DataSource = source;
            // Bind count column
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                // Add to count Column
                grdToaTau.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void txtCodeCuaKhau_Leave(object sender, EventArgs e)
        {
            var customs = CustomsFacory.FindByCode(txtCodeCuaKhau.Text.Trim());
            if (customs != null)
            {
                ddlCuaKhau.SelectedValue = customs.CustomsCode.Trim();
            }
            else
            {
                ddlCuaKhau.SelectedIndex = 0;
                txtCodeCuaKhau.Text = string.Empty;
            }
        }

        private void ddlCuaKhau_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodeCuaKhau.Text = ddlCuaKhau.SelectedValue.ToString();
        }

        private void txtCodeGaDenDi_Leave(object sender, EventArgs e)
        {
            var customs = CustomsFacory.FindByCode(txtCodeGaDenDi.Text.Trim());
            if (customs != null)
            {
                ddlGaDenDi.SelectedValue = customs.CustomsCode.Trim();
            }
            else
            {
                ddlGaDenDi.SelectedIndex = 0;
                txtCodeGaDenDi.Text = string.Empty;
            }
        }

        private void ddlGaDenDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodeGaDenDi.Text = ddlGaDenDi.SelectedValue.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var train = TrainFactory.GetByCode(txtNumberTrain.Text.Trim());
            if (train == null)
            {
                MessageBox.Show("Số hiệu đoàn tàu không tồn tại!");
                txtNumberTrain.Focus();
                return;
            }
            var frm = new frmDanhSachToaTau(train,ref listToaTau);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                BindToaTau();
            }
        }

        private void btnPrintBBBG_Click(object sender, EventArgs e)
        {
            printBBBG();
        }

        private void printBBBG()
        {
            try
            {
                var reportHandOver = new ReportHandOver();

                var txtNumberHandover = (TextObject)reportHandOver.Section1.ReportObjects["txtNumberHandover"];
                var txtSummary = (TextObject)reportHandOver.Section1.ReportObjects["txtSummary"];
                var txtStatusVehicle = (TextObject)reportHandOver.Section1.ReportObjects["txtStatusVehicle"];
                var txtStatusGoods = (TextObject)reportHandOver.Section1.ReportObjects["txtStatusGoods"];
                var txtCustoms = (TextObject)reportHandOver.Section1.ReportObjects["txtCustoms"];
                var txtPath = (TextObject)reportHandOver.Section1.ReportObjects["txtPath"];
                var txtConfirmOfToStation = (TextObject)reportHandOver.Section1.ReportObjects["txtConfirmOfToStation"];
                var txtToStation = (TextObject)reportHandOver.Section1.ReportObjects["txtToStation"];
                var txtFromStation = (TextObject)reportHandOver.Section1.ReportObjects["txtFromStation"];

                long handoverId = _handover.ID; //1L;

                tblHandover handover = TrainFactory.FindHandoverByID(handoverId);
                if (handover != null)
                {
                    if (handover.tblHandoverResources.IsLoaded == false)
                    {
                        handover.tblHandoverResources.Load();
                    }
                    List<tblHandoverResource> listTblHandoverResources = TrainFactory.FindHandoverResourceByHandoverID(handoverId);
                    //List<tblHandoverResource> listTblHandoverResources = handover.tblHandoverResources.ToList(); ;
                    List<tblToaTau> listToaTau = new List<tblToaTau>();
                    foreach (tblHandoverResource obj in listTblHandoverResources)
                    {
                        if (obj.tblToaTauReference.IsLoaded == false)
                        {
                            obj.tblToaTauReference.Load();
                        }
                        if (obj.tblToaTau != null)
                        {
                            listToaTau.Add(obj.tblToaTau);
                        }
                    }

                    DataSet1 dataset = new DataSet1();
                    DataTable dt = dataset.tblToaTau;
                    //dt = ListToDataTable.ToDataTable(listToaTau);
                    foreach (tblToaTau toaTau in listToaTau)
                    {
                        if (toaTau.tblChuyenTauReference.IsLoaded == false)
                        {
                            toaTau.tblChuyenTauReference.Load();
                        }
                        dt.Rows.Add(toaTau.ToaTauID,
                                      toaTau.Ma_ToaTau
                                      , toaTau.So_VanTai_Don
                                      , toaTau.Ngay_VanTai_Don
                                      , toaTau.Ten_DoiTac
                                      , toaTau.Ma_DoanhNghiep
                                      , toaTau.Ten_Hang
                                      , toaTau.Trong_Luong
                                      , toaTau.Don_Vi_Tinh
                                      , toaTau.Seal_VanTai
                                      , toaTau.Seal_VanTai2
                                      , toaTau.Seal_HaiQuan
                                      , toaTau.Seal_HaiQuan2
                                      , toaTau.Ghi_Chu
                                      , toaTau.CreatedDate
                                      , toaTau.CreatedBy
                                      , toaTau.ModifiedDate
                                      , toaTau.ModifiedBy
                                      , toaTau.tblChuyenTau.TrainID);
                    }

                    reportHandOver.SetDataSource(dataset);
                    String fromStation = CustomsFacory.FindByCode(handover.CodeStation).CustomsName;
                    String toStation = CustomsFacory.FindByCode(handover.CodeStationFromTo).CustomsName;

                    if (handover.DateHandover != null)
                    {
                        String dateString = "Hồi " + handover.DateHandover.Value.Hour + " giờ " + handover.DateHandover.Value.Minute + " phút, ngày " + handover.DateHandover.Value.Day + " tháng " + handover.DateHandover.Value.Month + " năm " + handover.DateHandover.Value.Year;
                        txtSummary.Text = dateString + " " + fromStation + " bàn giao cho " + toStation +
                        " lô hàng nhập khẩu chuyển cảng vận chuyển từ " + fromStation + " đến " + toStation + ".";
                    }

                    txtNumberHandover.Text = handover.NumberHandover;
                    txtStatusVehicle.Text = handover.StatusVehicle;
                    txtStatusGoods.Text = handover.StatusGoods;

                    txtCustoms.Text = fromStation.ToUpper();
                    txtPath.Text = "Từ " + fromStation + " đến " + toStation;
                    txtConfirmOfToStation.Text = "5. Xác nhận của " + toStation + ":";
                    txtFromStation.Text = fromStation;
                    txtToStation.Text = toStation;

                }

                FrmPreviewReport frmReport = new FrmPreviewReport(reportHandOver);
                frmReport.MdiParent = this.MdiParent;
                frmReport.Show();
            }
            catch (Exception ex)
            {
            }
        }
            

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                _handover.ModifiedBy = _userInfo.UserID;
                _handover.NumberHandover = txtNumberHandover.Text.Trim();
                _handover.DateHandover = dtpHandover.Value;
                _handover.CodeStation = txtCodeCuaKhau.Text.Trim();
                _handover.CodeStationFromTo = txtCodeGaDenDi.Text.Trim();
                _handover.StatusGoods = txtStatusGood.Text.Trim();
                _handover.StatusVehicle = txtStatusVehicle.Text.Trim();
                _handover.ModifiedBy = _userInfo.UserID;  
                
                var result = TrainFactory.UpdateHandover(_handover, listToaTau);
                if (result > 0)
                {
                    if (cbPrint.Checked == true)
                    {
                        MessageBox.Show("Cập nhật BBBG thành công. Bạn hãy tắt hộp thoại này để xem bản in");
                        printBBBG();
                    }
                    else
                    {

                        MessageBox.Show("Cập nhật BBBG thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật BBBG không thành công!");
                }

            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (TrainFactory.DeleteHandoverByID(_handover.ID) > 0)
                    {    
                        MessageBox.Show("Xóa xong");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Xóa bị lỗi");
                }
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }            
        }
    }
}
