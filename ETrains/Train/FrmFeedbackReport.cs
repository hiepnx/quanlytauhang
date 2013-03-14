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
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Reflection;

namespace ETrains
{
    public partial class FrmFeedbackReport : Form
    {
        public FrmFeedbackReport()
        {
            InitializeComponent();
            this.Text = "Báo cáo BBBG hồi báo";

            ////init ma cua khau
            var listHQ = CustomsFacory.getAll();
            var listStation = new List<tblCustom>();
            listStation.AddRange(listHQ);
            listStation.Insert(0, new tblCustom
            {
                CustomsName = "Tên HQ Cửa khẩu",
                CustomsCode = ""
            });
            ddlCuaKhau.DataSource = listStation.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            ddlCuaKhau.ValueMember = "CustomsCode";
            ddlCuaKhau.DisplayMember = "CustomsName";
            ddlCuaKhau.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlCuaKhau.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Chưa chọn đơn vị hải quan");
                    return;
                }
                var report = new ReportListFeedback();

                var txtReceiver = (TextObject)report.Section1.ReportObjects["txtReceiver"];
                txtReceiver.Text = txtReceiver.Text + CustomsFacory.FindByCode(ddlCuaKhau.SelectedValue.ToString()).CustomsName;

                List<tblHandover> listHandover = TrainFactory.SearchBBBG(txtNumberBBBG.Text.Trim(), cbNgayXNC.Checked, dtpFrom.Value, dtpTo.Value, ddlCuaKhau.SelectedValue.ToString());

                if (listHandover == null || listHandover.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thỏa mãn điều kiện tìm kiếm này");
                    return;
                }
                DataSet1 dataset = new DataSet1();
                DataTable dt = dataset.tblHandover;

                foreach (tblHandover obj in listHandover)
                {
                     if (obj.tblChuyenTauReference.IsLoaded == false)
                        {
                            obj.tblChuyenTauReference.Load();
                        }
                     dt.Rows.Add(obj.ID,
                         obj.tblChuyenTau.TrainID,
                         obj.NumberHandover,
                         obj.DateHandover,
                         obj.CodeStation,
                         obj.CodeStationFromTo,
                         obj.StatusGoods,
                         obj.StatusVehicle,
                         obj.CreatedDate,
                         obj.CreatedBy,
                         obj.ModifiedDate,
                         obj.ModifiedBy,
                         obj.NumberReply,
                         obj.DateReply,
                         obj.NoteReply,
                         obj.IsDeleted,
                         obj.IsReplied,
                         obj.Note,
                         obj.Type);
                }

                report.SetDataSource(dataset);

                FrmPreviewReport frmReport = new FrmPreviewReport(report);
                frmReport.MdiParent = this.MdiParent;
                frmReport.Show();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
