using System.Data.Objects.DataClasses;
using System.Linq;

namespace ETrains.DAL
{
    public partial class tblToaTau: EntityObject
    {
        private string _ten_DoanhNghiep;
        
        public string Ten_DoanhNghiep
        {
            get
            {
                if (string.IsNullOrEmpty(_ten_DoanhNghiep)) 
                {
                    var db = new dbTrainEntities(ConnectionController.GetConnection());
                    var company = db.tblCompanies.Where(x => x.CompanyCode == Ma_DoanhNghiep).FirstOrDefault();
                    _ten_DoanhNghiep = company == null ? string.Empty : company.CompanyName;
                }
                return _ten_DoanhNghiep;
            }
            set { _ten_DoanhNghiep = value; }
        }
    }
}
