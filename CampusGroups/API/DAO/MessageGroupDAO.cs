using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CampusGroups.API.Connection;
using CampusGroups.API.Entities;

namespace CampusGroups.API.DAO
{
    public class MessageGroupDAO
    {
        private static MessageGroupDAO instance;
        private CampusDbConnection connection;
        private SqlCommand command;

        private MessageGroupDAO()
        {
            connection = CampusDbConnection.getInstance();
            command = connection.getConnection().CreateCommand();
           
        }

        public static MessageGroupDAO getMessageGroupDAO()
        {
            if (instance == null)
            {
                instance = new MessageGroupDAO();
            }
            return instance;
        }

        public void createGroup(string groupName, char isPrivate)
        {
            var query = "INSERT INTO dbo.MessageGroup VALUES(@name, @isprivate, @actuality, @changeDate)";
            command.CommandText = query;
            command.Parameters.Add("@name", groupName);
            command.Parameters.Add("@isprivate", isPrivate);
            command.Parameters.Add("@actuality", '0');
            command.Parameters.Add("@changeDate", System.DateTime.Now);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void changeMessageGroupName(int messageGroupId, string newName)
        {
            var query = "UPDATE dbo.MessageGroup SET Name = @newName WHERE MessageGroupId = @id";
            command.CommandText = query;
            command.Parameters.Add("@newName", newName);
            command.Parameters.Add("@id", messageGroupId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void changeMessageGroupPrivacy(int messageGroupId, char isPrivate)
        {
            var query = "UPDATE dbo.MessageGroup SET IsPrivate = @isPrivate WHERE MessageGroupId = @id";
            command.CommandText = query;
            command.Parameters.Add("@isPrivate", isPrivate);
            command.Parameters.Add("@id", messageGroupId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void deleteMessageGroup(int messageGroupId)
        {
            var query = "DELETE FROM dbo.MessageGroup WHERE MessageGroupId = @id";
            command.CommandText = query;
            command.Parameters.Add("@id", messageGroupId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void addUser(int messageGroupId, int userAccountId, int isModetator)
        {
            var query = "INSERT INTO dbo.MessageGroupUser VALUES(@messageGroupId, @userAccountId, @actuality, @changeDate, @isModerator)";
            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            command.Parameters.Add("@userAccountId", userAccountId);
            command.Parameters.Add("@actuality", '0');
            command.Parameters.Add("@changeDate", System.DateTime.Now);
            command.Parameters.Add("@isModerator", isModetator);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void updateMessageGroupUserResponsibilities(int messageGroupId, int userAccountId, int isModetator)
        {
            var query = "UPDATE dbo.MessageGroupUser SET IsModerator = @isModerator WHERE MessageGroupId = @messageGroupId AND UserAccountId = @userAccountId";
            command.CommandText = query;
            command.Parameters.Add("@isModerator", isModetator);
            command.Parameters.Add("@messageGroupId", messageGroupId);
            command.Parameters.Add("@userAccountId", userAccountId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void deleteUser(int messageGroupId, int userAccountId)
        {
            var query = "DELETE FROM dbo.MessageGroupUser WHERE MessageGroupId = @messageGroupId AND UserAccountId = @userAccountId";
            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            command.Parameters.Add("@userAccountId", userAccountId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public CampusGroups.API.Entities.MessageGroup getMessageGroupsByMessageGroupId(int messageGroupId)
        {
            CampusGroups.API.Entities.MessageGroup messageGroup = new Entities.MessageGroup();
            var query = "SELECT * FROM MessageGroup WHERE MessageGroupId = @messageGroupId";
            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                if (reader.Read())
                {
                    messageGroup.MessageGroupId = reader.GetInt32(0);
                    messageGroup.Name = reader.GetString(1);
                    reader.GetChars(2, 0, buffer, 0, 1);
                    messageGroup.IsPrivate = buffer[0];
                    reader.GetChars(3, 0, buffer, 0, 1);
                    messageGroup.vsActuality = buffer[0];
                    messageGroup.vcChangeDate = reader.GetDateTime(4);
                }
            }
            reader.Close();
            command.Dispose();
            return messageGroup;
        }

        public List<CampusGroups.API.Entities.MessageGroup> getMessageGroupsByUserAccountId(int userAccountId)
        {
            List<CampusGroups.API.Entities.MessageGroup> messageGroups = new List<CampusGroups.API.Entities.MessageGroup>();
            var query = "SELECT * FROM MessageGroup JOIN MessageGroupUser ON MessageGroup.MessageGroupId = MessageGroupUser.MessageGroupId " +
                        "JOIN UserAccount ON UserAccount.UserAccountId = MessageGroupUser.UserAccountId WHERE UserAccount.UserAccountId = @userAccountId";
            command.CommandText = query;
            command.Parameters.Add("@userAccountId", userAccountId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                var buffer = new char[1];
                while (reader.Read())
                {
                    CampusGroups.API.Entities.MessageGroup currentGroup = new CampusGroups.API.Entities.MessageGroup();

                    currentGroup.MessageGroupId = reader.GetInt32(0);
                    currentGroup.Name = reader.GetString(1);
                    reader.GetChars(2, 0, buffer, 0, 1);
                    currentGroup.IsPrivate = buffer[0];
                    reader.GetChars(3, 0, buffer, 0, 1);
                    currentGroup.vsActuality = buffer[0];
                    currentGroup.vcChangeDate = reader.GetDateTime(4);

                    messageGroups.Add(currentGroup);
                }
            }
            reader.Close();
            command.Dispose();
            return messageGroups;
        }

        public List<int> getUsers(int messageGroupId)
        {
            List<int> userIds = new List<int>();
            var query = "SELECT UserAccountId FROM MessageGroupUser WHERE MessageGroupId = @messageGroupId";
            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userIds.Add(reader.GetInt32(0));
                }
            }
            reader.Close();
            command.Dispose();
            return userIds;
        }

        public bool isModerator(int messageGroupId, int userAccountId)
        {
            var query = "SELECT IsModerator FROM MessageGroupUser WHERE MessageGroupId = @messageGroupId AND UserAccountId = @userAccountId";
            command.CommandText = query;
            command.Parameters.Add("@messageGroupId", messageGroupId);
            command.Parameters.Add("@userAccountId", userAccountId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    int status = reader.GetInt32(0);
                    if (status == 0)
                        return false;
                    else
                        return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}