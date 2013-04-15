using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;

namespace ETrains.Train
{
    public partial class frmQLToKhai : Form
    {
        private List<tblToKhaiTau> listToKhai;
        public frmQLToKhai()
        {
            InitializeComponent();
        }

        private void frmQLToKhai_Load(object sender, EventArgs e)
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
            search();
        }
        public void search()
        {
            try
            {
                listToKhai = TrainFactory.SearchToKhai(txtNumberTrain.Text.Trim(),
                                                             Convert.ToInt16(((ComboBoxItem)ddlTypeName.SelectedItem).Value),
                                                             cbNgayDK.Checked, dtpFrom.Value, dtpTo.Value, txtSoHieuToaTau.Text.Trim());
                grdTrain.AutoGenerateColumns = false;
                grdTrain.DataSource = listToKhai;

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
            dtpFrom.Enabled = dtpTo.Enabled = cbNgayDK.Checked;
        }

        private void grdTrain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var toKhai = listToKhai[e.RowIndex];
            var frm = new Train.frmToKhai(frmMainForm._userInfo,toKhai,toKhai.Type.GetValueOrDefault(), 1);
            if(frm.ShowDialog()== DialogResult.OK)
            {
                search();
            }
            
        }
    }
}
