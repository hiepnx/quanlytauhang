using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETrains.DAL;
using ETrains.Utilities;
using log4net;
namespace ETrains.BOL
{
  public class UserInGroupFactory
  {
    public static List<ViewUserGroup> GetByUserID(int userID)
    {
      var db = new dbTrainEntities(ConnectionController.GetConnection());
      List<ViewUserGroup> list = db.ViewUserGroups.Where(g => g.UserID == userID).ToList();
      db.Connection.Close();
      return list;
    }

    public static List<ViewUserGroup> GetByGroupID(int groupID)
    {
      var db = new dbTrainEntities(ConnectionController.GetConnection());
      var userGroups = db.ViewUserGroups.Where(g => g.GroupID == groupID).ToList();
      db.Connection.Close();
      return userGroups;
    }

    public static List<tblUserInGroup> GetTblUserInGroupByGroupID(int groupID)
    {
      var db = new dbTrainEntities(ConnectionController.GetConnection());
      var userGroups = db.tblUserInGroups.Where(g => g.GroupID == groupID).ToList();
      db.Connection.Close();
      return userGroups;
    }

    public static int Insert(tblUserInGroup userGroup)
    {
      var db = new dbTrainEntities(ConnectionController.GetConnection());
      db.AddTotblUserInGroups(userGroup);
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int DeleteUserInGroupByUserID(int userID)
    {
      var db = new dbTrainEntities(ConnectionController.GetConnection());
      List<tblUserInGroup> listTblUserInGroup = db.tblUserInGroups.Where(g => g.UserID == userID).ToList();
      foreach (tblUserInGroup userInGroup in listTblUserInGroup)
      {
        db.DeleteObject(userInGroup);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int DeleteUserInGroupByGroupID(Int32 groupID)
    {
      var db = new dbTrainEntities(ConnectionController.GetConnection());
      List<tblUserInGroup> listTblUserInGroup = db.tblUserInGroups.Where(g => g.GroupID == groupID).ToList();
      foreach (tblUserInGroup userInGroup in listTblUserInGroup)
      {
        db.DeleteObject(userInGroup);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int DeleteUserInGroup(int groupID, int userID)
    {
      var db = new dbTrainEntities(ConnectionController.GetConnection());
      tblUserInGroup tblUserInGroup = db.tblUserInGroups.Where(g => g.GroupID == groupID && g.UserID == userID).FirstOrDefault();
      if (tblUserInGroup != null)
        db.DeleteObject(tblUserInGroup);
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }


  }
}
