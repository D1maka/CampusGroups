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
    public partial class ChangeAvatarControl : System.Web.UI.UserControl
    {
        public string OuterPage
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (OuterPage.Equals("UserControl"))
            { 
                UserDAO userDAO = UserDAO.getUserDAO();
                int id = Int32.Parse(Session["userId"].ToString());
                string avatarLink = userDAO.getAvatarLinkByGroupsUserId(id);
                this.Avatar.ImageUrl = avatarLink;
            }
        }

        protected void changeAvatarBtn_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 102400)
                        {
                            string filename = FileUploadControl.FileName;
                            string path = Server.MapPath("~/") + @"avatars\" + filename;
                            FileUploadControl.SaveAs(path);
                            StatusLabel.Text = "Upload status: File uploaded!";
                            UserDAO userDAO = UserDAO.getUserDAO();
                            int id = Int32.Parse(Session["userId"].ToString());
                            User usr = userDAO.getGroupUserByUserId(id);
                            userDAO.updateUserAvatar(usr, @"~\avatars\" + filename);
                            Response.Redirect("~/ChangeUserAvatarPAge.aspx");
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {

                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}