using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CampusGroups.API.Connection;
using CampusGroups.API.Entities;

namespace CampusGroups.API.DAO
{
    public class MessageDAO
    {
        private static MessageDAO instance;
        private CampusDbConnection connection;
        private SqlCommand command;

        private MessageDAO()
        {
            connection = CampusDbConnection.getInstance();
            command = connection.getConnection().CreateCommand();
           
        }

        public static MessageDAO getMessageGroupDAO()
        {
            if (instance == null)
            {
                instance = new MessageDAO();
            }
            return instance;
        }

        public void insertMessage(CampusGroups.API.Entities.Message message)
        {
            var messageQuery = "INSERT INTO Message VALUES(@senderAccountId, @text, @subject, @datesent, @messageGroupId, @actuality, @changeDate)";

            command.CommandText = messageQuery;
            command.Parameters.Add("@text", message.Text);
            command.Parameters.Add("@subject", message.Subject);
            command.Parameters.Add("@senderAccountId", message.SenderUserAccountId);
            command.Parameters.Add("@dateSent", message.DateSent);
            command.Parameters.Add("@messageGroupId", message.MessageGroupId);
            command.Parameters.Add("@actuality", message.vcActuality);
            command.Parameters.Add("@changeDate", message.vcChangeDate);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void updateMessageText(int messageId, string newText)
        {
            var query = "UPDATE Message SET Text = @newText WHERE MessageId = @messageId";

            command.CommandText = query;
            command.Parameters.Add("@newText", newText);
            command.Parameters.Add("@messageId", messageId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void deleteMessage(int messageId)
        {
            var query = "DELETE FROM dbo.Message WHERE MessageId = @messageID";

            command.CommandText = query;
            command.Parameters.Add("@messageID", messageId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void insertMessageDetail(CampusGroups.API.Entities.MessageDetail messageDetail)
        {
            var messageDetailsQuery = "INSERT INTO MessageDetail VALUES(@messageId, @userAccountId, @dateRead, @dateView, @dateDelete, @actuality, @changeDate)";
            command.CommandText = messageDetailsQuery;
            command.Parameters.Add("@messageId", messageDetail.MessageId);
            command.Parameters.Add("@userAccountId", messageDetail.UserAccountId);
            command.Parameters.Add("@dateRead", messageDetail.DateRead);
            command.Parameters.Add("@dateView", messageDetail.DateView);
            command.Parameters.Add("@dateDelete", messageDetail.DateDelete);
            command.Parameters.Add("@actuality", messageDetail.vcActuality);
            command.Parameters.Add("@changeDate", messageDetail.vcChangeDate);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void updateMessageDetailDateRead(int messageDetailId, DateTime dateRead)
        {
            var query = "UPDATE MessageDetail SET DateRead = @dateRead WHERE MessageDetailId = @messageDetailId";

            command.CommandText = query;
            command.Parameters.Add("@dateRead", dateRead);
            command.Parameters.Add("@messageDetailId", messageDetailId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void updateMessageDetailDateView(int messageDetailId, DateTime dateView)
        {
            var query = "UPDATE MessageDetail SET DateView = @dateView WHERE MessageDetailId = @messageDetailId";

            command.CommandText = query;
            command.Parameters.Add("@dateView", dateView);
            command.Parameters.Add("@messageDetailId", messageDetailId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void updateMessageDetailDateDelete(int messageDetailId, DateTime dateDelete)
        {
            var query = "UPDATE MessageDetail SET DateDelete = @dateDelete WHERE MessageDetailId = @messageDetailId";

            command.CommandText = query;
            command.Parameters.Add("@dateDelete", dateDelete);
            command.Parameters.Add("@messageDetailId", messageDetailId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void deleteMessageDetail(int messageDetailId)
        {
            var query = "DELETE FROM MessageDetail WHERE MessageDetailId = @messageDetailId";

            command.CommandText = query;
            command.Parameters.Add("@messageDetailId", messageDetailId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public List<CampusGroups.API.Entities.Message> getAllUserMessages(int userAccountId)
        {
            List<CampusGroups.API.Entities.Message> messages = new List<CampusGroups.API.Entities.Message>();
            var query = "SELECT * FROM Message WHERE SenderUserAccountId = @userAccountId";

            command.CommandText = query;
            command.Parameters.Add("@userAccountId", userAccountId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                while (reader.Read())
                {
                    CampusGroups.API.Entities.Message message = new CampusGroups.API.Entities.Message();

                    message.MessageId = reader.GetInt32(0);
                    message.SenderUserAccountId = reader.GetInt32(1);
                    message.Text = reader.GetString(2);
                    message.Subject = reader.GetString(3);
                    message.DateSent = reader.GetDateTime(4);
                    message.MessageGroupId = reader.GetInt32(5);
                    reader.GetChars(6, 0, buffer, 0, 1);
                    message.vcActuality = buffer[0];
                    message.vcChangeDate = reader.GetDateTime(4);

                    messages.Add(message);
                }
            }
            reader.Close();
            command.Dispose();

            return messages;
        }

        public List<CampusGroups.API.Entities.Message> getMessagesByGroup(int messageGroupId)
        {
            List<CampusGroups.API.Entities.Message> messages = new List<CampusGroups.API.Entities.Message>();
            var query = "SELECT * FROM Message WHERE MessageGroupId = @messageGroupId";

            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                while (reader.Read())
                {
                    CampusGroups.API.Entities.Message message = new CampusGroups.API.Entities.Message();

                    message.MessageId = reader.GetInt32(0);
                    message.SenderUserAccountId = reader.GetInt32(1);
                    message.Text = reader.GetString(2);
                    message.Subject = reader.GetString(3);
                    message.DateSent = reader.GetDateTime(4);
                    message.MessageGroupId = reader.GetInt32(5);
                    reader.GetChars(6, 0, buffer, 0, 1);
                    message.vcActuality = buffer[0];
                    message.vcChangeDate = reader.GetDateTime(4);

                    messages.Add(message);
                }
            }
            reader.Close();
            command.Dispose();

            return messages;
        }

        public List<CampusGroups.API.Entities.Message> getMessagesByGroupAndUser(int messageGroupId, int userAccountId)
        {
            List<CampusGroups.API.Entities.Message> messages = new List<CampusGroups.API.Entities.Message>();
            var query = "SELECT * FROM Message WHERE MessageGroupId = @messageGroupId AND SenderUserAccountId = @userAccountId";

            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            command.Parameters.Add("@userAccountId", userAccountId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                while (reader.Read())
                {
                    CampusGroups.API.Entities.Message message = new CampusGroups.API.Entities.Message();

                    message.MessageId = reader.GetInt32(0);
                    message.SenderUserAccountId = reader.GetInt32(1);
                    message.Text = reader.GetString(2);
                    message.Subject = reader.GetString(3);
                    message.DateSent = reader.GetDateTime(4);
                    message.MessageGroupId = reader.GetInt32(5);
                    reader.GetChars(6, 0, buffer, 0, 1);
                    message.vcActuality = buffer[0];
                    message.vcChangeDate = reader.GetDateTime(4);

                    messages.Add(message);
                }
            }
            reader.Close();
            command.Dispose();

            return messages;
        }
    }
}