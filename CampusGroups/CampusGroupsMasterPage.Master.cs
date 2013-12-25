using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusGroups
{
    public partial class CampusGroupsMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOutBtn_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect(@"~\LoginPage.aspx");
        }

        protected void toMyPageBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(@"~\UserPage.aspx");
        }
    }
}