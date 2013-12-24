using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampusGroups.data;

namespace CampusGroups.dao
{
    public class GroupDAO
    {
        private static GroupDAO instance;
        private dbCAmpusGroupsDataContext db;

        private GroupDAO()
        {
            try {
                db = new dbCAmpusGroupsDataContext(@"Data Source=.\sqlexpress;Initial Catalog=dbCampusGroups;Integrated Security=True");    
            } catch {
            
            }
        }

        public static GroupDAO getGroupDAO()
        {
            if(instance == null)
            {
                instance = new GroupDAO();
            }
            return instance;
        }

        public Group getGroupByGroupId(int id)
        {
            var query = from myGroup in db.Groups where myGroup.groupId == id select myGroup;
            if(query.Any())
                return query.First();
            else
                return null;
        }

        public void addGroup(Group group)
        {
            db.Groups.InsertOnSubmit(group);
            db.SubmitChanges();
        }

        public List<Group> getGroupsByUser(User user)
        {
            var filteredGroups = (from groups in db.Groups join userGroups in db.UserGroups
                                  on groups.groupId equals userGroups.groupId join users in db.Users
                                  on userGroups.userId equals users.userId where userGroups.userId == user.userId
                                  select groups).ToList();
            return filteredGroups;
        }

        public void insertGroup(Group group, User creator)
        {
            db.Groups.InsertOnSubmit(group);
            db.SubmitChanges();
            UserGroup userGroup = new UserGroup();
            userGroup.groupId = group.groupId;
            userGroup.userId = creator.userId;
            userGroup.roleId = 1;
            db.UserGroups.InsertOnSubmit(userGroup);
            db.SubmitChanges();
        }

        public List<Group> getAllGroups()
        {
            var groups = (from groupIterator in db.Groups select groupIterator).ToList();
            return groups;
        }

        public List<User> getUsersByGroup(Group targetGroup)
        {
            var resultUsers = (from users in db.Users join userGroups in db.UserGroups
                        on users.userId equals userGroups.userId join groups in db.Groups
                        on userGroups.groupId equals groups.groupId where groups.groupId == targetGroup.groupId
                        select users).ToList();
            return resultUsers;
        }

        public void addUser(Group targetGroup, User targetUser, Role role)
        {
            UserGroup userGroup = new UserGroup();
            userGroup.userId = targetUser.userId;
            userGroup.groupId = targetGroup.groupId;
            userGroup.roleId = role.roleId;
            db.UserGroups.InsertOnSubmit(userGroup);
            db.SubmitChanges();
        }

        public bool isModerator(int groupId, int userId)
        {
            var query = from userGroups in db.UserGroups where userGroups.userId == userId && userGroups.groupId == groupId && userGroups.roleId == 1 select userGroups;
            if (query.Any())
                return true;
            else
                return false;
        }

        public void deleteGroup(Group myGroup)
        {
            var query = from userGroup in db.UserGroups where userGroup.groupId == myGroup.groupId select userGroup;
            foreach (var usrgrp in query)
            {
                db.UserGroups.DeleteOnSubmit(usrgrp);
            }
            db.SubmitChanges();
            db.Groups.DeleteOnSubmit(myGroup);
            db.SubmitChanges();
        }

        public void deleteUserFromGroup(Group myGroup, User user)
        {
            UserGroup userGroup = (from userGroups in db.UserGroups where userGroups.groupId == myGroup.groupId && userGroups.userId == user.userId select userGroups).First();
            myGroup.usersAmmount -= 1;
            if (myGroup.usersAmmount == 0)
                deleteGroup(myGroup);
            db.UserGroups.DeleteOnSubmit(userGroup);
            db.SubmitChanges();
        }

        public List<Invitation> getUnprocessedGroupsInvitationsByUser(User user)
        {
            var query = (from myInvitation in db.Invitations
                         join myUser in db.Users on myInvitation.userId equals myUser.userId
                         where myUser.userId == user.userId && myInvitation.processed == 0
                         select myInvitation);
            if (query.Any())
                return query.ToList();
            else
                return null;
        }

        public bool isUserInGroup(Group myGroup, User user)
        {
            //var resultUsers = (from users in db.Users
            //                   join userGroups in db.UserGroups
            //                       on users.userId equals userGroups.userId
            //                   join groups in db.Groups
            //                       on userGroups.groupId equals groups.groupId
            //                   where userGroups.groupId == myGroup.groupId && userGroups.userId == user.userId
            //                   select userGroups);
            //if (resultUsers.Any())
            //    return true;
            //else
            //    return false;
            List<Group> gr = getGroupsByUser(user);
            foreach (var g in gr)
            {
                if (g.groupId == myGroup.groupId)
                    return true;
            }
            return false;
        }

        public Invitation getInvitationByGroupAndUser(User user, Group invgroup)
        {
            var query = (from myGroup in db.Groups join myInvitation in db.Invitations on myGroup.groupId equals myInvitation.groupId
                         join myUser in db.Users on myInvitation.userId equals myUser.userId
                         where myUser.userId == user.userId && myInvitation.processed == 0 && myGroup.groupId == invgroup.groupId
                         select myInvitation);
            if (query.Any())
                return query.First();
            else
                return null;
        }

        public void processInvitation(Invitation inv, int agreement)
        {
            inv.processed = 1;
            if (agreement == 1)
            {
                UserDAO userDAO = UserDAO.getUserDAO();
                User usr = userDAO.getGroupUserByUserId(inv.userId);
                Group gr = getGroupByGroupId(inv.groupId);
                SupportDAO suppDAO = SupportDAO.getSupportDAO();
                Role role = suppDAO.getUserRole();
                addUser(gr, usr, role);
            }
            db.SubmitChanges();
        }

        public void insertInvitation(Invitation inv)
        {
            db.Invitations.InsertOnSubmit(inv);
            db.SubmitChanges();
        }
    }
}