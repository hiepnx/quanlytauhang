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

namespace ETrains.Train
{
    public partial class frmTrainPassengers : Form
    {
        private UserInfo _userInfo;
        private short _mode; //0: addnew, 1: edit
        private tblTrain _tblTrain;
        private frmSearchTrainPassenger _frmSearch;

        public frmTrainPassengers()
        {
            InitializeComponent();
        }
        public frmTrainPassengers(frmSearchTrainPassenger frmSearch, UserInfo userInfo, tblTrain tblTrain, short mode = 0)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _tblTrain = tblTrain;
            _frmSearch = frmSearch;
            _mode = mode;
        }

        private void frmTrainPassengers_Load(object sender, EventArgs e)
        {
            if (_mode == 0)
            {
                this.Text = "Khai bao tau khach XNK" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            }
            else
            {
                this.Text = "Cap nhat tau khach XNK" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            }
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>
                               {
                                   new ComboBoxItem((short)ChuyenTauType.TypeExport, "Xuất cảnh"),
                                   new ComboBoxItem((short)ChuyenTauType.TypeImport, "Nhập cảnh")
                               };
            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 0;

            //mode add new
            if (_mode == 0)
            {
                btnUpdate.Enabled = false;
            }
            //mode update
            if (_mode == 1)
            {
                btnAddNew.Enabled = false;
                txtNumberTrain.Text = _tblTrain.Number;
                txtJourney.Text = _tblTrain.Jounery;
                txtNumberPersonForegin.Text = _tblTrain.PassengerForegin.GetValueOrDefault().ToString();
                txtNumberPersonVN.Text = _tblTrain.PassengerVN.GetValueOrDefault().ToString();
                txtNumberStaff.Text = _tblTrain.Staff.GetValueOrDefault().ToString();
                dtpRegisterDate.Value = _tblTrain.DateImportExport.GetValueOrDefault();
                ddlTypeName.SelectedValue = _tblTrain.Type;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validate()
        {
            return techlinkErrorProvider1.Validate(this);
        }

        private void Reset()
        {
            txtNumberTrain.Text = txtJourney.Text = txtNumberPersonVN.Text = txtNumberPersonForegin.Text = txtNumberStaff.Text = string.Empty;
            ddlTypeName.SelectedIndex = 0;
            dtpRegisterDate.Value = DateTime.Now;
            txtNumberTrain.Focus();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(ConstantInfo.CONFIRM_ADD_NEW, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (!Validate()) return;
                var trainPassenger = new tblTrain();
                trainPassenger.Number = txtNumberTrain.Text.Trim();
                trainPassenger.Type = (short) ((ComboBoxItem) ddlTypeName.SelectedItem).Value;
                trainPassenger.DateImportExport = dtpRegisterDate.Value;
                trainPassenger.Jounery = txtJourney.Text.Trim();
                trainPassenger.PassengerVN = int.Parse(txtNumberPersonVN.Text);
                trainPassenger.PassengerForegin = int.Parse(txtNumberPersonForegin.Text);
                trainPassenger.Staff = int.Parse(txtNumberStaff.Text);
                trainPassenger.CreatedBy = _userInfo.UserID;
                if (TrainFactory.Insert(trainPassenger) > 0)
                {
                    MessageBox.Show("Thêm mới thành công!");
                    Reset();
                }
                else MessageBox.Show("Thêm mới không thành công!");
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(ConstantInfo.CONFIRM_UPDATE, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }
            try
            {
                if (!Validate()) return;
                var trainPassenger = TrainFactory.FindTrainByID(_tblTrain.TrainID);

                trainPassenger.Number = txtNumberTrain.Text.Trim();
                trainPassenger.Type = (short)((ComboBoxItem)ddlTypeName.SelectedItem).Value;
                trainPassenger.DateImportExport = dtpRegisterDate.Value;
                trainPassenger.Jounery = txtJourney.Text.Trim();
                trainPassenger.PassengerVN = int.Parse(txtNumberPersonVN.Text);
                trainPassenger.PassengerForegin = int.Parse(txtNumberPersonForegin.Text);
                trainPassenger.Staff = int.Parse(txtNumberStaff.Text);
                trainPassenger.CreatedBy = _userInfo.UserID;

                if (TrainFactory.Update(trainPassenger) > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    if (_frmSearch != null)
                    {
                        _frmSearch.search();
                    }
                    this.Close();
                }
                else MessageBox.Show("Cập nhật không thành công!");
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void frmTrainPassengers_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirm = MessageBox.Show(ConstantInfo.CONFIRM_EXIT, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                e.Cancel=true;
            }
        }
    }
}
