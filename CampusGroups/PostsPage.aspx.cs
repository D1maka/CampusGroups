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
    public partial class PostsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderGroupControl.Controls.Add(Page.LoadControl(@"~\GroupMainControl.ascx"));

            GroupDAO groupDAO = GroupDAO.getGroupDAO();
            PostDAO postDAo = PostDAO.getInstance();
            Group currentGroup = groupDAO.getGroupByGroupId(Int32.Parse(Session["groupId"].ToString()));
            List<Post> posts = postDAo.getGroupPosts(currentGroup);

            if (posts != null)
            {
                foreach (var p in posts)
                {
                    PostControl postControl = (PostControl)Page.LoadControl(@"~\PostControl.ascx");
                    postControl.post = p;
                    this.PlaceHolderPosts.Controls.Add(postControl);
                }
            }
        }

        protected void newPostBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/NewPostPage.aspx");
        }
    }
}