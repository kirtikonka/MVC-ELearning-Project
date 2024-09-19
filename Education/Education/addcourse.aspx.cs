using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Education
{
    public partial class addcourse : System.Web.UI.Page
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

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            int subcategoryId = Convert.ToInt32(ddlSubcategory.SelectedValue);
            string courseName = txtCourseName.Text.Trim();

            if (categoryId == 0 || subcategoryId == 0 || string.IsNullOrEmpty(courseName))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

                using (SqlCommand cmd = new SqlCommand("spAddCourse", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                    cmd.Parameters.AddWithValue("@SubcategoryID", subcategoryId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        lblMessage.Text = "Course added successfully.";
                        ClearForm();
                    }
                    else
                    {
                        lblMessage.Text = "Error adding course. Please try again.";
                    }
                }
        }

        private void ClearForm()
        {
            ddlCategory.SelectedIndex = 0;
            ddlSubcategory.Items.Clear();
            txtCourseName.Text = string.Empty;
        }






        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string pname, pcat, pic, pdesc;
        //    double price;
        //    pname = TextBox1.Text;
        //    pcat = DropDownList1.SelectedValue;
        //    FileUpload1.SaveAs(System.Web.HttpContext.Current.Server.MapPath("product/") + Path.GetFileName(FileUpload1.FileName));
        //    pic = "product/" + Path.GetFileName(FileUpload1.FileName);
        //    price = double.Parse(TextBox3.Text);
        //    //int price = (int)Math.Floor(double.Parse(TextBox3.Text));
        //    pdesc = TextBox4.Text;
        //    string q = "exec addproductproc '" + pname + "','" + pcat + "','" + pdesc   + "','" + price + "','" + pic + "'";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    cmd.ExecuteNonQuery();
        //    Response.Write("<script>alert('Product Added Successfully!');</script>");
        //}





        //protected void btnAddCourse_Click(object sender, EventArgs e)
        //{
        //    string courseName = DropDownList1.SelectedValue;
        //    string subCourseName = SubCourse.Text;
        //    decimal price;

        //    string imagePath = null;
        //    if (FileUpload1.HasFile)
        //    {
        //        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //        string folderPath = Server.MapPath("/Images/");
        //        if (!Directory.Exists(folderPath))
        //        {
        //            Directory.CreateDirectory(folderPath);
        //        }
        //        FileUpload1.SaveAs(folderPath + fileName);
        //        imagePath = "/Images/" + fileName;
        //    }

        //    if (decimal.TryParse(CoursePrice.Text, out price))
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["E-Learning"].ConnectionString;
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand("AddCourse", connection))
        //            {
        //                command.CommandType = System.Data.CommandType.StoredProcedure;
        //                command.Parameters.AddWithValue("@CourseName", courseName);
        //                command.Parameters.AddWithValue("@SubcourseName", subCourseName);
        //                command.Parameters.AddWithValue("@Price", price);
        //                command.Parameters.AddWithValue("@ImagePath", imagePath);
        //                command.ExecuteNonQuery();
        //                Response.Write("<script>alert('Course Added Successfully')</script>");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Invalid Price')</script>");
        //    }
        //}
    }
}