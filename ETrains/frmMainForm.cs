using System;
using System.Windows.Forms;
using ETrains.Utilities;
using ETrains.Utilities.Enums;
using ETrains.Train;

namespace ETrains
{
    public partial class frmMainForm : MDIFormBase
    {
        public static UserInfo _userInfo;
        public frmMainForm()
        {
            InitializeComponent();

#if WINDOWS7
            ToolStripManager.Renderer = new TechLink.Windows.Windows7Rerenderer.Windows7Rerenderer();
#else
#if O2007D
            ToolStripManager.Renderer = new TechLink.Windows.Office2007DarkRenderer.Office2007DarkRenderer();
#else
#if O2007L
            ToolStripManager.Renderer = new TechLink.Windows.Office2007LightRenderer.Office2007LightRenderer();
#endif
#endif
#endif
        }

        public frmMainForm(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
#if WINDOWS7
            ToolStripManager.Renderer = new TechLink.Windows.Windows7Rerenderer.Windows7Rerenderer();
#else
#if O2007D
            ToolStripManager.Renderer = new TechLink.Windows.Office2007DarkRenderer.Office2007DarkRenderer();
#else
#if O2007L
            ToolStripManager.Renderer = new TechLink.Windows.Office2007LightRenderer.Office2007LightRenderer();
#endif
#endif
#endif
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao xuat nhap canh" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            InitData();
            this.FormClosed += new FormClosedEventHandler(frmMainForm_FormClosed);
        }

        void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Init data
        /// </summary>
        private void InitData()
        {
            toolstripLabelWelcome.Text = string.Format(ConstantInfo.MESSAGE_WELCOME, _userInfo.Name);

            //show/hide menu by user permission 
            //menuitemUser.Visible = (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_NGUOI_DUNG) ||
            //  _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_NGUOI_DUNG) ||
            //  _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_NGUOI_DUNG));

            //mnGroup.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_NHOM_NGUOI_DUNG) ||
            //        _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_NHOM_NGUOI_DUNG) ||
            //        _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_NHOM_NGUOI_DUNG);
            //        _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_NHOM_NGUOI_DUNG);

            ////khai bao xuat canh
            //tsExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
            ////khai bao nhap canh
            //tsImport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
            ////tim kiem phuong tien
            ////toolStripButtonSearch
            ////danh sach to khai
            //toolStripButtonListdeclarace.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI) ||
            //        _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI) ||
            //        _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_TO_KHAI);

        }

        
        private void menuitemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuitemLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();            
            frmLogin.Show();
            this.Hide();
        }

        private void menuitemUser_Click(object sender, EventArgs e)
        {
          var frmUser = new frmUser(_userInfo);
            frmUser.MdiParent = this;
            frmUser.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmChangePassword = new frmChangePassword(_userInfo);            
            frmChangePassword.Show(this);

        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var filePath = Application.StartupPath + @"\Docs\WebHelp\index.htm";
            //    Help.ShowHelp(this, filePath);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("File not found");
            //    if (GlobalInfo.IsDebug) throw ex;
            //}
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var filePath = Application.StartupPath + @"\Docs\GS1_UserManual.pdf";
            Help.ShowHelp(this, filePath);
        }

        private void mnuConfigSQL2DbEcus_Click(object sender, EventArgs e)
        {
            var frm = new frmConfigSQL2DbEcus();
            frm.ShowDialog(this);
        }


        #region Singleton support methods
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Maximized;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }
        #endregion

        private void tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///var frm = new Train.frmTrainImport(_userInfo, 1);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new Train.frmTrainImport(_userInfo, 0);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void khaiBáoToaTàuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new Train.frmPartTrainExport(_userInfo);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void tàuKháchXNKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmTrainPassengers(null,_userInfo,null,0);
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new Train.frmSearchTrain();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void quảnLýTàuKháchXNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmSearchTrainPassenger(_userInfo);
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsExport_Click(object sender, EventArgs e)
        {
            //var frm = new Train.frmTrainImport(_userInfo, 0);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void tsImport_Click(object sender, EventArgs e)
        {
            //var frm = new Train.frmTrainImport(_userInfo, 1);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            //var frm = new Train.frmSearchTrain();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void toolStripButtonListdeclarace_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmSearchTrainPassenger(_userInfo);
            frm.MdiParent = this;
            frm.Show();
        }

        private void khaiBáoTàuHàngXuấtCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmThemChuyenTau(_userInfo, 0);
            frm.MdiParent = this;
            frm.Show();
        }

        private void khaiBáoTàuHàngNhậpCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmThemChuyenTau(_userInfo, 1);
            frm.MdiParent = this;
            frm.Show();
        }

        private void cậpNhậtBBBGHồiBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmBBBG(_userInfo, "1");
            frm.MdiParent = this;
            frm.Show();
        }

        private void cậpNhậtBBBGChuyểnĐếnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmBBBG(_userInfo, "0");
            frm.MdiParent = this;
            frm.Show();
        }

        private void đăngKýTờKhaiXuấtCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmToKhai(_userInfo, null, (short)ChuyenTauType.TypeExport,0);
            frm.MdiParent = this;
            frm.Show();
        }

        private void đăngKýTờKhaiNhậpCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmToKhai(_userInfo, null, (short)ChuyenTauType.TypeImport, 0);
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýChuyếnTàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmQLChuyenTau();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýBiênBảnBànGiaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmQLBBBG();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýTờKhaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Train.frmQLToKhai();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuCompany_Click(object sender, EventArgs e)
        {
            FrmListCompany form = new FrmListCompany(_userInfo);
            form.MdiParent = this;
            form.Show();
        }

        private void mnuFeedbackReport_Click(object sender, EventArgs e)
        {
            FrmFeedbackReport form = new FrmFeedbackReport();
            form.MdiParent = this;
            form.Show();
        }

        private void mnuListReplyManagement_Click(object sender, EventArgs e)
        {
            FrmListHandoverReply form = new FrmListHandoverReply(_userInfo);
            form.MdiParent = this;
            form.Show();
        }

        private void mnuAddHandoverReply_Click(object sender, EventArgs e)
        {
            FrmAddListHandoverReply form = new FrmAddListHandoverReply(null,_userInfo,0);
            form.MdiParent = this;
            form.Show();
        }

        private void mnuTauKhachXNC_Click(object sender, EventArgs e)
        {
            FrmReportPassengerTrain form = new FrmReportPassengerTrain();
            form.MdiParent = this;
            form.Show();
        }

        private void mnuTauHangXNK_Click(object sender, EventArgs e)
        {
            FrmReportTrain form = new FrmReportTrain();
            form.MdiParent = this;
            form.Show();
        }

        private void mnuBBBG_Click(object sender, EventArgs e)
        {
            FrmReportHandover form = new FrmReportHandover();
            form.MdiParent = this;
            form.Show();

        }

        private void mnuReportBangKeHoiBao_Click(object sender, EventArgs e)
        {
            FrmReportListHanoverReply form = new FrmReportListHanoverReply();
            form.MdiParent = this;
            form.Show();
        }

    }
}
