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
    public partial class Registeration : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fname, lname, email, pass, profile = "user";
            fname=TextBox1.Text;
            lname=TextBox2.Text;
            email=TextBox3.Text;
            pass=TextBox4.Text;

            string q = "exec usersproc '" + fname + "','" + lname + "','" + email + "','" + pass + "','"+profile+"'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Registeration Successful');</script>");

            cleartext();
        }

        private void cleartext()
        {
            TextBox1.Text=String.Empty; 
            TextBox2.Text=String.Empty;
            TextBox3.Text=String.Empty;
            TextBox4.Text=String.Empty;
        }
    }
}