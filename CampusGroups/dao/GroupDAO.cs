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
    }
}