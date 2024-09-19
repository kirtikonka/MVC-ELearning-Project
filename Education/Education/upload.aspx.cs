using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Education
{
    public partial class upload : System.Web.UI.Page
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
            }

            //if (!IsPostBack)
            //{

            //}

            //ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

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
            ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            LoadSubcategories(categoryId);
            ddlCourse.Items.Clear();
            ddlCourse.Items.Insert(0, new ListItem("--Select Course--", "0"));
        }

        private void LoadSubcategories(int categoryId)
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
            ddlSubcategory.Items.Insert(0, new ListItem("--Select Subcategory--", "0"));
        }

        protected void ddlSubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int subcategoryId = Convert.ToInt32(ddlSubcategory.SelectedValue);
            LoadCourses(subcategoryId);
        }

        private void LoadCourses(int subcategoryId)
        {
                using (SqlCommand cmd = new SqlCommand("spGetCoursesBySubcategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubcategoryID", subcategoryId);
                    conn.Open();
                    ddlCourse.DataSource = cmd.ExecuteReader();
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataValueField = "CourseID";
                    ddlCourse.DataBind();
                }
            ddlCourse.Items.Insert(0, new ListItem("--Select Course--", "0"));
        }

        protected void btnUploadVideo_Click(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt32(ddlCourse.SelectedValue);
            string videoTitle = txtVideoTitle.Text.Trim();
            string youtubeLink = txtYouTubeLink.Text.Trim();

            if (courseId == 0 || string.IsNullOrEmpty(videoTitle) || string.IsNullOrEmpty(youtubeLink))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

                using (SqlCommand cmd = new SqlCommand("spUploadCourseVideo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@VideoTitle", videoTitle);
                    cmd.Parameters.AddWithValue("@YouTubeLink", youtubeLink);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        lblMessage.Text = "Video uploaded successfully.";
                        ClearForm();
                    }
                    else
                    {
                        lblMessage.Text = "Error uploading video. Please try again.";
                    }
                }
        }

        private void ClearForm()
        {
            ddlCategory.SelectedIndex = 0;
            ddlSubcategory.Items.Clear();
            ddlCourse.Items.Clear();
            txtVideoTitle.Text = string.Empty;
            txtYouTubeLink.Text = string.Empty;
        }







        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string vname, vcat, vurl, vdesc;
        //    vname = TextBox1.Text;
        //    vcat = categoryDropdown.SelectedValue;
        //    vdesc = TextBox3.Text;
        //    vurl = TextBox2.Text;

        //    string q = "exec videoproc '" + vname + "','" + vcat + "','" + vdesc + "'";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    cmd.ExecuteNonQuery();
        //    Response.Write("<script>alert('Video Added Successfully!');</script>");

        //    if (!Uri.TryCreate(vurl, UriKind.Absolute, out Uri validatedUrl))
        //    {
        //        return;
        //    }
        //    //string enteredUrl = validatedUrl.ToString();
        //}
        //protected void Dropdown1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int selectedCategoryId = int.Parse(categoryDropdown.SelectedValue);
        //    LoadSubcategories(selectedCategoryId);
        //}
        //private void LoadCategories()
        //{
        //    string sql = "SELECT vid, vname FROM video";
        //    SqlCommand command = new SqlCommand(sql, conn);

        //    using (SqlDataReader reader = command.ExecuteReader())
        //    {
        //        categoryDropdown.DataSource = reader;
        //        categoryDropdown.DataTextField = "vname";
        //        categoryDropdown.DataValueField = "vid";
        //        categoryDropdown.DataBind();
        //    }
        //}
        //private void LoadSubcategories(int categoryId)
        //{
        //    string sql = "SELECT sid, vsubcat FROM videosubcat WHERE vid = @vid";
        //    SqlCommand command = new SqlCommand(sql, conn);
        //    command.Parameters.AddWithValue("@vid", categoryId);

        //    using (SqlDataReader reader = command.ExecuteReader())
        //    {
        //        subcategoryDropdown.DataSource = reader;
        //        subcategoryDropdown.DataTextField = "vsubcat";
        //        subcategoryDropdown.DataValueField = "sid";
        //        subcategoryDropdown.DataBind();
        //        subcategoryDropdown.Enabled = reader.HasRows;
        //    }
        //}

        ////protected void Page_Load(object sender, EventArgs e)
        ////{
        ////    if (!IsPostBack)
        ////    {

        ////    }
        ////}

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    subcategoryDropdown.Items.Clear();
        //    switch (categoryDropdown.SelectedValue)
        //    {
        //        case "Java":
        //            subcategoryDropdown.Items.Add(new ListItem("Core Java"));
        //            subcategoryDropdown.Items.Add(new ListItem("Adv. Java"));
        //            subcategoryDropdown.Items.Add(new ListItem("MySQL"));
        //            break;

        //        case ".NET":
        //            subcategoryDropdown.Items.Add(new ListItem("ASP.NET"));
        //            subcategoryDropdown.Items.Add(new ListItem("C#"));
        //            subcategoryDropdown.Items.Add(new ListItem("SQL"));
        //            break;

        //        case "Others":
        //            subcategoryDropdown.Items.Add(new ListItem("Others"));
        //            break;

        //        default:
        //            break;
        //    }
        //}






        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string courseName = categoryDropdown.SelectedValue;
        //    string subCourse = subcategoryDropdown.SelectedValue;
        //    string topic = TextBox1.Text;
        //    string url = TextBox2.Text;
        //    string desc = TextBox3.Text;

        //    if (url.Contains("youtube.com"))
        //    {
        //        var uri = new Uri(url);
        //        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
        //        string videoId = query["v"];

        //        string embedUrl = $"https://www.youtube.com/embed/{videoId}";

        //        url = embedUrl;
        //    }

        //    // Insert into database
        //    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.Text;
        //        command.CommandText = "INSERT INTO video (vcat, vsubcat, vtitle, vurl, vdesc) " +
        //                              "VALUES (@vcat, @vsubcat, @vtitle, @vurl, vdesc)";

        //        command.Parameters.AddWithValue("@vcat", courseName);
        //        command.Parameters.AddWithValue("@vsubcat", subCourse);
        //        command.Parameters.AddWithValue("@vtitle", topic);
        //        command.Parameters.AddWithValue("@vurl", url);
        //        command.Parameters.AddWithValue("@vdesc", desc);

        //        try
        //        {
        //            connection.Open();
        //            int rowsAffected = command.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                // Display success message
        //                Response.Write("<script>alert('Course added successfully');</script>");
        //            }
        //            else
        //            {
        //                // Display error message
        //                Response.Write("<script>alert('Error adding course');</script>");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Display error message
        //            Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
        //        }
        //    }
        //}
    }
}