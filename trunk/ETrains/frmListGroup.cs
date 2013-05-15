﻿using System;
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
  public partial class frmListGroup : Form
  {
    private static ILog logger = LogManager.GetLogger("ETrains.frmListGroup");

    private UserInfo _userInfo;

    public frmListGroup()
    {
      InitializeComponent();
    }

    public frmListGroup(UserInfo userInfo)
    {
        InitializeComponent();
        _userInfo = userInfo;
        //btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_NHOM_NGUOI_DUNG);
        //btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_NHOM_NGUOI_DUNG);
        //btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_NHOM_NGUOI_DUNG);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      var addGroup = new frmAddGroup(this,Utilities.Enums.Mode.Create, 0, _userInfo);
      addGroup.MdiParent = this.MdiParent;
      //addGroup.Show(this.Owner);
      addGroup.Show();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmListGroup_Load(object sender, EventArgs e)
    {
        this.Text = "Danh sách nhóm người dùng" + ConstantInfo.MESSAGE_TITLE;        
        InitData();
    }

    public void InitData()
    {
      grvGroup.AutoGenerateColumns = false;
      var groups = GroupFactory.SelectAll();
      grvGroup.DataSource = groups;
    }

    private void grvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      btnUpdate.Enabled = true;
      btnDelete.Enabled = true;
      //btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_NHOM_NGUOI_DUNG);
      //btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_NHOM_NGUOI_DUNG);
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      DataGridViewRow dr = grvGroup.SelectedRows[0];
      int selectedGroupID = (Int32)dr.Cells[1].Value;
      var addGroup = new frmAddGroup(this,Utilities.Enums.Mode.Edit, selectedGroupID, _userInfo);
      addGroup.Show(this.Owner);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      try
      {
        if (grvGroup.SelectedRows.Count > 0)
        {
          var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          if (dr == DialogResult.Yes)
          {
            for (int i = 0; i < grvGroup.SelectedRows.Count; i++)
            {
              var groupID = Int32.Parse(grvGroup.SelectedRows[i].Cells["GroupID"].Value.ToString());
              GroupFactory.DeleteGroupByGroupID(groupID);
            }
            MessageBox.Show("Xóa xong");
            InitData();
          }
        }
        else
        {
          MessageBox.Show("Bạn cần chọn tờ khai.");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Xóa bị lỗi");
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }
    }

    private void grvGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {

      try
      {
        if (e.RowIndex >= 0 && grvGroup.SelectedRows.Count == 1) // Only select one row
        {
          var dr = grvGroup.SelectedRows[0];
          var selectedGroupID = (Int32)dr.Cells[1].Value;
          var addGroup = new frmAddGroup(this, Utilities.Enums.Mode.Edit, selectedGroupID, _userInfo);
          addGroup.Show(this.Owner);
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
