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
    public partial class FrmReportListHanoverReply : Form
    {
        public FrmReportListHanoverReply()
        {
            InitializeComponent();
        }

        private void FrmReportListHanoverReply_Load(object sender, EventArgs e)
        {
            this.Text = "So theo doi bang ke hoi bao BBBG chuyen cang den " + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             List < ViewListHanoverReply > listViewListHanoverReply = HandoverReplyFactory.search("", "", true, dtpFrom.Value, dtpTo.Value);

             var report = new ReportSoTheoDoiBangKeHoiBao();
             var txtFrom = (TextObject)report.Section1.ReportObjects["txtFrom"];
             var txtTo = (TextObject)report.Section1.ReportObjects["txtTo"];
             txtFrom.Text = txtFrom.Text + " " + dtpFrom.Text;
             txtTo.Text = txtTo.Text + " " + dtpTo.Text;

             DataSet1 dataset = new DataSet1();
             DataTable dt = dataset.BangKeHoiBao;
             foreach (ViewListHanoverReply obj in listViewListHanoverReply)
             {
                 dt.Rows.Add(obj.ID, obj.ListReplyNumber, obj.ListReplyDate, obj.CustomsReceiverName, obj.Note);
             }
             report.SetDataSource(dataset);
             FrmPreviewReport frmReport = new FrmPreviewReport(report);
             frmReport.MdiParent = this.MdiParent;
             frmReport.Show();
        }
    }
}
