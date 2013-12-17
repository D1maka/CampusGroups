using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusGroups
{
    public partial class CreateGroupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderUserControl.Controls.Add(Page.LoadControl(@"~\UserControl.ascx"));
            this.PlaceHolderCreateGroupControl.Controls.Add(Page.LoadControl(@"~\CreateGroupControl.ascx"));
        }
    }
}