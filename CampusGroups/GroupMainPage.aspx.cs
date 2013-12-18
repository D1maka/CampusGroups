using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusGroups
{
    public partial class GroupMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderGroupMainControl.Controls.Add(Page.LoadControl(@"~\GroupMainControl.ascx"));
        }
    }
}