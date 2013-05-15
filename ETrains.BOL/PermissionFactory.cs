using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETrains.DAL;
using ETrains.Utilities;
using log4net;
namespace ETrains.BOL
{
  public class PermissionFactory
  {
    public static List<tblPermission> GetAllPermission()
    {
      var db = new dbTrainEntities(ConnectionController.GetConnection());
      List<tblPermission> list = db.tblPermissions.ToList();
      db.Connection.Close();
      return list;
    }

  }
}
