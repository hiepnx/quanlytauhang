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
        private tblToaTau _currentToaTau;
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

            cbImportExportType.Items.Add(new ComboBoxItem(1, "Chuyển cảng"));
            cbImportExportType.Items.Add(new ComboBoxItem(2, "Tại chỗ"));
            //cbImportExportType.Items.Add(new ComboBoxItem(3, "-----"));
            cbImportExportType.SelectedValue = 1;
            cbImportExportType.SelectedIndex = 0;



            cbLoaiToa.Items.Add(new ComboBoxItem(1, "Toa kín"));
            cbLoaiToa.Items.Add(new ComboBoxItem(2, "Toa trần"));
            cbLoaiToa.Items.Add(new ComboBoxItem(3, "Toa rỗng"));
            cbLoaiToa.SelectedValue = 1;
            cbLoaiToa.SelectedIndex = 0;


            if (_type == 0)
            {

                lblImportType.Text = "Loại hình xuất";

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
            bool valid = true;
            
            valid = techlinkErrorProvider1.Validate(gbToaTau);

            if (valid == false)
            {
                return valid;
            }
            
            //kiem tra trung lap so hieu toa tau
            if ((_mode == 0 || (_mode == 1 && _currentToaTau == null)) && listToaTau.Any(c => c.Ma_ToaTau == txtNumberToaTau.Text.Trim()))
            {
                valid = false;
                MessageBox.Show("Số hiệu toa tàu " + txtNumberToaTau.Text.Trim() + " đã tồn tại, xin vui lòng kiểm tra lại");
                txtNumberToaTau.Focus();
                return valid;
            }

            //kiem tra trung lap seal hai quan trong danh sach cach toa tau cua doan tau
            tblToaTau existSeal1 = listToaTau.Where(x => x.Seal_HaiQuan == txtSealHQ.Text.Trim() && string.IsNullOrEmpty(x.Seal_HaiQuan)==false).FirstOrDefault();
            if (existSeal1!=null && _currentToaTau != null && _currentToaTau.Ma_ToaTau != existSeal1.Ma_ToaTau)
            {
                valid = false;
                MessageBox.Show("Số Seal Hải quan này đã tồn tại trong danh sách các toa tàu thuộc đoàn tàu này, xin vui lòng kiểm tra lại");
                txtSealHQ.Focus();
                return valid;
            }

            else if (existSeal1 != null && _currentToaTau==null)
            {
                valid = false;
                MessageBox.Show("Số Seal Hải quan này đã tồn tại trong danh sách các toa tàu thuộc đoàn tàu này, xin vui lòng kiểm tra lại");
                txtSealHQ.Focus();
                return valid;
            }

            tblToaTau existSeal2 = listToaTau.Where(x => x.Seal_HaiQuan2 == txtSealHQ2.Text.Trim() && string.IsNullOrEmpty(x.Seal_HaiQuan2) == false).FirstOrDefault();
            if (existSeal2!=null  && _currentToaTau != null && _currentToaTau.Ma_ToaTau != existSeal2.Ma_ToaTau)
            {
                valid = false;
                MessageBox.Show("Số Seal Hải quan 2 này đã tồn tại trong danh sách các toa tàu thuộc đoàn tàu này, xin vui lòng kiểm tra lại");
                txtSealHQ2.Focus();
                return valid;
            }

            else if (existSeal2!=null  && _currentToaTau==null)
            {
                valid = false;
                MessageBox.Show("Số Seal Hải quan 2 này đã tồn tại trong danh sách các toa tàu thuộc đoàn tàu này, xin vui lòng kiểm tra lại");
                txtSealHQ2.Focus();
                return valid;
            }


            if (_mode == 0) ///kiem tra seal hai quan khi them moi toa tau
            {
                //seal hai quan 1 la duy nhat
                
                if (TrainFactory.GetToaTauBySealHaiQuan1(txtSealHQ.Text.Trim()) != null)
                {
                    valid = false;
                    MessageBox.Show("Số Seal Hải quan này đã tồn tại, xin vui lòng kiểm tra lại");
                    txtSealHQ.Focus();
                    return valid;
                }
                //sel hai quan 2 la duy nhat

                if (TrainFactory.GetToaTauBySealHaiQuan2(txtSealHQ2.Text.Trim()) != null)
                {
                    valid = false;
                    MessageBox.Show("Số Seal Hải quan 2 này đã tồn tại, xin vui lòng kiểm tra lại");
                    txtSealHQ2.Focus();
                    return valid;
                }
            }


            if (_mode == 1 && _currentToaTau == null) ///kiem tra seal hai quan khi them moi toa tau trong mode update chuyen tau
            {
                //seal hai quan 1 la duy nhat

                if (TrainFactory.GetToaTauBySealHaiQuan1(txtSealHQ.Text.Trim()) != null)
                {
                    valid = false;
                    MessageBox.Show("Số Seal Hải quan này đã tồn tại, xin vui lòng kiểm tra lại");
                    txtSealHQ.Focus();
                    return valid;
                }
                //sel hai quan 2 la duy nhat

                if (TrainFactory.GetToaTauBySealHaiQuan2(txtSealHQ2.Text.Trim()) != null)
                {
                    valid = false;
                    MessageBox.Show("Số Seal Hải quan 2 này đã tồn tại, xin vui lòng kiểm tra lại");
                    txtSealHQ2.Focus();
                    return valid;
                }

            }

            if (_mode == 1 && _currentToaTau!=null) ///kiem tra seal hai quan khi update toa tau trong mode update chuyen tau
            {
                //seal hai quan 1 la duy nhat
                tblToaTau toaTau1 = TrainFactory.GetToaTauBySealHaiQuan1(txtSealHQ.Text.Trim());
                if (toaTau1 != null && _currentToaTau.ToaTauID !=null && toaTau1.ToaTauID!=_currentToaTau.ToaTauID)
                {
                    valid = false;
                    MessageBox.Show("Số Seal Hải quan này đã tồn tại, xin vui lòng kiểm tra lại");
                    txtSealHQ.Focus();
                    return valid;
                }
                //sel hai quan 2 la duy nhat

                tblToaTau toaTau2 = TrainFactory.GetToaTauBySealHaiQuan2(txtSealHQ2.Text.Trim());
                if (toaTau2 != null && _currentToaTau.ToaTauID !=null && toaTau2.ToaTauID!=_currentToaTau.ToaTauID)
                {
                    valid = false;
                    MessageBox.Show("Số Seal Hải quan 2 này đã tồn tại, xin vui lòng kiểm tra lại");
                    txtSealHQ2.Focus();
                    return valid;
                }
            
            }


            return valid;
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
            txtNumberToaTau.ReadOnly = false;
            txtNumberToaTau.Enabled = true;
            //txtNumberToaTau.Text = txtSoVanDon.Text = txtPartner.Text = txtCompanyCode.Text = txtCompanyName.Text =
            //    txtTenHang.Text = txtTrongLuong.Text = txtDVT.Text = txtSealVT.Text = txtSealVT2.Text = txtSealHQ2.Text = txtSealHQ.Text = txtNote.Text = string.Empty;
            //dtpVanDon.Value = DateTime.Now;

            txtNumberToaTau.Text = txtSoVanDon.Text = string.Empty;
            btnUpdateToaTau.Enabled = btnDeleteToaTau.Enabled = false;
            btnAddToaTau.Enabled = true;
            txtNumberToaTau.Focus();
            _currentToaTau = null;
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
                    ImportExportType=Int16.Parse(((ComboBoxItem)cbImportExportType.SelectedItem).Value.ToString()),
                    LoaiToaTau = Int16.Parse(((ComboBoxItem)cbLoaiToa.SelectedItem).Value.ToString()),
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
                    Seal_VanTai2 = txtSealVT2.Text.Trim(),
                    Seal_HaiQuan = txtSealHQ.Text.Trim(),
                    Seal_HaiQuan2 = txtSealHQ2.Text.Trim(),
                    Ghi_Chu = txtNote.Text.Trim(),
                    CreatedBy = _userInfo.UserID,
                    CreatedDate = CommonFactory.GetCurrentDate()
                };
                if (toaTau.LoaiToaTau == (short)LoaiToaTau.ToaRong)
                    toaTau.ImportExportType = null;

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
                bool hasDeleteToaTau = false;
                List<tblToaTau> listOriginToaTau = TrainFactory.GetToaTauByChuyenTauID(_train.TrainID);
                foreach (tblToaTau originalToaTau in listOriginToaTau)
                {
                    if (listToaTau.Any(c => c.ToaTauID == originalToaTau.ToaTauID) == false)
                    {
                        hasDeleteToaTau = true;
                        break;
                    }
                }
                var dr = DialogResult.No;
                if (hasDeleteToaTau)
                {
                    dr = MessageBox.Show("Trong trường hợp bạn xóa toa tàu của đoàn tàu: Các toa tàu cũ của đoàn tàu có thể liên kết với BBBG và Tờ khai hải quan. Các dữ liệu liên kết này sẽ bị xóa cùng với toa tàu. Bạn có muốn tiếp tục ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                }
                else
                {
                    dr = DialogResult.Yes;
                }
                if (dr==DialogResult.Yes)
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

            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        //private bool checkDeleteToaTau()
        //{
        //    if (!_train.tblToaTaus.IsLoaded) _train.tblToaTaus.Load();
        //    List<tblToaTau> listToaTauOrigin = _train.tblToaTaus.ToList();
        //    foreach (tblToaTau toaTau in listToaTauOrigin)
        //    {
                
        //    }
        //    return false;
        //}

        private void grdToaTau_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnAddToaTau.Enabled = false;
            btnUpdateToaTau.Enabled = btnDeleteToaTau.Enabled = true;
            var toaTau = listToaTau[e.RowIndex];
            _currentToaTau = toaTau;
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
            txtSealVT2.Text = toaTau.Seal_VanTai2;
            txtSealHQ.Text = toaTau.Seal_HaiQuan;
            txtSealHQ2.Text = toaTau.Seal_HaiQuan2;
            txtNote.Text = toaTau.Ghi_Chu;

            if(toaTau.LoaiToaTau!=null)
                cbLoaiToa.SelectedIndex = toaTau.LoaiToaTau.GetValueOrDefault()-1;
            if (toaTau.LoaiToaTau != (short)LoaiToaTau.ToaRong)
            {
                lblImportType.Visible = true;
                cbImportExportType.Visible = true;
            }
            else
            {
                lblImportType.Visible = false;
                cbImportExportType.Visible = false;
            }
            if (toaTau.ImportExportType != null)
            {
                cbImportExportType.SelectedIndex = toaTau.ImportExportType.GetValueOrDefault() - 1;
                //cbImportExportType.SelectedValue = toaTau.ImportExportType.GetValueOrDefault();
            }
            
        }

        private void btnUpdateToaTau_Click(object sender, EventArgs e)
        {
            if (!ValidateToaTau()) return;

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
            toaTau.Seal_VanTai2 = txtSealVT2.Text.Trim();
            toaTau.Seal_HaiQuan = txtSealHQ.Text.Trim();
            toaTau.Seal_HaiQuan2 = txtSealHQ2.Text.Trim();
            toaTau.Ghi_Chu = txtNote.Text.Trim();
            toaTau.ModifiedBy = _userInfo.UserID;
            toaTau.ImportExportType=Int16.Parse(((ComboBoxItem)cbImportExportType.SelectedItem).Value.ToString());
            toaTau.LoaiToaTau = Int16.Parse(((ComboBoxItem)cbLoaiToa.SelectedItem).Value.ToString());

            if (toaTau.LoaiToaTau == (short)LoaiToaTau.ToaRong)
                toaTau.ImportExportType = null;

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var dr = MessageBox.Show("Các toa tàu của đoàn tàu sẽ bị xóa cùng với đoàn tàu. Các toa tàu này có thể liên kết với BBBG và Tờ khai hải quan. Các dữ liệu liên kết này sẽ bị xóa cùng với toa tàu. Bạn có muốn tiếp tục ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (TrainFactory.DeleteChuyenTauByID(_train.TrainID) > 0)
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

        private void cbLoaiToa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbImportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbLoaiToa_SelectedValueChanged(object sender, EventArgs e)
        {
            short loaiToaTau = 0;
            if (cbLoaiToa.SelectedItem != null)
                loaiToaTau = Int16.Parse(((ComboBoxItem)cbLoaiToa.SelectedItem).Value.ToString());

            short loatHinhNhap = 1;
            if (cbImportExportType.SelectedItem != null)
                loatHinhNhap = Int16.Parse(((ComboBoxItem)cbImportExportType.SelectedItem).Value.ToString());
            
            if (loaiToaTau == (short)LoaiToaTau.ToaKin)
            {
                txtSealHQ.Tag = "required";
                txtSealHQ2.Tag = "required";

                txtSoVanDon.Tag = "required";
                txtPartner.Tag = "required";
                txtCompanyCode.Tag = "required";
                txtTenHang.Tag = "required";
                txtTrongLuong.Tag = "required";
                txtDVT.Tag = "required";
                txtSealVT.Tag = "required";
                txtSealVT2.Tag = "required";
            }
            //neu la toa tran hoac loai hinh nhap la "tai cho" thi k bat buoc nhap seal hai quan
            if (loaiToaTau == (short)LoaiToaTau.ToaTran || (loatHinhNhap == (short)ToaTauImportType.TaiCho))
            {
                txtSealHQ.Tag = null;
                txtSealHQ2.Tag = null;

                txtSoVanDon.Tag = "required";
                txtPartner.Tag = "required";
                txtCompanyCode.Tag = "required";
                txtTenHang.Tag = "required";
                txtTrongLuong.Tag = "required";
                txtDVT.Tag = "required";
                txtSealVT.Tag = "required";
                txtSealVT2.Tag = "required";

            }

            //Doi voi truong hop "toa tran", "chuyen cang" thi k can go seal van tai
            if (loaiToaTau == (short)LoaiToaTau.ToaTran || (loatHinhNhap == (short)ToaTauImportType.ChuyenCang))
            {

                txtSealVT.Tag = null;
                txtSealVT2.Tag = null;

            }
            if (loaiToaTau == (short)LoaiToaTau.ToaRong)
            {
                txtSealHQ.Tag = null;
                txtSealHQ2.Tag = null;

                txtSoVanDon.Tag = null;
                txtPartner.Tag = null;
                txtCompanyCode.Tag = null;
                txtTenHang.Tag = null;
                txtTrongLuong.Tag = null;
                txtDVT.Tag = null;
                txtSealVT.Tag = null;
                txtSealVT2.Tag = null;

                //cbImportExportType.SelectedIndex = 2;
                //cbImportExportType.SelectedValue = 3;
                //cbImportExportType.Enabled = false;
                lblImportType.Visible = false;
                cbImportExportType.Visible = false;
            }
            else
            {
                //cbImportExportType.Enabled = true;
                lblImportType.Visible = true;
                cbImportExportType.Visible = true;
            }
        }

        private void cbImportType_SelectedValueChanged(object sender, EventArgs e)
        {
            //cbLoaiToa.SelectedValue = ((ComboBoxItem)cbLoaiToa.SelectedItem).Value;
            //cbImportType.SelectedValue = ((ComboBoxItem)cbImportType.SelectedItem).Value;

            short loaiToaTau = 0;
            if (cbLoaiToa.SelectedItem != null)
                loaiToaTau = Int16.Parse(((ComboBoxItem)cbLoaiToa.SelectedItem).Value.ToString());

            short loatHinhNhap = 1;
            if (cbImportExportType.SelectedItem!=null)
                loatHinhNhap= Int16.Parse(((ComboBoxItem)cbImportExportType.SelectedItem).Value.ToString());
            
            //neu la toa tran hoa loai hinh nhap la "tai cho" thi k bat buoc nhap seal hai quan
            if (loaiToaTau == (short)LoaiToaTau.ToaRong || loaiToaTau == (short)LoaiToaTau.ToaTran || (loatHinhNhap == (short)ToaTauImportType.TaiCho))
            {
                txtSealHQ.Tag = null;
                txtSealHQ2.Tag = null;
            }
            else
            {
                txtSealHQ.Tag = "required";
                txtSealHQ2.Tag = "required";
            }

            //Doi voi truong hop "toa tran", "chuyen cang" thi k can go seal van tai
            if (loaiToaTau == (short)LoaiToaTau.ToaTran || (loatHinhNhap == (short)ToaTauImportType.ChuyenCang))
            {

                txtSealVT.Tag = null;
                txtSealVT2.Tag = null;

            }
            else
            {
                txtSealVT.Tag = "required";
                txtSealVT2.Tag = "required";
            }


            if (loaiToaTau == (short)LoaiToaTau.ToaRong)
            {
                txtSealHQ.Tag = null;
                txtSealHQ2.Tag = null;

                txtSoVanDon.Tag = null;
                txtPartner.Tag = null;
                txtCompanyCode.Tag = null;
                txtTenHang.Tag = null;
                txtTrongLuong.Tag = null;
                txtDVT.Tag = null;
                txtSealVT.Tag = null;
                txtSealVT2.Tag = null;

            }
        }
    }
}
