using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Education
{
    public partial class Student : System.Web.UI.MasterPage
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                countProduct();
            }
            if (Session["myuser"] != null)
            {
                string email = (Session["myuser"].ToString());
                string q = " select * from users where email='" + email + "'";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                string user = rdr["fname"].ToString();
                Label1.Text = user;
            }
            else
            {
                Response.Write("<script>alert('You need to login again');window.location.href=''Login.aspx</script>");
            }
        }

        protected void countProduct()
        {
            if (Session["myuser"] != null) 
            {

                string suser = Session["myuser"].ToString(); ; 
                string q = $"select count(pid) as cnt from cart where suser='{suser}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Label2.Text = rdr["cnt"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}