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
    public partial class GroupMemberControl : System.Web.UI.UserControl
    {
        public int userId
        {
            get; 
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserDAO usrDAO = UserDAO.getUserDAO();
            int campusUserId = usrDAO.getCampusUserIdByGroupsUserId(userId);
            string username = usrDAO.getUserNameByCampusUserAccountId(campusUserId);
            string avatarLink = usrDAO.getAvatarLinkByGroupsUserId(userId);
            int statusId = Int32.Parse(Session["statusId"].ToString());
            if (statusId == 1)
                this.deleteBtn.Visible = true;
            this.avatarImg.ImageUrl = avatarLink;
            this.userNameLbl.Text = username;
        }
    }
}