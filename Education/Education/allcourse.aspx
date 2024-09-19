<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="allcourse.aspx.cs" Inherits="Education.allcourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>All Courses</title>

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
        <h2>View Courses</h2>

        <div>
            <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div>
            <asp:Label ID="lblSubcategory" runat="server" Text="Subcategory:"></asp:Label>
            <asp:DropDownList ID="ddlSubcategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubcategory_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                <asp:BoundField DataField="SubcategoryName" HeaderText="Subcategory" />
            </Columns>
        </asp:GridView>
    </div>
    <!--Section 1-->
<%--    <section class="hero-section d-flex justify-content-center align-items-center" id="section_1">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-12 mx-auto">
                    <h1 class="text-white text-center">Discover. Learn. Enjoy</h1>
                    <h6 class="text-center">platform for creatives around the world</h6>--%>
                    <%--                    <div method="get" class="custom-form mt-4 pt-2 mb-lg-0 mb-5" role="search">
                        <div class="input-group input-group-lg">
                            <span class="input-group-text bi-search" id="basic-addon1"></span>
                            <input name="keyword" type="search" class="form-control" id="keyword" placeholder=".Net, Java, ASP.Net ..." aria-label="Search">
                            <button type="submit" class="form-control">Search</button>
                        </div>
                    </div>--%>
<%--                </div>

            </div>
        </div>
    </section>--%>

    <!--Section 2-->
<%--    <section class="featured-section">
        <div class="container">
            <div class="row justify-content-center">

                <div class="col-lg-4 col-12 mb-4 mb-lg-0">
                    <div class="custom-block bg-white shadow-lg">--%>
                        <%--                        <a href="topics-detail.html">--%>
<%--                        <div class="d-flex">
                            <div>
                                <h5 class="mb-2">.Net</h5>
                                <p class="mb-0">Best courses</p>
                            </div>--%>
                            <%--                                <span class="badge bg-design rounded-pill ms-auto">3</span>--%>
<%--                        </div>

                        <img src="images/topics/undraw_Remote_design_team_re_urdx.png" class="custom-block-image img-fluid" alt="">--%>
                        <%-- </a>--%>
<%--                    </div>
                </div>

                <div class="col-lg-6 col-12">
                    <div class="custom-block custom-block-overlay">
                        <div class="d-flex flex-column h-100">
                            <img src="images/businesswoman-using-tablet-analysis.jpg" class="custom-block-image img-fluid" alt="">

                            <div class="custom-block-overlay-text d-flex">
                                <div>
                                    <h5 class="text-white mb-2">Java</h5>
                                    <p class="text-white">Best Courses</p>--%>
                                    <%--                                    <a href="topics-detail.html" class="btn custom-btn mt-2 mt-lg-3">Learn More</a>--%>
                                    <!--Changes -->
<%--                                </div>--%>
                                <%--                                <span class="badge bg-finance rounded-pill ms-auto">3</span>--%>
<%--                            </div>
                            <div class="section-overlay"></div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class="col-lg-4 col-12 mb-4 mb-lg-0">
                    <div class="custom-block bg-white shadow-lg">
                        <a href="topics-detail.html">
                            <div class="d-flex">
                                <div>
                                    <h5 class="mb-2">Others</h5>--%>
                                    <%--                                <p class="mb-0">Best courses</p>--%>
<%--                                </div>
                                <span class="badge bg-design rounded-pill ms-auto">3</span>
                            </div>
                            <img src="images/topics/undraw_Remote_design_team_re_urdx.png" class="custom-block-image img-fluid" alt="">
                        </a>
                    </div>
                </div>

            </div>
        </div>
    </section>

    <section class="explore-section section-padding" id="section_2">
        <div class="container">
            <div class="col-12 text-center">
                <h2 class="mb-4">All Courses</h2>
            </div>
        </div>--%>

        <%--        <div class="container-fluid">
            <div class="row">
                <ul class="nav nav-tabs" id="myTab" role="tablist">
                    <li class="nav-item" role="presentation">
                        <button class="nav-link active" id="net-tab" data-bs-toggle="tab" data-bs-target="#net-tab-pane" type="button" role="tab" aria-controls="net-tab-pane" aria-selected="true">.NET</button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link" id="java-tab" data-bs-toggle="tab" data-bs-target="#java-tab-pane" type="button" role="tab" aria-controls="java-tab-pane" aria-selected="false">Java</button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button class="nav-link" id="others-tab" data-bs-toggle="tab" data-bs-target="#others-tab-pane" type="button" role="tab" aria-controls="others-tab-pane" aria-selected="false">Others</button>
                    </li>
                </ul>
            </div>
        </div>--%>

<%--        <div class="container">
            <div class="row">

                <div class="col-12 col-lg-4 col-md-6 mb-4 mb-lg-0">
                    <div>--%>
                        <%--class="tab-content" id="myTabContent"--%>
<%--                        <div class="row fade show active">
                            <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand" GridLines="Horizontal">
                                <ItemTemplate>
                                    <div class="card custom-block bg-white shadow-lg col-lg-4 col-md-6 col-12 mb-4 mb-lg-0" style="width: 18rem;">
                                        <img class="card-img-top" height="100" width="100" src="<%#Eval("pic")%>" alt="Card image cap">
                                        <div class="card-body">
                                            <h5 class="card-title"><%#Eval("pname")%></h5>
                                        </div>
                                        <ul class="list-group list-group-flush">
                                            <li class="list-group-item"><%#Eval("pcat")%></li>
                                            <li class="list-group-item"><%#Eval("price")%></li>
                                            <li class="list-group-item">Quantity :
                                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                    </asp:DropDownList>
                                            </li>
                                        </ul>
                                        <div class="card-body">
                                            <asp:Button ID="Button1" CommandName="AddToCart" CommandArgument='<%#Eval("pid")%>' Class="btn btn-info rounded-pill btn-dark btn-lg btn-block" runat="server" Text="Add to Cart" />
                                        </div>

                                    </div>
                                </ItemTemplate>
                            </asp:DataList>--%>
                            <%--                            <asp:SqlDataSource runat="server" ID="SqlDataSource1"></asp:SqlDataSource>--%>
<%--                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>--%>

    <%--    <footer class="site-footer section-padding">
        <div class="container">
            <div class="row">

                <div class="col-lg-3 col-12 mb-4 pb-2">
                    <a class="navbar-brand mb-2" href="welcome.aspx">
                        <i class="bi-back"></i>
                        <span>EduStation</span>
                    </a>
                </div>

            </div>
        </div>
    </footer>--%>








    <!-- JAVASCRIPT FILES -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/jquery.sticky.js"></script>
    <script src="js/click-scroll.js"></script>
    <script src="js/custom.js"></script>

</asp:Content>
