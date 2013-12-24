using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CampusGroups.data;

namespace CampusGroups.dao
{
    public class UserDAO
    {
        private static UserDAO instance;
        private CampusDbConnection connection;
        private SqlCommand command;
        private dbCAmpusGroupsDataContext db;

        public static String DEFAULT_AVATAR_PATH = @"~\avatars\noavatar.jpg";
        public static int ADMIN_STATUS_ID = 1;
        public static int USER_STATUS_ID = 2;
        

        private UserDAO()
        {
            connection = CampusDbConnection.getInstance();
            command = connection.getConnection().CreateCommand();
            db = new dbCAmpusGroupsDataContext(@"Data Source=.\sqlexpress;Initial Catalog=dbCampusGroups;Integrated Security=True");  
        }

        public static UserDAO getUserDAO()
        {
            if (instance == null)
            {
                instance = new UserDAO();
            }
            return instance;
        }

        public int getCampusUserAccountIdByLoginPassword(String login, String password)
        {
            int id = 0;
            var query = "SELECT * FROM UserAccount WHERE (Login = '" + login + "') AND (Password = '" + password + "')";
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            reader.Close();
            return id;         
        }

        public void updateUserAvatar(User user, string newLink)
        {
            user.avatarLink = newLink;
            db.SubmitChanges();
        }

        public List<User> getAllUsers()
        {
            var query = from usr in db.Users select usr;
            if (query.Any())
                return query.ToList();
            else
                return null;
        }

        public Role getUserRole(User user, Group currentGroup)
        {
            var query = from userGroups in db.UserGroups
                        join role in db.Roles on userGroups.roleId equals role.roleId
                        where userGroups.userId == user.userId && userGroups.groupId == currentGroup.groupId
                        select role;
            if (query.Any())
                return query.First();
            else
                return null;
        }

        public User getGroupUserByUserId(int id)
        {
            var query = from user in db.Users where user.userId == id select user;
            if (query.Any())
                return query.First();
            else
                return null;
        }

        public String getUserNameByCampusUserAccountId(int id)
        {
            String name = "";
            var query = "SELECT FullName FROM UserAccount WHERE UserAccountId = '" + id + "'";
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                name = reader.GetString(0);
            }
            reader.Close();
            return name;
        }

        public String getProfileNameByCampusUserAccountId(int id)
        {
            String name = "";
            var query = "SELECT DcProfile.Name FROM UserAccount JOIN UserAccountLinkDcProfile " +
                        "ON UserAccountLinkDcProfile.UserAccountId = UserAccount.UserAccountId " +
                        "JOIN DcProfile ON UserAccountLinkDcProfile.DcProfileId = DcProfile.DcProfileId " + 
                        "WHERE UserAccount.UserAccountId = " + id;
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                name = reader.GetString(0);
            }
            reader.Close();
            return name;
        }

        public String getSubdivisionNameByCampusUserAccountId(int id)
        {
            String name = "";
            var query = "SELECT DcSubdivision.Name FROM UserAccount JOIN UserAccountLinkDcProfile " +
                        "ON UserAccountLinkDcProfile.UserAccountId = UserAccount.UserAccountId " +
                        "JOIN DcSubdivision ON UserAccountLinkDcProfile.DcSubdivisionId = DcSubdivision.DcSubdivisionId " +
                        "WHERE UserAccount.UserAccountId = " + id;
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                name = reader.GetString(0);
            }
            reader.Close();
            return name;
        }

        public void addUser(User user)
        {
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
        }

        public User getGroupsUserByCampusAccountId(int id)
        {
            var userList = from users in db.Users where users.campusUserId == id select users;
            if (userList.Any())
                return userList.First();
            else
                return null;
        }

        public int getCampusUserIdByGroupsUserId(int id)
        {
            var query = (from users in db.Users where users.userId == id select users).First();
            return query.campusUserId;
        }

        public string getAvatarLinkByGroupsUserId(int id)
        {
            var query = (from users in db.Users where users.userId == id select users).First();
            return query.avatarLink;
        }
    }
}