using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CampusGroups.logic
{
    public class ViewHelper
    {
        public static void addControlToPlaceHolder(PlaceHolder ph, UserControl control)
        {
            ph.Controls.Add(control);
        }
    }
}