using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ETrains
{
    public partial class FrmPreviewReport : Form
    {
        public FrmPreviewReport()
        {
            InitializeComponent();
        }

        public FrmPreviewReport(ReportListHanoverReply report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }

        public FrmPreviewReport(ReportSoTheoDoiBangKeHoiBao report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }

        public FrmPreviewReport(ReportHandoverOut report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }
        public FrmPreviewReport(ReportHandoverComeIn report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }
        public FrmPreviewReport(ReportTrainImportExport report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }

        public FrmPreviewReport(ReportHandOver report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }

        public FrmPreviewReport(ReportListFeedback report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }

        public FrmPreviewReport(ReportPassengerTrain report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }
    }
}
