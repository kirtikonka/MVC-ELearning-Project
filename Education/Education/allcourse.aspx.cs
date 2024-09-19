using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Education
{
    public partial class allcourse : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                LoadCategories();
                LoadCourses(0, 0);
            }

            //if (!IsPostBack)
            //{
            //    FetchAllProducts();
            //}
        }

        private void LoadCategories()
        {
                using (SqlCommand cmd = new SqlCommand("spGetCategories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    ddlCategory.DataSource = cmd.ExecuteReader();
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                }
            ddlCategory.Items.Insert(0, new ListItem("All Categories", "0"));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            LoadSubcategories(categoryId);
            LoadCourses(categoryId, 0);
        }

        private void LoadSubcategories(int categoryId)
        {
            ddlSubcategory.Items.Clear();
            if (categoryId > 0)
            {
                    using (SqlCommand cmd = new SqlCommand("spGetSubcategories", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        conn.Open();
                        ddlSubcategory.DataSource = cmd.ExecuteReader();
                        ddlSubcategory.DataTextField = "SubcategoryName";
                        ddlSubcategory.DataValueField = "SubcategoryID";
                        ddlSubcategory.DataBind();
                    }
            }
            ddlSubcategory.Items.Insert(0, new ListItem("All Subcategories", "0"));
        }

        protected void ddlSubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            int subcategoryId = Convert.ToInt32(ddlSubcategory.SelectedValue);
            LoadCourses(categoryId, subcategoryId);
        }

        private void LoadCourses(int categoryId, int subcategoryId)
        {
                using (SqlCommand cmd = new SqlCommand("spGetCourses", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                    cmd.Parameters.AddWithValue("@SubcategoryID", subcategoryId);
                    conn.Open();
                    gvCourses.DataSource = cmd.ExecuteReader();
                    gvCourses.DataBind();
                }
        }


        //protected void FetchAllProducts()
        //{
        //    string q = "select * from product";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    DataList1.DataSource = reader;
        //    DataList1.DataBind();
        //}
        //protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        //{
        //    string pname, pcat, pic, dt, suser;
        //    double price, total_price;
        //    int qty;
        //    if (e.CommandName == "AddToCart")
        //    {

        //        string id = e.CommandArgument.ToString();

        //        string q = $"exec FindProductDetailsById '{id}'";
        //        SqlCommand cmd = new SqlCommand(q, conn);
        //        SqlDataReader r = cmd.ExecuteReader();
        //        if (r.HasRows)
        //        {
        //            r.Read();

        //            pname = r["pname"].ToString();
        //            pcat = r["pcat"].ToString();
        //            pic = r["pic"].ToString();
        //            price = double.Parse(r["price"].ToString());
        //            DropDownList dl = (DropDownList)e.Item.FindControl("DropDownList1");
        //            qty = int.Parse(dl.SelectedValue.ToString());
        //            total_price = price * qty;

        //            dt = DateTime.Now.ToString("M-d-yyyy");
        //            suser = Session["myuser"].ToString();

        //            string q1 = $"exec AddToCartProc '{pname}','{pcat}','{total_price}','{qty}','{pic}','{dt}','{suser}','{price}'";
        //            SqlCommand cmd1 = new SqlCommand(q1, conn);
        //            cmd1.ExecuteNonQuery();
        //            Response.Redirect("cart.aspx");

        //        }
        //    }
        //}
    }
}