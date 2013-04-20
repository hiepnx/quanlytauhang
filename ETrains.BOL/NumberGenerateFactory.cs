using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETrains.DAL;

namespace ETrains.BOL
{
    public class NumberGenerateFactory
    {
        public const int NUMBER_TYPE_HANDOVER = 1;
        public const int NUMBER_TYPE_REPLY = 2;

        public static tblNumberGenerate AutoGenerate(int type)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            tblNumberGenerate number= new tblNumberGenerate();
            number.Year = CommonFactory.GetCurrentDate().Year + "";
            number.NumberType = type;
            tblNumberGenerate max = getMaxValueByType(type);
            if (max == null)
            {
                max = new tblNumberGenerate
                {
                    HandoverNumber = 0,
                    ReplyReportNumber = 0,
                    Year=CommonFactory.GetCurrentDate().Year+""
                };
            }
            if (type == NUMBER_TYPE_HANDOVER)
            {
                number.HandoverNumber = max.HandoverNumber + 1;
            }
            if (type == NUMBER_TYPE_REPLY)
            {
                number.ReplyReportNumber = max.ReplyReportNumber + 1;
            }

            return number;
        }

        public static int AddNew(tblNumberGenerate number)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            
            db.AddTotblNumberGenerates(number);

            return db.SaveChanges();
            
        }

        public static tblNumberGenerate getMaxValueByType(int type)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            String year = CommonFactory.GetCurrentDate().Year + "";
            return db.tblNumberGenerates.
                Where(x => x.NumberType == type && x.Year==year).
                OrderByDescending(x => x.ID).FirstOrDefault(); 
        }
    }
}
