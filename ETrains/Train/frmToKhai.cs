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
    public partial class frmToKhai : Form
    {
        private short _type; //0: xuat canh, 1 nhap canh
        private short _mode; //0: addnew, 1: edit
        private UserInfo _userInfo;
        private List<tblToaTau> listToaTau = new List<tblToaTau>();

        public frmToKhai()
        {
            InitializeComponent();
        }
        public frmToKhai(UserInfo userInfo, short type, short mode = (short)0)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mode = mode;
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
            txtNumberToKhai.Text = txtCustomsCode.Text = txtTypeCode.Text = txtNumberTrain.Text = string.Empty;
            dtpDeclaration.Value = DateTime.Now;
            ddlTypeName.SelectedIndex = ddlCustomsName.SelectedIndex = 0;
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
                var declaration = new tblToKhaiTau
                                      {
                                          TrainID = train.TrainID,
                                          Number = int.Parse(txtNumberToKhai.Text.Trim()),
                                          DateDeclaration = dtpDeclaration.Value,
                                          TypeCode = txtTypeCode.Text.Trim(),
                                          CustomCode = txtCustomsCode.Text.Trim(),
                                          CreatedBy = _userInfo.UserID,
                                          CreatedDate = CommonFactory.GetCurrentDate()
                                      };
                foreach (var toaTau in listToaTau)
                {
                    var declarationResource = new tblToKhaiTauResource
                                               {
                                                   ToaTauID = toaTau.ToaTauID
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var train = TrainFactory.GetByCode(txtNumberTrain.Text.Trim());
            if (train == null)
            {
                MessageBox.Show("Số hiệu đoàn tàu không tồn tại!");
                txtNumberTrain.Focus();
                return;
            }
            var frm = new frmDanhSachToaTau(train, ref listToaTau);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                BindToaTau();
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
    }
}
