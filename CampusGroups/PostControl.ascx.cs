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
    public partial class PostControl : System.Web.UI.UserControl
    {
        public Post post
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GroupDAO goupDAO = GroupDAO.getGroupDAO();
            UserDAO userDAO = UserDAO.getUserDAO();
            User user = userDAO.getGroupUserByUserId(post.authorId);
            postDateLbl.Text = post.postDate.ToString();
            postTextLbl.Text = post.postText;
            avatar.ImageUrl = user.avatarLink;
            postAuthorNameLbl.Text = userDAO.getUserNameByCampusUserAccountId(userDAO.getCampusUserIdByGroupsUserId(user.userId));
        }
    }
}