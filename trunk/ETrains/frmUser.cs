using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETrains.Utilities;
using ETrains.BOL;
using ETrains.DAL;
using log4net;

namespace ETrains
{
  public partial class frmUser : Form
  {
    private static log4net.ILog logger = LogManager.GetLogger("ETrains.frmUser");
    private UserFactory _userBOL;
    private UserInfo _userInfo;

    public frmUser()
    {
      InitializeComponent();
    }

    public frmUser(UserInfo userInfo)
    {
      InitializeComponent();
      _userInfo = userInfo;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      try
      {
        var addUser = new frmAddUser(this, 0, _userInfo);
        addUser.MdiParent = this.ParentForm;
        addUser.Show();
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }

    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmUser_Load(object sender, EventArgs e)
    {
        this.Text = "Danh sách người dùng" + ConstantInfo.MESSAGE_TITLE;        
        _userBOL = new UserFactory();
        grvUser.AutoGenerateColumns = false;
        var users = UserFactory.SelectAllUser();
        BindData(users);
        //btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_NGUOI_DUNG);
        //btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_NGUOI_DUNG);
        //btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_NGUOI_DUNG);
    }

    /// <summary>
    /// Bind Data to gridview
    /// </summary>
    /// <param name="uerInfos">UerInfo objcts</param>
    public void BindData(List<tblUser> userInfos)
    {
      grvUser.DataSource = userInfos;
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (grvUser.SelectedRows.Count != 0)
        {
          frmAddUser addUser = new frmAddUser(this, 1, Convert.ToInt32(grvUser.SelectedRows[0].Cells[ConstantInfo.TBL_USER_USERID].Value), _userInfo);
          addUser.MdiParent = this.ParentForm;
          addUser.Show();
        }
        else
        {
          MessageBox.Show("Bạn cần chọn 1 người dùng");
        }
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }
    }

    private void btnDelete_Click_1(object sender, EventArgs e)
    {
      try
      {
        //TODO: Need to delete multiple instanse one time
        if (grvUser.SelectedRows.Count > 0)
        {
          var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          if (dr == DialogResult.Yes)
          {
            for (int i = 0; i < grvUser.SelectedRows.Count; i++)
            {
              var userID = Convert.ToInt32(grvUser.SelectedRows[i].Cells["UserID"].Value);
              UserFactory.Delete(userID);
            }
            MessageBox.Show("Xóa xong");
            BindData(UserFactory.SelectAllUser());
          }
        }
        else
        {
          MessageBox.Show("Bạn cần chọn một người dùng.");
        }
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }
    }

    private void grvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {

      try
      {
        if (e.RowIndex >= 0 && grvUser.SelectedRows.Count == 1) // Only select one row
        {
          var addUser = new frmAddUser(this, 1, Convert.ToInt32(grvUser.SelectedRows[0].Cells[ConstantInfo.TBL_USER_USERID].Value), _userInfo);
          addUser.MdiParent = this.ParentForm;
          addUser.Show();
        }
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }

    }
           
           
  }
}
