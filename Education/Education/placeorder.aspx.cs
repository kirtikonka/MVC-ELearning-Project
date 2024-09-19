using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Razorpay;
using Razorpay.Api;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net.Mime;
using Font = System.Drawing.Font;
using System.Data;

namespace Education
{
    public partial class placeorder : System.Web.UI.Page
    {
        SqlConnection conn;
        //string s = "true";
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
            //Session["MyUser"] = "piyushmaurya7799@gmail.com";
            //if (!IsPostBack)
            //{
            //    FetchDetails();
            //}


            if (!IsPostBack)
            {
                LoadCourses();
                LoadCart();
            }
        }

        private void LoadCourses()
        {
                using (SqlCommand cmd = new SqlCommand("spGetAvailableCourses", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    gvCourses.DataSource = cmd.ExecuteReader();
                    gvCourses.DataBind();
                }
        }

        private void LoadCart()
        {
                using (SqlCommand cmd = new SqlCommand("spGetCartItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    gvCart.DataSource = dt;
                    gvCart.DataBind();

                    decimal totalAmount = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalAmount += Convert.ToDecimal(row["Price"]) * Convert.ToInt32(row["Quantity"]);
                    }
                    lblTotalAmount.Text = $"Total Amount: {totalAmount:C}";
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

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int courseId = Convert.ToInt32(e.CommandArgument);
                RemoveFromCart(courseId);
                LoadCart();
            }
        }

        private void AddToCart(int courseId)
        {
                using (SqlCommand cmd = new SqlCommand("spAddToCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
        }

        private void RemoveFromCart(int courseId)
        {
                using (SqlCommand cmd = new SqlCommand("spRemoveFromCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
                using (SqlCommand cmd = new SqlCommand("spPlaceOrder", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", GetCurrentUserId());
                    SqlParameter outputParam = new SqlParameter("@OrderID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    int orderId = Convert.ToInt32(outputParam.Value);
                    lblMessage.Text = $"Order placed successfully. Your Order ID is: {orderId}";
                }
            LoadCart(); // Refresh the cart after placing the order
        }

        private int GetCurrentUserId()
        {
            // Implement this method to return the current user's ID
            // For example, you might get it from a session variable or authentication system
            return 1; // Placeholder value
        }





        //protected void FetchDetails()
        //{
        //    if (Session["MyUser"].ToString() != "")
        //    {

        //        //string email = "piyushmaurya7799@gmail.com";
        //        string email = Session["MyUser"].ToString();  //uncomment
        //        Label2.Text = email;
        //        Label4.Text = Session["Address"].ToString();
        //        Label3.Text = Session["contact"].ToString();
        //        Label1.Text = "Inv" + GenerateOrderId();
        //        Label5.Text = Session["GrandTotal"].ToString();
        //    }
        //}
        //protected string GenerateOrderId()
        //{
        //    Random random = new Random();
        //    return random.Next(100, 999).ToString();
        //}
        //protected void DownloadInvoice()
        //{
        //    //if (1==1)
        //    //{
        //    //s = "false";
        //    SendMail();
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=OrderInvoice.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter writer = new HtmlTextWriter(sw);
        //    Panel1.RenderControl(writer);
        //    StringReader stringReader = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //    HTMLWorker worker = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    worker.Parse(stringReader);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();


        //    //HttpContext.Current.Response.Close();
        //    //HttpContext.Current.ApplicationInstance.CompleteRequest();
        //    //    return;
        //    //}
        //    //SendMail();
        //}
        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //    DownloadInvoice();
        //}
        //public override void VerifyRenderingInServerForm(Control control)
        //{

        //}

        //protected void SendMail()
        //{
        //    try
        //    {
        //        // Directory where PDFs are stored
        //        string directoryPath = @"C:\Users\Asus\Downloads\"; // Replace with your directory path
        //        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
        //        FileInfo newestFile = directoryInfo.GetFiles("*.pdf")
        //                                           .OrderByDescending(f => f.LastWriteTime)
        //                                           .FirstOrDefault();

        //        if (newestFile == null)
        //        {
        //            // No PDF files found in the directory
        //            return;
        //        }

        //        string recipient = Session["MyUser"].ToString(); // Replace with the recipient's email
        //        string subject = "Subject of the Email";
        //        string body = "Body of the email";

        //        // Create a new MailMessage object
        //        MailMessage mail = new MailMessage();
        //        mail.From = new MailAddress("piyushmaurya7798@gmail.com"); // Replace with your email
        //        mail.To.Add(recipient);
        //        mail.Subject = subject;
        //        mail.Body = body;

        //        // Attach the newest PDF
        //        mail.Attachments.Add(new Attachment(newestFile.FullName));

        //        // Configure the SMTP client
        //        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // Replace with your SMTP server
        //        smtpClient.Port = 587; // Replace with your SMTP port
        //        smtpClient.Credentials = new NetworkCredential("piyushmaurya7798@gmail.com", "qbposjoyllyywcld"); // Replace with your credentials
        //        smtpClient.EnableSsl = true; // Enable SSL if required by your server

        //        // Send the email
        //        smtpClient.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception (e.g., log it)
        //        // For simplicity, we are just writing to the Event Log
        //        EventLog.WriteEntry("EmailService", ex.Message, EventLogEntryType.Error);
        //    }

        //}



        //protected void SendEmailButton_Click(object sender, EventArgs e)
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Convert the panel to an image
        //    Bitmap bitmap = RenderPanelToBitmap(Panel1);

        //    Save the image to a memory stream
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitmap.Save(ms, ImageFormat.Png);
        //        ms.Position = 0;

        //        Send the email with the attachment
        //        SendEmailWithAttachment(ms, "panel_image.png");
        //    }
        //}

        //private Bitmap RenderPanelToBitmap(Panel panel)
        //{
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //        panel.RenderControl(hw);
        //        string panelHtml = sw.ToString();

        //        Convert HTML to image
        //        return HtmlToImageConverter(panelHtml);
        //    }
        //}

        //private Bitmap HtmlToImageConverter(string html)
        //{
        //    Implementation for converting HTML to image

        //    This part requires a third - party library or a custom solution.

        //    Here we provide a placeholder method.


        //    For simplicity, returning a dummy image.


        //   Bitmap bitmap = new Bitmap(400, 300);
        //    using (Graphics g = Graphics.FromImage(bitmap))
        //    {
        //        g.Clear(Color.White);
        //        g.DrawString("HTML to Image Conversion Needed", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));

        //    }
        //    return bitmap;
        //}

        //private void SendEmailWithAttachment(Stream attachmentStream, string attachmentName)
        //{
        //    try
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.From = new MailAddress("piyushmaurya7798@gmail.com");
        //        mail.To.Add("piyushmaurya7799@gmail.com");
        //        mail.Subject = "Panel Image Attachment";
        //        mail.Body = "Please find the attached image of the panel.";

        //        Attachment attachment = new Attachment(attachmentStream, attachmentName, MediaTypeNames.Image.Jpeg);
        //        mail.Attachments.Add(attachment);

        //        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
        //        smtpClient.Port = 587;
        //        smtpClient.Credentials = new System.Net.NetworkCredential("piyushmaurya7798@gmail.com", "qbposjoyllyywcld");
        //        smtpClient.EnableSsl = true;

        //        smtpClient.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        Handle exceptions
        //    }
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    SendMail();
        //}

        //demo use not important --->

        //        protected void Button2_Click(object sender, EventArgs e)
        //        {
        //            string KeyId = "rzp_test_4DrJJevYZkd0No";
        //            string KeySecret = "3oX1Dvxlpy2wB3BGnDPxGtH8";
        //            RazorpayClient razorpayClient=new RazorpayClient(KeyId, KeySecret);

        //            double amount = double.Parse(Session["GrandTotal"].ToString());
        //            Dictionary<string ,object> options= new Dictionary<string ,object>();
        //            options.Add("amount", amount * 100);
        //            options.Add("currency", "INR");
        //            //options.Add("recepit", "oeder_recepit_123");
        //            options.Add("payment_capture",1);

        //            Razorpay.Api.Order order =razorpayClient.Order.Create(options);

        //            string orderId = order["id"].ToString();

        //            string razorpayScript = $@"
        //            var options=
        //            {{
        //            'key':'{KeyId}',
        //'amount':{amount * 100},
        //'currency':'INR',
        //'name':'Eyescape',
        //'description':'Check out',
        //'order_id':'{orderId}',
        //'handler':function(response)
        //{{
        //alert('Payment Successfull.Payment ID: '+response.razorpay_payment_id);
        //}},

        //'theme':{{'color':'#ffffff'
        //}}
        //}};
        //var rzp =new Razorpay(options);
        //rzp.open();";

        //            ClientScript.RegisterStartupScript(this.GetType(), "razorpayScript", razorpayScript,true);


        //        }
    }
}