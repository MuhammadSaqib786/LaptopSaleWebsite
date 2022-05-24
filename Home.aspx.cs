using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = HttpContext.Current.User.Identity.Name;
                if(userName=="admin")
                {
                    Response.Redirect("Admin.aspx");
                }
         
    }
}