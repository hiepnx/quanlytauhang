namespace ETrains
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfigSQL2DbEcus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTauHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khaiBáoToaTàuXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàuKháchXNKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàuKháchXNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstripLabelWelcome = new System.Windows.Forms.ToolStripLabel();
            this.tsExport = new System.Windows.Forms.ToolStripButton();
            this.tsImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonListdeclarace = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.khaiBáoTàuHàngXuấtCảnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khaiBáoTàuHàngNhậpCảnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnMain
            // 
            this.mnMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.mnuTauHang,
            this.trợGiúpToolStripMenuItem});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(1140, 24);
            this.mnMain.TabIndex = 0;
            this.mnMain.Tag = "";
            this.mnMain.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemUser,
            this.mnGroup,
            this.mnuSettings,
            this.mnuConfigSQL2DbEcus,
            this.toolStripMenuItem1,
            this.menuitemLogout,
            this.toolStripSeparator1,
            this.menuitemExit,
            this.aboutUsToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.hệThốngToolStripMenuItem.Text = "&Hệ thống";
            // 
            // menuitemUser
            // 
            this.menuitemUser.Image = global::ETrains.Properties.Resources.user1;
            this.menuitemUser.Name = "menuitemUser";
            this.menuitemUser.Size = new System.Drawing.Size(239, 22);
            this.menuitemUser.Text = "Quản lý người dùng";
            this.menuitemUser.Click += new System.EventHandler(this.menuitemUser_Click);
            // 
            // mnGroup
            // 
            this.mnGroup.Image = global::ETrains.Properties.Resources.goup;
            this.mnGroup.Name = "mnGroup";
            this.mnGroup.Size = new System.Drawing.Size(239, 22);
            this.mnGroup.Text = "Quản lý nhóm";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Image = global::ETrains.Properties.Resources.column_preferences;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(239, 22);
            this.mnuSettings.Text = "Cấu hình hệ thống";
            // 
            // mnuConfigSQL2DbEcus
            // 
            this.mnuConfigSQL2DbEcus.Image = global::ETrains.Properties.Resources.gear;
            this.mnuConfigSQL2DbEcus.Name = "mnuConfigSQL2DbEcus";
            this.mnuConfigSQL2DbEcus.Size = new System.Drawing.Size(239, 22);
            this.mnuConfigSQL2DbEcus.Text = "Cấu hình kết nối CSDL Hải quan";
            this.mnuConfigSQL2DbEcus.Click += new System.EventHandler(this.mnuConfigSQL2DbEcus_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::ETrains.Properties.Resources.key1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem1.Text = "Thay đổi mật khẩu";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuitemLogout
            // 
            this.menuitemLogout.Image = global::ETrains.Properties.Resources.signout;
            this.menuitemLogout.Name = "menuitemLogout";
            this.menuitemLogout.Size = new System.Drawing.Size(239, 22);
            this.menuitemLogout.Text = "Đăng xuất";
            this.menuitemLogout.Click += new System.EventHandler(this.menuitemLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // menuitemExit
            // 
            this.menuitemExit.Image = global::ETrains.Properties.Resources.Exit;
            this.menuitemExit.Name = "menuitemExit";
            this.menuitemExit.Size = new System.Drawing.Size(239, 22);
            this.menuitemExit.Text = "Thoát Khỏi chương trình";
            this.menuitemExit.Click += new System.EventHandler(this.menuitemExit_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Image = global::ETrains.Properties.Resources.about;
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            this.aboutUsToolStripMenuItem.Visible = false;
            // 
            // mnuTauHang
            // 
            this.mnuTauHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem,
            this.tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem,
            this.khaiBáoToaTàuXuấtToolStripMenuItem,
            this.tàuKháchXNKToolStripMenuItem,
            this.quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem,
            this.quảnLýTàuKháchXNCToolStripMenuItem,
            this.khaiBáoTàuHàngXuấtCảnhToolStripMenuItem,
            this.khaiBáoTàuHàngNhậpCảnhToolStripMenuItem});
            this.mnuTauHang.Name = "mnuTauHang";
            this.mnuTauHang.Size = new System.Drawing.Size(109, 20);
            this.mnuTauHang.Text = "Quản lý tàu hàng";
            // 
            // tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem
            // 
            this.tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem.Name = "tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem";
            this.tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem.Text = "Tàu hàng Trung Quốc nhập cảnh";
            this.tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem.Click += new System.EventHandler(this.tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem_Click);
            // 
            // tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem
            // 
            this.tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem.Name = "tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem";
            this.tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem.Text = "Tàu hàng Trung Quốc xuất cảnh";
            this.tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem.Click += new System.EventHandler(this.tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem_Click);
            // 
            // khaiBáoToaTàuXuấtToolStripMenuItem
            // 
            this.khaiBáoToaTàuXuấtToolStripMenuItem.Name = "khaiBáoToaTàuXuấtToolStripMenuItem";
            this.khaiBáoToaTàuXuấtToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.khaiBáoToaTàuXuấtToolStripMenuItem.Text = "Khai báo toa tàu xuất";
            this.khaiBáoToaTàuXuấtToolStripMenuItem.Click += new System.EventHandler(this.khaiBáoToaTàuXuấtToolStripMenuItem_Click);
            // 
            // tàuKháchXNKToolStripMenuItem
            // 
            this.tàuKháchXNKToolStripMenuItem.Name = "tàuKháchXNKToolStripMenuItem";
            this.tàuKháchXNKToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.tàuKháchXNKToolStripMenuItem.Text = "Tàu khách XNC";
            this.tàuKháchXNKToolStripMenuItem.Click += new System.EventHandler(this.tàuKháchXNKToolStripMenuItem_Click);
            // 
            // quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem
            // 
            this.quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem.Name = "quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem";
            this.quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem.Text = "Quản lý tàu hàng Trung Quốc XNC";
            this.quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem.Click += new System.EventHandler(this.quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem_Click);
            // 
            // quảnLýTàuKháchXNCToolStripMenuItem
            // 
            this.quảnLýTàuKháchXNCToolStripMenuItem.Name = "quảnLýTàuKháchXNCToolStripMenuItem";
            this.quảnLýTàuKháchXNCToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.quảnLýTàuKháchXNCToolStripMenuItem.Text = "Quản lý tàu khách XNC";
            this.quảnLýTàuKháchXNCToolStripMenuItem.Click += new System.EventHandler(this.quảnLýTàuKháchXNCToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnSửDụngToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.trợGiúpToolStripMenuItem.Text = "Trợ &giúp";
            // 
            // hướngDẫnSửDụngToolStripMenuItem
            // 
            this.hướngDẫnSửDụngToolStripMenuItem.Image = global::ETrains.Properties.Resources.help;
            this.hướngDẫnSửDụngToolStripMenuItem.Name = "hướngDẫnSửDụngToolStripMenuItem";
            this.hướngDẫnSửDụngToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.hướngDẫnSửDụngToolStripMenuItem.Text = "Hướng dẫn sử dụng";
            this.hướngDẫnSửDụngToolStripMenuItem.Click += new System.EventHandler(this.hướngDẫnSửDụngToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripLabelWelcome,
            this.tsExport,
            this.tsImport,
            this.toolStripButtonSearch,
            this.toolStripButtonListdeclarace,
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1140, 44);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstripLabelWelcome
            // 
            this.toolstripLabelWelcome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolstripLabelWelcome.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolstripLabelWelcome.ForeColor = System.Drawing.Color.Red;
            this.toolstripLabelWelcome.Name = "toolstripLabelWelcome";
            this.toolstripLabelWelcome.Size = new System.Drawing.Size(93, 41);
            this.toolstripLabelWelcome.Text = "toolStripLabel1";
            // 
            // tsExport
            // 
            this.tsExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExport.Image = ((System.Drawing.Image)(resources.GetObject("tsExport.Image")));
            this.tsExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExport.Name = "tsExport";
            this.tsExport.Size = new System.Drawing.Size(36, 41);
            this.tsExport.Text = "toolStripButton1";
            this.tsExport.ToolTipText = "Khai báo tàu hàng xuất cảnh";
            this.tsExport.Click += new System.EventHandler(this.tsExport_Click);
            // 
            // tsImport
            // 
            this.tsImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsImport.Image = global::ETrains.Properties.Resources.importBig;
            this.tsImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImport.Name = "tsImport";
            this.tsImport.Size = new System.Drawing.Size(36, 41);
            this.tsImport.Text = "toolStripButton1";
            this.tsImport.ToolTipText = "Khai báo tàu hàng nhập cảnh";
            this.tsImport.Click += new System.EventHandler(this.tsImport_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = global::ETrains.Properties.Resources.viewBig;
            this.toolStripButtonSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(36, 41);
            this.toolStripButtonSearch.Text = "toolStripButton2";
            this.toolStripButtonSearch.ToolTipText = "Tìm kiếm tàu";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonListdeclarace
            // 
            this.toolStripButtonListdeclarace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonListdeclarace.Image = global::ETrains.Properties.Resources.DeclaBig;
            this.toolStripButtonListdeclarace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonListdeclarace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonListdeclarace.Name = "toolStripButtonListdeclarace";
            this.toolStripButtonListdeclarace.Size = new System.Drawing.Size(36, 41);
            this.toolStripButtonListdeclarace.Text = "toolStripButton3";
            this.toolStripButtonListdeclarace.ToolTipText = "Quản lý tàu khách";
            this.toolStripButtonListdeclarace.Click += new System.EventHandler(this.toolStripButtonListdeclarace_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::ETrains.Properties.Resources.HelpBig;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 41);
            this.toolStripButton2.Text = "Trợ giúp";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 41);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // khaiBáoTàuHàngXuấtCảnhToolStripMenuItem
            // 
            this.khaiBáoTàuHàngXuấtCảnhToolStripMenuItem.Name = "khaiBáoTàuHàngXuấtCảnhToolStripMenuItem";
            this.khaiBáoTàuHàngXuấtCảnhToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.khaiBáoTàuHàngXuấtCảnhToolStripMenuItem.Text = "Khai báo tàu hàng xuất cảnh";
            this.khaiBáoTàuHàngXuấtCảnhToolStripMenuItem.Click += new System.EventHandler(this.khaiBáoTàuHàngXuấtCảnhToolStripMenuItem_Click);
            // 
            // khaiBáoTàuHàngNhậpCảnhToolStripMenuItem
            // 
            this.khaiBáoTàuHàngNhậpCảnhToolStripMenuItem.Name = "khaiBáoTàuHàngNhậpCảnhToolStripMenuItem";
            this.khaiBáoTàuHàngNhậpCảnhToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.khaiBáoTàuHàngNhậpCảnhToolStripMenuItem.Text = "Khai báo tàu hàng nhập cảnh";
            this.khaiBáoTàuHàngNhậpCảnhToolStripMenuItem.Click += new System.EventHandler(this.khaiBáoTàuHàngNhậpCảnhToolStripMenuItem_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ETrains.Properties.Resources.logoBackgound;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1140, 668);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mnMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnMain;
            this.Name = "frmMainForm";
            this.Text = "Quản lý phương tiện xuất nhập biên";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.Controls.SetChildIndex(this.mnMain, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolstripLabelWelcome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuitemExit;
        private System.Windows.Forms.ToolStripMenuItem menuitemLogout;
        private System.Windows.Forms.ToolStripMenuItem menuitemUser;
        private System.Windows.Forms.ToolStripButton tsExport;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonListdeclarace;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsImport;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnGroup;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuConfigSQL2DbEcus;
        private System.Windows.Forms.ToolStripMenuItem mnuTauHang;
        private System.Windows.Forms.ToolStripMenuItem tàuHàngTrungQuốcNhậpCảnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàuHàngTrungQuốcXuấtCảnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khaiBáoToaTàuXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàuKháchXNKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýTàuHàngTrungQuốcXNCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýTàuKháchXNCToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem khaiBáoTàuHàngXuấtCảnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khaiBáoTàuHàngNhậpCảnhToolStripMenuItem;
    }
}