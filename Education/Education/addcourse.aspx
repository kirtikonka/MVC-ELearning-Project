<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addcourse.aspx.cs" Inherits="Education.addcourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Add New Course</title>

    <!-- CSS FILES -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;600;700&family=Open+Sans&display=swap" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-icons.css" rel="stylesheet">
    <link href="css/templatemo-topic-listing.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-black fw-normal d-flex align-items-center hero-section justify-content-center">
        <div style="width: 25%; display: flex; flex-direction: column; gap: 10px">

            <div style="text-align: center; text-transform: uppercase; font-size: xx-large">Add New Course</div>

            <div class="form-group">
                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblSubcategory" runat="server" Text="Subcategory:"></asp:Label>
                <asp:DropDownList ID="ddlSubcategory" class="form-control" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:label for="lblCourseName" runat="server" Text="Course Name:"></asp:Label>
                <asp:TextBox ID="txtCourseName" class="form-control" placeholder="Add Product Name" runat="server"></asp:TextBox>
           </div>

            <div class="form-group">
                <asp:Label ID="lblImage" runat="server" Text="Course Image"></asp:Label>
                <asp:FileUpload ID="FileUpload2" runat="server" class="form-control" />
            </div>

            <div>
                <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" class="btn btn-primary mt-3 form-control" OnClick="btnAddCourse_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>

    </div>

    <%--    <div class="text-black fw-normal d-flex align-items-center hero-section justify-content-center">
        
        <div style="width: 25%; display: flex; flex-direction: column; gap: 10px">
            <div style="text-align: center; text-transform: uppercase; font-size: xx-large">Add New Course</div>
            <div class="form-group">
                <label for="exampleInputEmail1">Name: </label>
                <asp:TextBox ID="TextBox1" class="form-control" placeholder="Add Product Name" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Category</label>
                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                    <asp:ListItem>.NET</asp:ListItem>
                    <asp:ListItem>Java</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Price: </label>
                <asp:TextBox ID="TextBox3" class="form-control" placeholder="Add Price" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Picture: </label>
                <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Description: </label>
                <br />
                <asp:TextBox ID="TextBox4" class="form-control" placeholder="Add Description" runat="server"></asp:TextBox>
            </div>
            <div style="width: 100%; display: flex; align-items: center; justify-content: center">
                <asp:Button ID="Button1" class="btn btn-dark btn-lg btn-block" Style="color: white;" runat="server" Width="100%" Text="Add Product" OnClick="Button1_Click" />
            </div>
        </div>
    </div>--%>

    <!-- JAVASCRIPT FILES -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/jquery.sticky.js"></script>
    <script src="js/click-scroll.js"></script>
    <script src="js/custom.js"></script>


    <%--<div class="mybg">
    <div class="container mt-5 mb-2 mb-5 overflow-hidden">
        <div runat="server" class="form-container w-50 border shadow offset-3 rounded">
            <div style="padding: 20px">
                <h2 class="text-center">Add Course</h2>

                <div class="form-group">
                    <asp:Label ID="PName" runat="server" Text="Course Name"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                        <asp:ListItem>.net</asp:ListItem>
                        <asp:ListItem>Java</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />

                <div class="form-group">
                    <asp:Label ID="Pcat" runat="server" Text="SubCourse"></asp:Label>
                    <asp:TextBox ID="SubCourse" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <br />

                <div class="form-group">
                    <asp:Label ID="Price" runat="server" Text="Price"></asp:Label>
                    <asp:TextBox ID="CoursePrice" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <br />

                <div class="form-group">
                    <asp:Label ID="lblImage" runat="server" Text="Course Image"></asp:Label>
                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                </div>
                <br />

                <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" class="btn btn-primary mt-3" OnClick="btnAddCourse_Click" />
            </div>
        </div>
    </div>
</div>--%>

</asp:Content>
