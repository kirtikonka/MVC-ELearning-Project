<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="mycourses.aspx.cs" Inherits="Education.mycourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Purchased Courses</title>

    <!-- CSS FILES -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;600;700&family=Open+Sans&display=swap" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-icons.css" rel="stylesheet">
    <link href="css/templatemo-topic-listing.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-black fw-normal d-flex align-items-center hero-section d-flex justify-content-center align-items-center" style="display: flex;" >
        <div>
            <h2>Available Video Courses</h2>
            
            <asp:GridView ID="gvAvailableCourses" runat="server" AutoGenerateColumns="False" OnRowCommand="gvAvailableCourses_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnPurchase" runat="server" Text="Purchase" CommandName="PurchaseCourse" CommandArgument='<%# Eval("CourseID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <h2>My Purchased Courses</h2>
            
            <asp:GridView ID="gvPurchasedCourses" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("ExpiryDate")) >= DateTime.Now ? "Active" : "Expired" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnViewCourse" runat="server" Text="View Course" Enabled='<%# Convert.ToDateTime(Eval("ExpiryDate")) >= DateTime.Now %>' OnClick="btnViewCourse_Click" CommandArgument='<%# Eval("CourseID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <!-- JAVASCRIPT FILES -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/jquery.sticky.js"></script>
    <script src="js/click-scroll.js"></script>
    <script src="js/custom.js"></script>

</asp:Content>
