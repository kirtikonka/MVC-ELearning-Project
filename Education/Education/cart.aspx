<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Education.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>My Cart</title>

    <!-- CSS FILES -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;600;700&family=Open+Sans&display=swap" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-icons.css" rel="stylesheet">
    <link href="css/templatemo-topic-listing.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--    <div style="padding: 50px"  class="hero-section justify-content-center align-items-center ext-black fw-normal">
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="False" AutoGenerateColumns="False" CellPadding="10" HorizontalAlign="Center" Width="100%" AlternatingRowStyle-BorderStyle="None" GridLines="None" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("pid")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image Height="50" Width="50" ImageUrl='<%#Eval("pic")%>' ID="Image1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("pname")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("perprice")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("qty")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Price">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("price")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>--%>
    <%--<asp:Button ID="Button1" CommandName="Delete" class="btn btn-secondary" runat="server" Text="Remove" />--%>
    <%--                        <asp:Button ID="Button1" runat="server" Text="Remove" CommandName="Delete" class="btn btn-dark btn-lg btn-block"/>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
            <EditRowStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <div style="display: flex; justify-content: center; padding-right: 110px; font-weight: bold; font-size: large; padding-top: 50px">
            Grand Total :&nbsp<asp:Label ID="Label8" runat="server" Text=" "></asp:Label>
        </div>
        &nbsp;
    <br />
        <br />
        <div style="width: 30%;">
            <div style="display: flex; align-items: center;">
                &nbsp;<asp:Label ID="Label9" runat="server" Text="Address" Width="150"></asp:Label>
                &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" class="form-control" placeholder="Enter Address" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div style="display: flex; align-items: center;">
                <asp:Label ID="Label10" runat="server" Text="Contact No" Width="150"></asp:Label>&nbsp&nbsp&nbsp
    <asp:TextBox ID="TextBox3" class="form-control" placeholder="Enter Contact no" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
        </div>
        <br />
        <br />
        <br />

        <div style="display: flex; justify-content: space-between; padding-right: 50px; padding-left: 50px;">--%>
    <%--            <a href="UserHome.aspx">
                <button type="button" class="btn" style="width: 190px; height: 40px; background-color: #9834eb; color: white"><i class="fa fa-arrow-left" style="margin: 0; padding: 0">Continue Shopping</i></button></a> <%-- //Require change--%>--%>
    <%--            <asp:Button ID="Button2" class="btn btn-dark btn-lg btn-block" runat="server" Text="Place Order" OnClick="Button2_Click1" />
        </div>
    </div>--%>


    <div>
        <h2>Course Catalog</h2>

        <asp:DropDownList ID="ddlSubcategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubcategory_SelectedIndexChanged"></asp:DropDownList>

        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCourses_RowCommand">
            <Columns>
                <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CommandName="AddToCart" CommandArgument='<%# Eval("CourseID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <h2>Shopping Cart</h2>

        <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand">
            <Columns>
                <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("CourseID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblGrandTotal" runat="server" Font-Bold="true"></asp:Label>
    </div>


    <!-- JAVASCRIPT FILES -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/jquery.sticky.js"></script>
    <script src="js/click-scroll.js"></script>
    <script src="js/custom.js"></script>

</asp:Content>
