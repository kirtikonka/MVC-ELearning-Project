using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Education
{
    public partial class mycourses : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                LoadAvailableCourses();
                LoadPurchasedCourses();
            }
        }

        private void LoadAvailableCourses()
        {
                using (SqlCommand cmd = new SqlCommand("spGetAvailableCourses", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    gvAvailableCourses.DataSource = cmd.ExecuteReader();
                    gvAvailableCourses.DataBind();
                }
        }

        private void LoadPurchasedCourses()
        {
                using (SqlCommand cmd = new SqlCommand("spGetPurchasedCourses", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    conn.Open();
                    gvPurchasedCourses.DataSource = cmd.ExecuteReader();
                    gvPurchasedCourses.DataBind();
                }
        }

        protected void gvAvailableCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PurchaseCourse")
            {
                int courseId = Convert.ToInt32(e.CommandArgument);
                PurchaseCourse(courseId);
                LoadAvailableCourses();
                LoadPurchasedCourses();
            }
        }

        private void PurchaseCourse(int courseId)
        {
                using (SqlCommand cmd = new SqlCommand("spPurchaseCourse", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
        }

        protected void btnViewCourse_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int courseId = Convert.ToInt32(btn.CommandArgument);
            // Redirect to the course viewing page
            Response.Redirect($"ViewCourse.aspx?CourseID={courseId}");
        }

        private int GetCurrentUserId()
        {
            // Implement this method to return the current user's ID
            // For example, you might get it from a session variable or authentication system
            return 1; // Placeholder value
        }
    }
}