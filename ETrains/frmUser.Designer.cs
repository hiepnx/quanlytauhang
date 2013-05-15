﻿namespace ETrains
{
  partial class frmUser
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
        this.grbUser = new System.Windows.Forms.GroupBox();
        this.grvUser = new System.Windows.Forms.DataGridView();
        this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.btnClose = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.grbUser.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
        this.SuspendLayout();
        // 
        // grbUser
        // 
        this.grbUser.Controls.Add(this.grvUser);
        this.grbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.grbUser.Location = new System.Drawing.Point(12, 12);
        this.grbUser.Name = "grbUser";
        this.grbUser.Size = new System.Drawing.Size(911, 457);
        this.grbUser.TabIndex = 7;
        this.grbUser.TabStop = false;
        this.grbUser.Text = "Danh sách người dùng";
        // 
        // grvUser
        // 
        this.grvUser.AllowUserToAddRows = false;
        this.grvUser.AllowUserToDeleteRows = false;
        this.grvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.grvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.FirstName,
            this.Email,
            this.Address,
            this.PhoneNumber,
            this.IsActive,
            this.UserID});
        this.grvUser.Location = new System.Drawing.Point(9, 25);
        this.grvUser.Name = "grvUser";
        this.grvUser.ReadOnly = true;
        this.grvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.grvUser.Size = new System.Drawing.Size(894, 417);
        this.grvUser.TabIndex = 0;
        this.grvUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvUser_CellDoubleClick);
        // 
        // UserName
        // 
        this.UserName.DataPropertyName = "UserName";
        this.UserName.HeaderText = "Tên truy cập";
        this.UserName.Name = "UserName";
        this.UserName.ReadOnly = true;
        this.UserName.Width = 150;
        // 
        // FirstName
        // 
        this.FirstName.DataPropertyName = "Name";
        this.FirstName.HeaderText = "Họ và tên";
        this.FirstName.Name = "FirstName";
        this.FirstName.ReadOnly = true;
        this.FirstName.Width = 150;
        // 
        // Email
        // 
        this.Email.DataPropertyName = "Email";
        this.Email.HeaderText = "Email";
        this.Email.Name = "Email";
        this.Email.ReadOnly = true;
        // 
        // Address
        // 
        this.Address.DataPropertyName = "Address";
        this.Address.HeaderText = "Địa chỉ";
        this.Address.Name = "Address";
        this.Address.ReadOnly = true;
        this.Address.Width = 150;
        // 
        // PhoneNumber
        // 
        this.PhoneNumber.DataPropertyName = "PhoneNumber";
        this.PhoneNumber.HeaderText = "Điện thoại";
        this.PhoneNumber.Name = "PhoneNumber";
        this.PhoneNumber.ReadOnly = true;
        this.PhoneNumber.Width = 150;
        // 
        // IsActive
        // 
        this.IsActive.DataPropertyName = "IsActive";
        this.IsActive.HeaderText = "Trạng thái";
        this.IsActive.Name = "IsActive";
        this.IsActive.ReadOnly = true;
        this.IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        this.IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        this.IsActive.Width = 150;
        // 
        // UserID
        // 
        this.UserID.DataPropertyName = "UserID";
        this.UserID.HeaderText = "UserID";
        this.UserID.Name = "UserID";
        this.UserID.ReadOnly = true;
        this.UserID.Visible = false;
        // 
        // btnClose
        // 
        this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnClose.Image = global::ETrains.Properties.Resources.Exit;
        this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnClose.Location = new System.Drawing.Point(266, 475);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(63, 33);
        this.btnClose.TabIndex = 20;
        this.btnClose.Text = "Đóng";
        this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnDelete.Image = global::ETrains.Properties.Resources.delete;
        this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnDelete.Location = new System.Drawing.Point(197, 475);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(63, 33);
        this.btnDelete.TabIndex = 19;
        this.btnDelete.Text = "Xóa";
        this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
        // 
        // btnAdd
        // 
        this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnAdd.Image = global::ETrains.Properties.Resources.add;
        this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnAdd.Location = new System.Drawing.Point(12, 475);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(81, 33);
        this.btnAdd.TabIndex = 17;
        this.btnAdd.Text = "Tạo mới";
        this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        // 
        // btnUpdate
        // 
        this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnUpdate.Image = global::ETrains.Properties.Resources.edit;
        this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnUpdate.Location = new System.Drawing.Point(99, 475);
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Size = new System.Drawing.Size(89, 33);
        this.btnUpdate.TabIndex = 18;
        this.btnUpdate.Text = "Cập nhật";
        this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
        // 
        // frmUser
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(931, 518);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.grbUser);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnUpdate);
        this.Name = "frmUser";
        this.Text = "Danh sách người dùng";
        this.Load += new System.EventHandler(this.frmUser_Load);
        this.grbUser.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox grbUser;
    private System.Windows.Forms.DataGridView grvUser;
    private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
    private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsActive;
    private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
  }
}