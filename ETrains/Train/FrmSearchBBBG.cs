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
using System.Windows.Forms.VisualStyles;


namespace ETrains.Train
{
    public partial class FrmSearchBBBG : Form
    {
        private string _handoverNumber;
        private List<tblHandover> _listHandover;
        public FrmSearchBBBG()
        {
            InitializeComponent();
        }

        public FrmSearchBBBG(string handoverNumber, ref List<tblHandover> listHandover)
        {
            InitializeComponent();
            _handoverNumber = handoverNumber;
            txtNumberBBBG.Text = _handoverNumber;
            _listHandover = listHandover;
        }

        private void FrmSearchBBBG_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {

            cbType.Items.Add(new ComboBoxItem("-1", "Tất cả"));
            cbType.Items.Add(new ComboBoxItem("0", "BBBG đến"));
            cbType.Items.Add(new ComboBoxItem("1", "BBBG đi"));
            cbType.SelectedIndex = 1;
            cbType.Enabled = false;

            cbReplyStatus.Items.Add(new ComboBoxItem(null, "Tất cả"));
            cbReplyStatus.Items.Add(new ComboBoxItem(true, "Đã hồi báo"));
            cbReplyStatus.Items.Add(new ComboBoxItem(false, "Chưa hồi báo"));
            cbReplyStatus.SelectedIndex = 0;

            //custumize check box column
            var cusCheckbox = new DataGridViewDisableCheckBoxColumn();
            cusCheckbox.Name = "CusCheck";
            cusCheckbox.Width = 50;
            var cbCusHeader = new DatagridViewCheckBoxHeaderCell();
            cbCusHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbCusHeader_OnCheckBoxClicked);
            cusCheckbox.HeaderCell = cbCusHeader;
            cusCheckbox.HeaderText = "";
            grdHandover.Columns.Insert(0, cusCheckbox);

            //search BBBG
            search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            try
            {
                String replyType = ((ComboBoxItem)cbType.SelectedItem).Value.ToString();
                Nullable<Boolean> replyStatus = null;
                if (((ComboBoxItem)cbReplyStatus.SelectedItem).Value != null)
                {
                    replyStatus = (Boolean)(((ComboBoxItem)cbReplyStatus.SelectedItem).Value);
                }
                List<tblHandover> listHandOver = TrainFactory.SearchBBBG(txtNumberBBBG.Text.Trim(),
                                                             cbNgayXNC.Checked, dtpFrom.Value, dtpTo.Value, replyStatus, replyType, cbChuaTaoBangKe.Checked);
                foreach (tblHandover handover in listHandOver)
                {
                    if (handover.Type == "0")
                    {
                        handover.Type = "BBBG Đến";
                    }
                    else
                    {
                        handover.Type = "BBBG Đi";
                    }
                }

                grdHandover.AutoGenerateColumns = false;
                grdHandover.DataSource = listHandOver;

                for (var i = 0; i < grdHandover.Rows.Count; i++)
                {
                    // Add to count Column
                    grdHandover.Rows[i].Cells["Count"].Value = i + 1;
                }
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }


        private void cbCusHeader_OnCheckBoxClicked(bool check)
        {
            for (var i = 0; i < grdHandover.Rows.Count; i++)
            {
                grdHandover.Rows[i].Cells["CusCheck"].Value = check;
            }
            grdHandover.EndEdit();

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _listHandover.Clear();
                for (var i = 0; i < grdHandover.Rows.Count; i++)
                {
                    if (grdHandover.Rows[i].Cells["CusCheck"].Value != null && (bool)grdHandover.Rows[i].Cells["CusCheck"].Value)
                    {
                        var handover = (tblHandover)grdHandover.Rows[i].DataBoundItem;
                        _listHandover.Add(handover);
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdHandover_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grdHandover.Columns[e.ColumnIndex].Name != "CusCheck")
            {
                grdHandover.Columns[e.ColumnIndex].ReadOnly = true;
            }
        }

        private void cbNgayXNC_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = cbNgayXNC.Checked;
            dtpTo.Enabled = cbNgayXNC.Checked;
        }



    }
}
