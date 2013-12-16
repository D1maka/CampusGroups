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
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            Page.RegisterRequiresControlState(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

               
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string login = this.loginTxtBox.Text;
            string passwd = this.passwdTxtBox.Text;
            UserDAO usrDAO = UserDAO.getUserDAO();
            int id = usrDAO.getCampusUserAccountIdByLoginPassword(login, passwd);
            if (id != 0)
            {
                User user = usrDAO.getGroupsUserByCampusAccountId(id);
                if (user == null)
                {
                    user = new User();
                    user.campusUserId = id;
                    user.avatarLink = UserDAO.DEFAULT_AVATAR_PATH;
                    user.statusId = UserDAO.USER_STATUS_ID;
                    usrDAO.addUser(user);
                }
                Session["userCampusId"] = id;
                Session["userId"] = user.userId;
                Session["statusId"] = user.statusId;
                Response.Redirect("~/UserPage.aspx");
            }
            else 
            {
                this.errorLbl.Text = "Не вірна комбінація імені користувача і паролю";
            }
        }

        
    }
}