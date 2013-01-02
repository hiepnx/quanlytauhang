using System;
using System.Collections.Generic;
using System.Linq;
using ETrains.DAL;
using ETrains.Utilities;
using System.Configuration;
using System.Data;
using log4net;

namespace ETrains.BOL
{
    public class CompanyFactory
    {
        public static List<tblCompany> getAllCompany()
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.tblCompanies.ToList();
        }

        public static List<tblCompany> getTopCompany(string name = "", string code = "")
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            IQueryable<tblCompany> result = db.tblCompanies;
            if (!string.IsNullOrEmpty(name)) result = result.Where(x => x.CompanyName.Contains(name));
            if (!string.IsNullOrEmpty(code)) result = result.Where(x => x.CompanyCode.Contains(code));
            return result.Take(200).ToList();

        }


        public static tblCompany FindByCode(string code)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.tblCompanies.Where(g => g.CompanyCode == code).FirstOrDefault();

        }

        public static int Insert(tblCompany company)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            company.CreatedDate = CommonFactory.GetCurrentDate();
            company.ModifiedDate = CommonFactory.GetCurrentDate();
            db.AddTotblCompanies(company);
            return db.SaveChanges();
        }

        public static int Update(tblCompany companyObj)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            tblCompany originCompany = db.tblCompanies.Where(g => g.CompanyCode == companyObj.CompanyCode).FirstOrDefault();

            if (originCompany == null)
            {
                return -1;
            }

            originCompany.CompanyName = companyObj.CompanyName;
            originCompany.Description = companyObj.Description;
            originCompany.ModifiedBy = companyObj.ModifiedBy;
            originCompany.ModifiedDate = CommonFactory.GetCurrentDate();

            try
            {
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int Delete(String companyCode)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            var company = db.tblCompanies.FirstOrDefault(vt => vt.CompanyCode == companyCode);
            db.DeleteObject(company);
            return db.SaveChanges();
        }

    }
}
