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
    public partial class GroupRequestControl : System.Web.UI.UserControl
    {
        public User user
        { get; set; }

        public Group group
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userCampusId"] == null)
            {
                Response.Redirect("~/LoginPage.aspx");
            }
            else
            {
                UserDAO usrDAO = UserDAO.getUserDAO();
                String name = usrDAO.getUserNameByCampusUserAccountId(user.campusUserId);
                String profile = usrDAO.getProfileNameByCampusUserAccountId(user.campusUserId);
                String department = usrDAO.getSubdivisionNameByCampusUserAccountId(user.campusUserId);
                this.usernameLbl.Text = name;
                this.userProfileType.Text = profile;
                this.userDepartment.Text = department;
                this.avatarImg.Height = 128;
                this.avatarImg.Width = 128;
                this.avatarImg.ImageUrl = user.avatarLink;
            }
        }

        protected void acceptRequest_Click(object sender, ImageClickEventArgs e)
        {
            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            SupportDAO suppDAO = SupportDAO.getSupportDAO();
            groupDAO.addUser(group, user, suppDAO.getUserRole());
        }
    }
}