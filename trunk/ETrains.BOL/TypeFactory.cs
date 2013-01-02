using System;
using System.Collections.Generic;
using System.Linq;
using ETrains.DAL;

namespace ETrains.BOL
{
    public class TypeFactory
    {

        public static List<tblType> getAllType()
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.tblTypes.ToList();
        }


        public static tblType FindByCode(string code)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.tblTypes.Where(g => g.TypeCode == code).FirstOrDefault();

        }

        public static int Insert(tblType type)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            type.CreatedDate = CommonFactory.GetCurrentDate();
            type.ModifiedDate = CommonFactory.GetCurrentDate();
            db.AddTotblTypes(type);

            return db.SaveChanges();
        }

        public static int Update(tblType typeObj)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            tblType originType = db.tblTypes.Where(g => g.TypeCode == typeObj.TypeCode).FirstOrDefault();

            if (originType == null)
            {
                return -1;
            }

            originType.TypeName = typeObj.TypeName;
            originType.Description = typeObj.Description;
            originType.ModifiedBy = typeObj.ModifiedBy;
            originType.ModifiedDate = CommonFactory.GetCurrentDate();

            try
            {
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public static int DeleteType(String typeCode)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            var type = db.tblTypes.FirstOrDefault(vt => vt.TypeCode == typeCode);
            db.DeleteObject(type);
            return db.SaveChanges();

        }

    }
}
