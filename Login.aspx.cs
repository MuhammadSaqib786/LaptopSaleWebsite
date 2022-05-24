using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    public static string cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Authenticateuser(TextBox1.Text, TextBox2.Text))
            FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, CheckBox1.Checked);
        else
        {
            Label2.Text = "*Invalid Username or Password";
            Label2.ForeColor = System.Drawing.Color.Red;
        }
    }
    private bool Authenticateuser(String username, String pass)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("Select count(*) from tbl_user where uname = @u and pass = @pa", con);
            cmd.Parameters.AddWithValue("@u", TextBox1.Text.ToLower());
            cmd.Parameters.AddWithValue("@pa", TextBox2.Text);
            con.Open();
            int Returncode = (int)cmd.ExecuteScalar();
            return Returncode == 1;
        }
    }
}