using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampusGroups.API;

namespace CampusGroups.API
{
    public class MessageGroupDAO
    {
        private MessageGroupDAO instance;
        private CampusGroupsDataContext context;
        private String connectionString = @"Data Source=tcp:10.13.125.167,1433;Initial Catalog=rIrCampus1.8TestElizaveta;User ID=veres;Password=dima12345";

        private MessageGroupDAO()
        {
            context = new CampusGroupsDataContext(connectionString);
        }

        public MessageGroupDAO getGroupUserDAO()
        {
            if (instance == null)
                instance = new MessageGroupDAO();
            return instance;
        }

        public MessageGroup getMessageGroupById(int groupId)
        {
            var groups = from messageGroup in context.MessageGroups where messageGroup.MessageGroupId == groupId select messageGroup;
            if (groups.Any())
                return groups.First();
            else
                return null;
        }

        public void insertMessageGroup(MessageGroup messageGroup)
        {
            context.MessageGroups.InsertOnSubmit(messageGroup);
            context.SubmitChanges();
        }

        public List<MessageGroup> getMessageGroupsByUser(UserAccount user)
        {
            var groups = from messageGroup in context.MessageGroups
                         join messageGroupUser in context.MessageGroupUsers
                         on messageGroup.MessageGroupId equals messageGroupUser.MessageGroupId
                         join userAccount in context.UserAccounts
                         on messageGroupUser.UserAccountId equals userAccount.UserAccountId
                         where userAccount.UserAccountId == user.UserAccountId
                         select messageGroup;
            if (groups.Any())
                return groups.ToList();
            else
                return null;
        }

        public void createMessageGroup(MessageGroup messageGroup, UserAccount creator)
        {
            insertMessageGroup(messageGroup);
            MessageGroupUser user = new MessageGroupUser();
            user.UserAccountId = creator.UserAccountId;
            user.MessageGroupId = messageGroup.MessageGroupId;
            user.vcActuality = '0';
            user.vcChangeDate = System.DateTime.Now;
            context.MessageGroupUsers.InsertOnSubmit(user);
            context.SubmitChanges();
        }

        public List<MessageGroup> getAllMessageGroups()
        {
            var groups = from messageGroup in context.MessageGroups select messageGroup;
            if (groups.Any())
                return groups.ToList();
            else
                return null;
        }

        public List<UserAccount> getUserAccountsByMessageGroup(MessageGroup messageGroup)
        {
            var userAccounts = from mGroup in context.MessageGroups
                               join messageGroupUser in context.MessageGroupUsers
                                   on mGroup.MessageGroupId equals messageGroupUser.MessageGroupId
                               join user in context.UserAccounts on messageGroupUser.UserAccountId equals user.UserAccountId
                               where mGroup.MessageGroupId == messageGroup.MessageGroupId
                               select user;
            if (userAccounts.Any())
                return userAccounts.ToList();
            else
                return null;
        }

        public void addUserInMessageGroup(MessageGroup messageGroup, UserAccount account)
        {
            MessageGroupUser userGroup = new MessageGroupUser();
            userGroup.UserAccountId = account.UserAccountId;
            userGroup.MessageGroupId = messageGroup.MessageGroupId;
            userGroup.vcActuality = '0';
            userGroup.vcChangeDate = System.DateTime.Now;
            context.MessageGroupUsers.InsertOnSubmit(userGroup);
            context.SubmitChanges();
        }

        public void deleteUserFromGroup(MessageGroup messageGroup, UserAccount account)
        {
            var user = from userGroup in context.MessageGroupUsers where userGroup.UserAccountId == account.UserAccountId && userGroup.MessageGroupId == messageGroup.MessageGroupId select userGroup;
            if (user.Any())
                context.MessageGroupUsers.DeleteOnSubmit(user.First());
            context.SubmitChanges();
        }

        public bool isUserInMessageGroup(MessageGroup messageGroup, UserAccount account)
        {
            var user = from userGroup in context.MessageGroupUsers where userGroup.UserAccountId == account.UserAccountId && userGroup.MessageGroupId == messageGroup.MessageGroupId select userGroup;
            if (user.Any())
                return true;
            else
                return false;
        }


    }
}