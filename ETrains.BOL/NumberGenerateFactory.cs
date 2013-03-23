﻿using System;
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

        public static tblNumberGenerate Insert(int type)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            tblNumberGenerate number= new tblNumberGenerate();
            number.NumberType = type;
            tblNumberGenerate max = getMaxValueByType(type);
            if (max == null)
            {
                max = new tblNumberGenerate
                {
                    HandoverNumber = 0,
                    ReplyReportNumber = 0
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

            db.AddTotblNumberGenerates(number);

            //number.HandoverNumber = getMaxValueByType(type)!=null?getMaxValueByType

            db.SaveChanges();
            return number;
        }
        public static tblNumberGenerate getMaxValueByType(int type)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            return db.tblNumberGenerates.
                Where(x => x.NumberType == type).
                OrderByDescending(x => x.ID).FirstOrDefault();
            
        }
    }
}