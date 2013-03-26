﻿using System;
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
using CrystalDecisions.CrystalReports.Engine;


namespace ETrains.Train
{
    public partial class FrmAddListHandoverReply : Form
    {
        private short _mode; //0: addnew, 1: edit
        private UserInfo _userInfo;
        private FrmListHandoverReply _listReplyForm;
        private List<tblHandover> _listHanover;
        private tblListHandoverReply _tblListHandoverReply;

        public FrmAddListHandoverReply()
        {
            InitializeComponent();
        }

        public FrmAddListHandoverReply(FrmListHandoverReply listReply, UserInfo userInfo, tblListHandoverReply tblListHandoverReply, short mode = (short)0)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mode = mode;
            _listReplyForm = listReply;
            _listHanover = new List<tblHandover>();  
            _tblListHandoverReply = tblListHandoverReply;
        }


        public FrmAddListHandoverReply(FrmListHandoverReply listReply, UserInfo userInfo, short mode = (short)0)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mode = mode;
            _listReplyForm = listReply;
            _listHanover = new List<tblHandover>();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<tblHandover> listAddMoreHandOver = new List<tblHandover>();
            FrmSearchBBBG frm = new FrmSearchBBBG(txtHandoverNumber.Text.Trim(), ref listAddMoreHandOver);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                BinBBBG(listAddMoreHandOver);
            }
        }

        private void BinBBBG(List<tblHandover> listAddMoreHandOver)
        {
            //HashSet<tblHandover> hashSetHandover = new HashSet<tblHandover>();
            var dataHandover = new Dictionary<Int64, tblHandover>();
            foreach(tblHandover handover in _listHanover)
            {
                dataHandover.Add(handover.ID, handover);
                
            }
            _listHanover.Clear();
            foreach (tblHandover handover in listAddMoreHandOver)
            {
                if (dataHandover.ContainsKey(handover.ID) == false)
                {
                    dataHandover.Add(handover.ID, handover);
                }
                
            }
            listAddMoreHandOver.Clear();
            _listHanover = dataHandover.Values.ToList();

            grdHandover.AutoGenerateColumns = false;
            grdHandover.DataSource = _listHanover;
        }

        private void FrmAddListHandoverReply_Load(object sender, EventArgs e)
        {

            ////init ma cua khau
            var listHQ = CustomsFacory.getAll();
            var listStation = new List<tblCustom>();
            listStation.AddRange(listHQ);
            listStation.Insert(0, new tblCustom
            {
                CustomsName = "Tên HQ Cửa khẩu",
                CustomsCode = ""
            });
            ddlCustomsName.DataSource = listStation.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            ddlCustomsName.ValueMember = "CustomsCode";
            ddlCustomsName.DisplayMember = "CustomsName";
            ddlCustomsName.SelectedIndex = 0;
            txtCustomsCode.Text = "";

            if (_mode == 0)
            {
                btnAddNew.Enabled = true;
                btnUpdate.Enabled = false;
                lblHeader.Text = "Thêm mới bảng kê hồi báo";
                tblNumberGenerate NumberGenerate = NumberGenerateFactory.Insert(NumberGenerateFactory.NUMBER_TYPE_REPLY);
                txtNumberHandoverReply.Text = NumberGenerate.ReplyReportNumber + "/BK-HQGA";
            }
            else
            {
                btnAddNew.Enabled = false;
                btnUpdate.Enabled = true;
                lblHeader.Text = "Cập nhật bảng kê hồi báo";
                initUpdateForm();
            }
        }

        private void initUpdateForm()
        {
            if(_tblListHandoverReply!=null && _tblListHandoverReply.tblHandovers.IsLoaded==false)
                _tblListHandoverReply.tblHandovers.Load();
            _listHanover = _tblListHandoverReply.tblHandovers.ToList();
            grdHandover.AutoGenerateColumns=false;

            foreach (tblHandover handover in _listHanover)
            {
                if (handover.tblChuyenTauReference.IsLoaded == false)
                    handover.tblChuyenTauReference.Load();
                if (handover.Type == "0")
                {
                    handover.Type = "BBBG Đến";
                }
                else
                {
                    handover.Type = "BBBG Đi";
                }
            }

            grdHandover.DataSource=_listHanover;
           
            txtNumberHandoverReply.Enabled=false;
            txtNumberHandoverReply.Text=_tblListHandoverReply.ListReplyNumber;
            dtpHandoverReplyDate.Value=_tblListHandoverReply.ListReplyDate.GetValueOrDefault();
            dtpFrom.Value = _tblListHandoverReply.ReportFromDate.GetValueOrDefault();
            dtpTo.Value=_tblListHandoverReply.ReportToDate.GetValueOrDefault();
            txtCustomsCode.Text = _tblListHandoverReply.CustomsCodeReceiver;
            ddlCustomsName.SelectedValue = _tblListHandoverReply.CustomsCodeReceiver;
            txtStatusGood.Text =_tblListHandoverReply.ReplyStatusGoods;
            txtNote.Text=_tblListHandoverReply.Note;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdHandover_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;

            var dataHandover = new Dictionary<Int64, tblHandover>();
            foreach(tblHandover handover in _listHanover)
            {
                dataHandover.Add(handover.ID, handover);
                
            }
            dataHandover.Remove(_listHanover[e.RowIndex].ID);
            _listHanover.Clear();
            _listHanover = dataHandover.Values.ToList();
           
            grdHandover.DataSource = _listHanover;

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!ValidateAddNew()) return;

            tblListHandoverReply hanoverReply= new tblListHandoverReply
            {
                ListReplyNumber = txtNumberHandoverReply.Text.Trim(),
                ListReplyDate = dtpHandoverReplyDate.Value,
                ReportFromDate = dtpFrom.Value,
                ReportToDate = dtpTo.Value,
                CustomsCodeReceiver = ddlCustomsName.SelectedValue.ToString(),
                ReplyStatusGoods = txtStatusGood.Text.Trim(),
                Note = txtNote.Text.Trim(),
               
            };

            //foreach (var handover in _listHanover)
            //{

            //    hanoverReply.tblHandovers.Add(handover);
            //}

            var result = HandoverReplyFactory.InsertListHandoverReply(hanoverReply, _listHanover);
            if (result > 0)
            {
                if (cbPrint.Checked == true)
                {
                    // MessageBox.Show("Thêm mới bảng kê hồi báo  thành công. Bạn hãy tắt hộp thoại này để xem bản in");
                    //printBBBG();
                    //Reset();
                }
                else
                {
                    MessageBox.Show("Thêm mới bảng kê hồi báo thành công!");
                    Reset();
                }
            }
            else MessageBox.Show("Thêm mới bảng kê hồi báo không thành công!");
            if (_listReplyForm != null)
            {
                _listReplyForm.search();
            }

        }

        private void printBBBG()
        {
        }

        private void Reset()
        {
            txtCustomsCode.Text = "";
            txtHandoverNumber.Text = "";
            txtNote.Text = "";
            txtNumberHandoverReply.Text = "";
            txtStatusGood.Text = "";
            _listHanover.Clear();
            _listHanover = new List<tblHandover>();
            grdHandover.DataSource = _listHanover;
            tblNumberGenerate NumberGenerate = NumberGenerateFactory.Insert(NumberGenerateFactory.NUMBER_TYPE_REPLY);
            txtNumberHandoverReply.Text = NumberGenerate.ReplyReportNumber + "/BK-HQGA";
        }


        private bool ValidateAddNew()
        {
            bool valid= techlinkErrorProvider1.Validate(this);
            if (valid == true)
            {
                tblListHandoverReply reply = HandoverReplyFactory.FindByNumber(txtNumberHandoverReply.Text.Trim());
                if (reply != null)
                {
                    MessageBox.Show("Số bảng kê này đã tồn tại, xin chọn số mới");
                    return false;
                }
            }
            return valid;
        }

        private bool ValidateUpdate()
        {
            bool valid = techlinkErrorProvider1.Validate(this);
            return valid;
        }

        private void ddlCustomsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomsCode.Text = ddlCustomsName.SelectedValue.ToString();
        }

        private void txtCustomsCode_Leave(object sender, EventArgs e)
        {
            var customs = CustomsFacory.FindByCode(txtCustomsCode.Text.Trim());
            if (customs != null)
            {
                ddlCustomsName.SelectedValue = customs.CustomsCode.Trim();
            }
            else
            {
                ddlCustomsName.SelectedIndex = 0;
                txtCustomsCode.Text = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateUpdate()) return;

            
            _tblListHandoverReply.ListReplyNumber = txtNumberHandoverReply.Text.Trim();
            _tblListHandoverReply.ListReplyDate = dtpHandoverReplyDate.Value;
            _tblListHandoverReply.ReportFromDate = dtpFrom.Value;
            _tblListHandoverReply.ReportToDate = dtpTo.Value;
            _tblListHandoverReply.CustomsCodeReceiver = ddlCustomsName.SelectedValue.ToString();
            _tblListHandoverReply.ReplyStatusGoods = txtStatusGood.Text.Trim();
            _tblListHandoverReply.Note = txtNote.Text.Trim();

            var result = HandoverReplyFactory.UpdateListHandoverReply(_tblListHandoverReply, _listHanover);
            if (result > 0)
            {
                if (cbPrint.Checked == true)
                {
                     MessageBox.Show("Cập nhật Biên bản bàn giao thành công. Bạn hãy tắt hộp thoại này để xem bản in");
                    //printBBBG();
                     this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật bảng kê hồi báo giao thành công!");
                    this.Close();
                }
            }
            else MessageBox.Show("Cập nhật bảng kê hồi báo không thành công!");
            if (_listReplyForm != null)
            {
                _listReplyForm.search();
            }
            
        }

    }
}