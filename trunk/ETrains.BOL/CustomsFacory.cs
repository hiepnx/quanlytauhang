using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETrains.DAL;
using ETrains.Utilities;
using System.Configuration;
using System.Data;
using log4net;

namespace ETrains.BOL
{
    public class CustomsFacory
    {
        public static List<tblCustom> getAll()
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.tblCustoms.ToList();

        }


        public static tblCustom FindByCode(string code)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.tblCustoms.Where(g => g.CustomsCode == code).FirstOrDefault();

        }

        public static int Insert(tblCustom customs)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            customs.CreatedDate = CommonFactory.GetCurrentDate();
            customs.ModifiedDate = CommonFactory.GetCurrentDate();

            db.AddTotblCustoms(customs);

            return db.SaveChanges();

        }

        public static int Update(tblCustom customsObj)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            tblCustom originCustoms = db.tblCustoms.Where(g => g.CustomsCode == customsObj.CustomsCode).FirstOrDefault();

            if (originCustoms == null)
            {
                return -1;
            }

            originCustoms.CustomsName = customsObj.CustomsName;
            originCustoms.Description = customsObj.Description;
            originCustoms.ModifiedBy = customsObj.ModifiedBy;
            originCustoms.ModifiedDate = CommonFactory.GetCurrentDate();

            try
            {
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public static int Delete(String customsCode)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            var customs = db.tblCustoms.FirstOrDefault(g => g.CustomsCode == customsCode);
            db.DeleteObject(customs);
            return db.SaveChanges();
        }
    }
}
