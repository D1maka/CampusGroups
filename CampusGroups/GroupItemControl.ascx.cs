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
    public partial class GroupItemControl : System.Web.UI.UserControl
    {
        public Group currentGroup
        { 
            get; 
            set; 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.groupNameLbl.Text = currentGroup.groupName;
        }
    }
}