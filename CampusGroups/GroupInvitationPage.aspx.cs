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
    public partial class GroupInvitationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderGroupControl.Controls.Add(Page.LoadControl(@"~\GroupMainControl.ascx"));

            UserDAO userDAO = UserDAO.getUserDAO();
            List<User> users = userDAO.getAllUsers();
            User user = userDAO.getGroupUserByUserId(Int32.Parse(Session["userId"].ToString()));
            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            Group currentGroup = groupDAO.getGroupByGroupId(Int32.Parse(Session["groupId"].ToString()));

            foreach (var u in users)
            {
                if (u.userId == user.userId || groupDAO.isUserInGroup(currentGroup, u))
                {
                    continue;
                }
                else
                {
                    InviteUserControl inviteControl = (InviteUserControl)Page.LoadControl(@"~\InviteUserControl.ascx");
                    inviteControl.usr = u;
                    this.PlaceHolderInvitations.Controls.Add(inviteControl);
                }
            }
        }
    }
}