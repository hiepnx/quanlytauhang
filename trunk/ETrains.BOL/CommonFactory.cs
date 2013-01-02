using System;
using System.Linq;
using ETrains.DAL;

namespace ETrains.BOL
{
    public class CommonFactory
    {
        public static DateTime GetCurrentDate()
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            var objCurentDate = db.ViewGetCurrentDates.FirstOrDefault();
            return objCurentDate.CurrentDateTime;
        }
    }
}
