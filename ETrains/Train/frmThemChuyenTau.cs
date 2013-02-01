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
    public partial class frmThemChuyenTau : Form
    {
        private short _type; //0: xuat canh, 1 nhap canh
        private short _mode; //0: addnew, 1: edit
        private tblChuyenTau _train;
        private UserInfo _userInfo;
        private List<tblToaTau> listToaTau = new List<tblToaTau>();

        public frmThemChuyenTau()
        {
            InitializeComponent();
        }
        public frmThemChuyenTau(UserInfo userInfo, short type, short mode = (short)0)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
        }

        public frmThemChuyenTau(UserInfo userInfo, short type, long trainID, short mode = (short)1)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
        }
        public frmThemChuyenTau(UserInfo userInfo, short type, tblChuyenTau train, short mode = (short)1)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
            _train = train;
        }

        private void frmThemChuyenTau_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao tau hang " + (_type == 0 ? "xuat canh" : "nhap canh") + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            if (_type == 0)
            {
                lblHeader.Text = "Khai báo tàu hàng xuất cảnh";
                lblDateXNK.Text = "Ngày giờ xuất cảnh";
                gbChuyenTau.Text = "Thông tin tàu hàng xuất cảnh";
                lblPartner.Text = "Tên người nhận (đối tác TQ)";
                grdToaTau.Columns["Ten_DoiTac"].HeaderText = "Tên người nhận";
                grdToaTau.Columns["Ten_DoanhNghiep"].HeaderText = "Tên người gửi";
            }
            else if (_type == 1)
            {
                lblHeader.Text = "Khai báo tàu hàng nhập cảnh";
                lblDateXNK.Text = "Ngày giờ nhập cảnh";
                gbChuyenTau.Text = "Thông tin tàu hàng nhập cảnh";
                lblPartner.Text = "Tên người gửi (đối tác TQ)";
                grdToaTau.Columns["Ten_DoiTac"].HeaderText = "Tên người gửi";
                grdToaTau.Columns["Ten_DoanhNghiep"].HeaderText = "Tên người nhận";
            }

            //grid Toa tau
            grdToaTau.AutoGenerateColumns = false;

            //mode
            if (_mode == 0) //add
            {
                btnUpdate.Enabled = btnDelete.Enabled = false;
            }
            else // edit
            {
                btnAddNew.Enabled = false;
                InitData();
            }
        }

        private void InitData()
        {
            if (_train == null) return;
            _train = TrainFactory.GetById(_train.TrainID);
            txtNumberTrain.Text = _train.Ma_Chuyen_Tau;
            if (_train.Ngay_XNC != null) dtpDateXNC.Value = (DateTime)_train.Ngay_XNC;
            if (!_train.tblToaTaus.IsLoaded) _train.tblToaTaus.Load();
            listToaTau = _train.tblToaTaus.ToList();
            BindToaTau();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateChuyenTau()
        {
            return techlinkErrorProvider1.Validate(gbChuyenTau);
        }
        private bool ValidateToaTau()
        {
            return techlinkErrorProvider1.Validate(gbToaTau);
        }

        private void ResetChuyenTau()
        {
            txtNumberTrain.Text = string.Empty;
            dtpDateXNC.Value = DateTime.Now;
            grdToaTau.DataSource = null;
            btnUpdate.Enabled = btnDelete.Enabled = false;
            btnAddNew.Enabled = true;
            listToaTau.Clear();
        }
        private void ResetToaTau()
        {
            txtNumberToaTau.Text = txtSoVanDon.Text = txtPartner.Text = txtCompanyCode.Text = txtCompanyName.Text =
                txtTenHang.Text = txtTrongLuong.Text = txtDVT.Text = txtSealVT.Text = txtSealHQ.Text = txtNote.Text = string.Empty;
            dtpVanDon.Value = DateTime.Now;
            btnUpdateToaTau.Enabled = btnDeleteToaTau.Enabled = false;
            btnAddToaTau.Enabled = true;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChuyenTau()) return;
                var train = new tblChuyenTau
                                {
                                    Ma_Chuyen_Tau = txtNumberTrain.Text.Trim(),
                                    Type = _type,
                                    Ngay_XNC = dtpDateXNC.Value,
                                    IsPassengerTrain = false,
                                    CreatedDate = CommonFactory.GetCurrentDate(),
                                    CreatedBy = _userInfo.UserID
                                };
                foreach (var toaTau in listToaTau)
                {
                    train.tblToaTaus.Add(toaTau);
                }
                var result = TrainFactory.InsertChuyenTau(train);
                if (result > 0)
                {
                    MessageBox.Show("Thêm mới chuyến tàu thành công!");
                    ResetChuyenTau();
                }
                else MessageBox.Show("Thêm mới chuyến không thành công!");
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnAddToaTau_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateToaTau()) return;
                var toaTau = new tblToaTau
                {
                    Ma_ToaTau = txtNumberToaTau.Text.Trim(),
                    So_VanTai_Don = txtSoVanDon.Text.Trim(),
                    Ngay_VanTai_Don = dtpVanDon.Value,
                    Ten_DoiTac = txtPartner.Text.Trim(),
                    Ma_DoanhNghiep = txtCompanyCode.Text.Trim(),
                    Ten_DoanhNghiep = txtCompanyName.Text.Trim(),
                    Ten_Hang = txtTenHang.Text.Trim(),
                    Trong_Luong = txtTrongLuong.Text.Trim(),
                    Don_Vi_Tinh = txtDVT.Text.Trim(),
                    Seal_VanTai = txtSealVT.Text.Trim(),
                    Seal_HaiQuan = txtSealHQ.Text.Trim(),
                    Ghi_Chu = txtNote.Text.Trim(),
                    CreatedBy = _userInfo.UserID,
                    CreatedDate = CommonFactory.GetCurrentDate()
                };

                listToaTau.Add(toaTau);
                BindToaTau();
                MessageBox.Show("Thêm mới toa tàu thành công!");
                ResetToaTau();
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
            grdToaTau.DataSource = listToaTau;
            // Bind count column
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                // Add to count Column
                grdToaTau.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void txtCompanyCode_Leave(object sender, EventArgs e)
        {
            var company = CompanyFactory.FindByCode(txtCompanyCode.Text.Trim());
            txtCompanyName.Text = company != null ? Converter.TCVN3ToUnicode(company.CompanyName) : "";
            if (company == null) txtCompanyCode.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChuyenTau()) return;
                _train.ModifiedBy = _userInfo.UserID;
                _train.Ma_Chuyen_Tau = txtNumberTrain.Text.Trim();
                _train.Ngay_XNC = dtpDateXNC.Value;
                //_train.tblToaTaus.Clear();
                //foreach (var toaTau in listToaTau)
                //{
                //    _train.tblToaTaus.Add(toaTau);
                //}
                var result = TrainFactory.UpdateChuyenTau(_train, listToaTau);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật chuyến tàu thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật chuyến tàu không thành công!");
                }

            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grdToaTau_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnAddToaTau.Enabled = false;
            btnUpdateToaTau.Enabled = btnDeleteToaTau.Enabled = true;
            var toaTau = listToaTau[e.RowIndex];
            txtNumberToaTau.Text = toaTau.Ma_ToaTau;
            txtNumberToaTau.ReadOnly = true;
            txtSoVanDon.Text = toaTau.So_VanTai_Don;
            if (toaTau.Ngay_VanTai_Don != null) dtpVanDon.Value = (DateTime)toaTau.Ngay_VanTai_Don;
            txtPartner.Text = toaTau.Ten_DoiTac;
            txtCompanyCode.Text = toaTau.Ma_DoanhNghiep;
            txtCompanyName.Text = toaTau.Ten_DoanhNghiep;
            txtTenHang.Text = toaTau.Ten_Hang;

            txtTrongLuong.Text = toaTau.Trong_Luong;
            txtDVT.Text = toaTau.Don_Vi_Tinh;
            txtSealVT.Text = toaTau.Seal_VanTai;
            txtSealHQ.Text = toaTau.Seal_HaiQuan;
            txtNote.Text = toaTau.Ghi_Chu;
        }

        private void btnUpdateToaTau_Click(object sender, EventArgs e)
        {
            var toaTau = listToaTau.Where(t => t.Ma_ToaTau == txtNumberToaTau.Text).FirstOrDefault();

            toaTau.So_VanTai_Don = txtSoVanDon.Text.Trim();
            toaTau.Ngay_VanTai_Don = dtpVanDon.Value;
            toaTau.Ten_DoiTac = txtPartner.Text.Trim();
            toaTau.Ma_DoanhNghiep = txtCompanyCode.Text.Trim();
            toaTau.Ten_DoanhNghiep = txtCompanyName.Text.Trim();
            toaTau.Ten_Hang = txtTenHang.Text.Trim();
            toaTau.Trong_Luong = txtTrongLuong.Text.Trim();
            toaTau.Don_Vi_Tinh = txtDVT.Text.Trim();
            toaTau.Seal_VanTai = txtSealVT.Text.Trim();
            toaTau.Seal_HaiQuan = txtSealHQ.Text.Trim();
            toaTau.Ghi_Chu = txtNote.Text.Trim();
            toaTau.ModifiedBy = _userInfo.UserID;

            BindToaTau();
            MessageBox.Show("Cập nhật toa tàu thành công!");
            ResetToaTau();
        }

        private void btnDeleteToaTau_Click(object sender, EventArgs e)
        {
            var toaTau = listToaTau.Where(t => t.Ma_ToaTau == txtNumberToaTau.Text).FirstOrDefault();
            listToaTau.Remove(toaTau);
            BindToaTau();
            MessageBox.Show("Xóa toa tàu thành công!");
            ResetToaTau();
        }
    }
}
