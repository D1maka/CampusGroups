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
        public User usr
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
                SupportDAO suppDAO = SupportDAO.getSupportDAO();
                int campusId = usrDAO.getCampusUserIdByGroupsUserId(usr.userId);
                String name = usrDAO.getUserNameByCampusUserAccountId(campusId);
                String profile = usrDAO.getProfileNameByCampusUserAccountId(campusId);
                String department = usrDAO.getSubdivisionNameByCampusUserAccountId(campusId);
                this.usernameLbl.Text = name;
                this.userProfileType.Text = profile;
                this.userDepartment.Text = department;
                this.avatarImg.Height = 128;
                this.avatarImg.Width = 128;
                this.avatarImg.ImageUrl = usr.avatarLink;
               // this.DropDownListRoles.DataSource = suppDAO.getRoles();
            }
        }

        protected void inviteBtn_Click(object sender, ImageClickEventArgs e)
        {
            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            Invitation inv = new Invitation();
            inv.groupId = Int32.Parse(Session["groupId"].ToString());
            inv.moderatorId = Int32.Parse(Session["userId"].ToString());
            inv.userId = usr.userId;
            inv.processed = 0;
            inv.date = System.DateTime.Now;
            groupDAO.insertInvitation(inv);
            this.inviteBtn.Visible = false;
        }
    }
}