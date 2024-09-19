using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Razorpay.Api;
using System.Configuration;
using System.Data.SqlClient;
using Razorpay;
using System.Data;

namespace Education
{
    public partial class cart : System.Web.UI.Page
    {
        SqlConnection conn;
        string address, contact;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                LoadSubcategories();
                LoadCourses();
                LoadCart();
            }


            //address = TextBox2.Text;
            //contact = TextBox2.Text;
            //Session["Address"] = address;
            //Session["Contact"] = contact;
            //if (!IsPostBack)
            //{
            //    fetchCart();
            //    GrandTotal();
            //}
            //string q = $"truncate table PaymentPlace";

            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }
        private void LoadSubcategories()
        {
                using (SqlCommand cmd = new SqlCommand("spGetSubcategories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    ddlSubcategory.DataSource = cmd.ExecuteReader();
                    ddlSubcategory.DataTextField = "SubcategoryName";
                    ddlSubcategory.DataValueField = "SubcategoryID";
                    ddlSubcategory.DataBind();
                }
            ddlSubcategory.Items.Insert(0, new ListItem("All Subcategories", "0"));
        }

        protected void ddlSubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            int subcategoryId = Convert.ToInt32(ddlSubcategory.SelectedValue);
                using (SqlCommand cmd = new SqlCommand("spGetCoursesForSubcategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubcategoryID", subcategoryId);
                    conn.Open();
                    gvCourses.DataSource = cmd.ExecuteReader();
                    gvCourses.DataBind();
                }
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int courseId = Convert.ToInt32(e.CommandArgument);
                AddToCart(courseId);
                LoadCart();
            }
        }

        private void AddToCart(int courseId)
        {
                using (SqlCommand cmd = new SqlCommand("spAddToCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId()); // Implement this method to get the current user's ID
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
        }

        private void LoadCart()
        {
                using (SqlCommand cmd = new SqlCommand("spGetCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    gvCart.DataSource = dt;
                    gvCart.DataBind();

                    decimal grandTotal = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalPrice"));
                    lblGrandTotal.Text = $"Grand Total: {grandTotal:C}";
                }
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int courseId = Convert.ToInt32(e.CommandArgument);
                RemoveFromCart(courseId);
                LoadCart();
            }
        }

        private void RemoveFromCart(int courseId)
        {
                using (SqlCommand cmd = new SqlCommand("spRemoveFromCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
        }

        private int GetCurrentUserId()
        {
            return 1; 
        }






        //protected void GrandTotal()
        //{
        //    string suser = Session["myuser"].ToString();    
        //    //string suser = "piyushmaurya7799@gmail.com";
        //    string total_price;
        //    if (Session["myuser"] != null)
        //    {
        //        string q = $"select sum(price) as total from cart where suser = '{suser}'";
        //        SqlCommand cmd = new SqlCommand(q, conn);
        //        SqlDataReader r = cmd.ExecuteReader();
        //        r.Read();

        //        total_price = r["total"].ToString();
        //        Label8.Text = total_price;
        //        Session["GrandTotal"] = total_price;
        //    }
        //    else
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //}
        //protected void fetchCart()
        //{
        //    if (Session["myuser"] != null)    //Require change
        //    {

        //        string suser = Session["myuser"].ToString(); ;  //require Work Session["MyUser"].ToString();
        //        string q = $"exec FindCartDetailsBySession '{suser}'";
        //        SqlCommand cmd = new SqlCommand(q, conn);
        //        SqlDataReader r = cmd.ExecuteReader();

        //        GridView1.DataSource = r;
        //        GridView1.DataBind();
        //    }
        //    else
        //    {
        //        Response.Redirect("Login.aspx");       //require change
        //    }
        //}
        ////exec AddtoCartProcc "'+Pname+'",....,"'+totalprice+'",....."'+Perprice+'";      // in Allproduct page
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("allcourse.aspx"); //Require Changes
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("placeorder.aspx"); //Require Changes
        //}

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    Response.Write("<script>alert('Hello')</script>");
        //}







        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    Label L1=(Label)GridView1.Rows[e.RowIndex].FindControl("Label7");
        //    string id = L1.Text;
        //    string q = $"exec DeleteCartProducts '{id}'";
        //    SqlCommand c = new SqlCommand(q, conn);
        //    c.ExecuteNonQuery();
        //    fetchCart();
        //    Response.Redirect("cart.aspx");
        //}

        //protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        //{
        //    Label L1 = (Label)GridView1.Rows[e.RowIndex].FindControl("Label7");
        //    string id = L1.Text;
        //    string q = $"exec DeleteCartProducts '{id}'";
        //    SqlCommand c = new SqlCommand(q, conn);
        //    c.ExecuteNonQuery();
        //    fetchCart();
        //    Response.Redirect("cart.aspx");
        //}

        //protected void Button2_Click1(object sender, EventArgs e)
        //{
        //    if (Session["myuser"] != null)
        //    {
        //        string suser = Session["myuser"].ToString();     //Need to uncomment
        //        //string suser = "piyushmaurya7799@gmail.com";
        //        string address, contact;
        //        address = TextBox2.Text;
        //        contact = TextBox3.Text;
        //        string q = $"insert into placeorder(pname,pcat,price,qty,pic,dt,suser,perprice,address,contact,status) select pname,pcat,price,qty,pic,dt,suser,perprice,'{address}','{contact}','Not Delivered' from cart where suser='{suser}'";
        //        string q2 = $"insert into PaymentPlace(pname,pcat,price,qty,pic,dt,suser,perprice,address,contact,status) select pname,pcat,price,qty,pic,dt,suser,perprice,'{address}','{contact}','Not Delivered' from cart where suser='{suser}'";

        //        SqlCommand cmd = new SqlCommand(q, conn);
        //        SqlCommand cmd2 = new SqlCommand(q2, conn);
        //        int row = cmd.ExecuteNonQuery();
        //        cmd2.ExecuteNonQuery();
        //        if (row > 0)
        //        {
        //            string query = $"delete from cart where suser='{suser}'";
        //            SqlCommand command = new SqlCommand(query, conn);
        //            command.ExecuteNonQuery();
        //string KeyId = "rzp_test_4DrJJevYZkd0No";
        //string KeySecret = "3oX1Dvxlpy2wB3BGnDPxGtH8";
        //RazorpayClient razorpayClient = new RazorpayClient(KeyId, KeySecret);

        //double amount = double.Parse(Session["GrandTotal"].ToString());
        //Dictionary<string, object> options = new Dictionary<string, object>();
        //options.Add("amount", amount * 100);
        //options.Add("currency", "INR");
        //options.Add("recepit", "oeder_recepit_123");
        //options.Add("payment_capture", 1);

        //Razorpay.Api.Order order = razorpayClient.Order.Create(options);

        //string orderId = order["id"].ToString();

        //                    string razorpayScript = $@"
        //            var options=
        //            {{
        //            'key':'{KeyId}',
        //'amount':{amount * 100},
        //'currency':'INR',
        //'name':'Eyescape',
        //'description':'Check out',
        //'order_id':'{orderId}',

        // 'callback_url': 'https://localhost:44345/PlaceOrder.aspx',
        //'theme':{{'color':'#9834eb'
        //}}
        //}};
        //var rzp =new Razorpay(options);
        //rzp.open();";
        //                'handler':function(response)
        //{
        //                    {
        //                        Response.redirect('PlaceOrder.aspx');
        //                    }
        //                },
        //alert('Payment Successfull.Payment ID: ' + response.razorpay_payment_id);
        //ClientScript.RegisterStartupScript(this.GetType(), "razorpayScript", razorpayScript, true);


        //Response.Redirect("PlaceOrder.aspx");
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('Something went wrong')</script>");
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //}
    }
}
