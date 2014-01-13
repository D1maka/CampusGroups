using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CampusGroups.API.Connection;
using CampusGroups.API.Entities;

namespace CampusGroups.API.DAO
{
    public class MessageGroupRequestDAO
    {
        private static MessageGroupRequestDAO instance;
        private CampusDbConnection connection;
        private SqlCommand command;

        private MessageGroupRequestDAO()
        {
            connection = CampusDbConnection.getInstance();
            command = connection.getConnection().CreateCommand();
           
        }

        public static MessageGroupRequestDAO getMessageGroupRequestDAO()
        {
            if (instance == null)
            {
                instance = new MessageGroupRequestDAO();
            }
            return instance;
        }

        public void insertMessageGroupRequest(CampusGroups.API.Entities.MessageGroupRequest messageGroupRequest)
        {
            var query = "INSERT INTO MessageGroupRequest VALUES(@messageGroupId, @userAccountId, @requestDate, @isProcessed, @actuality, @changeDate)";

            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupRequest.MessageGrouptId);
            command.Parameters.Add("@userAccountId", messageGroupRequest.UserAccountId);
            command.Parameters.Add("@requestDate", messageGroupRequest.RequestDate);
            command.Parameters.Add("@isProcessed", messageGroupRequest.IsProcessed);
            command.Parameters.Add("@actuality", messageGroupRequest.vcActuality);
            command.Parameters.Add("@changeDate", messageGroupRequest.vcChangeDate);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void updateMessageGroupRequestProcessed(int messageGroupRequestId, int isProcessed)
        {
            var query = "UPDATE MessageGroupRequest SET IsProcessed = @isProcessed WHERE MessageGroupRequestId = @messageGroupRequestId";

            command.CommandText = query;
            command.Parameters.Add("@isProcessed", isProcessed);
            command.Parameters.Add("@messageGroupRequestId", messageGroupRequestId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void deleteMessageGroupRequest(int messageGroupRequestId)
        {
            var query = "DELETE FROM MessageGroupRequest WHERE MessageGroupRequestId = @messageGroupRequestId";

            command.CommandText = query;
            command.Parameters.Add("@messageGroupRequestId", messageGroupRequestId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public List<CampusGroups.API.Entities.MessageGroupRequest> getUnprocessedRequestsByUserAccountId(int userAccountId)
        {
            List<CampusGroups.API.Entities.MessageGroupRequest> requests = new List<Entities.MessageGroupRequest>();
            var query = "SELECT * FROM MessageGroupRequest WHERE UserAccountId = @userAccountId";
            command.CommandText = query;
            command.Parameters.Add("@userAccountId", userAccountId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                while (reader.Read())
                {
                    CampusGroups.API.Entities.MessageGroupRequest request = new Entities.MessageGroupRequest();
                    request.MessageGroupRequestId = reader.GetInt32(0);
                    request.MessageGrouptId = reader.GetInt32(1);
                    request.UserAccountId = reader.GetInt32(2);
                    request.RequestDate = reader.GetDateTime(3);
                    request.IsProcessed = reader.GetInt32(4);
                    reader.GetChars(5, 0, buffer, 0, 1);
                    request.vcActuality = buffer[0];
                    request.vcChangeDate = reader.GetDateTime(6);
                }
            }
            reader.Close();
            command.Dispose();

            return requests;
        }

        public List<CampusGroups.API.Entities.MessageGroupRequest> getUnprocessedRequestsByGroupId(int messageGroupId)
        {
            List<CampusGroups.API.Entities.MessageGroupRequest> requests = new List<Entities.MessageGroupRequest>();
            var query = "SELECT * FROM MessageGroupRequest WHERE MessageGroupId = @messageGroupId";
            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                while (reader.Read())
                {
                    CampusGroups.API.Entities.MessageGroupRequest request = new Entities.MessageGroupRequest();
                    request.MessageGroupRequestId = reader.GetInt32(0);
                    request.MessageGrouptId = reader.GetInt32(1);
                    request.UserAccountId = reader.GetInt32(2);
                    request.RequestDate = reader.GetDateTime(3);
                    request.IsProcessed = reader.GetInt32(4);
                    reader.GetChars(5, 0, buffer, 0, 1);
                    request.vcActuality = buffer[0];
                    request.vcChangeDate = reader.GetDateTime(6);
                }
            }
            reader.Close();
            command.Dispose();

            return requests;
        }
    }
}