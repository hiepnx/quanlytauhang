using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ETrains.BOL;
using ETrains.DAL;
using ETrains.Utilities;
using ETrains.Utilities.Enums;

namespace ETrains.Train
{
    public partial class frmDanhSachToaTau : Form
    {
        private List<tblToaTau> _listToaTau;
        private string _soVanDon;
        private short _type; //0: xuat canh, 1: nhap canh

        public frmDanhSachToaTau()
        {
            InitializeComponent();
        }
        public frmDanhSachToaTau(short type, string soVanDon, ref List<tblToaTau> listToaTau)
        {
            InitializeComponent();
            _listToaTau = listToaTau;
            _soVanDon = soVanDon ;
            _type = type;
        }

        private void frmDanhSachToaTau_Load(object sender, EventArgs e)
        {
            this.Text = "Tim kiem toa tau theo so hieu doan tau" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            txtSoVanTaiDon.Text = _soVanDon;
            Init();
        }

        private void Init()
        {
            if (_type == 0)
            {
                //lblDateXNK.Text = "Ngày giờ xuất cảnh";
                grdToaTau.Columns["Ten_DoiTac"].HeaderText = "Tên người nhận";
                grdToaTau.Columns["Ten_DoanhNghiep"].HeaderText = "Tên người gửi";
            }
            else if (_type == 1)
            {
                //lblDateXNK.Text = "Ngày giờ nhập cảnh";
                grdToaTau.Columns["Ten_DoiTac"].HeaderText = "Tên người gửi";
                grdToaTau.Columns["Ten_DoanhNghiep"].HeaderText = "Tên người nhận";
            }

            //custumize check box column
            var cusCheckbox = new DataGridViewDisableCheckBoxColumn();
            cusCheckbox.Name = "CusCheck";
            cusCheckbox.Width = 50;
            var cbCusHeader = new DatagridViewCheckBoxHeaderCell();
            cbCusHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbCusHeader_OnCheckBoxClicked);
            cusCheckbox.HeaderCell = cbCusHeader;
            cusCheckbox.HeaderText = "";
            grdToaTau.Columns.Insert(0, cusCheckbox);
            //grid Toa tau
            grdToaTau.AutoGenerateColumns = false;
            List<tblToaTau> listToaTau = TrainFactory.searchToaTau(_type, txtSoVanTaiDon.Text.Trim(), cbNgayVT.Checked, dtpFrom.Value, dtpTo.Value);
            grdToaTau.DataSource = listToaTau;
            // Bind count column
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                // Add to count Column
                grdToaTau.Rows[i].Cells["Count"].Value = (i + 1).ToString();
                var toaTau = (tblToaTau) grdToaTau.Rows[i].DataBoundItem;
                //if (_listToaTau.Any(tau => tau.tblChuyenTau.TrainID == toaTau.tblChuyenTau.TrainID))
                //{
                //    grdToaTau.Rows[i].Cells["CusCheck"].Value = true;
                //}
            }

        }

        private void cbCusHeader_OnCheckBoxClicked(bool check)
        {
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                grdToaTau.Rows[i].Cells["CusCheck"].Value = check;
            }
            grdToaTau.EndEdit();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _listToaTau.Clear();
                for (var i = 0; i < grdToaTau.Rows.Count; i++)
                {
                    if (grdToaTau.Rows[i].Cells["CusCheck"].Value != null && (bool)grdToaTau.Rows[i].Cells["CusCheck"].Value)
                    {
                        var toaTau = (tblToaTau) grdToaTau.Rows[i].DataBoundItem;
                        _listToaTau.Add(toaTau);
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }       
        }

        private void grdToaTau_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grdToaTau.Columns[e.ColumnIndex].Name != "CusCheck")
            {
                grdToaTau.Columns[e.ColumnIndex].ReadOnly = true;
            }
        }

        private void cbNgayVT_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = cbNgayVT.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<tblToaTau> listToaTau = TrainFactory.searchToaTau(_type, txtSoVanTaiDon.Text.Trim(), cbNgayVT.Checked, dtpFrom.Value, dtpTo.Value);
            grdToaTau.DataSource = listToaTau;
            // Bind count column
            for (var i = 0; i < grdToaTau.Rows.Count; i++)
            {
                // Add to count Column
                grdToaTau.Rows[i].Cells["Count"].Value = (i + 1).ToString();
                var toaTau = (tblToaTau)grdToaTau.Rows[i].DataBoundItem;
                //if (_listToaTau.Any(tau => tau.tblChuyenTau.TrainID == toaTau.tblChuyenTau.TrainID))
                //{
                //    grdToaTau.Rows[i].Cells["CusCheck"].Value = true;
                //}
            }
        }
    }
}

#region Custumize checkbox column data gird view
public delegate void CheckBoxClickedHandler(bool state);
public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
{
    bool _bChecked;
    public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
    {
        _bChecked = bChecked;
    }
    public bool Checked
    {
        get { return _bChecked; }
    }
}
class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
{
    Point checkBoxLocation;
    Size checkBoxSize;
    bool _checked = false;
    Point _cellLocation = new Point();
    System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
        System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
    public event CheckBoxClickedHandler OnCheckBoxClicked;

    public DatagridViewCheckBoxHeaderCell()
    {
    }

    protected override void Paint(System.Drawing.Graphics graphics,
        System.Drawing.Rectangle clipBounds,
        System.Drawing.Rectangle cellBounds,
        int rowIndex,
        DataGridViewElementStates dataGridViewElementState,
        object value,
        object formattedValue,
        string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
    {
        base.Paint(graphics, clipBounds, cellBounds, rowIndex,
            dataGridViewElementState, value,
            formattedValue, errorText, cellStyle,
            advancedBorderStyle, paintParts);
        Point p = new Point();
        Size s = CheckBoxRenderer.GetGlyphSize(graphics,
        System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
        p.X = cellBounds.Location.X +
            (cellBounds.Width / 2) - (s.Width / 2);
        p.Y = cellBounds.Location.Y +
            (cellBounds.Height / 2) - (s.Height / 2);
        _cellLocation = cellBounds.Location;
        checkBoxLocation = p;
        checkBoxSize = s;
        if (_checked)
            _cbState = System.Windows.Forms.VisualStyles.
                CheckBoxState.CheckedNormal;
        else
            _cbState = System.Windows.Forms.VisualStyles.
                CheckBoxState.UncheckedNormal;
        CheckBoxRenderer.DrawCheckBox
        (graphics, checkBoxLocation, _cbState);
    }

    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
        Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
        if (p.X >= checkBoxLocation.X && p.X <=
            checkBoxLocation.X + checkBoxSize.Width
        && p.Y >= checkBoxLocation.Y && p.Y <=
            checkBoxLocation.Y + checkBoxSize.Height)
        {
            _checked = !_checked;
            if (OnCheckBoxClicked != null)
            {
                OnCheckBoxClicked(_checked);
                this.DataGridView.InvalidateCell(this);
            }

        }
        base.OnMouseClick(e);
    }
}
public class DataGridViewDisableCheckBoxColumn : DataGridViewCheckBoxColumn
{
    public DataGridViewDisableCheckBoxColumn()
    {
        this.CellTemplate = new DataGridViewDisableCheckBoxCell();
    }
}
public class DataGridViewDisableCheckBoxCell : DataGridViewCheckBoxCell
{
    bool enabledValue;
    public bool Enabled
    {
        get
        {
            return enabledValue;
        }
        set
        {
            enabledValue = value;
        }
    }
    // Override the Clone method so that the Enabled property is copied.
    public override object Clone()
    {
        DataGridViewDisableCheckBoxCell cell = (DataGridViewDisableCheckBoxCell)base.Clone();
        cell.Enabled = this.Enabled;
        return cell;
    }
    // By default, enable the CheckBox cell.
    public DataGridViewDisableCheckBoxCell()
    {
        this.enabledValue = true;
    }
    protected override void Paint(Graphics graphics,
    Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
    DataGridViewElementStates elementState, object value,
    object formattedValue, string errorText,
    DataGridViewCellStyle cellStyle,
    DataGridViewAdvancedBorderStyle advancedBorderStyle,
    DataGridViewPaintParts paintParts)
    {
        // The checkBox cell is disabled, so paint the border,
        // background, and disabled checkBox for the cell.
        if (!this.enabledValue)
        {
            // Draw the cell background, if specified.
            if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
            {
                Brush cellBackground = new SolidBrush(this.Selected ? cellStyle.SelectionBackColor : cellStyle.BackColor);
                graphics.FillRectangle(cellBackground, cellBounds);
                cellBackground.Dispose();
            }
            // Draw the cell borders, if specified.
            if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
            {
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            }
            CheckState checkState = CheckState.Unchecked;
            if (formattedValue != null)
            {
                if (formattedValue is CheckState)
                {
                    checkState = (CheckState)formattedValue;
                }
                else if (formattedValue is bool)
                {
                    if ((bool)formattedValue)
                    {
                        checkState = CheckState.Checked;
                    }
                }
            }
            CheckBoxState state = checkState == CheckState.Checked ? CheckBoxState.CheckedDisabled : CheckBoxState.UncheckedDisabled;
            // Calculate the area in which to draw the checkBox.
            // force to unchecked!!
            Size size = CheckBoxRenderer.GetGlyphSize(graphics, state);
            Point center = new Point(cellBounds.X, cellBounds.Y);
            center.X += (cellBounds.Width - size.Width) / 2;
            center.Y += (cellBounds.Height - size.Height) / 2;
            // Draw the disabled checkBox.
            // We prevent painting of the checkbox if the Width,
            // plus a little padding, is too small.
            if (size.Width + 4 < cellBounds.Width)
            {
                CheckBoxRenderer.DrawCheckBox(graphics, center, state);
            }
        }
        else
        {
            // The checkBox cell is enabled, so let the base class
            // handle the painting.
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }
    }
}
#endregion
