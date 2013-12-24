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
            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            int campusUserId = usrDAO.getCampusUserIdByGroupsUserId(userId);
            string username = usrDAO.getUserNameByCampusUserAccountId(campusUserId);
            string avatarLink = usrDAO.getAvatarLinkByGroupsUserId(userId);
            int statusId = Int32.Parse(Session["statusId"].ToString());
            User currentUser = usrDAO.getGroupsUserByCampusAccountId(campusUserId);
            Group currentGroup = groupDAO.getGroupByGroupId(Int32.Parse(Session["groupId"].ToString()));
            Role userRole = usrDAO.getUserRole(currentUser, currentGroup);
            if (statusId == 1 || userRole.roleId == 1)
                this.deleteBtn.Visible = true;
            int currentUserId = Int32.Parse(Session["userId"].ToString());
            if (currentUserId == userId)
                this.deleteBtn.Visible = false;
            this.avatarImg.ImageUrl = avatarLink;
            this.userNameLbl.Text = username;
        }

        protected void deleteBtn_Click(object sender, ImageClickEventArgs e)
        {
            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            UserDAO userDAO = UserDAO.getUserDAO();
            Group currentGroup = groupDAO.getGroupByGroupId(Int32.Parse(Session["groupId"].ToString()));
            User user = userDAO.getGroupUserByUserId(userId);
            groupDAO.deleteUserFromGroup(currentGroup, user);
            
        }
    }
}