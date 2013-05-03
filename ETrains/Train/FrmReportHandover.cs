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
    public partial class FrmReportHandover : Form
    {
        public FrmReportHandover()
        {
            InitializeComponent();
        }

        private void FrmReportHandover_Load(object sender, EventArgs e)
        {
            this.Text = "So theo doi Bien ban ban giao " + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            cbType.Items.Add(new ComboBoxItem("0", "BBBG đến"));
            cbType.Items.Add(new ComboBoxItem("1", "BBBG đi"));
            cbType.SelectedIndex = 0;

            cbReplyStatus.Items.Add(new ComboBoxItem(null, "     "));
            cbReplyStatus.Items.Add(new ComboBoxItem(true, "Đã hồi báo"));
            cbReplyStatus.Items.Add(new ComboBoxItem(false, "Chưa hồi báo"));
            cbReplyStatus.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            String replyType = ((ComboBoxItem)cbType.SelectedItem).Value.ToString();
            Nullable<Boolean> replyStatus = null;
            if (((ComboBoxItem)cbReplyStatus.SelectedItem).Value != null)
            {
                replyStatus = (Boolean)(((ComboBoxItem)cbReplyStatus.SelectedItem).Value);
            }
            List<tblHandover> listHandover = TrainFactory.SearchBBBG("",true, dtpFrom.Value, dtpTo.Value, replyStatus, replyType, false);

            DataSet1 dataset = new DataSet1();
            DataTable dt = dataset.BBBG;

            foreach (tblHandover handover in listHandover)
            {
                string tenHaiQuanChuyenDen="";
                string tenHaiQuanChuyenDi="";
                if(replyType=="0") //BBBG den
                {
                    tenHaiQuanChuyenDen=CustomsFacory.FindByCode(handover.CodeStation).CustomsName;
                    tenHaiQuanChuyenDi=CustomsFacory.FindByCode(handover.CodeStationFromTo).CustomsName;
                }
                else if(replyType=="1") //BBBG di
                {
                    tenHaiQuanChuyenDen=CustomsFacory.FindByCode(handover.CodeStationFromTo).CustomsName;
                    tenHaiQuanChuyenDi=CustomsFacory.FindByCode(handover.CodeStation).CustomsName;
                }

                dt.Rows.Add(handover.ID, handover.NumberHandover, handover.DateHandover, tenHaiQuanChuyenDi, tenHaiQuanChuyenDen, handover.StatusVehicle, handover.StatusGoods, handover.DateReply, handover.Note);
            }

            if (replyType == "0") //BBBG den
            {
                //txtType.Text = ("SỔ THEO DÕI BBBG HÀNG CHUYỂN CẢNG ĐẾN").ToUpper();
            }
            else if (replyType == "1") //BBBG di
            {
                var report = new ReportHandoverOut();
                var txtType = (TextObject)report.Section1.ReportObjects["txtType"];
                var txtFrom = (TextObject)report.Section1.ReportObjects["txtFrom"];
                var txtTo = (TextObject)report.Section1.ReportObjects["txtTo"];
                txtFrom.Text = txtFrom.Text + " " + dtpFrom.Text;
                txtTo.Text = txtTo.Text + " " + dtpTo.Text;
                txtType.Text = ("SỔ THEO DÕI BBBG HÀNG CHUYỂN CẢNG ĐI").ToUpper();

                report.SetDataSource(dataset);
                FrmPreviewReport frmReport = new FrmPreviewReport(report);
                frmReport.MdiParent = this.MdiParent;
                frmReport.Show();
            }

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String replyType = ((ComboBoxItem)cbType.SelectedItem).Value.ToString();
            if (replyType == "0") //BBBG den
            {  
                cbReplyStatus.Enabled = false;
            }
            else //BBBG di
            {
                cbReplyStatus.Enabled = true;
            }
        }
    }
}
