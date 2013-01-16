using System;
using System.Collections.Generic;
using System.Linq;
using ETrains.DAL;
using ETrains.Utilities.Enums;

namespace ETrains.BOL
{
    public class TrainFactory
    {
        private static dbTrainEntities _db;
        private static dbTrainEntities Instance()
        {
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

        public static List<tblTrain> SearchTrain(string numberTrain, int type, DateTime date)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());

            IQueryable<tblTrain> lst = db.tblTrains;//.Where(x => (x.DateExport == date) || (x.DateImport == date));
            if (!string.IsNullOrEmpty(numberTrain)) lst = lst.Where(x => x.Number.Contains(numberTrain));
            if (type >= 0) lst = lst.Where(x => x.Type == type);
            else if (type == -1) // search tau hang 
            {
                lst = lst.Where(x => x.Type == (short)TrainType.TypeExportNormal || x.Type == (short)TrainType.TypeExportChange || x.Type == (short)TrainType.TypeImportNormal || x.Type == (short)TrainType.TypeImportChange);
            }
            else
            {
                //search tau khach
                lst = lst.Where(x => x.Type == (short)TrainType.TypeExport || x.Type == (short)TrainType.TypeImport);
            }

            return lst.ToList();

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

        public static tblChuyenTau GetByCode(string code)
        {
            var db = Instance();
            var train = db.tblChuyenTaus.Where(x=>x.Ma_Chuyen_Tau == code).FirstOrDefault();
            return train;
        }

        public static tblChuyenTau GetById(long id)
        {
            var db = Instance();
            var train = db.tblChuyenTaus.Where(x => x.TrainID == id).FirstOrDefault();
            return train;
        }

        public static int InsertBBBG(tblHandover handover)
        {
            var db = Instance();
            db.AddTotblHandovers(handover);
            return db.SaveChanges();
        }

        public static tblHandover FindHandoverByID(long id)
        {
            var db = Instance();
            return db.tblHandovers.Where(g => g.ID == id).FirstOrDefault();

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

        public static int InsertToKhaiTauResource(tblToKhaiTauResource resource)
        {
            var db = Instance();
            db.AddTotblToKhaiTauResources(resource);
            return db.SaveChanges();
        }
    }
}
