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
        private string _type; //0: BBBG chuyen den, 1 BBBG chuyen di
        private short _mode; //0: addnew, 1: edit
        private UserInfo _userInfo;
        private List<tblToaTau> listToaTau = new List<tblToaTau>();
        private tblNumberGenerate _NumberGenerate;  
        private tblHandover _handover;

        public frmBBBG()
        {
            InitializeComponent();
        }
        public frmBBBG(UserInfo userInfo, string type, short mode = (short)0)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
        }

        public frmBBBG(UserInfo userInfo, string type, tblHandover handover, short mode = (short)1)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
            _handover = handover;
        }

        private void frmBBBG_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao Bien ban ban giao " + (_type == "0" ? "chuyen den" : "chuyen di") + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            if (_mode == 1)
            {
                txtNumberHandover.Enabled = false;
            }
            if (_type == ((short)HandoverType.HandoverComeIn).ToString()) //BBBG chuyen den
            {
                lblHeader.Text = "Cập nhật Biên bản bàn giao, chuyển đến";
                if (_mode == 0)
                {
                    lblHeader.Text = "Thêm mới Biên bản bàn giao, chuyển đến";
                }
                lblCodeGaDenDi.Text = "Mã HQ ga đi";
                lblGaDenDi.Text = "Tên HQ ga đi";
                
            }
            else if (_type == ((short)HandoverType.HandoverToGoOut).ToString()) //BBBG chuyen di
            {
                txtNumberHandover.Enabled = false;
                lblHeader.Text = "Cập nhật Biên bản bàn giao, chuyển đi";
                if (_mode == 0)
                {
                    lblHeader.Text = "Thêm mới Biên bản bàn giao, chuyển đi";
                    _NumberGenerate = NumberGenerateFactory.AutoGenerate(NumberGenerateFactory.NUMBER_TYPE_HANDOVER);
                    txtNumberHandover.Text = _NumberGenerate.Year + "-" + _NumberGenerate.HandoverNumber + "/BBBG-HQGA";
                }
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
            //txtSoVanDon.Text = _handover.Ma_Chuyen_Tau;
            //txtSoVanDon.ReadOnly = true;
            cbReply.Checked = _handover.IsReplied.Value;
            if (cbReply.Checked)
            {
                dtpReplyDate.Enabled = true;
                dtpReplyDate.Value = _handover.DateReply.Value;
                txtReplyNote.Text = _handover.NoteReply;
                txtReplyNote.Enabled = true;
                txtReplyStatusGoods.Text = _handover.ReplyStatusGoods;
                txtReplyStatusGoods.Enabled = true;
            }
            else
            {
                dtpReplyDate.Enabled = false;
                txtReplyNote.Text = "";
                txtReplyNote.Enabled = false;
                txtReplyStatusGoods.Enabled = false;
                txtReplyStatusGoods.Text = "";
            }

            if (!_handover.tblHandoverResources.IsLoaded) _handover.tblHandoverResources.Load();
            foreach(var resource in _handover.tblHandoverResources)
            {
                resource.tblToaTauReference.Load();
                listToaTau.Add(resource.tblToaTau);
            }
            BindToaTau(null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private bool Validate()
        {
            var valid= techlinkErrorProvider1.Validate(this);
            if (_mode == 0) //kiem tra so BBBG trung lap khi nhap moi
            {
                tblHandover exist = TrainFactory.FindHandoverByNumber(txtNumberHandover.Text.Trim());
                if (exist != null)
                {
                    MessageBox.Show("Số BBBG này đã tồn tại, xin nhập số khác");
                    return false;
                }
                return valid;
            }
            else
            {
                return valid;
            }
        }

        private void Reset()
        {
            txtNumberHandover.Text = txtCodeCuaKhau.Text = txtCodeGaDenDi.Text = txtStatusVehicle.Text = txtStatusGood.Text = txtSoVanDon.Text = string.Empty;
            dtpHandover.Value = DateTime.Now;
            ddlCuaKhau.SelectedIndex = ddlGaDenDi.SelectedIndex = 0;
            grdToaTau.DataSource = null;
            btnUpdate.Enabled = btnDelete.Enabled = false;
            btnAddNew.Enabled = true;
            listToaTau.Clear();
            cbReply.Checked = false;
            dtpReplyDate.Enabled = false;
            txtReplyNote.Enabled = false;
            txtReplyNote.Text = "";
            txtReplyStatusGoods.Enabled = false;
            txtReplyStatusGoods.Text = "";

            if (_type == ((short)HandoverType.HandoverToGoOut).ToString()) //BBBG chuyen di
            {
                if (_mode == 0) //add mode
                {
                    _NumberGenerate = NumberGenerateFactory.AutoGenerate(NumberGenerateFactory.NUMBER_TYPE_HANDOVER);
                    txtNumberHandover.Text =_NumberGenerate.Year + "-" + _NumberGenerate.HandoverNumber + "/BBBG-HQGA";
                }
            }
        }
        
        private void btnAddNew_Click(object sender, EventArgs e)
        {

            var dr = MessageBox.Show(ConstantInfo.CONFIRM_ADD_NEW, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (!Validate()) return;
                var train = TrainFactory.GetByCode(txtSoVanDon.Text.Trim());

                if (grdToaTau.RowCount == 0)
                {
                    MessageBox.Show("Bạn phải chọn ít nhất một toa tàu!");
                    return;    
                } 
                Nullable<DateTime> replyDate = null;
                if(cbReply.Checked)
                {
                    replyDate = dtpReplyDate.Value;
                }
                var handOver = new tblHandover
                                   {
                                       NumberHandover = txtNumberHandover.Text.Trim(),
                                       DateHandover = dtpHandover.Value,
                                       CodeStation = txtCodeCuaKhau.Text.Trim(),
                                       CodeStationFromTo = txtCodeGaDenDi.Text.Trim(),
                                       StatusGoods = txtStatusGood.Text.Trim(),
                                       StatusVehicle = txtStatusVehicle.Text.Trim(),
                                       CreatedBy = _userInfo.UserID,
                                       CreatedDate = CommonFactory.GetCurrentDate(),
                                       Type= _type.ToString(),
                                       IsReplied=cbReply.Checked,
                                       DateReply = replyDate,
                                       NoteReply = cbReply.Checked?txtReplyNote.Text:null,
                                       ReplyStatusGoods = cbReply.Checked ? txtReplyStatusGoods.Text : null,
                                   };
                foreach (var toaTau in listToaTau)
                {
                    var handOverResource = new tblHandoverResource
                                               {
                                                   tblToaTau = toaTau
                                               };
                    handOver.tblHandoverResources.Add(handOverResource);
                }
                
                var result = TrainFactory.InsertBBBG(handOver, _NumberGenerate);
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

        public void BindToaTau(List<tblToaTau> listAddMoreToaTau)
        {
            if (listAddMoreToaTau != null)
            {
                var dataToaTau = new Dictionary<Int64, tblToaTau>();
                foreach (tblToaTau toatau in listToaTau)
                {
                    dataToaTau.Add(toatau.ToaTauID, toatau);

                }
                listToaTau.Clear();
                foreach (tblToaTau toatau in listAddMoreToaTau)
                {
                    if (dataToaTau.ContainsKey(toatau.ToaTauID) == false)
                    {
                        dataToaTau.Add(toatau.ToaTauID, toatau);
                    }

                }
                listAddMoreToaTau.Clear();
                listToaTau = dataToaTau.Values.ToList();
            }

            grdToaTau.DataSource = null;
            grdToaTau.AutoGenerateColumns = false;
            var source = new List<tblToaTau>();
            source.AddRange(listToaTau);
            grdToaTau.DataSource = source;
            // Bind count column
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                // Add to count Column
                grdToaTau.Rows[i].Cells[1].Value = (i + 1).ToString();
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
            List<tblToaTau> listAddMoreToaTau = new List<tblToaTau>();
            var frm = new frmDanhSachToaTau(-1, _type, txtSoVanDon.Text.Trim(), ref listAddMoreToaTau);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                BindToaTau(listAddMoreToaTau);
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
                        txtSummary.Text = dateString + " " + fromStation + " bàn giao cho Chi nhánh vận tải hàng hóa đường sắt Đồng Đăng" +
                        " lô hàng nhập khẩu chuyển cảng vận chuyển từ " + fromStation + " đến " + toStation + ".";
                    }
                    
                    //txtNumberHandover.Text = "Số: " + handover.NumberHandover + "/BBBG-HQGA";
                    txtNumberHandover.Text = "Số: " + handover.NumberHandover;
                    txtStatusVehicle.Text = handover.StatusVehicle;
                    txtStatusGoods.Text = handover.StatusGoods;

                    txtCustoms.Text = fromStation.ToUpper();
                    txtPath.Text = "Từ " + fromStation + " đến " + toStation;
                    txtConfirmOfToStation.Text = "5. Xác nhận của " + toStation + ":";
                    txtFromStation.Text = fromStation;
                    txtToStation.Text = toStation;

                }

                reportHandOver.Section3.SectionFormat.EnableUnderlaySection = true;
                reportHandOver.Section3.SectionFormat.EnableKeepTogether = true;
                

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
            var dr = MessageBox.Show(ConstantInfo.CONFIRM_UPDATE, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

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

                //thong tin hoi bao
                _handover.IsReplied = cbReply.Checked;
                _handover.NoteReply = cbReply.Checked ? txtReplyNote.Text : null;
                _handover.ReplyStatusGoods = cbReply.Checked ? txtReplyStatusGoods.Text : null;
                 Nullable < DateTime > replyDate = null;;
                if(cbReply.Checked)
                {
                    replyDate=dtpReplyDate.Value;
                }
                _handover.DateReply = replyDate;
                
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

        private void cbReply_CheckedChanged(object sender, EventArgs e)
        {
            dtpReplyDate.Enabled = cbReply.Checked;
            txtReplyNote.Enabled = cbReply.Checked;
            txtReplyStatusGoods.Enabled = cbReply.Checked;
            if (cbReply.Checked == false)
            {
                txtReplyNote.Text = "";
                txtReplyStatusGoods.Text = "";
            }
        }

        private void txtNumberHandover_Leave(object sender, EventArgs e)
        {
            //do nothing
           
        }

        private void grdToaTau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;

            var dataToatau = new Dictionary<Int64, tblToaTau>();
            foreach (tblToaTau toatau in listToaTau)
            {
                dataToatau.Add(toatau.ToaTauID, toatau);

            }
            dataToatau.Remove(listToaTau[e.RowIndex].ToaTauID);
            listToaTau.Clear();
            listToaTau = dataToatau.Values.ToList();

            grdToaTau.DataSource = listToaTau;

            // Bind count column
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                // Add to count Column
                grdToaTau.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        private void frmBBBG_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dr = MessageBox.Show(ConstantInfo.CONFIRM_EXIT, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                e.Cancel=true;
            }
        }
    }
}
