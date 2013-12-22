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
    public partial class InviteUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userCampusId"] == null)
            {
                Response.Redirect("~/LoginPage.aspx");
            }
            else
            {
                int id = Int32.Parse(Session["userCampusId"].ToString());
                UserDAO usrDAO = UserDAO.getUserDAO();
                User user = usrDAO.getGroupsUserByCampusAccountId(id);
                String name = usrDAO.getUserNameByCampusUserAccountId(id);
                String profile = usrDAO.getProfileNameByCampusUserAccountId(id);
                String department = usrDAO.getSubdivisionNameByCampusUserAccountId(id);
                this.usernameLbl.Text = name;
                this.userProfileType.Text = profile;
                this.userDepartment.Text = department;
                this.avatarImg.Height = 128;
                this.avatarImg.Width = 128;
                this.avatarImg.ImageUrl = user.avatarLink;
            }
        }
    }
}