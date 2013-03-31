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

namespace ETrains.Train
{
    public partial class frmSearchTrainPassenger : Form
    {
        private UserInfo _userInfor;
        public frmSearchTrainPassenger(UserInfo userInfor)
        {
            InitializeComponent();
            _userInfor = userInfor;
        }

        private void frmSearchTrainPassenger_Load(object sender, EventArgs e)
        {
            this.Text = "Quan ly Tau khach XNC" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>();
            listType.Add(new ComboBoxItem(-2, "Tất cả"));
            listType.Add(new ComboBoxItem((short)ChuyenTauType.TypeExport, "Xuất cảnh"));
            listType.Add(new ComboBoxItem((short)ChuyenTauType.TypeImport, "Nhập cảnh"));

            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        public void search()
        {
            try
            {
                DateTime fromDate = dtpFrom.Value;
                DateTime toDate = dtpTo.Value;

                var listTrain = TrainFactory.SearchTrain(txtNumberTrain.Text.Trim(),
                                                             Convert.ToInt16(((ComboBoxItem)ddlTypeName.SelectedItem).Value),
                                                             cbNgayXNC.Checked, fromDate, toDate);

                grdTrain.AutoGenerateColumns = false;
                grdTrain.DataSource = listTrain;


                for (var i = 0; i < grdTrain.Rows.Count; i++)
                {
                    // Add to count Column
                    grdTrain.Rows[i].Cells[1].Value = (i + 1).ToString();
                    short type = short.Parse(grdTrain.Rows[i].Cells[4].Value.ToString());
                    if (type == (short)ChuyenTauType.TypeExport)
                    {
                        grdTrain.Rows[i].Cells[5].Value = "Xuất cảnh";
                    }
                    if (type == (short)ChuyenTauType.TypeImport)
                    {
                        grdTrain.Rows[i].Cells[5].Value = "Nhập cảnh";
                    }
                }
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grdTrain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grdTrain.SelectedRows.Count > 0)
                {
                    int selectedIndex = grdTrain.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    Int64 trainID = Int64.Parse(grdTrain[0, selectedIndex].Value.ToString());

                    tblTrain train = TrainFactory.FindTrainByID(trainID);
                    if (train == null)
                    {
                        MessageBox.Show("Tàu khách này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    frmTrainPassengers form = new frmTrainPassengers(this, _userInfor, train, 1);
                    form.MdiParent = this.MdiParent;
                    form.Show();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTrainPassengers form = new frmTrainPassengers(this, _userInfor, null, 0);
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdTrain.SelectedRows.Count > 0)
                {
                    int selectedIndex = grdTrain.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    Int64 trainID = Int64.Parse(grdTrain[0, selectedIndex].Value.ToString());

                    tblTrain train = TrainFactory.FindTrainByID(trainID);
                    if (train == null)
                    {
                        MessageBox.Show("Tàu khách này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    frmTrainPassengers form = new frmTrainPassengers(this, _userInfor, train, 1);
                    form.MdiParent = this.MdiParent;
                    form.Show();
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
                if (this.grdTrain.SelectedRows.Count > 0)
                {
                    int selectedIndex = grdTrain.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    Int64 trainID = Int64.Parse(grdTrain[0, selectedIndex].Value.ToString());

                    tblTrain train = TrainFactory.FindTrainByID(trainID);
                    if (train == null)
                    {
                        MessageBox.Show("Tàu khách này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int delete = TrainFactory.Delete(trainID);
                    if (delete > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        search();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công, xin kiểm tra lại kết nối mạng");
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

        private void cbNgayXNC_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = cbNgayXNC.Checked;
        }
    }
}
