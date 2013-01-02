﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;

namespace ETrains
{
  public partial class frmAddUser : Form
  {
    private frmUser _parrent;
    private int _mode;
    private int _userID;        
    private UserInfo _userInfo;
    private TabPage _tabUser;
    private TabPage _tabGroup;
    private TabPage _tabPermission;
    private HashSet<int> listCheckPermission;

    public frmAddUser()
    {
      InitializeComponent();
    }

    public frmAddUser(frmUser parrent, int mode, UserInfo userInfo)
    {
      InitializeComponent();
      _userInfo = userInfo;
      _tabUser = tabControl1.TabPages[0];
      _tabGroup = tabControl1.TabPages[1];
      _tabPermission = tabControl1.TabPages[2];
      _parrent = parrent;
      _mode = mode;
    }

    public frmAddUser(frmUser parrent, int mode, int userID, UserInfo userInfo)
    {
      InitializeComponent();
      _tabUser = tabControl1.TabPages[0];
      _tabGroup = tabControl1.TabPages[1];
      _tabPermission = tabControl1.TabPages[2];
      _userInfo = userInfo;
      _parrent = parrent;
      _mode = mode;
      _userID = userID;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmAddUser_Load(object sender, EventArgs e)
    {
      this.Text = "Thong tin nguoi dung" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
      // Show form to the center
      this.Location = new Point((this.ParentForm.Width - this.Width) / 2, (this.ParentForm.Height - this.Height) / 2);      
      grvGroup.AutoGenerateColumns = false;
      Init();
      initTreeView();
      fillPermission();
    }


    private void initTreeView()
    {
        //treeView1.CheckBoxes = true;

        //// Add nodes to treeView1.
        ////TreeNode node;
        //TreeNode rootNode;
        //TreeNode node;
        //rootNode = treeView1.Nodes.Add("root","Tất cả");

        //List<tblPermissionType> list = PermissionTypeFactory.GetAllPermissionType();
        //foreach (tblPermissionType type in list)
        //{
        //    node = rootNode.Nodes.Add(type.TypeCode, type.TypeName);
        //    List<tblPermission> listPermission = PermissionFactory.GetPermissionByType(type.TypeCode);
        //    foreach (tblPermission permission in listPermission)
        //    {
        //        node.Nodes.Add(permission.PermissionID +"", permission.Permission);
        //    }
        //}
        //treeView1.ExpandAll();

    }
    private void fillPermission()
    {
       // treeView1.Nodes.Find("root", true)[0].Checked = false;
       // this.listCheckPermission = new HashSet<int>();
       ////check Permissions if User has them
       // List<tblUserGroupPermission> listUserGroupPermission = UserGroupPermissionFactory.GetByUserID(_userID);
       // foreach (tblUserGroupPermission obj in listUserGroupPermission)
       // {
       //     TreeNode[] listNode= treeView1.Nodes.Find(obj.PermissionID + "", true);
       //     if (listNode != null && listNode.Length > 0)
       //     {
       //         TreeNode checkNode = listNode[0];
       //         try
       //         {
       //             checkNode.Checked = true;
       //         }
       //         catch (Exception ex)
       //         {
       //         }
       //     }
       // }
    }

    private void BinDataForListGroup()
    {
      ////load all Groups
      //grvGroup.DataSource = GroupFactory.SelectAll();

      ////check Groups if user in them
      //List<ViewUserGroup> listUserGroupPermission = UserInGroupFactory.GetByUserID(_userID);
      //foreach (ViewUserGroup obj in listUserGroupPermission)
      //{
      //  foreach (DataGridViewRow dr in grvGroup.Rows)
      //  {
      //    if (dr.Cells[1].Value + "" == obj.GroupID + "")
      //    {
      //      dr.Cells[0].Value = true;
      //      break;
      //    }
      //  }
      //}
    }

    /// <summary>
    /// Init data
    /// </summary>
    private void Init()
    {
      try
      {
        if (_mode == 0) // Add new Mode
        {
          tabControl1.TabPages.Remove(_tabGroup);
          tabControl1.TabPages.Remove(_tabPermission);
          btnUpdate.Enabled = false;
          btnAdd.Enabled = true;
        }
        else // Update Mode
        {
          btnUpdate.Enabled = true;
          btnAdd.Enabled = false;
          // Get User by ID
          var userInfo = UserFactory.GetByID(_userID);
          // Bind data to the UI
          txtUserName.Text = userInfo.UserName;

          // Don't allow you edit username
          txtUserName.Enabled = false;

          txtPassword.Text = userInfo.Password;
          txtRetypePassword.Text = userInfo.Password;
          txtEmail.Text = userInfo.Email;
          txtName.Text = userInfo.Name;
          txtAddress.Text = userInfo.Address;
          txtPhone.Text = userInfo.PhoneNumber;
          cbActive.Checked = Convert.ToBoolean(userInfo.IsActive);
        }
      }
      catch (Exception ex)
      {
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }

    }

    public static void EnableTab(TabPage page, bool enable)
    {
      EnableControls(page.Controls, enable);
    }
    private static void EnableControls(Control.ControlCollection ctls, bool enable)
    {
      foreach (Control ctl in ctls)
      {
        ctl.Enabled = enable;
        EnableControls(ctl.Controls, enable);
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      try
      {
        // Validate
        if (Validate())
        {
          // Check the existing username   
          if (!UserFactory.CheckIsUserExisting(txtUserName.Text.Trim()))
          {
            // Insert to database
            var userInfo = new tblUser();
            BindControlToData(ref userInfo);
            // Insert to database
             UserFactory.Insert(userInfo);
            _parrent.BindData(UserFactory.SelectAllUser());
            //TODO: Need to check number of rows are effected
            MessageBox.Show(ConstantInfo.MESSAGE_INSERT_SUCESSFULLY);

            //get userInfor after insert
            tblUser user = UserFactory.getUserByUserName(txtUserName.Text.Trim());
            _userID = user.UserID;

            //show tab listGroup and ListPermissior
            tabControl1.TabPages.Add(_tabGroup);
            tabControl1.TabPages.Add(_tabPermission);

            btnAdd.Enabled = false;
            EnableTab(_tabUser, false);
            btnClose.Enabled = true;
            //this.Close();
          }
          else
          {
            MessageBox.Show(ConstantInfo.MESSAGE_USERNAME_EXISTING);
          }
        }
      }
      catch (Exception ex)
      {
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }
    }

    private bool Validate()
    {
      if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
      {
        MessageBox.Show(ConstantInfo.MESSAGE_BLANK_USERNAME);
        txtUserName.Focus();
        return false;
      }

      if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
      {
        MessageBox.Show(ConstantInfo.MESSAGE_BLANK_PASSWORD);
        txtPassword.Focus();
        return false;
      }


      if (!txtPassword.Text.Trim().Equals(txtRetypePassword.Text.Trim()))
      {
        MessageBox.Show(ConstantInfo.MESSAGE_COMPARE_PASSWORD);
        txtPassword.Focus();
        return false;
      }

      Regex rEMail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
      if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
      {
        MessageBox.Show(ConstantInfo.MESSAGE_BLANK_EMAIL);
        txtEmail.Focus();
        return false;
      }
      else if (!rEMail.IsMatch(txtEmail.Text.Trim()))
      {
        MessageBox.Show(ConstantInfo.MESSAGE_WRONG_EMAIL);
        txtEmail.Focus();
        return false;
      }

      return true;
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {

        var user = UserFactory.GetByID(_userID);
        BindControlToData(ref user);        
        // Update
        UserFactory.Update(user);
        
        _parrent.BindData(UserFactory.SelectAllUser());
        //TODO: Need to check number of rows are effected
        MessageBox.Show(ConstantInfo.MESSAGE_UPDATE_SUCESSFULLY);
        //this.Close();
      }
      catch (Exception ex)
      {
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }
    }

    /// <summary>
    /// Bind data to controls
    /// </summary>
    private void BindControlToData(ref tblUser tblUser)
    {
      try
      {
        tblUser.UserName = txtUserName.Text.Trim();
        tblUser.Password = txtPassword.Text.Trim();
        tblUser.Email = txtEmail.Text;
        tblUser.Name = txtName.Text;
        tblUser.Address = txtAddress.Text;
        tblUser.PhoneNumber = txtPhone.Text;
        tblUser.IsActive = Convert.ToInt16(cbActive.Checked);
      }
      catch (Exception ex)
      {
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {

    }

    private void btnUpdatePermission_Click(object sender, EventArgs e)
    {

    }

    private void tabControl1_Click(object sender, EventArgs e)
    {
      if (tabControl1.SelectedIndex == 1)
      {
        BinDataForListGroup();
      }
      if (tabControl1.SelectedIndex == 2)
      {
          fillPermission();
      }
    }

    private void btnResetPermission_Click(object sender, EventArgs e)
    {
      fillPermission();
    }

    private void tbnResetListGroup_Click(object sender, EventArgs e)
    {
      BinDataForListGroup();
    }

    private void btnUpdateListGroup_Click(object sender, EventArgs e)
    {
      ////check is user exist
      //tblUser user = UserFactory.GetByID(_userID);
      //if (user == null)
      //{
      //  MessageBox.Show("Người dùng này không còn tại tại trong hệ thống nữa, xin kiểm tra lại");
      //  return;
      //}

      ////delete all current Group of this User before add new ones
      //UserInGroupFactory.DeleteUserInGroupByUserID(_userID);
      ////add selected group into userInGroup
      //try
      //{
      //  foreach (DataGridViewRow dr in grvGroup.Rows)
      //  {
      //    if (dr.Cells[0].Value + "" == "True")
      //    {
      //      int groupID = new Int32();
      //      groupID = (Int32)dr.Cells[1].Value;
      //      tblUserInGroup userInGroup = new tblUserInGroup();
      //      userInGroup.GroupID = groupID;
      //      userInGroup.UserID = _userID;
      //      UserInGroupFactory.Insert(userInGroup);
      //    }
      //  }
      //}
      //catch (Exception)
      //{
      //  MessageBox.Show(ConstantInfo.MESSAGE_ADD_USER_IN_GROUP_FAIL);
      //  return;
      //}
      //MessageBox.Show(ConstantInfo.MESSAGE_ADD_USER_IN_GROUP_SUCESSFULLY);
    }

    private void btnUpdatePermission_Click_1(object sender, EventArgs e)
    {
      //check is user exist
      tblUser user = UserFactory.GetByID(_userID);
      if (user == null)
      {
        MessageBox.Show("Người dùng này không còn tại tại trong hệ thống nữa, xin kiểm tra lại");
        return;
      }

      //delete all old permissions
      //UserGroupPermissionFactory.DeleteUserGroupPermissionByUserID(_userID);

      //add new permissions
      try
      {
        //List<tblUserGroupPermission> listUserGroupPermission = new List<tblUserGroupPermission>();
        //foreach (int permissionID in listCheckPermission)
        //{
        //    tblUserGroupPermission userGroupPermission = new tblUserGroupPermission();
        //    userGroupPermission.UserID = _userID;
        //    userGroupPermission.PermissionID = permissionID;
        //    userGroupPermission.PermissionType = UserGroupPermissionFactory.PERMISSION_TYPE_USER;
        //    userGroupPermission.CreatedBy = _userInfo.UserID;
        //    userGroupPermission.ModifiedBy = _userInfo.UserID;
        //    userGroupPermission.CreatedDate = CommonFactory.GetCurrentDate();
        //    userGroupPermission.ModifiedDate = CommonFactory.GetCurrentDate();
        //    //add to listUserGroupPermission
        //    listUserGroupPermission.Add(userGroupPermission);
          
        //}

        ////save listUserGroupPermission to database
        //UserGroupPermissionFactory.Insert(listUserGroupPermission);
      }
      catch (Exception)
      {
        MessageBox.Show(ConstantInfo.MESSAGE_ADD_USER_IN_GROUP_FAIL);
        return;
      }

      MessageBox.Show(ConstantInfo.MESSAGE_ADD_USER_IN_GROUP_SUCESSFULLY);
    }


    private void chbCheckAllGroup_CheckedChanged(object sender, EventArgs e)
    {
      for (int i = 0; i < grvGroup.RowCount; i++)
      {
        grvGroup[0, i].Value = chbCheckAllGroup.Checked;
      }
      grvGroup.EndEdit();
    }

    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        //MessageBox.Show("node: " + e.Node.Name);
        //check all child node
        foreach (TreeNode node in e.Node.Nodes)
        {
            node.Checked = e.Node.Checked;
        }

        //add permission to list
        try
        {
            int permissionID = int.Parse(e.Node.Name);
            if (e.Node.Checked)
            {
                listCheckPermission.Add(permissionID);
            }
            else
            {
                listCheckPermission.Remove(permissionID);
            }
        }
        catch (Exception ex)
        {
            //do nothing
        }
    }
  }
}
