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
        private List<Attachment> attachments;
        public int parentPostId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            attachments = new List<Attachment>();
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
            foreach (var attach in attachments)
            {
                attach.postId = newPost.postId;
                postDAO.insertAttachment(attach);
            }
            
        }

        protected void addAttachmentBtn_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = FileUploadControl.FileName;
                    FileUploadControl.SaveAs(@"~\files\" + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    Attachment att = new Attachment();
                    att.fileLink = @"~\files\" + filename;
                    att.postId = 0;
                    attachments.Add(att);
                    AttachmentControl attControl = (AttachmentControl)Page.LoadControl(@"~\AttachmentControl.ascx");
                    attControl.OuterPage = "NewPostControl";
                    attControl.attachment = att;
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}