using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CampusGroups.dao
{
    public class CampusDbConnection
    {
        private static CampusDbConnection instance;

        private static String connectionString = @"Data Source=tcp:10.13.125.167,1433;Initial Catalog=rIrCampus1.8Test;User ID=veres";
        private SqlConnection campusConnection;

        private CampusDbConnection()
        {
            campusConnection = new SqlConnection(connectionString);
            campusConnection.Open();
        }

        public static CampusDbConnection getInstance()
        {
            if (instance == null)
            {
                instance = new CampusDbConnection();
            }

            return instance;
        }

        public SqlConnection getConnection()
        {
            return campusConnection;
        }
    }
}