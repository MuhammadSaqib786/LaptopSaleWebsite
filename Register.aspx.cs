using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    int count = 0;
    private static string cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        checkuser();
        if (count > 0)
        {
            Label2.Text = "*user already exist, use another username";
            Label2.ForeColor = System.Drawing.Color.Red;
        }
            
        else
        {
            createuser();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
    }
    private void createuser()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_user(uname,email,pno,gender,pass)values(@u,@e,@p,@g,@pa)", con);
                cmd.Parameters.AddWithValue("@u", TextBox1.Text.ToLower());
                cmd.Parameters.AddWithValue("@e", TextBox2.Text);
                cmd.Parameters.AddWithValue("@p", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@g", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@pa", TextBox4.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                Label2.Text = "User Created Succesfully <a href = 'Login.aspx' style='color:blue'> click to Login</a>";
                Label2.ForeColor = System.Drawing.Color.Blue;
            }
            catch
            {
                Label2.Text = "User not registered";
            }
        }
    }
    private void checkuser()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from tbl_user where uname=@u", con);
                cmd.Parameters.AddWithValue("@u", TextBox1.Text.ToLower());
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                Label2.Text = "User not registered";
            }
        }
    }
}