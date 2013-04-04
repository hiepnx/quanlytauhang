using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ETrains.DAL;
using ETrains.Utilities.Enums;

namespace ETrains.BOL
{
    public class TrainFactory
    {
        private static dbTrainEntities _db;
        private static dbTrainEntities Instance(bool isNewInstance = false)
        {
            if (isNewInstance) return new dbTrainEntities(ConnectionController.GetConnection());
            return _db ?? (_db = new dbTrainEntities(ConnectionController.GetConnection()));
        }

        public static List<tblTrain> GetAll()
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            return db.tblTrains.ToList();
        }

        public static int Insert(tblTrain train)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            train.CreatedDate = CommonFactory.GetCurrentDate();
            db.AddTotblTrains(train);
            return db.SaveChanges();
        }

        public static int Update(tblTrain train)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            train.ModifiedDate = CommonFactory.GetCurrentDate();
            var originTrain = db.tblTrains.Where(g => g.TrainID == train.TrainID).FirstOrDefault();
            if (originTrain == null)
            {
                return -1;
            }
            db.Attach(originTrain);
            db.ApplyPropertyChanges("tblTrains", train);

            return db.SaveChanges();
        }

        public static int Delete(long trainId)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            var train = db.tblTrains.FirstOrDefault(g => g.TrainID == trainId);
            db.DeleteObject(train);
            return db.SaveChanges();

        }

        public static tblTrain FindTrainByID(Int64 ID)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            var originTrain = db.tblTrains.Where(g => g.TrainID == ID).FirstOrDefault();
            return originTrain;
        }

        public static List<tblTrain> SearchTrain(string numberTrain, short type, bool seachDate, DateTime dateFrom, DateTime dateTo)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            try
            {
                
                IQueryable<tblTrain> lst = db.tblTrains;
                if (!string.IsNullOrEmpty(numberTrain)) lst = lst.Where(x => x.Number.Contains(numberTrain));
                if (type >= 0) lst = lst.Where(x => x.Type == type);

                if (seachDate == true)
                {
                    var fromDate = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
                    var toDate = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
                    lst = lst.Where(x => x.DateImportExport.HasValue && x.DateImportExport.Value >= fromDate && x.DateImportExport.Value <= toDate);
                }

                return lst.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }

        }

        public static int InsertToKhai(tblToKhaiTau tokhai)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            tokhai.CreatedDate = CommonFactory.GetCurrentDate();

            db.AddTotblToKhaiTaus(tokhai);

            return db.SaveChanges();

        }

        public static int InsertToaTau(tblToaTau toaTau)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            db.Connection.Open();
            toaTau.CreatedDate = CommonFactory.GetCurrentDate();

            db.AddTotblToaTaus(toaTau);

            return db.SaveChanges();

        }

        public static int InsertToaTau(List<tblToaTau> listToaTau)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            foreach (var toaTau in listToaTau)
            {
                toaTau.CreatedDate = CommonFactory.GetCurrentDate();
                db.AddTotblToaTaus(toaTau);
            }

            return db.SaveChanges();

        }

        //New Flow
        public static int InsertChuyenTau(tblChuyenTau train)
        {
            var db = Instance();
            db.AddTotblChuyenTaus(train);

            return db.SaveChanges();    
        }
        public static int UpdateChuyenTau(tblChuyenTau train, List<tblToaTau> listToaTau)
        {
            var db = Instance();
            train.ModifiedDate = CommonFactory.GetCurrentDate();
            var originChuyenTau = db.tblChuyenTaus.Include("tblToaTaus").Where(g => g.TrainID == train.TrainID).FirstOrDefault();
          
            foreach (var toaTau in listToaTau)
            {
                var originalToaTau = originChuyenTau.tblToaTaus
                    .Where(c => c.ToaTauID == toaTau.ToaTauID)
                    .FirstOrDefault();
                if (originalToaTau != null)
                {
                    toaTau.ModifiedDate = train.ModifiedDate;
                    db.Detach(originalToaTau);
                    if (originalToaTau.EntityState == EntityState.Detached)
                    {
                        object original = null;
                        if (db.TryGetObjectByKey(originalToaTau.EntityKey, out original))
                            db.ApplyPropertyChanges(originalToaTau.EntityKey.EntitySetName, toaTau);
                    }
                }
                else
                {
                    originChuyenTau.tblToaTaus.Add(toaTau);
                }
            }

            foreach (var originalToaTau in originChuyenTau.tblToaTaus.Where(c => c.ToaTauID != 0).ToList())
            {
                if (!listToaTau.Any(c => c.ToaTauID == originalToaTau.ToaTauID))
                    db.DeleteObject(originalToaTau);
            }

            db.Detach(originChuyenTau);
            if (originChuyenTau.EntityState == EntityState.Detached)
            {
                object original = null;
                if (db.TryGetObjectByKey(originChuyenTau.EntityKey, out original))
                    db.ApplyPropertyChanges(originChuyenTau.EntityKey.EntitySetName, train);
            }

            return db.SaveChanges();
        }
        public static int UpdateHandover(tblHandover handover)
        {
            try
            {
                var db = Instance();
                handover.ModifiedDate = CommonFactory.GetCurrentDate();
                var originHandover = db.tblHandovers.Include("tblHandoverResources").Where(g => g.ID == handover.ID).FirstOrDefault();
                if (originHandover == null) return 0;
                db.Detach(originHandover);
                if (originHandover.EntityState == EntityState.Detached)
                {
                    object original = null;
                    if (db.TryGetObjectByKey(originHandover.EntityKey, out original))
                        db.ApplyPropertyChanges(originHandover.EntityKey.EntitySetName, handover);
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public static int UpdateHandover(tblHandover handover, List<tblToaTau> listToaTau)
        {
            try
            {
                var db = Instance();

                //xoa cac toa tau cu BBBG
                List<tblHandoverResource> listReource = db.tblHandoverResources.Where(x => x.tblHandover.ID == handover.ID).ToList();
                foreach (tblHandoverResource resource in listReource)
                {
                    db.DeleteObject(resource);
                }

                //cap nhat thong tin to BBBG
                tblHandover handoverOrigin = db.tblHandovers.Where(x => x.ID == handover.ID).FirstOrDefault();
                if (handoverOrigin != null)
                {
                    handoverOrigin.ModifiedBy = handover.ModifiedBy;
                    handoverOrigin.NumberHandover = handover.NumberHandover;
                    handoverOrigin.DateHandover = handover.DateHandover;
                    handoverOrigin.CodeStation = handover.CodeStation;
                    handoverOrigin.CodeStationFromTo = handover.CodeStationFromTo;
                    handoverOrigin.StatusGoods = handover.StatusGoods;
                    handoverOrigin.StatusVehicle = handover.StatusVehicle;
                    handoverOrigin.ModifiedBy = handover.ModifiedBy;

                    //thong tin hoi bao
                    handoverOrigin.IsReplied = handover.IsReplied;
                    handoverOrigin.NoteReply = handover.NoteReply;
                    handoverOrigin.ReplyStatusGoods = handover.ReplyStatusGoods;
                    handoverOrigin.DateReply = handover.DateReply;

                    //them cac toa tau moi cho BBBG
                    foreach (var toaTau in listToaTau)
                    {
                        var declarationResource = new tblHandoverResource
                        {
                            tblToaTau = toaTau
                        };
                        handoverOrigin.tblHandoverResources.Add(declarationResource);
                    }

                    db.SaveChanges();

                }
                return 1;
            }
            catch (Exception)
            {

            }
            return 0;
        }


        /*
        public static int UpdateHandover(tblHandover handover, List<tblToaTau> listToaTau)
        {
            try
            {
                var db = Instance();
                handover.ModifiedDate = CommonFactory.GetCurrentDate();
                var originHandover = db.tblHandovers.Include("tblHandoverResources").Where(g => g.ID == handover.ID).FirstOrDefault();

                foreach (var toaTau in listToaTau)
                {
                    var originalResource = originHandover.tblHandoverResources
                        .Where(c => c.tblToaTau.ToaTauID == toaTau.ToaTauID)
                        .FirstOrDefault();
                    if (originalResource != null)
                    {
                        //db.Detach(originalToaTau);
                        //if (originalToaTau.EntityState == EntityState.Detached)
                        //{
                        //    object original = null;
                        //    if (db.TryGetObjectByKey(originalToaTau.EntityKey, out original))
                        //        db.ApplyPropertyChanges(originalToaTau.EntityKey.EntitySetName, toaTau);
                        //}
                    }
                    else
                    {
                        originalResource = new tblHandoverResource {tblToaTau = toaTau};
                        db.AddTotblHandoverResources(originalResource);
                    }
                }

                foreach (var originalResource in originHandover.tblHandoverResources.Where(c => c.ID != 0).ToList())
                {
                    if (!listToaTau.Any(c => c.ToaTauID == originalResource.tblToaTau.ToaTauID))
                        db.DeleteObject(originalResource);
                }

                db.Detach(originHandover);
                if (originHandover.EntityState == EntityState.Detached)
                {
                    object original = null;
                    if (db.TryGetObjectByKey(originHandover.EntityKey, out original))
                        db.ApplyPropertyChanges(originHandover.EntityKey.EntitySetName, handover);
                }

                return db.SaveChanges();
            }
            catch (Exception)
            {

            }
            return 0;
        }
         */

        public static tblChuyenTau GetByCode(string code)
        {
            var db = Instance();
            var train = db.tblChuyenTaus.Where(x=>x.Ma_Chuyen_Tau == code).FirstOrDefault();
            return train;
        }

        public static List<tblToaTau> searchToaTauByToKhaiTauID(Int64 toKhaiTauID)
        {
            var db = Instance();
            try
            {
                List<tblToKhaiTauResource> listTblToKhaiTauResource = db.tblToKhaiTauResources.Where(x => x.tblToKhaiTau.ID == toKhaiTauID).ToList();
                List<tblToaTau> listToatau = new List<tblToaTau>();
                foreach (tblToKhaiTauResource toKhaiResource in listTblToKhaiTauResource)
                {
                    if (toKhaiResource.tblToaTauReference.IsLoaded == false)
                        toKhaiResource.tblToaTauReference.Load();
                    listToatau.Add(toKhaiResource.tblToaTau);
                }
                return listToatau;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<tblToaTau> searchToaTau(short type, string soVanDon, bool searchDate, DateTime dateFrom, DateTime dateTo)
        {
            var db = Instance();
            IQueryable<tblToaTau> lst = db.tblToaTaus.Where(x => x.ToaTauID != null);
            if (!string.IsNullOrEmpty(soVanDon)) lst = lst.Where(x => x.So_VanTai_Don.Contains(soVanDon));
            if (type != -1)
            {
                lst = lst.Where(x => x.tblChuyenTau.Type == type);
            }
            if (searchDate == true)
            {
                var fromDate = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
                var toDate = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
                lst = lst.Where(x => x.Ngay_VanTai_Don.HasValue && x.Ngay_VanTai_Don.Value >= fromDate && x.Ngay_VanTai_Don.Value <= toDate);
            }
           
            return lst.ToList() ;
        }

        public static tblChuyenTau GetById(long id)
        {
            var db = Instance();
            var train = db.tblChuyenTaus.Where(x => x.TrainID == id).FirstOrDefault();
            return train;
        }

        public static int InsertBBBG(tblHandover handover, tblNumberGenerate numberGenerate)
        {
            var db = Instance();
            if (handover.Type == "1") //neu la BBBG chuyen den, khong generate handoverNumber
            {
                db.AddTotblNumberGenerates(numberGenerate);
            }
            db.AddTotblHandovers(handover);
            return db.SaveChanges();
        }

        public static tblHandover FindHandoverByNumber(string number)
        {
            var db = Instance();
            return db.tblHandovers.Where(g => g.NumberHandover == number).FirstOrDefault();

        }

        public static tblHandover FindHandoverByID(long id)
        {
            var db = Instance();
            return db.tblHandovers.Where(g => g.ID == id).FirstOrDefault();

        }


        public static tblToKhaiTau FindToKhaiTauByNumber(long number)
        {
            var db = Instance();
            return db.tblToKhaiTaus.Where(g => g.Number == number).FirstOrDefault();

        }

        public static List<tblHandoverResource> FindHandoverResourceByHandoverID(long id)
        {
            var db = Instance();

            return db.tblHandoverResources.Where(g => g.tblHandover.ID == id).ToList();

        }

        public static tblToaTau GetToaTauByID(long id)
        {
            var db = Instance();
            return db.tblToaTaus.Where(g => g.ToaTauID == id).FirstOrDefault();

        }

        public static int InsertToKhaiTau(tblToKhaiTau toKhaiTau)
        {
            var db = Instance();
            db.AddTotblToKhaiTaus(toKhaiTau);
            return db.SaveChanges();
        }
        public static int deleteToKhaiTauResource(tblToKhaiTauResource toKhaiTauResource)
        {
            var db = Instance();

            try
            {
                tblToKhaiTauResource originObj = db.tblToKhaiTauResources.Where(x => x.ID == toKhaiTauResource.ID).FirstOrDefault();
                if (originObj != null)
                {
                    db.DeleteObject(originObj);
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;

        }

        public static int UpdateToKhaiTau(tblToKhaiTau toKhaiTau,List<tblToaTau> listToaTau)
        {
            try
            {
                var db = Instance(); 
               
                //xoa cac toa tau cu thuoc to khai
                List<tblToKhaiTauResource> listReource = db.tblToKhaiTauResources.Where(x => x.tblToKhaiTau.ID == toKhaiTau.ID).ToList();
                foreach (tblToKhaiTauResource resource in listReource)
                {
                    deleteToKhaiTauResource(resource);
                }

                //cap nhat thong tin to khai tau
                tblToKhaiTau toKhaitauOrigin = db.tblToKhaiTaus.Where(x => x.ID == toKhaiTau.ID).FirstOrDefault();
                if (toKhaitauOrigin != null)
                {
                    toKhaitauOrigin.Number = toKhaiTau.Number;
                    toKhaitauOrigin.DateDeclaration = toKhaiTau.DateDeclaration;
                    toKhaitauOrigin.TypeCode = toKhaiTau.TypeCode;
                    toKhaitauOrigin.CustomCode = toKhaiTau.CustomCode;
                    toKhaitauOrigin.ModifiedBy = toKhaiTau.ModifiedBy;
                    toKhaitauOrigin.ModifiedDate = CommonFactory.GetCurrentDate();

                    //them cac toa tau moi cho to khai
                    foreach (var toaTau in listToaTau)
                    {
                        var declarationResource = new tblToKhaiTauResource
                        {
                            tblToaTau = toaTau
                        };
                        toKhaitauOrigin.tblToKhaiTauResources.Add(declarationResource);
                    }

                    db.SaveChanges();

                }
                return 1;
            }
            catch (Exception)
            {

            }
            return 0;
        }

        public static int InsertToKhaiTauResource(tblToKhaiTauResource resource)
        {
            var db = Instance();
            db.AddTotblToKhaiTauResources(resource);
            return db.SaveChanges();
        }

        public static List<tblChuyenTau> SearchChuyenTau(string number, int type, bool searchByDate, DateTime dateFrom, DateTime dateTo)
        {
            var db = Instance();
            IQueryable<tblChuyenTau> lst = db.tblChuyenTaus.Where(t=>t.IsDeleted == null || t.IsDeleted == false);
            if (searchByDate) {
                var fromDate = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
                var toDate = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
                lst = lst.Where(x => x.Ngay_XNC.HasValue && x.Ngay_XNC.Value >= fromDate && x.Ngay_XNC.Value <= toDate);
            }
            if (!string.IsNullOrEmpty(number)) lst = lst.Where(x => x.Ma_Chuyen_Tau.Contains(number));
            if (type >= 0) lst = lst.Where(x => x.Type == type);
            return lst.ToList();
        }

        public static List<tblHandover> SearchBBBG(string number, bool searchByDate, DateTime dateFrom, DateTime dateTo,Nullable<Boolean> replyStatus, String replyType)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            try
            {
                IQueryable<tblHandover> lst = db.tblHandovers.Where(h => h.IsDeleted == null || h.IsDeleted == false);
                if (searchByDate)
                {
                    var fromDate = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
                    var toDate = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
                    lst = lst.Where(x => x.DateHandover.HasValue && x.DateHandover.Value >= fromDate && x.DateHandover.Value <= toDate);
                }
                if (!string.IsNullOrEmpty(number)) lst = lst.Where(x => x.NumberHandover.Contains(number));
                if (replyStatus != null) lst = lst.Where(x => x.IsReplied == replyStatus);

                if (replyType != "-1") lst = lst.Where(x => x.Type == replyType);
                //if (type >= 0) lst = lst.Where(x => x.Type == type);
                return lst.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally{
                db.Dispose();
            }
        }


        public static List<tblHandover> SearchBBBG(string number, bool searchByDate, DateTime dateFrom, DateTime dateTo, String customCode)
        {
            var db = Instance();
            IQueryable<tblHandover> lst = db.tblHandovers.Include("tblChuyenTau").Where(h => h.IsDeleted == null || h.IsDeleted == false);
            lst = lst.Where(x => x.CodeStationFromTo == customCode);
            if (searchByDate)
            {
                var fromDate = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
                var toDate = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
                lst = lst.Where(x => x.DateHandover.HasValue && x.DateHandover.Value >= fromDate && x.DateHandover.Value <= toDate);
            }
            if (!string.IsNullOrEmpty(number)) lst = lst.Where(x => x.NumberHandover.Contains(number));
            //if (type >= 0) lst = lst.Where(x => x.Type == type);
            return lst.ToList();
        }

        public static List<tblToKhaiTau> SearchToKhai(string number, short type, bool searchByDate, DateTime dateFrom, DateTime dateTo)
        {
            var db = Instance();
            IQueryable<tblToKhaiTau> lst = db.tblToKhaiTaus.Where(h => h.IsDeleted == null || h.IsDeleted == false);
            if (searchByDate)
            {
                var fromDate = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0);
                var toDate = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
                lst = lst.Where(x => x.DateDeclaration.HasValue && x.DateDeclaration.Value >= fromDate && x.DateDeclaration.Value <= toDate);
            }
            if (!string.IsNullOrEmpty(number))
            {
                int intNumber;
                int.TryParse(number, out intNumber);
                if (intNumber > 0) lst = lst.Where(x => x.Number == intNumber);
            }
            if (type >= 0)
            {
                lst = lst.Where(x => x.Type == type);
            }
            
            return lst.ToList();
        }

        public static int DeleteHandoverByID(long handoverId)
        {
            var db = Instance();
            var handover = db.tblHandovers.Where(h => h.ID == handoverId).FirstOrDefault();
            handover.IsDeleted = true;
            return db.SaveChanges();
        }

        public static int DeleteChuyenTauByID(long trainID)
        {
            var db = Instance();
            var train = db.tblChuyenTaus.Where(t => t.TrainID == trainID).FirstOrDefault();
            train.IsDeleted = true;
            return db.SaveChanges();
        }

        public static int DeleteToKhaiByID(long toKhaiID)
        {
            var db = Instance();
            var toKhai = db.tblToKhaiTaus.Where(t => t.ID == toKhaiID).FirstOrDefault();
            toKhai.IsDeleted = true;
            return db.SaveChanges();
        }
    }
}
