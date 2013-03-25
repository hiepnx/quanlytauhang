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
using ETrains.Utilities.Enums;
using CrystalDecisions.CrystalReports.Engine;

namespace ETrains.Train
{
    public partial class FrmListHandoverReply : Form
    {
        private UserInfo _userInfo;
        public FrmListHandoverReply()
        {
            InitializeComponent();
        }

        public FrmListHandoverReply(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void FrmListHandoverReply_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            ////init ma cua khau
            var listHQ = CustomsFacory.getAll();
            var listStation = new List<tblCustom>();
            listStation.AddRange(listHQ);
            listStation.Insert(0, new tblCustom
            {
                CustomsName = "Tất cả",
                CustomsCode = ""
            });
            cbCustoms.DataSource = listStation.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            cbCustoms.ValueMember = "CustomsCode";
            cbCustoms.DisplayMember = "CustomsName";
            cbCustoms.SelectedIndex = 0;
            search();
        }

        public void search()
        {
            List<ViewListHanoverReply> listViewListHanoverReply = HandoverReplyFactory.search(txtNumberReply.Text.Trim(), (string)cbCustoms.SelectedValue, cbNgayXNC.Checked, dtpFrom.Value, dtpTo.Value);
            grdHandover.AutoGenerateColumns = false;
            grdHandover.DataSource = listViewListHanoverReply;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void cbNgayXNC_CheckedChanged(object sender, EventArgs e)
        {
            dtpTo.Enabled = cbNgayXNC.Checked;
            dtpFrom.Enabled = cbNgayXNC.Checked;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdHandover.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn thự sự muốn xóa bảng kê đã chọn?", "Cảnh báo!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int selectedIndex = grdHandover.SelectedRows[0].Index;

                        // gets the RowID from the first column in the grid
                        var ID = Int64.Parse(grdHandover[0, selectedIndex].Value.ToString());

                        tblListHandoverReply reply = HandoverReplyFactory.FindByID(ID);
                        if (reply == null)
                        {
                            MessageBox.Show("Bảng kê này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (HandoverReplyFactory.Delete(reply.ID) > 0)
                        {
                            search();
                            MessageBox.Show("Xóa bảng kê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            search();
                            MessageBox.Show("Xóa bảng kê không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddListHandoverReply addForm = new FrmAddListHandoverReply(this, _userInfo, 0);
            addForm.MdiParent = this.MdiParent;
            addForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdHandover.SelectedRows.Count > 0)
                {

                    int selectedIndex = grdHandover.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var ID = Int64.Parse(grdHandover[0, selectedIndex].Value.ToString());

                    tblListHandoverReply reply = HandoverReplyFactory.FindByID(ID);
                    if (reply == null)
                    {
                        MessageBox.Show("Bảng kê này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        FrmAddListHandoverReply form = new FrmAddListHandoverReply(this, _userInfo, reply, 1);
                        form.MdiParent = this.MdiParent;
                        form.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void grdHandover_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grdHandover.SelectedRows.Count > 0)
                {

                    int selectedIndex = grdHandover.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var ID = Int64.Parse(grdHandover[0, selectedIndex].Value.ToString());

                    tblListHandoverReply reply = HandoverReplyFactory.FindByID(ID);
                    if (reply == null)
                    {
                        MessageBox.Show("Bảng kê này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        FrmAddListHandoverReply form = new FrmAddListHandoverReply(this, _userInfo, reply, 1);
                        form.MdiParent = this.MdiParent;
                        form.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
