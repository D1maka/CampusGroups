using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampusGroups.dao;
using CampusGroups.data;
using System.Drawing;


namespace CampusGroups
{
    public partial class UserControl : System.Web.UI.UserControl
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

        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        protected void myGroupsBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UserPage.aspx");
        }

        protected void newGroupBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/CreateGroupPage.aspx");
        }

        protected void viewAllGroupsBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/AllGroupsPage.aspx");
        }

        protected void setAvatarBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ChangeUserAvatarPage.aspx");
        }

        protected void myInvitationsButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UserInvitationsPage.aspx");
        }
    }
}