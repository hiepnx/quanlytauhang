using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;

namespace ETrains.Train
{
    public partial class frmQLChuyenTau : Form
    {
        private List<tblChuyenTau> listTrain;
        public frmQLChuyenTau()
        {
            InitializeComponent();
        }

        private void frmQLChuyenTau_Load(object sender, EventArgs e)
        {
            this.Text = "Quan ly Tau hang XNK" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>
                               {
                                   new ComboBoxItem(-1, "Tất cả"),
                                   new ComboBoxItem(0, "Xuất cảnh"),
                                   new ComboBoxItem(1, "Nhập cảnh")
                               };
            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                listTrain = TrainFactory.SearchChuyenTau(txtNumberTrain.Text.Trim(),
                                                             Convert.ToInt32(((ComboBoxItem) ddlTypeName.SelectedItem).Value),
                                                             cbNgayXNC.Checked, dtpFrom.Value, dtpTo.Value);
                grdTrain.AutoGenerateColumns = false;
                grdTrain.DataSource = listTrain;

                for (var i = 0; i < grdTrain.Rows.Count; i++)
                {
                    // Add to count Column
                    grdTrain.Rows[i].Cells["Count"].Value = i + 1;
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
            var train = listTrain[e.RowIndex];
            var frm = new Train.frmThemChuyenTau(frmMainForm._userInfo, (short)train.Type, train);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK )
            {
                btnSearch_Click(null, null);
            }
        }

    }
}
