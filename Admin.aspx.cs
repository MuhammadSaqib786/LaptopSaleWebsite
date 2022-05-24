using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    private static string cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        try
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * From Products", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        int laptopId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string model = (row.Cells[2].Controls[0] as TextBox).Text;
        string company = (row.Cells[3].Controls[0] as TextBox).Text;
        int price = Convert.ToInt32((row.Cells[4].Controls[0] as TextBox).Text);
        int items= Convert.ToInt32((row.Cells[5].Controls[0] as TextBox).Text);
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Products SET model = @model, company = @company, price = @price,available_items = @items WHERE laptopId = @laptopId"))
            {
                cmd.Parameters.AddWithValue("@laptopId", laptopId);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@company", company);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@items", items);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int laptopId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE laptopId = @laptopId"))
            {
                cmd.Parameters.AddWithValue("@laptopId", laptopId);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        this.BindGrid();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Products(model,company,price,available_items)values(@m,@c,@p,@av)", con);
                cmd.Parameters.AddWithValue("@m", txtModel.Text);
                cmd.Parameters.AddWithValue("@c", txtCompany.Text);
                cmd.Parameters.AddWithValue("@p", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@av", Convert.ToInt32(txtItems.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                Label1.Text = "New Product added successfully";
                Label1.ForeColor = System.Drawing.Color.Blue;
                this.BindGrid();
            }
            catch
            {
                Label1.Text = "Some issue";
            }
        }
    }
}