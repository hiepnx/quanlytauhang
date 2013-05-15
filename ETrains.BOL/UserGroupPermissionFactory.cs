﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETrains.DAL;
using ETrains.Utilities;
using log4net;
namespace ETrains.BOL
{
  public class UserGroupPermissionFactory
  {
    public const int PERMISSION_TYPE_GROUP = 1;
    public const int PERMISSION_TYPE_USER = 2;

    public static List<tblUserGroupPermission> GetByGroupID(int groupID)
    {
        var db = new dbTrainEntities(ConnectionController.GetConnection());

      List<tblUserGroupPermission> list = db.tblUserGroupPermissions.Where(g => g.GroupID == groupID && g.PermissionType == PERMISSION_TYPE_GROUP).ToList();
      db.Connection.Close();
      return list;
    }

    public static List<tblUserGroupPermission> GetByUserID(int userID)
    {
        var db = new dbTrainEntities(ConnectionController.GetConnection());

      List<tblUserGroupPermission> list = db.tblUserGroupPermissions.Where(g => g.UserID == userID && g.PermissionType == PERMISSION_TYPE_USER).ToList();
      db.Connection.Close();
      return list;
    }

    public static int DeleteUserGroupPermissionByGroupID(int groupID)
    {
        var db = new dbTrainEntities(ConnectionController.GetConnection());
      List<tblUserGroupPermission> listUserGroupPermission = db.tblUserGroupPermissions.Where(g => g.GroupID == groupID && g.PermissionType == PERMISSION_TYPE_GROUP).ToList();
      foreach (tblUserGroupPermission userGroupPermission in listUserGroupPermission)
      {
        db.DeleteObject(userGroupPermission);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int DeleteUserGroupPermissionByUserID(int userID)
    {
        var db = new dbTrainEntities(ConnectionController.GetConnection());
      List<tblUserGroupPermission> listUserGroupPermission = db.tblUserGroupPermissions.Where(g => g.UserID == userID && g.PermissionType == PERMISSION_TYPE_USER).ToList();
      foreach (tblUserGroupPermission userGroupPermission in listUserGroupPermission)
      {
        db.DeleteObject(userGroupPermission);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int Insert(tblUserGroupPermission userGroupPermission)
    {
        var db = new dbTrainEntities(ConnectionController.GetConnection());
      db.AddTotblUserGroupPermissions(userGroupPermission);
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int Insert(List<tblUserGroupPermission> listUserGroupPermission)
    {
        var db = new dbTrainEntities(ConnectionController.GetConnection());

      foreach (tblUserGroupPermission userGroupPermission in listUserGroupPermission)
      {
        db.AddTotblUserGroupPermissions(userGroupPermission);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    //get all permission of Users (user's permissions and permission of Groups that User in them)
    public static List<int> GetAllPermissionOfUser(int userID)
    {
      List<int> listAllPermission = new List<int>();
      List<tblUserGroupPermission> listUserPermission = GetByUserID(userID);
      foreach (tblUserGroupPermission userGroupPermission in listUserPermission)
      {
        var permissionID = userGroupPermission.PermissionID;
        listAllPermission.Add((int)permissionID);
      }
      List<ViewUserGroup> listUserInGroup = UserInGroupFactory.GetByUserID(userID);
      foreach (ViewUserGroup userGroup in listUserInGroup)
      {
        List<tblUserGroupPermission> listGroupPermission = GetByGroupID(userGroup.GroupID);
        foreach (tblUserGroupPermission userGroupPermission in listGroupPermission)
        {
          var permissionID = userGroupPermission.PermissionID;
          if (listAllPermission.Contains((int)permissionID) == false)
          {
            listAllPermission.Add((int)permissionID);
          }
        }
      }
      return listAllPermission;
    }

    public static List<int> GetAllPermissionForAdmin()
    {
      List<int> listAllPermission = new List<int>();
      List<tblPermission> listPermission = PermissionFactory.GetAllPermission();
      foreach (tblPermission permission in listPermission)
      {
        var permissionID = permission.PermissionID;
        listAllPermission.Add((int)permissionID);
      }
      return listAllPermission;
    }

    //Check permission of UserID
    public bool chectPermission(int userID, int permissionID)
    {
      List<int> listAllPermission = GetAllPermissionOfUser(userID);
      if (listAllPermission != null && listAllPermission.Count > 0)
      {
        return listAllPermission.Contains(permissionID);
      }
      return false;
    }
  }
}
