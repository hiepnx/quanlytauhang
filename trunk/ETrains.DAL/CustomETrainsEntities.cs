﻿using System.Data.Objects.DataClasses;
using System.Linq;

namespace ETrains.DAL
{
    public class DataAccess
    {
        private static dbTrainEntities _db;
        public static dbTrainEntities Instance()
        {
            return _db ?? (_db = new dbTrainEntities(ConnectionController.GetConnection()));
        }
    }

    public partial class tblToaTau : EntityObject
    {
        private string _ten_DoanhNghiep;

        public string Ten_DoanhNghiep
        {
            get
            {
                if (string.IsNullOrEmpty(_ten_DoanhNghiep))
                {
                    var db = DataAccess.Instance();
                    var company = db.tblCompanies.Where(x => x.CompanyCode == Ma_DoanhNghiep).FirstOrDefault();
                    _ten_DoanhNghiep = company == null ? string.Empty : company.CompanyName;
                }
                return _ten_DoanhNghiep;
            }
            set { _ten_DoanhNghiep = value; }
        }
    }

    public partial class tblChuyenTau : EntityObject
    {
        private string _typeName;
        private string _createdByName;
        private string _modifiedByName;

        public string TypeName
        {
            get
            {
                if (string.IsNullOrEmpty(_typeName))
                    _typeName = Type == (short)Utilities.Enums.ChuyenTauType.TypeExport ? "Xuất cảnh" : "Nhập cảnh";
                return _typeName;
            }
        }
        public string CreatedByName
        {
            get
            {
                if (string.IsNullOrEmpty(_createdByName))
                {
                    var db = DataAccess.Instance();
                    _createdByName = db.tblUsers.Where(x => x.UserID == CreatedBy).FirstOrDefault().Name;
                }
                return _createdByName;
            }
        }
        public string ModifiedByName
        {
            get
            {
                if (string.IsNullOrEmpty(_modifiedByName))
                {
                    if (ModifiedBy == null) _modifiedByName = string.Empty;
                    else
                    {
                        var db = DataAccess.Instance();
                        _modifiedByName = db.tblUsers.Where(x => x.UserID == ModifiedBy).FirstOrDefault().Name;
                    }
                }
                return _modifiedByName;
            }
        }
    }
}
