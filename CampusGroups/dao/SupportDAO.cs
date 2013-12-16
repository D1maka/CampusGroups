using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampusGroups.data;
using CampusGroups.dao;

namespace CampusGroups.dao
{
    public class SupportDAO
    {
        public static SupportDAO instance;
        CampusDbConnection connection;
        private dbCAmpusGroupsDataContext db;

        private SupportDAO() 
        {
            connection = CampusDbConnection.getInstance();
            db = new dbCAmpusGroupsDataContext(@"Data Source=.\sqlexpress;Initial Catalog=dbCampusGroups;Integrated Security=True"); 
        }

        public static SupportDAO getSupportDAO()
        {
            if (instance == null)
            {
                instance = new SupportDAO();
            }
            return instance;
        }

        public Role getModeratorRole()
        {
            var query = (from roles in db.Roles where roles.roleId == 1 select roles).First();
            return query;
        }

        public Role getUserRole()
        {
            var query = (from roles in db.Roles where roles.roleId == 2 select roles).First();
            return query;
        }
    }
}