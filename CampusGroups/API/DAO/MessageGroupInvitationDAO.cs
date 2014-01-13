using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CampusGroups.API.Connection;
using CampusGroups.API.Entities;

namespace CampusGroups.API.DAO
{
    public class MessageGroupInvitationDAO
    {
        private static MessageGroupInvitationDAO instance;
        private CampusDbConnection connection;
        private SqlCommand command;

        private MessageGroupInvitationDAO()
        {
            connection = CampusDbConnection.getInstance();
            command = connection.getConnection().CreateCommand();
           
        }

        public static MessageGroupInvitationDAO getMessageGroupInvitationDAO()
        {
            if (instance == null)
            {
                instance = new MessageGroupInvitationDAO();
            }
            return instance;
        }

        public void insertMessageGroupInvitation(CampusGroups.API.Entities.MessageGroupInvitation invitation)
        {
            var query = "INSERT INTO MessageGroupInvitation VALUES(@messageGroupId, @userAccountId, @invitationDate, @isProcessed, @actuality, @changeDate)";

            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", invitation.MessageGrouptId);
            command.Parameters.Add("@userAccountId", invitation.UserAccountId);
            command.Parameters.Add("@invitationDate", invitation.InvitationDate);
            command.Parameters.Add("@isProcessed", invitation.IsProcessed);
            command.Parameters.Add("@actuality", invitation.vcActuality);
            command.Parameters.Add("@changeDate",invitation.vcChangeDate);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void updateMessageGroupInvitationProcessed(int messageGroupInvitationId, int isProcessed)
        {
            var query = "UPDATE MessageGroupInvitation SET IsProcessed = @isProcessed WHERE MessageGroupInvitationId = @messageGroupInvitationId";

            command.CommandText = query;
            command.Parameters.Add("@isProcessed", isProcessed);
            command.Parameters.Add("@messageGroupInvitationId", messageGroupInvitationId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void deleteMessageGroupInvitation(int messageGroupInvitationId)
        {
            var query = "DELETE FROM MessageGroupInvitation WHERE MessageGroupInvitationId = @messageGroupInvitationId";

            command.CommandText = query;
            command.Parameters.Add("@messageGroupInvitationId", messageGroupInvitationId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public List<CampusGroups.API.Entities.MessageGroupInvitation> getUnprocessedInvitationsByGroupId(int messageGroupId)
        {
            List<CampusGroups.API.Entities.MessageGroupInvitation> invitations = new List<Entities.MessageGroupInvitation>();
            var query = "SELECT * FROM MessageGroupInvitation WHERE MessageGroupId = @messageGroupId";
            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                while (reader.Read())
                {
                    CampusGroups.API.Entities.MessageGroupInvitation invitation = new Entities.MessageGroupInvitation();
                    invitation.MessageGroupInvitationId = reader.GetInt32(0);
                    invitation.MessageGrouptId = reader.GetInt32(1);
                    invitation.UserAccountId = reader.GetInt32(2);
                    invitation.InvitationDate = reader.GetDateTime(3);
                    invitation.IsProcessed = reader.GetInt32(4);
                    reader.GetChars(5, 0, buffer, 0, 1);
                    invitation.vcActuality = buffer[0];
                    invitation.vcChangeDate = reader.GetDateTime(6);
                }
            }
            reader.Close();
            command.Dispose();

            return invitations;
        }

        public List<CampusGroups.API.Entities.MessageGroupInvitation> getUnprocessedInvitationsByUserAccountId(int userAccountId)
        {
            List<CampusGroups.API.Entities.MessageGroupInvitation> invitations = new List<Entities.MessageGroupInvitation>();
            var query = "SELECT * FROM MessageGroupInvitation WHERE UserAccountId = @userAccountId";
            command.CommandText = query;
            command.Parameters.Add("@userAccountId", userAccountId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                while (reader.Read())
                {
                    CampusGroups.API.Entities.MessageGroupInvitation invitation = new Entities.MessageGroupInvitation();
                    invitation.MessageGroupInvitationId = reader.GetInt32(0);
                    invitation.MessageGrouptId = reader.GetInt32(1);
                    invitation.UserAccountId = reader.GetInt32(2);
                    invitation.InvitationDate = reader.GetDateTime(3);
                    invitation.IsProcessed = reader.GetInt32(4);
                    reader.GetChars(5, 0, buffer, 0, 1);
                    invitation.vcActuality = buffer[0];
                    invitation.vcChangeDate = reader.GetDateTime(6);
                }
            }
            reader.Close();
            command.Dispose();

            return invitations;
        }
    }
}