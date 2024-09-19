<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="Education.upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Upload Videos</title>

    <!-- CSS FILES -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;600;700&family=Open+Sans&display=swap" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-icons.css" rel="stylesheet">
    <link href="css/templatemo-topic-listing.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div>
            <h2>Upload Course Video</h2>
            
            <div>
                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
            </div>
            
            <div>
                <asp:Label ID="lblSubcategory" runat="server" Text="Subcategory:"></asp:Label>
                <asp:DropDownList ID="ddlSubcategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubcategory_SelectedIndexChanged"></asp:DropDownList>
            </div>
            
            <div>
                <asp:Label ID="lblCourse" runat="server" Text="Course:"></asp:Label>
                <asp:DropDownList ID="ddlCourse" runat="server"></asp:DropDownList>
            </div>
            
            <div>
                <asp:Label ID="lblVideoTitle" runat="server" Text="Video Title:"></asp:Label>
                <asp:TextBox ID="txtVideoTitle" runat="server"></asp:TextBox>
            </div>
            
            <div>
                <asp:Label ID="lblYouTubeLink" runat="server" Text="YouTube Link:"></asp:Label>
                <asp:TextBox ID="txtYouTubeLink" runat="server"></asp:TextBox>
            </div>
            
            <div>
                <asp:Button ID="btnUploadVideo" runat="server" Text="Upload Video" OnClick="btnUploadVideo_Click" />
            </div>
            
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>


















<%--    <style>
        .gradient-custom {
            background: #f093fb;
            background: -webkit-linear-gradient(to bottom right, rgba(240, 147, 251, 1), rgba(245, 87, 108, 1));
            background: linear-gradient(to bottom right, rgba(240, 147, 251, 1), rgba(245, 87, 108, 1))
        }
    </style>--%>

<%--    <div class="text-black fw-normalalign-items-center hero-section justify-content-center align-items-center" style="display: flex;" >

        <div style="width: 25%; display: flex; flex-direction: column; gap: 10px">
            <div style="text-align: center; text-transform: uppercase; font-size: xx-large">Upload Video</div>
            <div class="form-group">
                <label for="exampleInputEmail1">Title: </label>
                <asp:TextBox ID="TextBox1" class="form-control" placeholder="Add Video Title" runat="server"></asp:TextBox>
            </div>
--%>
<%--        <div class="form-container">
            <asp:ListBox ID="lstCourseName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstCourseName_SelectedIndexChanged">
                <asp:ListItem Value="JAVA">JAVA</asp:ListItem>
                <asp:ListItem Value=".NET">.NET</asp:ListItem>
                <asp:ListItem Value="PYTHON">PYTHON</asp:ListItem>
            </asp:ListBox>
        </div>--%>

<%--            <div class="form-group">
                <label for="Category" runat="server">Category: </label>
                <asp:DropDownList ID="categoryDropdown" class="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>.NET</asp:ListItem>
                    <asp:ListItem>Java</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label for="SubCategory" runat="server">SubCategory: </label>
                <asp:DropDownList ID="subcategoryDropdown" runat="server" class="form-control" >
                    <asp:ListItem>.C# (.NET)</asp:ListItem>
                    <asp:ListItem>ASP.NET (.NET)</asp:ListItem>
                    <asp:ListItem>SQL (.NET)</asp:ListItem>
                    <asp:ListItem>Core Java (Java)</asp:ListItem>
                    <asp:ListItem>Adv. Java (Java)</asp:ListItem>
                    <asp:ListItem>MySQL (Java)</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Description of the Video: </label>
                <br />
                <asp:TextBox ID="TextBox3" class="form-control" placeholder="Add Description" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Upload URL: </label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="url" CssClass="form-control" placeholder="https://example.com" required="required"></asp:TextBox>
            </div>--%>
<%--                    <input type="url" name="url" id="url" placeholder="https://example.com" class="form-control" runat="server" required />--%>
<%--                <asp:HyperLink ID="HyperLink1" class="form-control" placeholder="Add Link" runat="server"></asp:HyperLink>--%>
<%--                <iframe id="iframeID" src="http://www.weather.com" sandbox="" seamless="" width="100%" height="200"></iframe>
                <form name="FormInput" action="" method="get" id="input" onsubmit="document.getElementById('iframeID').src=document.FormInput.site.value;">
                    Website URL: --%>
<%--            <div style="width: 100%; display: flex; align-items: center; justify-content: center">
                <asp:Button ID="Button1" class="btn btn-dark btn-lg btn-block" Style="color: white;" runat="server" Width="100%" Text="Upload" OnClick="Button1_Click" />
            </div>
        </div>
    </div>--%>

    <!-- JAVASCRIPT FILES -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/jquery.sticky.js"></script>
    <script src="js/click-scroll.js"></script>
    <script src="js/custom.js"></script>

</asp:Content>
