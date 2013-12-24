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
    public partial class GroupMainControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserDAO usrDAO = UserDAO.getUserDAO();
            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            int groupId = Int32.Parse(Session["groupId"].ToString());
            int id = Int32.Parse(Session["userId"].ToString());
            Group currentGroup = groupDAO.getGroupByGroupId(groupId);
            this.groupNameLabel.Text = currentGroup.groupName;
            this.groupDescriptionLabel.Text = currentGroup.groupDescription;
            int statusId = Int32.Parse(Session["statusId"].ToString());
            if (statusId == 1 || groupDAO.isModerator(groupId, id))
            {
                this.sendInvitationsBtn.Visible = true;
                this.viewRequestBtn.Visible = true;
            }
            else
            {
                this.sendInvitationsBtn.Visible = false;
                this.viewRequestBtn.Visible = false;
            }
        }

        protected void viewRequestBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ProcessGroupRequests.aspx");
        }

        protected void sendInvitationsBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/GroupInvitationPage.aspx");
        }

        protected void viewMembersBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/GroupUsersPage.aspx");
        }

        protected void viewPostsBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PostsPage.aspx");
        }
    }
}