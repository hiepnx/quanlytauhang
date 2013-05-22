using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;

namespace ETrains
{
    public partial class FrmListCompany : Form
    {
        private UserInfo _userInfo;

        public FrmListCompany()
        {
            InitializeComponent();
        }

        public FrmListCompany(UserInfo userInfo)
        {
            _userInfo = userInfo;
            InitializeComponent();

        }

        private void FrmListCompany_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sach doanh nghiep" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            init();
        }

        public void init()
        {
            //set permission for user
            btnAdd.Visible = btnUpdate.Visible = btnDelete.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_QUAN_LY_THONG_TIN_DOANH_NGHIEP);
            
            List<tblCompany> list = CompanyFactory.getTopCompany();
            grvCompany.AutoGenerateColumns = false;
            grvCompany.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCompany frmAddCompany = new FrmAddCompany(null, 0, _userInfo, this);
            frmAddCompany.MdiParent = this.MdiParent;
            frmAddCompany.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        public void search()
        {
            List<tblCompany> list = CompanyFactory.getTopCompany(txtCompanyName.Text.Trim(), txtCompanyCode.Text.Trim());

            grvCompany.AutoGenerateColumns = false;
            grvCompany.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvCompany.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvCompany.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var companyCode = grvCompany[0, selectedIndex].Value.ToString();

                    tblCompany company = CompanyFactory.FindByCode(companyCode);
                    if (company == null)
                    {
                        MessageBox.Show("Doanh nghiệp này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    FrmAddCompany frmAddCompany = new FrmAddCompany(companyCode, 1, _userInfo, this);
                    frmAddCompany.MdiParent = this.MdiParent;
                    frmAddCompany.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (this.grvCompany.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn thự sự muốn xóa doanh nghiệp đã chọn?", "Cảnh báo!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int selectedIndex = grvCompany.SelectedRows[0].Index;

                        // gets the RowID from the first column in the grid
                        var companyCode = grvCompany[0, selectedIndex].Value.ToString();

                        tblCompany company = CompanyFactory.FindByCode(companyCode);
                        if (company == null)
                        {
                            MessageBox.Show("Loại hình này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (CompanyFactory.Delete(companyCode) > 0)
                        {
                            search();
                            MessageBox.Show("Xóa doanh nghiệp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            search();
                            MessageBox.Show("Xóa doanh nghiệp không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            } 
        }

        private void grvCompany_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_QUAN_LY_THONG_TIN_DOANH_NGHIEP) == false)
                return;

            try
            {
                if (this.grvCompany.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvCompany.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var companyCode = grvCompany[0, selectedIndex].Value.ToString();

                    tblCompany company = CompanyFactory.FindByCode(companyCode);
                    if (company == null)
                    {
                        MessageBox.Show("Doanh nghiệp này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    FrmAddCompany frmAddCompany = new FrmAddCompany(companyCode, 1, _userInfo, this);
                    frmAddCompany.MdiParent = this.MdiParent;
                    frmAddCompany.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
    
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            } 
        }
    }
}
