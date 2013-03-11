﻿namespace ETrains.Train
{
    partial class frmDanhSachToaTau
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grdToaTau = new System.Windows.Forms.DataGridView();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToaTauID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_ToaTau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_VanTai_Don = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_VanTai_Don = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_DoiTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_DoanhNghiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_DoanhNghiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_Hang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trong_Luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Don_Vi_Tinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seal_VanTai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seal_HaiQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ghi_Chu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.techlinkErrorProvider1 = new ETrains.Utilities.TechlinkErrorProvider();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbToaTau = new System.Windows.Forms.GroupBox();
            this.gbChuyenTau = new System.Windows.Forms.GroupBox();
            this.dtpDateXNC = new System.Windows.Forms.DateTimePicker();
            this.txtNumberTrain = new System.Windows.Forms.TextBox();
            this.lblDateXNK = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdToaTau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).BeginInit();
            this.gbToaTau.SuspendLayout();
            this.gbChuyenTau.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(851, 24);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Tìm kiếm toa tàu theo số hiệu đoàn tàu";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdToaTau
            // 
            this.grdToaTau.AllowUserToAddRows = false;
            this.grdToaTau.AllowUserToDeleteRows = false;
            this.grdToaTau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdToaTau.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdToaTau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdToaTau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Count,
            this.ToaTauID,
            this.Ma_ToaTau,
            this.So_VanTai_Don,
            this.Ngay_VanTai_Don,
            this.Ten_DoiTac,
            this.Ten_DoanhNghiep,
            this.Ma_DoanhNghiep,
            this.Ten_Hang,
            this.Trong_Luong,
            this.Don_Vi_Tinh,
            this.Seal_VanTai,
            this.Seal_HaiQuan,
            this.Ghi_Chu});
            this.grdToaTau.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdToaTau.Location = new System.Drawing.Point(6, 19);
            this.grdToaTau.Name = "grdToaTau";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdToaTau.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdToaTau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdToaTau.Size = new System.Drawing.Size(845, 369);
            this.grdToaTau.TabIndex = 2;
            this.grdToaTau.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdToaTau_CellFormatting);
            // 
            // Count
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Count.DefaultCellStyle = dataGridViewCellStyle2;
            this.Count.HeaderText = "STT";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 50;
            // 
            // ToaTauID
            // 
            this.ToaTauID.DataPropertyName = "ToaTauID";
            this.ToaTauID.HeaderText = "ToaTauID";
            this.ToaTauID.Name = "ToaTauID";
            this.ToaTauID.Visible = false;
            // 
            // Ma_ToaTau
            // 
            this.Ma_ToaTau.DataPropertyName = "Ma_ToaTau";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ma_ToaTau.DefaultCellStyle = dataGridViewCellStyle3;
            this.Ma_ToaTau.HeaderText = "SH Toa tàu";
            this.Ma_ToaTau.Name = "Ma_ToaTau";
            // 
            // So_VanTai_Don
            // 
            this.So_VanTai_Don.DataPropertyName = "So_VanTai_Don";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.So_VanTai_Don.DefaultCellStyle = dataGridViewCellStyle4;
            this.So_VanTai_Don.HeaderText = "Số Vận đơn";
            this.So_VanTai_Don.Name = "So_VanTai_Don";
            // 
            // Ngay_VanTai_Don
            // 
            this.Ngay_VanTai_Don.DataPropertyName = "Ngay_VanTai_Don";
            this.Ngay_VanTai_Don.HeaderText = "Ngày vận đơn";
            this.Ngay_VanTai_Don.Name = "Ngay_VanTai_Don";
            // 
            // Ten_DoiTac
            // 
            this.Ten_DoiTac.DataPropertyName = "Ten_DoiTac";
            this.Ten_DoiTac.HeaderText = "Tên người gửi";
            this.Ten_DoiTac.Name = "Ten_DoiTac";
            // 
            // Ten_DoanhNghiep
            // 
            this.Ten_DoanhNghiep.DataPropertyName = "Ten_DoanhNghiep";
            this.Ten_DoanhNghiep.HeaderText = "Tên người nhận";
            this.Ten_DoanhNghiep.Name = "Ten_DoanhNghiep";
            this.Ten_DoanhNghiep.Width = 120;
            // 
            // Ma_DoanhNghiep
            // 
            this.Ma_DoanhNghiep.DataPropertyName = "Ma_DoanhNghiep";
            this.Ma_DoanhNghiep.HeaderText = "Ma_DoanhNghiep";
            this.Ma_DoanhNghiep.Name = "Ma_DoanhNghiep";
            this.Ma_DoanhNghiep.Visible = false;
            // 
            // Ten_Hang
            // 
            this.Ten_Hang.DataPropertyName = "Ten_Hang";
            this.Ten_Hang.HeaderText = "Tên hàng";
            this.Ten_Hang.Name = "Ten_Hang";
            this.Ten_Hang.Width = 200;
            // 
            // Trong_Luong
            // 
            this.Trong_Luong.DataPropertyName = "Trong_Luong";
            this.Trong_Luong.HeaderText = "Trọng lượng";
            this.Trong_Luong.Name = "Trong_Luong";
            // 
            // Don_Vi_Tinh
            // 
            this.Don_Vi_Tinh.DataPropertyName = "Don_Vi_Tinh";
            this.Don_Vi_Tinh.HeaderText = "Đơn vị tính";
            this.Don_Vi_Tinh.Name = "Don_Vi_Tinh";
            // 
            // Seal_VanTai
            // 
            this.Seal_VanTai.DataPropertyName = "Seal_VanTai";
            this.Seal_VanTai.HeaderText = "Số Seal hãng vận tải";
            this.Seal_VanTai.Name = "Seal_VanTai";
            this.Seal_VanTai.Width = 130;
            // 
            // Seal_HaiQuan
            // 
            this.Seal_HaiQuan.DataPropertyName = "Seal_HaiQuan";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.Seal_HaiQuan.DefaultCellStyle = dataGridViewCellStyle5;
            this.Seal_HaiQuan.HeaderText = "Số Seal Hải quan";
            this.Seal_HaiQuan.Name = "Seal_HaiQuan";
            this.Seal_HaiQuan.Width = 130;
            // 
            // Ghi_Chu
            // 
            this.Ghi_Chu.DataPropertyName = "Ghi_Chu";
            this.Ghi_Chu.HeaderText = "Ghi chú";
            this.Ghi_Chu.Name = "Ghi_Chu";
            this.Ghi_Chu.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::ETrains.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(105, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Th&oát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdate.Image = global::ETrains.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(18, 508);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(81, 28);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "&Cập nhật";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // techlinkErrorProvider1
            // 
            this.techlinkErrorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ToaTauID";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "SH Toa tàu";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ma_ToaTau";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Số Vận đơn";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Note";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "Số Seal hãng vận tải";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Ngay_VanTai_Don";
            dataGridViewCellStyle10.Format = "dd/MM/yyyy";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn5.HeaderText = "Số Seal Hải quan";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 130;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Ten_DoiTac";
            this.dataGridViewTextBoxColumn6.HeaderText = "Số Seal hãng vận tải";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Ma_DoanhNghiep";
            dataGridViewCellStyle11.Format = "dd/MM/yyyy";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn7.HeaderText = "Số Seal Hải quan";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 130;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn8.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Trong_Luong";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn9.HeaderText = "Số Vận đơn";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Seal_VanTai";
            this.dataGridViewTextBoxColumn10.HeaderText = "Tên hàng";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 200;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Seal_HaiQuan";
            dataGridViewCellStyle13.Format = "dd/MM/yyyy";
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn11.HeaderText = "Trọng lượng";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 130;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Ghi_Chu";
            this.dataGridViewTextBoxColumn12.HeaderText = "Số Seal hãng vận tải";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 130;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle14.Format = "dd/MM/yyyy";
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn13.HeaderText = "Số Seal Hải quan";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 130;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn14.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 150;
            // 
            // gbToaTau
            // 
            this.gbToaTau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbToaTau.Controls.Add(this.grdToaTau);
            this.gbToaTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gbToaTau.Location = new System.Drawing.Point(12, 102);
            this.gbToaTau.Name = "gbToaTau";
            this.gbToaTau.Size = new System.Drawing.Size(851, 394);
            this.gbToaTau.TabIndex = 1;
            this.gbToaTau.TabStop = false;
            this.gbToaTau.Text = "Thông tin đoàn tàu và toa tàu";
            // 
            // gbChuyenTau
            // 
            this.gbChuyenTau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChuyenTau.Controls.Add(this.dtpDateXNC);
            this.gbChuyenTau.Controls.Add(this.txtNumberTrain);
            this.gbChuyenTau.Controls.Add(this.lblDateXNK);
            this.gbChuyenTau.Controls.Add(this.lblNumber);
            this.gbChuyenTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gbChuyenTau.Location = new System.Drawing.Point(12, 36);
            this.gbChuyenTau.Name = "gbChuyenTau";
            this.gbChuyenTau.Size = new System.Drawing.Size(851, 60);
            this.gbChuyenTau.TabIndex = 7;
            this.gbChuyenTau.TabStop = false;
            this.gbChuyenTau.Text = "Thông tin đoàn tàu";
            // 
            // dtpDateXNC
            // 
            this.dtpDateXNC.CustomFormat = "dd/MM/yyyy      hh:mm";
            this.dtpDateXNC.Enabled = false;
            this.dtpDateXNC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateXNC.Location = new System.Drawing.Point(457, 26);
            this.dtpDateXNC.Name = "dtpDateXNC";
            this.dtpDateXNC.Size = new System.Drawing.Size(145, 20);
            this.dtpDateXNC.TabIndex = 1;
            // 
            // txtNumberTrain
            // 
            this.txtNumberTrain.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberTrain.Location = new System.Drawing.Point(154, 26);
            this.txtNumberTrain.Name = "txtNumberTrain";
            this.txtNumberTrain.ReadOnly = true;
            this.txtNumberTrain.Size = new System.Drawing.Size(142, 20);
            this.txtNumberTrain.TabIndex = 0;
            this.txtNumberTrain.Tag = "required";
            // 
            // lblDateXNK
            // 
            this.lblDateXNK.AutoSize = true;
            this.lblDateXNK.Location = new System.Drawing.Point(348, 29);
            this.lblDateXNK.Name = "lblDateXNK";
            this.lblDateXNK.Size = new System.Drawing.Size(103, 13);
            this.lblDateXNK.TabIndex = 10;
            this.lblDateXNK.Text = "Ngày giờ nhập cảnh";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(6, 29);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(89, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Số hiệu đoàn tàu";
            // 
            // frmDanhSachToaTau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 548);
            this.Controls.Add(this.gbChuyenTau);
            this.Controls.Add(this.gbToaTau);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmDanhSachToaTau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDanhSachToaTau";
            this.Load += new System.EventHandler(this.frmDanhSachToaTau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdToaTau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).EndInit();
            this.gbToaTau.ResumeLayout(false);
            this.gbChuyenTau.ResumeLayout(false);
            this.gbChuyenTau.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private Utilities.TechlinkErrorProvider techlinkErrorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.GroupBox gbToaTau;
        private System.Windows.Forms.GroupBox gbChuyenTau;
        private System.Windows.Forms.DateTimePicker dtpDateXNC;
        private System.Windows.Forms.TextBox txtNumberTrain;
        public System.Windows.Forms.Label lblDateXNK;
        public System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToaTauID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_ToaTau;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_VanTai_Don;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_VanTai_Don;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_DoiTac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_DoanhNghiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_DoanhNghiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_Hang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trong_Luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Don_Vi_Tinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seal_VanTai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seal_HaiQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ghi_Chu;
        private System.Windows.Forms.DataGridView grdToaTau;
    }
}