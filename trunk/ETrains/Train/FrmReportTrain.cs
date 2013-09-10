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

namespace ETrains.Train
{
    public partial class FrmReportTrain : Form
    {
        public FrmReportTrain()
        {
            InitializeComponent();
        }

        private void FrmReportTrain_Load(object sender, EventArgs e)
        {
            this.Text = "So theo doi tau hang xuat nhap khau " + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>();
            listType.Add(new ComboBoxItem((short)ChuyenTauType.TypeExport, "Xuất khẩu"));
            listType.Add(new ComboBoxItem((short)ChuyenTauType.TypeImport, "Nhập khẩu"));

            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 0;

            //init data for ImportExportType

            var listImportExportType = new List<ComboBoxItem>();
            listImportExportType.Add(new ComboBoxItem(-1, "Tất cả"));
            listImportExportType.Add(new ComboBoxItem((short)ToaTauImportType.ChuyenCang, "Chuyển cảng"));
            listImportExportType.Add(new ComboBoxItem((short)ToaTauImportType.TaiCho, "Tại chỗ"));
            listImportExportType.Add(new ComboBoxItem(0, "Rỗng"));

            ddlImportExportType.Items.AddRange(listImportExportType.ToArray());
            ddlImportExportType.SelectedIndex = 0; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 countTrain = 0, countToaTau = 0, countHandoder = 0, countDeclaration = 0, countEmpty = 0;

                int importExportTypeSearch = Convert.ToInt32(((ComboBoxItem)ddlImportExportType.SelectedItem).Value);

                List<tblChuyenTau> listTrain = TrainFactory.SearchChuyenTau("", Convert.ToInt32(((ComboBoxItem)ddlTypeName.SelectedItem).Value),
                                                                 true, dtpFrom.Value, dtpTo.Value);

                //if(importExportTypeSearch == 0) //chi list ke toa rong
                //{
                //   listTrain = listTrain.Where(x => x.tblToaTaus.Where( y => y.LoaiToaTau == (short)LoaiToaTau.ToaRong)).ToList();
                //}
                

                DataSet1 dataset = new DataSet1();
                DataTable dt = dataset.ViewToaTau;

                foreach (tblChuyenTau train in listTrain)
                {
                    countTrain++;

                    if(train.tblToaTaus.IsLoaded==false)
                        train.tblToaTaus.Load();
                    List<tblToaTau> listToaTau = train.tblToaTaus.ToList();
                    foreach (tblToaTau toaTau in listToaTau)
                    {
                        countToaTau++;

                        string loaiToa = "";
                        string loaiHinh = "";
                        string soBBBG = "";
                        string tenNguoiGui = "";
                        string tenNguoiNhan = "";

                        if(importExportTypeSearch == 0) //chi list ke toa rong
                        {
                          if(toaTau.LoaiToaTau != (short)LoaiToaTau.ToaRong)
                          {
                              continue;
                          }

                        }

                        if(importExportTypeSearch == (int)ToaTauImportType.TaiCho) //chi list ke toa co loai hinh "tai cho"
                        {
                          if(toaTau.ImportExportType != (short)ToaTauImportType.TaiCho)
                          {
                              continue;
                          }

                        }

                        if(importExportTypeSearch == (int)ToaTauImportType.ChuyenCang) //chi list ke toa co loai hinh "chuyen cang"
                        {
                          if(toaTau.ImportExportType != (short)ToaTauImportType.ChuyenCang)
                          {
                              continue;
                          }

                        }

                        switch(toaTau.LoaiToaTau)
                        {
                            case (short)LoaiToaTau.ToaKin:
                                loaiToa="Toa kín";
                                break;
                            case (short)LoaiToaTau.ToaRong:
                                loaiToa = "Toa rỗng";
                                countEmpty++;
                                break;
                            case (short)LoaiToaTau.ToaTran:
                                loaiToa = "Toa trần";
                                break;
                            default:
                                break;
                            
                        }
                        switch (toaTau.ImportExportType)
                        {
                            case (short)ToaTauImportType.ChuyenCang:
                                loaiHinh = "Chuyển cảng";
                                try
                                {
                                    if (toaTau.tblHandoverResources.IsLoaded == false)
                                        toaTau.tblHandoverResources.Load();
                                    tblHandoverResource handoverResource = toaTau.tblHandoverResources.FirstOrDefault();
                                    if (handoverResource != null)
                                    {
                                        if (handoverResource.tblHandoverReference.IsLoaded == false)
                                            handoverResource.tblHandoverReference.Load();
                                        soBBBG = handoverResource.tblHandover.NumberHandover;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    soBBBG = "";
                                }
                                countHandoder++;
                                break;
                            case (short)ToaTauImportType.TaiCho:
                                loaiHinh = "Tại chỗ";
                                try
                                {
                                    if (toaTau.tblToKhaiTauResources.IsLoaded == false)
                                        toaTau.tblToKhaiTauResources.Load();
                                    tblToKhaiTauResource toKhaiTauResources = toaTau.tblToKhaiTauResources.FirstOrDefault();
                                    if (toKhaiTauResources != null)
                                    {
                                        if (toKhaiTauResources.tblToKhaiTauReference.IsLoaded == false)
                                            toKhaiTauResources.tblToKhaiTauReference.Load();

                                        soBBBG = toKhaiTauResources.tblToKhaiTau.Number + "";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    soBBBG = "";
                                }

                                countDeclaration++;
                                break;
                            default:
                                break;
                        }
                        if (train.Type == 0) //xuat
                        {
                            tenNguoiGui = toaTau.Ten_DoanhNghiep;
                            tenNguoiNhan = toaTau.Ten_DoiTac;
                        }
                        else //nhap
                        {
                            tenNguoiGui = toaTau.Ten_DoiTac;
                            tenNguoiNhan = toaTau.Ten_DoanhNghiep;
                        }


                        dt.Rows.Add(toaTau.ToaTauID, train.Ma_Chuyen_Tau, train.Ngay_XNC, toaTau.Ma_ToaTau, toaTau.So_VanTai_Don, tenNguoiGui, tenNguoiNhan, toaTau.Ten_Hang, toaTau.Don_Vi_Tinh, toaTau.Trong_Luong,soBBBG,
                                   toaTau.Seal_VanTai, toaTau.Seal_VanTai2, toaTau.Seal_HaiQuan, toaTau.Seal_HaiQuan2, loaiToa, loaiHinh, toaTau.Ghi_Chu);
                    }
                }


                var report = new ReportTrainImportExport();
                var txtType = (TextObject)report.Section1.ReportObjects["txtType"];
                var txtFrom = (TextObject)report.Section1.ReportObjects["txtFrom"];
                var txtTo = (TextObject)report.Section1.ReportObjects["txtTo"];

                var txtCountTrain = (TextObject)report.Section1.ReportObjects["txtCountTrain"];
                var txtCountToaTau = (TextObject)report.Section1.ReportObjects["txtCountToaTau"];
                var txtCountHandover = (TextObject)report.Section1.ReportObjects["txtCountHandover"];
                var txtCountDeclaration = (TextObject)report.Section1.ReportObjects["txtCountDeclaration"];
                var txtCountEmpty = (TextObject)report.Section1.ReportObjects["txtCountEmpty"];

                txtType.Text = ("SỔ THEO DÕI TÀU HÀNG " + ddlTypeName.Text).ToUpper();
                txtFrom.Text = txtFrom.Text + " " + dtpFrom.Text;
                txtTo.Text = txtTo.Text + " " + dtpTo.Text;

                txtCountTrain.Text = txtCountTrain.Text + " " + (countTrain!=0?countTrain.ToString("#.###"):"0");
                txtCountToaTau.Text = txtCountToaTau.Text + " " + (countToaTau!=0?countToaTau.ToString("#.###"):"0");
                txtCountHandover.Text = txtCountHandover.Text + " " + (countHandoder!=0? countHandoder.ToString("#.###"):"0");
                txtCountDeclaration.Text = txtCountDeclaration.Text + " " + (countDeclaration!=0?countDeclaration.ToString("#.###"):"0");
                txtCountEmpty.Text = txtCountEmpty.Text + " " + (countEmpty != 0 ? countEmpty.ToString("#.###") : "0");

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
