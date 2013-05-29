using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;
using ETrains.Utilities.Enums;

namespace ETrains.Train
{
    public partial class frmToKhai : Form
    {
        private short _type; //0: xuat canh, 1 nhap canh
        private short _mode; //0: addnew, 1: edit
        private UserInfo _userInfo;
        private List<tblToaTau> _listToaTau = new List<tblToaTau>();
        private tblToKhaiTau _toKhaiTau;

        public frmToKhai()
        {
            InitializeComponent();
        }
        public frmToKhai(UserInfo userInfo, tblToKhaiTau toKhaiTau, short type, short mode = (short)0)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
            _toKhaiTau = toKhaiTau;
        }

        private void frmToKhai_Load(object sender, EventArgs e)
        {
            this.Text = "Dang ky to khai " + (_type == 0 ? "xuat canh" : "nhap canh") + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            if (_type == 0)
            {
                lblHeader.Text = _mode == 0 ? "Đăng ký tờ khai xuất cảnh" : "Cập nhật tờ khai xuất cảnh";
            }
            else if (_type == 1)
            {
                lblHeader.Text = _mode == 0 ? "Đăng ký tờ khai nhập cảnh" : "Cập nhật tờ khai nhập cảnh";
            }

            //init dropdownlist Type name
            var listTypeName = TypeFactory.getAllType();
            listTypeName.Insert(0, new tblType
            {
                TypeName = "Tên loại hình",
                TypeCode = ""
            });
            ddlTypeName.DataSource = listTypeName.Select(x => new
            {
                x.TypeName,
                TypeCode = x.TypeCode.Trim()
            }).ToList();
            ddlTypeName.ValueMember = "TypeCode";
            ddlTypeName.DisplayMember = "TypeName";
            ddlTypeName.SelectedIndex = 0;

            //init dropdownlist Customs name
            var listHQ = CustomsFacory.getAll();
            var listCustomsName = new List<tblCustom>();
            listCustomsName.AddRange(listHQ);
            listCustomsName.Insert(0, new tblCustom
            {
                CustomsName = "Tên Đơn vị Hải quan",
                CustomsCode = ""
            });
            ddlCustomsName.DataSource = listCustomsName.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            ddlCustomsName.ValueMember = "CustomsCode";
            ddlCustomsName.DisplayMember = "CustomsName";
            ddlCustomsName.SelectedIndex = 0;

            //grid Toa tau
            grdToaTau.AutoGenerateColumns = false;

            //mode
            if (_mode == 0)
            {
                btnUpdate.Enabled = btnDelete.Enabled = false;
            }
            else
            {
                txtNumberToKhai.Enabled = false;
                btnAddNew.Enabled = false;
                txtNumberToKhai.Text = _toKhaiTau.Number.ToString();
                txtCustomsCode.Text = _toKhaiTau.CustomCode;
                txtTypeCode.Text = _toKhaiTau.TypeCode;
                ddlCustomsName.SelectedValue = _toKhaiTau.CustomCode;
                ddlTypeName.SelectedValue = _toKhaiTau.TypeCode;
                dtpDeclaration.Value = _toKhaiTau.DateDeclaration.GetValueOrDefault();
                _listToaTau = TrainFactory.searchToaTauByToKhaiTauID(_toKhaiTau.ID);
                if (_listToaTau == null)
                    _listToaTau = new List<tblToaTau>();
                grdToaTau.DataSource = null;
                grdToaTau.AutoGenerateColumns = false;
                var source = new List<tblToaTau>();
                source.AddRange(_listToaTau);
                grdToaTau.DataSource = source;
                // Bind count column
                for (var i = 0; i < grdToaTau.Rows.Count; i++)
                {
                    // Add to count Column
                    grdToaTau.Rows[i].Cells[0].Value = (i + 1).ToString();
                }

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
            txtNumberToKhai.Text = txtCustomsCode.Text = txtTypeCode.Text = txtSoVanDon.Text = string.Empty;
            dtpDeclaration.Value = DateTime.Now;
            ddlTypeName.SelectedIndex = ddlCustomsName.SelectedIndex = 0;
            grdToaTau.DataSource = null;
            btnUpdate.Enabled = btnDelete.Enabled = false;
            btnAddNew.Enabled = true;
            _listToaTau.Clear();
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
                //if (grdToaTau.RowCount == 0)
                //{
                //    MessageBox.Show("Bạn phải chọn ít nhất một toa tàu!");
                //    return;    
                //}
                //kiem tra su trung lap so to khai
                if (TrainFactory.FindToKhaiTauByNumber(Int64.Parse(txtNumberToKhai.Text.Trim()))!=null)
                {
                    MessageBox.Show("Số tờ khai này đã tồn tại, xin nhập số khác!");
                    return;   
                }
                var declaration = new tblToKhaiTau
                                      {
                                          Type=_type,
                                          Number = Int64.Parse(txtNumberToKhai.Text.Trim()),
                                          DateDeclaration = dtpDeclaration.Value,
                                          TypeCode = txtTypeCode.Text.Trim(),
                                          CustomCode = txtCustomsCode.Text.Trim(),
                                          CreatedBy = _userInfo.UserID,
                                          CreatedDate = CommonFactory.GetCurrentDate()
                                      };
                foreach (var toaTau in _listToaTau)
                {
                    var declarationResource = new tblToKhaiTauResource
                                                  {
                                                      tblToaTau = toaTau
                                                  };
                    declaration.tblToKhaiTauResources.Add(declarationResource);
                }
                var result = TrainFactory.InsertToKhaiTau(declaration);
                if (result > 0)
                {
                    MessageBox.Show(string.Format("Thêm mới Tờ khai {0} thành công!", _type == 0 ? "xuất cảnh" : "nhập cảnh"));
                    Reset();
                }
                else MessageBox.Show("Thêm mới Tờ khai không thành công!");
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
                foreach (tblToaTau toatau in _listToaTau)
                {
                    dataToaTau.Add(toatau.ToaTauID, toatau);

                }
                _listToaTau.Clear();
                foreach (tblToaTau toatau in listAddMoreToaTau)
                {
                    if (dataToaTau.ContainsKey(toatau.ToaTauID) == false)
                    {
                        dataToaTau.Add(toatau.ToaTauID, toatau);
                    }

                }
                listAddMoreToaTau.Clear();
                _listToaTau = dataToaTau.Values.ToList();
            }

            grdToaTau.DataSource = null;
            grdToaTau.AutoGenerateColumns = false;
            var source = new List<tblToaTau>();
            source.AddRange(_listToaTau);
            grdToaTau.DataSource = source;
            // Bind count column
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                // Add to count Column
                grdToaTau.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //var train = TrainFactory.searchToaTau(txtSoVanDon.Text.Trim(), false, new DateTime(), new DateTime());
            //if (train == null )
            //{
            //    MessageBox.Show("Số hiệu đoàn tàu không tồn tại!");
            //    txtSoVanDon.Focus();
            //    return;
            //}

            List<tblToaTau> listAddMoreToaTau = new List<tblToaTau>();
            var frm = new frmDanhSachToaTau(_type, "", txtSoVanDon.Text.Trim(), ref listAddMoreToaTau);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                BindToaTau(listAddMoreToaTau);
            }
        }

        private void txtTypeCode_Leave(object sender, EventArgs e)
        {
            var typeCode = txtTypeCode.Text.Trim();
            var type = TypeFactory.FindByCode(typeCode);
            if (type != null)
            {
                ddlTypeName.SelectedValue = typeCode;
            }
            else
            {
                ddlTypeName.SelectedIndex = 0;
            }
        }

        private void ddlTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTypeCode.Text = ddlTypeName.SelectedValue.ToString();
        }

        private void txtCustomsCode_Leave(object sender, EventArgs e)
        {
            var customs = CustomsFacory.FindByCode(txtCustomsCode.Text.Trim());
            if (customs != null)
            {
                ddlCustomsName.SelectedValue = customs.CustomsCode.Trim();
            }
            else
            {
                ddlCustomsName.SelectedIndex = 0;
            }
        }

        private void ddlCustomsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomsCode.Text = ddlCustomsName.SelectedValue.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (TrainFactory.DeleteToKhaiByID(_toKhaiTau.ID) > 0)
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
                
                //if (grdToaTau.RowCount == 0)
                //{
                //    MessageBox.Show("Bạn phải chọn ít nhất một toa tàu!");
                //    return;
                //}
                
                    
                _toKhaiTau.Number = int.Parse(txtNumberToKhai.Text.Trim());
                _toKhaiTau.DateDeclaration = dtpDeclaration.Value;
                _toKhaiTau.TypeCode = txtTypeCode.Text.Trim();
                _toKhaiTau.CustomCode = txtCustomsCode.Text.Trim();
                _toKhaiTau.ModifiedBy = _userInfo.UserID;
                _toKhaiTau.ModifiedDate = CommonFactory.GetCurrentDate();


                var result = TrainFactory.UpdateToKhaiTau(_toKhaiTau, _listToaTau);

                if (result > 0)
                {
                    MessageBox.Show(string.Format("Cập nhật Tờ khai {0} thành công!", _type == 0 ? "xuất cảnh" : "nhập cảnh"));
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show("Cập nhật Tờ khai không thành công!");
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grdToaTau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;

            var dataToatau = new Dictionary<Int64, tblToaTau>();
            foreach (tblToaTau toatau in _listToaTau)
            {
                dataToatau.Add(toatau.ToaTauID, toatau);

            }
            dataToatau.Remove(_listToaTau[e.RowIndex].ToaTauID);
            _listToaTau.Clear();
            _listToaTau = dataToatau.Values.ToList();

            grdToaTau.DataSource = _listToaTau;

            // Bind count column
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                // Add to count Column
                grdToaTau.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        private void frmToKhai_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dr = MessageBox.Show(ConstantInfo.CONFIRM_EXIT, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                e.Cancel=true;
            }
        }

        private void gbToaTau_Enter(object sender, EventArgs e)
        {

        }
    }
}
