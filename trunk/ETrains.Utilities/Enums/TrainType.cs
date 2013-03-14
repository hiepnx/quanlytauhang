using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETrains.Utilities.Enums
{
    public enum TrainType
    {
        //Loai hinh xuat canh
        TypeExport = 0,
        //Loai hinh tau TQ xuat canh thong thuong
        TypeExportNormal = 1,
        //Loai hinh tau TQ xuat canh chuyen cang
        TypeExportChange = 2,

        //Loai hinh nhap canh
        TypeImport = 3,
        //Loai hinh tau TQ nhap canh thong thuong
        TypeImportNormal = 4,
        //Loai hinh tau TQ nhap canh chuyen cang
        TypeImportChange = 5,
    }

    public enum ChuyenTauType
    {
        //Xuat canh
        TypeExport = 0,
        
        //Nhap canh
        TypeImport = 1
    }

    public enum HandoverType
    {
        //BBBG chuyen den
        HandoverComeIn = 0,

        //BBBG chuyen di
        HandoverToGoOut = 1
    }
}
