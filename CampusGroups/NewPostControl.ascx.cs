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
    public partial class NewPostControl : System.Web.UI.UserControl
    {
        public int parentPostId = 0;
        private Attachment attach;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addPostBrn_Click(object sender, EventArgs e)
        {
            PostDAO postDAO = PostDAO.getInstance();
            int authorId = Int32.Parse(Session["userId"].ToString());
            int groupId = Int32.Parse(Session["groupId"].ToString());
            var date = System.DateTime.Now;
            Post post = new Post();
            post.authorId = authorId;
            post.groupId = groupId;
            post.parentPostId = parentPostId;
            post.postDate = date;
            post.postText = this.postTxtBox.Text;
            postDAO.insertPost(post);
            Post newPost = postDAO.getPostByPostUserGroupTime(authorId, groupId, date);
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = FileUploadControl.FileName;
                    FileUploadControl.SaveAs(@"~\files\" + filename);
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    attach = null;
                }
            }

            if (attach != null)
            {
                attach.postId = newPost.postId;
                postDAO.insertAttachment(attach);
            }

            Response.Redirect("~/PostsPage.aspx");
        }

        protected void addAttachmentBtn_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = FileUploadControl.FileName;
                    StatusLabel.Text = "Upload status: File uploaded!";
                    attach = new Attachment();
                    attach.fileLink = @"~\files\" + filename;
                    attach.postId = 0;
                    AttachmentControl attControl = (AttachmentControl)Page.LoadControl(@"~\AttachmentControl.ascx");
                    attControl.OuterPage = "NewPostControl";
                    attControl.attachment = attach;
                    PlaceHolderAtt.Controls.Add(attControl);
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}