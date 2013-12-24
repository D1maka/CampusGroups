using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusGroups
{
    public partial class NewPostPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolderGroupControl.Controls.Add(Page.LoadControl(@"~\GroupMainControl.ascx"));

            this.PlaceHolderNewPostControl.Controls.Add(Page.LoadControl(@"~\NewPostControl.ascx"));
        }
    }
}