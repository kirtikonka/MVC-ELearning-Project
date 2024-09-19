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
    public partial class orders : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                LoadAllOrders();
            }
        }




        private void LoadAllOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllOrders", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    gvAllOrders.DataSource = cmd.ExecuteReader();
                    gvAllOrders.DataBind();
                }
            }
        }

        protected void gvAllOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                ddlStatus.SelectedValue = status;

                // Color-coding for status
                switch (status)
                {
                    case "Pending":
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Orange;
                        break;
                    case "Processing":
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Blue;
                        break;
                    case "Completed":
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                        break;
                    case "Cancelled":
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                        break;
                }
            }
        }

        protected void gvAllOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int orderId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "UpdateStatus")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
                string newStatus = ddlStatus.SelectedValue;

                UpdateOrderStatus(orderId, newStatus);
                LoadAllOrders();
            }
            else if (e.CommandName == "ViewDetails")
            {
                LoadOrderDetails(orderId);
                //pnlOrderDetails.Visible = true;
            }
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
        {
                using (SqlCommand cmd = new SqlCommand("spUpdateOrderStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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


        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //    GridView1.DataSourceID = "";
        //    string from, to;
        //    from = TextBox1.Text;
        //    to = TextBox2.Text;
        //    string q = $"select * from placeorder where dt between '{from}' AND '{to}' order by dt";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader r = cmd.ExecuteReader();
        //    GridView2.DataSource = r;
        //    GridView2.DataBind();
        //}

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //    if (e.CommandName == "status")
        //    {
        //        string id = e.CommandArgument.ToString();
        //        string q = $"select * from placeorder where pid='{id}'";
        //        SqlCommand c = new SqlCommand(q, conn);
        //        SqlDataReader r = c.ExecuteReader();
        //        r.Read();
        //        string status = r["status"].ToString();
        //        if (status.Equals("Not Delivered"))
        //        {
        //            string q1 = $"update placeorder set status='Delivered' where pid='{id}'";
        //            SqlCommand cmd1 = new SqlCommand(q1, conn);
        //            cmd1.ExecuteNonQuery();
        //            Response.Redirect("orders.aspx");
        //        }
        //        else
        //        {

        //        }
        //    }
        //}
    }
}