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
    public partial class ProcessGroupRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderGroupControl.Controls.Add(Page.LoadControl(@"~\GroupMainControl.ascx"));

            SupportDAO suppDAO = SupportDAO.getSupportDAO();
            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            UserDAO userDAO = UserDAO.getUserDAO();
            int groupId = Int32.Parse(Session["groupId"].ToString());
            Group currentGroup = groupDAO.getGroupByGroupId(groupId);
            List<GroupRequest> req = suppDAO.getUnprocessedGroupRequestByGroup(currentGroup);

            if (req != null)
            {
                foreach (var r in req)
                {
                    GroupRequestControl requestControl = (GroupRequestControl)Page.LoadControl(@"~\GroupRequestControl.ascx");
                    requestControl.currentGroup = currentGroup;
                    User usr = userDAO.getGroupUserByUserId(r.userId);
                    requestControl.user = usr;
                    this.PlaceHolderRequests.Controls.Add(requestControl);
                }
            }
        }
    }
}