using System;
using System.Collections.Generic;
using System.Linq;
using ETrains.DAL;
using ETrains.Utilities;
using log4net;

namespace ETrains.BOL
{
    public class UserFactory
    {
        //private static ILog logger = LogManager.GetLogger("ECustoms.UserFactory");
        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="userInfo">The user info.</param>
        /// <returns></returns>
        public static tblUser GetUserInfo(tblUser userInfo)
        {
                var db = new dbTrainEntities(ConnectionController.GetConnection());
                // Encode the password & username
                userInfo.Password = Common.Encode(userInfo.Password);
                return
                    db.tblUsers.Where(g => g.UserName.Equals(userInfo.UserName, StringComparison.OrdinalIgnoreCase) && g.Password.Equals(userInfo.Password) && g.IsActive == 1).
                        FirstOrDefault();
        }

        /// <summary>
        /// Insert User
        /// </summary>
        /// <param name="userInfo">UserInfo object</param>
        /// <returns>Number of rows are effected</returns>
        public static int Insert(tblUser userInfo)
        {
            // Encode password & username
            userInfo.Password = Common.Encode(userInfo.Password);
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            db.AddTotblUsers(userInfo);
            var re = db.SaveChanges();
            return re;
        }

        /// <summary>
        /// Checks the is user existing.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public static bool CheckIsUserExisting(string username)
        {
            try
            {
                var db = new dbTrainEntities(ConnectionController.GetConnection());
                var result = false;
                var users = db.tblUsers.Where(g => g.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();
                if (users.Count > 0)
                {
                    result = true;
                }
                if (users.Count == 0) result = false;
                return result;
            }
            catch (Exception ex)
            {
                //logger.Error(ex.ToString());
                throw;
            }
        }

        public static tblUser GetByID(int userID)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            var user = db.tblUsers.Where(g => g.UserID.Equals(userID)).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="userInfo">userInfo object</param>
        /// <returns>Number of rows are effected</returns>
        public static int Update(tblUser userInfo)
        {
            // Encode password & username
            userInfo.Password = Common.Encode(userInfo.Password);

            var db = new dbTrainEntities(ConnectionController.GetConnection());
            var usrOrgin = db.tblUsers.Where(g => g.UserID == userInfo.UserID).FirstOrDefault();
            if (usrOrgin == null) return -1;
            db.Attach(usrOrgin);
            db.ApplyPropertyChanges("tblUsers", userInfo);
            return db.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified user ID.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public static int Delete(int userID)
        {
            try
            {
                var db = new dbTrainEntities(ConnectionController.GetConnection());
                var user = db.tblUsers.Where(g => g.UserID.Equals(userID)).FirstOrDefault();
                db.DeleteObject(user);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                //logger.Error(ex.ToString());
                throw;
            }
        }


        public static List<tblUser> SelectAllUser()
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            List<tblUser> list = db.tblUsers.OrderBy(g => g.Name).ToList();
            return list;
        }

        public static List<tblUser> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return SelectAllUser();
            }
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            List<tblUser> list = db.tblUsers.Where(g => g.Name.Contains(name)).OrderByDescending(g => g.Name).ToList();
            return list;
        }

        public static tblUser getUserByUserName(string userName)
        {
            var db = new dbTrainEntities(ConnectionController.GetConnection());
            tblUser user = db.tblUsers.Where(g => g.UserName == userName).FirstOrDefault();
            return user;
        }        
    }
}
