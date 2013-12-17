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
    public partial class AllGroupsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderAllGroups.Controls.Add(Page.LoadControl(@"~\UserControl.ascx"));

            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            UserDAO userDAO = UserDAO.getUserDAO();
            int campusUserId = Int32.Parse(Session["userCampusId"].ToString());
            List<Group> userGroups = groupDAO.getAllGroups();

            foreach (var group in userGroups)
            {
                GroupItemControl groupControl = (GroupItemControl)Page.LoadControl(@"~\GroupItemControl.ascx");
                groupControl.currentGroup = group;
                this.PlaceHolderAllGroups.Controls.Add(groupControl); 
                
            }
        }
    }
}