using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampusGroups.data;
using CampusGroups.dao;

namespace CampusGroups.dao
{
    public class SupportDAO
    {
        public static SupportDAO instance;
        CampusDbConnection connection;
        private dbCAmpusGroupsDataContext db;

        private SupportDAO() 
        {
            connection = CampusDbConnection.getInstance();
            db = new dbCAmpusGroupsDataContext(@"Data Source=.\sqlexpress;Initial Catalog=dbCampusGroups;Integrated Security=True"); 
        }

        public static SupportDAO getSupportDAO()
        {
            if (instance == null)
            {
                instance = new SupportDAO();
            }
            return instance;
        }

        public Role getModeratorRole()
        {
            var query = (from roles in db.Roles where roles.roleId == 1 select roles).First();
            return query;
        }

        public Role getUserRole()
        {
            var query = (from roles in db.Roles where roles.roleId == 2 select roles).First();
            return query;
        }

        public void insertRequest(User user, Group myGroup)
        {
            GroupRequest request = new GroupRequest();
            request.date = System.DateTime.Now;
            request.groupId = myGroup.groupId;
            request.userId = user.userId;
            request.processed = 0;
            db.GroupRequests.InsertOnSubmit(request);
            db.SubmitChanges();
        }

        public List<GroupRequest> getGroupRequestByGroup(Group myGroup)
        {
            var query = (from request in db.GroupRequests where request.groupId == myGroup.groupId select request);
            if(query.Any())
                return query.ToList();
            else
                return null;
        }

        public List<GroupRequest> getUnprocessedGroupRequestByGroup(Group myGroup)
        {
            var query = (from request in db.GroupRequests where request.groupId == myGroup.groupId && request.processed == 0 select request);
            if (query.Any())
                return query.ToList();
            else
                return null;
        }

        public void insertAttachment(Attachment att)
        {
            db.Attachments.InsertOnSubmit(att);
            db.SubmitChanges();
        }

        public List<Role> getRoles()
        {
            var query = from role in db.Roles select role;
            return query.ToList();
        }

        public List<GroupRequest> getUnprocessedRequestByUserGroup(Group myGroup, User user)
        {
            var query = (from request in db.GroupRequests where request.groupId == myGroup.groupId && request.userId == user.userId && request.processed == 0 select request);
            if (query.Any())
                return query.ToList();
            else
                return null;
        }

        public void processRequest(GroupRequest request, int agreement)
        {
            request.processed = 1;
            if (agreement == 1)
            {
                GroupDAO groupDAO = GroupDAO.getGroupDAO();
                UserDAO userDAO = UserDAO.getUserDAO();
                SupportDAO suppDAO = SupportDAO.getSupportDAO();
                Group currentGroup = groupDAO.getGroupByGroupId(request.groupId);
                User user = userDAO.getGroupUserByUserId(request.userId);
                groupDAO.addUser(currentGroup, user, suppDAO.getUserRole());
            }
            db.SubmitChanges();
        }
    }
}