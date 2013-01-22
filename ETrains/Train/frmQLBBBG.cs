using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;

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
            try
            {
                listHandOver = TrainFactory.SearchBBBG(txtNumberBBBG.Text.Trim(),
                                                             cbNgayXNC.Checked, dtpFrom.Value, dtpTo.Value);
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
            var handover = listHandOver[e.RowIndex];
            var frm = new Train.frmBBBG(frmMainForm._userInfo, (short)handover.tblChuyenTau.Type, handover);
            frm.ShowDialog();
        }
    }
}
