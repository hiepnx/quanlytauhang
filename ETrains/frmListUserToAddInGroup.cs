using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETrains.Utilities;
using log4net;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities.Enums;

namespace ETrains
{
  public partial class frmListUserToAddInGroup : Form
  {
    private static ILog logger = LogManager.GetLogger("ETrains.frmListUserToAddInGroup");

    private Mode _mode;
    private int _groupID;
    private UserInfo _userInfo;
    private UserFactory _userBOL;
    private frmAddGroup _parent;

    public frmListUserToAddInGroup()
    {
      InitializeComponent();
    }

    public frmListUserToAddInGroup(Mode mode, int groupID, UserInfo userInfo, frmAddGroup parent)
    {
      InitializeComponent();
      _userInfo = userInfo;
      _groupID = groupID;
      _mode = mode;
      _parent = parent;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmListUserToAddInGroup_Load(object sender, EventArgs e)
    {
        this.Text = "Thêm người dùng vào nhóm" + ConstantInfo.MESSAGE_TITLE;        
        InitData();
    }

    private void BindData()
    {
      // _userBOL = new UserFactory();
      grvUser.AutoGenerateColumns = false;
      grvUser.DataSource = UserFactory.SelectAllUser();

    }

    private void InitData()
    {
      this.BindData();
      if (_mode.Equals(Mode.Create)) // New mode
      {
        //todo
      }
      else // Edit mode
      {
        checkUserInGroup();
      }
    }

    private void checkUserInGroup()
    {
      List<ViewUserGroup> listViewUserGroup = UserInGroupFactory.GetByGroupID(_groupID);
      foreach (ViewUserGroup userInGroup in listViewUserGroup)
      {
        foreach (DataGridViewRow dr in grvUser.Rows)
        {
          if (dr.Cells[1].Value + "" == userInGroup.UserID + "")
          {
            dr.Cells[0].Value = true;
          }
        }
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {

      //delete all current user of this Group before add new ones
      UserInGroupFactory.DeleteUserInGroupByGroupID(_groupID);
      //add selected user into groups
      try
      {
        foreach (DataGridViewRow dr in grvUser.Rows)
        {
          if (dr.Cells[0].Value + "" == "True")
          {
            int userID = new Int32();
            userID = (Int32)dr.Cells[1].Value;
            tblUserInGroup userInGroup = new tblUserInGroup();
            userInGroup.GroupID = _groupID;
            userInGroup.UserID = userID;
            UserInGroupFactory.Insert(userInGroup);
          }
        }
      }
      catch (Exception)
      {
        MessageBox.Show(ConstantInfo.MESSAGE_ADD_USER_IN_GROUP_FAIL);
        return;
      }

      MessageBox.Show(ConstantInfo.MESSAGE_ADD_USER_IN_GROUP_SUCESSFULLY);
      // Bind the lastest to the parrent
      _parent.BindData();
      //Form[] listForm = this.Owner.OwnedForms;
      //foreach (Form form in listForm)
      //{
      //  if (form.Name == "frmAddGroup")
      //  {
      //    ((frmAddGroup)form).BindData();
      //  }
      //}
      _parent.Show();
      _parent.Focus();
      this.Close();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      InitData();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      grvUser.DataSource = UserFactory.SearchByName(txtKeyWord.Text.Trim());
    }
  }
}
