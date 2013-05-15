namespace ETrains
{
  partial class frmListUserToAddInGroup
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
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.btnReset = new System.Windows.Forms.Button();
        this.btnSearch = new System.Windows.Forms.Button();
        this.grvUser = new System.Windows.Forms.DataGridView();
        this.label1 = new System.Windows.Forms.Label();
        this.txtKeyWord = new System.Windows.Forms.TextBox();
        this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
        this.SuspendLayout();
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.btnSave);
        this.groupBox1.Controls.Add(this.btnClose);
        this.groupBox1.Controls.Add(this.btnReset);
        this.groupBox1.Controls.Add(this.btnSearch);
        this.groupBox1.Controls.Add(this.grvUser);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Controls.Add(this.txtKeyWord);
        this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.groupBox1.Location = new System.Drawing.Point(12, 10);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(858, 503);
        this.groupBox1.TabIndex = 1;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Danh sách người dùng";
        // 
        // btnSave
        // 
        this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSave.Image = global::ETrains.Properties.Resources.save;
        this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnSave.Location = new System.Drawing.Point(6, 464);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(64, 33);
        this.btnSave.TabIndex = 18;
        this.btnSave.Text = "Lưu";
        this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnClose
        // 
        this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnClose.Image = global::ETrains.Properties.Resources.Exit;
        this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnClose.Location = new System.Drawing.Point(166, 464);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(68, 33);
        this.btnClose.TabIndex = 17;
        this.btnClose.Text = "Đóng";
        this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // btnReset
        // 
        this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnReset.Image = global::ETrains.Properties.Resources.undo;
        this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnReset.Location = new System.Drawing.Point(76, 464);
        this.btnReset.Name = "btnReset";
        this.btnReset.Size = new System.Drawing.Size(84, 33);
        this.btnReset.TabIndex = 16;
        this.btnReset.Text = "Làm lại";
        this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnReset.UseVisualStyleBackColor = true;
        this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
        // 
        // btnSearch
        // 
        this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSearch.Image = global::ETrains.Properties.Resources.search;
        this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnSearch.Location = new System.Drawing.Point(493, 23);
        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Size = new System.Drawing.Size(90, 33);
        this.btnSearch.TabIndex = 15;
        this.btnSearch.Text = "Tìm kiếm";
        this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnSearch.UseVisualStyleBackColor = true;
        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
        // 
        // grvUser
        // 
        this.grvUser.AllowUserToAddRows = false;
        this.grvUser.AllowUserToDeleteRows = false;
        this.grvUser.AllowUserToOrderColumns = true;
        this.grvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.grvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelected,
            this.UserID,
            this.UserName,
            this.FirstName,
            this.Email,
            this.Address,
            this.PhoneNumber});
        this.grvUser.Location = new System.Drawing.Point(11, 86);
        this.grvUser.MultiSelect = false;
        this.grvUser.Name = "grvUser";
        this.grvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.grvUser.Size = new System.Drawing.Size(836, 365);
        this.grvUser.TabIndex = 7;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(7, 30);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(140, 15);
        this.label1.TabIndex = 6;
        this.label1.Text = "Tìm theo tên người dùng";
        // 
        // txtKeyWord
        // 
        this.txtKeyWord.Location = new System.Drawing.Point(153, 27);
        this.txtKeyWord.Name = "txtKeyWord";
        this.txtKeyWord.Size = new System.Drawing.Size(308, 21);
        this.txtKeyWord.TabIndex = 4;
        // 
        // dataGridViewCheckBoxColumn1
        // 
        this.dataGridViewCheckBoxColumn1.HeaderText = "Chọn";
        this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
        this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
        this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        this.dataGridViewCheckBoxColumn1.Width = 50;
        // 
        // dataGridViewTextBoxColumn1
        // 
        this.dataGridViewTextBoxColumn1.DataPropertyName = "UserID";
        this.dataGridViewTextBoxColumn1.HeaderText = "UserID";
        this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        // 
        // dataGridViewTextBoxColumn2
        // 
        this.dataGridViewTextBoxColumn2.DataPropertyName = "UserName";
        this.dataGridViewTextBoxColumn2.HeaderText = "Tên truy cập";
        this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        this.dataGridViewTextBoxColumn2.ReadOnly = true;
        this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.dataGridViewTextBoxColumn2.Width = 150;
        // 
        // dataGridViewTextBoxColumn3
        // 
        this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
        this.dataGridViewTextBoxColumn3.HeaderText = "Họ và tên";
        this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        this.dataGridViewTextBoxColumn3.ReadOnly = true;
        this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.dataGridViewTextBoxColumn3.Width = 150;
        // 
        // dataGridViewTextBoxColumn4
        // 
        this.dataGridViewTextBoxColumn4.DataPropertyName = "Email";
        this.dataGridViewTextBoxColumn4.HeaderText = "Email";
        this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        this.dataGridViewTextBoxColumn4.ReadOnly = true;
        this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        // 
        // dataGridViewTextBoxColumn5
        // 
        this.dataGridViewTextBoxColumn5.DataPropertyName = "Address";
        this.dataGridViewTextBoxColumn5.HeaderText = "Địa chỉ";
        this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        this.dataGridViewTextBoxColumn5.ReadOnly = true;
        this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.dataGridViewTextBoxColumn5.Width = 150;
        // 
        // dataGridViewTextBoxColumn6
        // 
        this.dataGridViewTextBoxColumn6.DataPropertyName = "PhoneNumber";
        this.dataGridViewTextBoxColumn6.HeaderText = "Điện thoại";
        this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        this.dataGridViewTextBoxColumn6.ReadOnly = true;
        this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.dataGridViewTextBoxColumn6.Width = 150;
        // 
        // IsSelected
        // 
        this.IsSelected.HeaderText = "Chọn";
        this.IsSelected.Name = "IsSelected";
        this.IsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
        this.IsSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        this.IsSelected.Width = 50;
        // 
        // UserID
        // 
        this.UserID.DataPropertyName = "UserID";
        this.UserID.HeaderText = "UserID";
        this.UserID.Name = "UserID";
        this.UserID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        // 
        // UserName
        // 
        this.UserName.DataPropertyName = "UserName";
        this.UserName.HeaderText = "Tên truy cập";
        this.UserName.Name = "UserName";
        this.UserName.ReadOnly = true;
        this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.UserName.Width = 150;
        // 
        // FirstName
        // 
        this.FirstName.DataPropertyName = "Name";
        this.FirstName.HeaderText = "Họ và tên";
        this.FirstName.Name = "FirstName";
        this.FirstName.ReadOnly = true;
        this.FirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.FirstName.Width = 150;
        // 
        // Email
        // 
        this.Email.DataPropertyName = "Email";
        this.Email.HeaderText = "Email";
        this.Email.Name = "Email";
        this.Email.ReadOnly = true;
        this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        // 
        // Address
        // 
        this.Address.DataPropertyName = "Address";
        this.Address.HeaderText = "Địa chỉ";
        this.Address.Name = "Address";
        this.Address.ReadOnly = true;
        this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.Address.Width = 150;
        // 
        // PhoneNumber
        // 
        this.PhoneNumber.DataPropertyName = "PhoneNumber";
        this.PhoneNumber.HeaderText = "Điện thoại";
        this.PhoneNumber.Name = "PhoneNumber";
        this.PhoneNumber.ReadOnly = true;
        this.PhoneNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.PhoneNumber.Width = 150;
        // 
        // frmListUserToAddInGroup
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(876, 523);
        this.Controls.Add(this.groupBox1);
        this.Name = "frmListUserToAddInGroup";
        this.Text = "Thêm người dùng vào nhóm";
        this.Load += new System.EventHandler(this.frmListUserToAddInGroup_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.DataGridView grvUser;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
    private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
    private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
    private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtKeyWord;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
  }
}