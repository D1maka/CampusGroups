using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampusGroups.data;
using CampusGroups.dao;

namespace CampusGroups
{
    public partial class GroupItemControl : System.Web.UI.UserControl
    {
        public Group currentGroup
        { 
            get; 
            set; 
        }

        public string OuterPage
        { get; set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            this.groupNameBtn.Text = currentGroup.groupName;
            if (OuterPage.Equals("AllGroups"))
            {
                SupportDAO suppDAO = SupportDAO.getSupportDAO();
                GroupDAO groupDAO = GroupDAO.getGroupDAO();
                int id = Int32.Parse(Session["userCampusId"].ToString());
                UserDAO usrDAO = UserDAO.getUserDAO();
                User user = usrDAO.getGroupsUserByCampusAccountId(id);
                List<User> us = groupDAO.getUsersByGroup(currentGroup);
                bool isInGroup = false;
                List<Group> gr = groupDAO.getGroupsByUser(user);
                foreach (var g in gr)
                {
                    if (g.groupId.Equals(currentGroup.groupId))
                        isInGroup = true;
                }
                
                if (suppDAO.getUnprocessedRequestByUserGroup(currentGroup, user) != null || isInGroup)
                {
                    sendRequestButton.Visible = false;
                }
                else
                {
                    sendRequestButton.Visible = true;
                }
                if (isInGroup)
                {
                    leaveGroupButton.Visible = true;
                } 
                else
                {
                    leaveGroupButton.Visible = false;
                }   
                
                acceptInvitationbutton.Visible = false;
            }
            if (OuterPage.Equals("UserPage"))
            {
                leaveGroupButton.Visible = true;
                sendRequestButton.Visible = false;
                acceptInvitationbutton.Visible = false;
            }
            if(OuterPage.Equals("UserInvitationsPage"))
            {
                sendRequestButton.Visible = false;
            }
        }

        protected void leaveGroupButton_Click(object sender, ImageClickEventArgs e)
        {
            if (OuterPage.Equals("UserPAge") || OuterPage.Equals("AllGroups"))
            {
                int id = Int32.Parse(Session["userCampusId"].ToString());
                UserDAO usrDAO = UserDAO.getUserDAO();
                GroupDAO groupDAO = GroupDAO.getGroupDAO();
                User user = usrDAO.getGroupsUserByCampusAccountId(id);
                groupDAO.deleteUserFromGroup(currentGroup, user);
                Response.Redirect("~/UserPage.aspx");
            }
            if (OuterPage.Equals("UserInvitationsPage"))
            {
                GroupDAO groupDAO = GroupDAO.getGroupDAO();
                int id = Int32.Parse(Session["userCampusId"].ToString());
                UserDAO usrDAO = UserDAO.getUserDAO();
                User user = usrDAO.getGroupsUserByCampusAccountId(id);
                Invitation inv = groupDAO.getInvitationByGroupAndUser(user, currentGroup);
                groupDAO.processInvitation(inv, 0);
                Response.Redirect("~/UserInvitationsPage.aspx");
            }
        }

        protected void groupNameBtn_Click(object sender, EventArgs e)
        {
            Session["groupId"] = currentGroup.groupId;
            Response.Redirect(@"~\GroupMainPage.aspx");
        }

        protected void sendRequestButton_Click(object sender, ImageClickEventArgs e)
        {
            SupportDAO suppDAO = SupportDAO.getSupportDAO();
            int id = Int32.Parse(Session["userCampusId"].ToString());
            UserDAO usrDAO = UserDAO.getUserDAO();
            User user = usrDAO.getGroupsUserByCampusAccountId(id);
            suppDAO.insertRequest(user, currentGroup);
            sendRequestButton.Visible = false;
        }

        protected void acceptInvitationbutton_Click(object sender, ImageClickEventArgs e)
        {
            if (OuterPage.Equals("UserInvitationsPage"))
            {
                GroupDAO groupDAO = GroupDAO.getGroupDAO();
                int id = Int32.Parse(Session["userCampusId"].ToString());
                UserDAO usrDAO = UserDAO.getUserDAO();
                User user = usrDAO.getGroupsUserByCampusAccountId(id);
                Invitation inv = groupDAO.getInvitationByGroupAndUser(user, currentGroup);
                groupDAO.processInvitation(inv, 1);
                acceptInvitationbutton.Visible = false;
            }
        }
    }
}