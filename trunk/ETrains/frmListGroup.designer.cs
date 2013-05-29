namespace ETrains
{
  partial class frmListGroup
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
        this.grvGroup = new System.Windows.Forms.DataGridView();
        this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.grbUser.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grvGroup)).BeginInit();
        this.SuspendLayout();
        // 
        // grbUser
        // 
        this.grbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.grbUser.Controls.Add(this.grvGroup);
        this.grbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.grbUser.Location = new System.Drawing.Point(12, 12);
        this.grbUser.Name = "grbUser";
        this.grbUser.Size = new System.Drawing.Size(615, 357);
        this.grbUser.TabIndex = 9;
        this.grbUser.TabStop = false;
        this.grbUser.Text = "Danh sách nhóm người dùng";
        // 
        // grvGroup
        // 
        this.grvGroup.AllowUserToAddRows = false;
        this.grvGroup.AllowUserToDeleteRows = false;
        this.grvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.grvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.grvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.GroupID});
        this.grvGroup.Location = new System.Drawing.Point(6, 25);
        this.grvGroup.Name = "grvGroup";
        this.grvGroup.ReadOnly = true;
        this.grvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.grvGroup.Size = new System.Drawing.Size(603, 326);
        this.grvGroup.TabIndex = 1;
        this.grvGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvGroup_CellClick);
        this.grvGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvGroup_CellDoubleClick);
        // 
        // GroupName
        // 
        this.GroupName.DataPropertyName = "GroupName";
        this.GroupName.HeaderText = "Tên nhóm";
        this.GroupName.Name = "GroupName";
        this.GroupName.ReadOnly = true;
        this.GroupName.Width = 500;
        // 
        // GroupID
        // 
        this.GroupID.DataPropertyName = "GroupID";
        this.GroupID.HeaderText = "GroupID";
        this.GroupID.Name = "GroupID";
        this.GroupID.ReadOnly = true;
        this.GroupID.Visible = false;
        // 
        // btnDelete
        // 
        this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnDelete.Image = global::ETrains.Properties.Resources.delete;
        this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnDelete.Location = new System.Drawing.Point(254, 375);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(62, 33);
        this.btnDelete.TabIndex = 11;
        this.btnDelete.Text = "Xóa";
        this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnAdd
        // 
        this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnAdd.Image = global::ETrains.Properties.Resources.add;
        this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnAdd.Location = new System.Drawing.Point(8, 375);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(116, 33);
        this.btnAdd.TabIndex = 9;
        this.btnAdd.Text = "Tạo mới nhóm";
        this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        // 
        // btnUpdate
        // 
        this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnUpdate.Image = global::ETrains.Properties.Resources.edit;
        this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnUpdate.Location = new System.Drawing.Point(130, 375);
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Size = new System.Drawing.Size(118, 33);
        this.btnUpdate.TabIndex = 10;
        this.btnUpdate.Text = "Cập nhật nhóm";
        this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnClose.Image = global::ETrains.Properties.Resources.Exit;
        this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnClose.Location = new System.Drawing.Point(322, 375);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(69, 33);
        this.btnClose.TabIndex = 12;
        this.btnClose.Text = "Đóng";
        this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // dataGridViewTextBoxColumn1
        // 
        this.dataGridViewTextBoxColumn1.DataPropertyName = "GroupName";
        this.dataGridViewTextBoxColumn1.HeaderText = "Tên nhóm";
        this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        this.dataGridViewTextBoxColumn1.ReadOnly = true;
        this.dataGridViewTextBoxColumn1.Width = 500;
        // 
        // dataGridViewTextBoxColumn2
        // 
        this.dataGridViewTextBoxColumn2.DataPropertyName = "GroupID";
        this.dataGridViewTextBoxColumn2.HeaderText = "GroupID";
        this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        this.dataGridViewTextBoxColumn2.ReadOnly = true;
        this.dataGridViewTextBoxColumn2.Visible = false;
        // 
        // frmListGroup
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(639, 423);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.grbUser);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.btnAdd);
        this.Name = "frmListGroup";
        this.Text = "Danh sách nhóm người dùng";
        this.Load += new System.EventHandler(this.frmListGroup_Load);
        this.grbUser.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.grvGroup)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox grbUser;
    private System.Windows.Forms.DataGridView grvGroup;
    private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
    private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

  }
}