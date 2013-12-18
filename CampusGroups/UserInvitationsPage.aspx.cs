using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampusGroups.dao;
using CampusGroups.data;

namespace CampusGroups
{
    public partial class UserInvitationsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderUserControl.Controls.Add(Page.LoadControl(@"~\UserControl.ascx"));

            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            UserDAO userDAO = UserDAO.getUserDAO();
            int campusUserId = Int32.Parse(Session["userCampusId"].ToString());
            User user = userDAO.getGroupsUserByCampusAccountId(campusUserId);
            List<Invitation> invs = groupDAO.getUnprocessedGroupsInvitationsByUser(user);
            List<Group> userGroups = new List<Group>();
            foreach (var inv in invs)
            {
                userGroups.Add(groupDAO.getGroupByGroupId(inv.groupId));
            }

            foreach (var group in userGroups)
            {
                GroupItemControl groupControl = (GroupItemControl)Page.LoadControl(@"~\GroupItemControl.ascx");
                groupControl.currentGroup = group;
                groupControl.OuterPage = "UserInvitationPage";
                this.PlaceHolderInvitations.Controls.Add(groupControl);

            }
        }
    }
}