using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;
using ETrains.Utilities.Enums;

namespace ETrains.Train
{
    public partial class frmBBBG : Form
    {
        private short _type; //0: xuat canh, 1 nhap canh
        private short _mode; //0: addnew, 1: edit
        private UserInfo _userInfo;
        private List<tblToaTau> listToaTau = new List<tblToaTau>();

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
            }
            else
            {
                btnAddNew.Enabled = false;
            }
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
                                       TrainID = train.TrainID,
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
                                                   ToaTauID = toaTau.ToaTauID
                                               };
                    handOver.tblHandoverResources.Add(handOverResource);
                }

                var result = TrainFactory.InsertBBBG(handOver);
                if (result > 0)
                {
                    MessageBox.Show("Thêm mới Biên bản bàn giao thành công!");
                    Reset();
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
    }
}
