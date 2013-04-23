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
    public partial class FrmReportPassengerTrain : Form
    {
        public FrmReportPassengerTrain()
        {
            InitializeComponent();
        }

        private void FrmReportPassengerTrain_Load(object sender, EventArgs e)
        {
            this.Text = "So theo doi tau khach xuat nhap canh " + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>();
            listType.Add(new ComboBoxItem((short)ChuyenTauType.TypeExport, "Xuất cảnh"));
            listType.Add(new ComboBoxItem((short)ChuyenTauType.TypeImport, "Nhập cảnh"));

            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;

            List<tblTrain> listTrain = TrainFactory.SearchTrain("", Convert.ToInt16(((ComboBoxItem)ddlTypeName.SelectedItem).Value),
                                                         true, fromDate, toDate);
            try
            {
                var report = new ReportPassengerTrain();
                var txtType = (TextObject)report.Section1.ReportObjects["txtType"];
                var txtFrom = (TextObject)report.Section1.ReportObjects["txtFrom"];
                var txtTo = (TextObject)report.Section1.ReportObjects["txtTo"];
                txtType.Text = ("HÀNH KHÁCH " + ddlTypeName.Text + " BẰNG ĐƯỜNG SẮT").ToUpper();
                txtFrom.Text = txtFrom.Text + " " +dtpFrom.Text;
                txtTo.Text = txtTo.Text + " " + dtpTo.Text;

                DataSet1 dataset = new DataSet1();
                DataTable dt = dataset.tblTrain;
                foreach (tblTrain train in listTrain)
                {
                    dt.Rows.Add(train.TrainID,train.Number,train.Type,train.DateImportExport,
                        train.Jounery, train.PassengerVN, train.PassengerForegin, train.Staff,
                    train.CreatedDate, train.CreatedByName, train.ModifiedDate, train.ModifiedByName);
                }
                report.SetDataSource(dataset);
                FrmPreviewReport frmReport = new FrmPreviewReport(report);
                frmReport.MdiParent = this.MdiParent;
                frmReport.Show();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
