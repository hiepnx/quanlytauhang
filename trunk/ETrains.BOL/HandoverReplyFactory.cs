﻿using System;
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
    public class HandoverReplyFactory
    {
        public static List<ViewListHanoverReply> getAllHanoverReply()
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.ViewListHanoverReplies.ToList();
        }

        public static List<ViewListHanoverReply> search(string number, string customsCode, bool searchByDate, DateTime dateFrom, DateTime dateTo)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            IQueryable<ViewListHanoverReply> lst = db.ViewListHanoverReplies.Where(x => x.ID!=null);
            if (searchByDate)
            {
                var fromDate = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
                var toDate = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
                lst = lst.Where(x => x.ListReplyDate.HasValue && x.ListReplyDate.Value >= fromDate && x.ListReplyDate.Value <= toDate);
            }
            if (!string.IsNullOrEmpty(number)) lst = lst.Where(x => x.ListReplyNumber.Contains(number));
            if (!string.IsNullOrEmpty(customsCode)) lst = lst.Where(x => x.CustomsCodeReceiver == customsCode);
            
            return lst.ToList();
        }

        public static tblListHandoverReply FindByCode(Int64 ID)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            return db.tblListHandoverReplies.Where(g => g.ID == ID).FirstOrDefault();

        }

        public static int RemoveListReplyIDFromHandover(Int64 replyID)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            try
            {
                //update all related Handover 
                List<tblHandover> list = db.tblHandovers.Where(g => g.tblListHandoverReply.ID == replyID).ToList();
                foreach (tblHandover obj in list)
                {
                    obj.tblListHandoverReply = null;
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int Delete(Int64 ID)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            try
            {
                
                var reply = db.tblListHandoverReplies.FirstOrDefault(vt => vt.ID == ID);
                if (reply == null)
                    return 0;
                else
                {
                    //update all related Handover 
                    RemoveListReplyIDFromHandover(ID);

                    //delete Bang ke hoi bao
                    db.DeleteObject(reply);
                    return db.SaveChanges();
                }
              
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}