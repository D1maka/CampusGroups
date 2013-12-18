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
    public partial class AttachmentControl : System.Web.UI.UserControl
    {
        public Attachment attachment
        { get; set; }

        public string OuterPage
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.attachmentNameLbl.Text = attachment.fileLink;
            if (OuterPage.Equals("NewPostControl"))
            {
                this.downloadAttachmentBtn.Visible = false;
            }
        }

        protected void downloadAttachmentBtn_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}