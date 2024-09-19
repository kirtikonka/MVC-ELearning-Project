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
    public partial class orderhistory : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
            //Session["MyUser"] = "piyushmaurya7798@gmail.com";

            if (!IsPostBack)
            {
                LoadOrderHistory();
            }

        }

        private void LoadOrderHistory()
        {
                using (SqlCommand cmd = new SqlCommand("spGetOrderHistory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    conn.Open();
                    gvOrderHistory.DataSource = cmd.ExecuteReader();
                    gvOrderHistory.DataBind();
                }
        }

        protected void gvOrderHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                if (status == "Completed")
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
                }
                else if (status == "Pending")
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Orange;
                }
            }
        }

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int orderId = Convert.ToInt32(btn.CommandArgument);
            LoadOrderDetails(orderId);
            pnlOrderDetails.Visible = true;
        }

        private void LoadOrderDetails(int orderId)
        {
                using (SqlCommand cmd = new SqlCommand("spGetOrderDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    conn.Open();
                    gvOrderDetails.DataSource = cmd.ExecuteReader();
                    gvOrderDetails.DataBind();
                }
            lblOrderID.Text = $"Order ID: {orderId}";
        }

        private int GetCurrentUserId()
        {
            // Implement this method to return the current user's ID
            // For example, you might get it from a session variable or authentication system
            return 1; // Placeholder value
        }





        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (Session["myuser"] != null)
        //    {

        //        GridView1.DataSourceID = "";
        //        string from, to;
        //        from = TextBox1.Text;
        //        to = TextBox2.Text;

        //        string MyUser = Session["myuser"].ToString();
        //        string q = $"select * from placeorder where suser='{MyUser}' AND dt between '{from}' AND '{to}' order by dt";
        //        SqlCommand cmd = new SqlCommand(q, conn);
        //        SqlDataReader r = cmd.ExecuteReader();
        //        GridView2.DataSource = r;
        //        GridView2.DataBind();
        //    }

        //}

    }
}