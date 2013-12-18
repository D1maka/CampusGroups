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
                leaveGroupButton.Visible = false;
        }

        protected void leaveGroupButton_Click(object sender, ImageClickEventArgs e)
        {
            int id = Int32.Parse(Session["userCampusId"].ToString());
            UserDAO usrDAO = UserDAO.getUserDAO();
            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            User user = usrDAO.getGroupsUserByCampusAccountId(id);
            groupDAO.deleteUserFromGroup(currentGroup, user);
            Response.Redirect("~/UserPage.aspx");
        }

        protected void groupNameBtn_Click(object sender, EventArgs e)
        {
            Session["groupId"] = currentGroup.groupId;
            Response.Redirect(@"~\GroupMainPage.aspx");
        }
    }
}