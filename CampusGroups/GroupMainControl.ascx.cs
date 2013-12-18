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
            Group currentGroup = groupDAO.getGroupByGroupId(groupId);
            this.groupNameLabel.Text = currentGroup.groupName;
            this.groupDescriptionLabel.Text = currentGroup.groupDescription;
        }
    }
}