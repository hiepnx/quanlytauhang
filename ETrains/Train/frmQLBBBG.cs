using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;
using ETrains.Utilities.Enums;

namespace ETrains.Train
{
    public partial class frmQLBBBG : Form
    {
        private List<tblHandover> listHandOver;
        public frmQLBBBG()
        {
            InitializeComponent();
        }

        private void frmQLBBBG_Load(object sender, EventArgs e)
        {
            this.Text = "Quan ly BBBG" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
            cbType.Items.Add(new ComboBoxItem("-1","Tất cả"));
            cbType.Items.Add(new ComboBoxItem("0", "BBBG đến"));
            cbType.Items.Add(new ComboBoxItem("1", "BBBG đi"));
            cbType.SelectedIndex = 0;

            cbReplyStatus.Items.Add(new ComboBoxItem(null,"Tất cả"));
            cbReplyStatus.Items.Add(new ComboBoxItem(true, "Đã hồi báo"));
            cbReplyStatus.Items.Add(new ComboBoxItem(false, "Chưa hồi báo"));
            cbReplyStatus.SelectedIndex = 0;

            //search();
        }

        private void Init()
        {
            //init data for Type
            //var listType = new List<ComboBoxItem>
            //                   {
            //                       new ComboBoxItem(-1, "Tất cả"),
            //                       new ComboBoxItem(0, "Xuất cảnh"),
            //                       new ComboBoxItem(1, "Nhập cảnh")
            //                   };
            //ddlTypeName.Items.AddRange(listType.ToArray());
            //ddlTypeName.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        public void search()
        {
            try
            {
                String replyType = ((ComboBoxItem)cbType.SelectedItem).Value.ToString();
                Nullable<Boolean> replyStatus = null;
                if (((ComboBoxItem)cbReplyStatus.SelectedItem).Value != null)
                {
                    replyStatus = (Boolean)(((ComboBoxItem)cbReplyStatus.SelectedItem).Value);
                }
                listHandOver = TrainFactory.SearchBBBG(txtNumberBBBG.Text.Trim(),
                                                             cbNgayXNC.Checked, dtpFrom.Value, dtpTo.Value, replyStatus, replyType);
                foreach (tblHandover handover in listHandOver)
                {
                    if (handover.Type == "0")
                    {
                        handover.Type = "BBBG Đến";
                    }
                    else
                    {
                        handover.Type = "BBBG Đi";
                    }
                }

                grdHandover.AutoGenerateColumns = false;
                grdHandover.DataSource = listHandOver;

                for (var i = 0; i < grdHandover.Rows.Count; i++)
                {
                    // Add to count Column
                    grdHandover.Rows[i].Cells["Count"].Value = i + 1;
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

        private void grdTrain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var handover = TrainFactory.FindHandoverByID(listHandOver[e.RowIndex].ID);

            var frm = new Train.frmBBBG(frmMainForm._userInfo, handover.Type, handover);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                search();
            }
        }

        private void grdHandover_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1) return;
            var handover = TrainFactory.FindHandoverByID(listHandOver[e.RowIndex].ID);
            if (handover.IsReplied != true && handover.Type == "1") //neu chua duoc hoi bao, va la loai BBBG di
            {
                var dr = MessageBox.Show("Bạn có muốn hồi báo BBBG: " + handover.NumberHandover, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    handover.IsReplied = true;
                    handover.DateReply = DateTime.Now;
                    int update = TrainFactory.UpdateHandover(handover);
                    if (update < 1)
                    {
                        MessageBox.Show("Thực hiện hồi báo không thành công, xin kiểm tra lại kết nối Cơ sở dữ liệu, hoặc BBBG này không còn tồn tại");
                    }
                    else
                    {
                        search();
                    }
                }
            }
            //if (handover.tblChuyenTauReference.IsLoaded == false)
            //{
            //    handover.tblChuyenTauReference.Load();
            //}
            //var frm = new Train.frmBBBG(frmMainForm._userInfo, (short)handover.tblChuyenTau.Type, handover);
            //frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    search();
            //}
        }
    }
}
