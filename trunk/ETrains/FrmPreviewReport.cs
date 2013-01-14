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

        public FrmPreviewReport(ReportHandOver report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
        }
    }
}
