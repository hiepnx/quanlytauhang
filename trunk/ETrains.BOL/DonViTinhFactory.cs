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
    public class DonViTinhFactory
    {
        public static List<tblDonViTinh> getAll()
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.tblDonViTinhs.ToList();
        }
    }
}
