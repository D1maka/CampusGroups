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
    public partial class CreateGroupControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "ololo";
        }

        protected void createGroupBtn_Click(object sender, EventArgs e)
        {
            if (this.groupNameTxtBox.Text != string.Empty)
            {
                GroupDAO groupDAO = GroupDAO.getGroupDAO();
                UserDAO userDAO = UserDAO.getUserDAO();
                Group newGroup = new Group();
                newGroup.groupName = this.groupNameTxtBox.Text;
                newGroup.groupDescription = this.groupDescriptionTxtBox.Text;
                newGroup.groupCreationDate = System.DateTime.Now;
                newGroup.usersAmmount = 1;

                User user = userDAO.getGroupsUserByCampusAccountId(Int32.Parse(Session["userCampusId"].ToString()));

                groupDAO.insertGroup(newGroup, user);
                Label1.Text = newGroup.groupName + " " + newGroup.groupDescription + " " + newGroup.groupCreationDate.ToString() + " " + newGroup.usersAmmount;
               
            } else {
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = "ololo1";
        }
    }
}