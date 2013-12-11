using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusGroups.dao
{
    public class SupportDAO
    {
        public static SupportDAO instance;
        CampusDbConnection connection;

        private SupportDAO() 
        {
            connection = CampusDbConnection.getInstance();
        }

        public static SupportDAO getInstance()
        {
            if (instance == null)
            {
                instance = new SupportDAO();
            }
            return instance;
        }
    }
}