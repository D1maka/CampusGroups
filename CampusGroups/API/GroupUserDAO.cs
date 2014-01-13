using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampusGroups.API;

namespace CampusGroups.dao
{
    public class GroupUserDAO
    {
        private GroupUserDAO instance;
        private CampusGroupsDataContext context;
        private String connectionString = @"Data Source=tcp:10.13.125.167,1433;Initial Catalog=rIrCampus1.8TestElizaveta;User ID=veres;Password=dima12345";

        private GroupUserDAO()
        {
            context = new CampusGroupsDataContext(connectionString);
        }

        public GroupUserDAO getGroupUserDAO()
        {
            if (instance == null)
                instance = new GroupUserDAO();
            return instance;
        }

        public UserAccount getUserAccountIdByLoginPassword(string login, string pass)
        {
            var users = from account in context.UserAccounts where account.Login == login && account.Password == pass select account;
            if (users.Any())
                return users.First();
            else
                return null;
        }

        public List<UserAccount> getAllAccounts()
        {
            var accounts = from account in context.UserAccounts select account;
            if (accounts.Any())
                return accounts.ToList();
            else
                return null;
        }

        public UserAccount getUserAccountByAccountId(int id)
        {
            var accounts = from account in context.UserAccounts where account.UserAccountId == id select account;
            if (accounts.Any())
                return accounts.First();
            else
                return null;
        }

        public DcProfile getProfileByUserAccount(UserAccount user)
        {
            var profiles = from account in context.UserAccounts
                           join accountLinkProfile in context.UserAccountLinkDcProfiles on account.UserAccountId equals accountLinkProfile.UserAccountId
                           join profile in context.DcProfiles on accountLinkProfile.DcProfileId equals profile.DcProfileId
                           where account.UserAccountId == user.UserAccountId
                           select profile;
            if (profiles.Any())
                return profiles.First();
            else
                return null;
        }
    }
}