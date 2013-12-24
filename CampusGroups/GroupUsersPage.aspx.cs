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
    public partial class GroupUsersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderGroupControl.Controls.Add(Page.LoadControl(@"~\GroupMainControl.ascx"));

            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            UserDAO userDAO = UserDAO.getUserDAO();
            Group currentGroup = groupDAO.getGroupByGroupId(Int32.Parse(Session["groupId"].ToString()));
            List<User> users = groupDAO.getUsersByGroup(currentGroup);

            if (users != null)
            {
                foreach (var u in users)
                {
                    GroupMemberControl member = (GroupMemberControl)Page.LoadControl(@"~\GroupMemberControl.ascx");
                    member.userId = u.userId;
                    PlaceHolderUsers.Controls.Add(member);
                }
            }
        }
    }
}