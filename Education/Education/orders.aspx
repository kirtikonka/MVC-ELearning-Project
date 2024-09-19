<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="Education.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Orders</title>

    <!-- CSS FILES -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;600;700&family=Open+Sans&display=swap" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-icons.css" rel="stylesheet">
    <link href="css/templatemo-topic-listing.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; padding-left: 50px; padding-right: 100px; display: flex;" class="text-black fw-normal d-flex align-items-center hero-section d-flex justify-content-center align-items-center">
        <br />
        <br />

        <div style="display: flex; gap: 10px; align-items: center;">
            From
            <asp:TextBox ID="TextBox1" class="form-control" Style="width: 200px" runat="server" TextMode="Date"></asp:TextBox>
            To
            <asp:TextBox ID="TextBox2" class="form-control" Style="width: 200px" runat="server" TextMode="Date"></asp:TextBox>
            <asp:Button ID="Button1" class="btn" BackColor="#9834eb" ForeColor="White" runat="server" Text="Search" OnClick="Button1_Click" />
        </div>
        <br />
        <br />

        <div>
            <h2>Admin Order Management</h2>
            
            <asp:GridView ID="gvAllOrders" runat="server" AutoGenerateColumns="False" 
                OnRowDataBound="gvAllOrders_RowDataBound" DataKeyNames="OrderID"
                OnRowCommand="gvAllOrders_RowCommand">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                    <asp:BoundField DataField="Username" HeaderText="User" />
                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem Text="Pending" Value="Pending" />
                                <asp:ListItem Text="Processing" Value="Processing" />
                                <asp:ListItem Text="Completed" Value="Completed" />
                                <asp:ListItem Text="Cancelled" Value="Cancelled" />
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnUpdateStatus" runat="server" Text="Update Status" 
                                CommandName="UpdateStatus" CommandArgument='<%# Eval("OrderID") %>' />
                            <asp:Button ID="btnViewDetails" runat="server" Text="View Details" 
                                CommandName="ViewDetails" CommandArgument='<%# Eval("OrderID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <asp:Panel ID="pnlOrderDetails" runat="server" Visible="false">
                <h3>Order Details</h3>
                <asp:Label ID="lblOrderID" runat="server" Font-Bold="true"></asp:Label>
                <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>


<%--        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" PageSize="5" CellPadding="10" GridLines="None" HorizontalAlign="Center" Width="100%" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="pid" HeaderText="pid" ReadOnly="True" InsertVisible="False" SortExpression="pid" />
                <asp:BoundField DataField="pname" HeaderText="pname" SortExpression="pname" />
                <asp:BoundField DataField="pcat" HeaderText="pcat" SortExpression="pcat" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price"></asp:BoundField>
                <asp:BoundField DataField="qty" HeaderText="qty" SortExpression="qty" />
                <asp:BoundField DataField="pic" HeaderText="pic" SortExpression="pic"></asp:BoundField>
                <asp:BoundField DataField="dt" HeaderText="dt" SortExpression="dt" />
                <asp:BoundField DataField="suser" HeaderText="suser" SortExpression="suser"></asp:BoundField>
                <asp:BoundField DataField="perprice" HeaderText="perprice" SortExpression="perprice"></asp:BoundField>
                <asp:BoundField DataField="address" HeaderText="address" SortExpression="address"></asp:BoundField>
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:TemplateField>
                    </asp:TemplateField>
            </Columns>
            <EditRowStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbconn %>" SelectCommand="SELECT * FROM [placeorder]"></asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" CellPadding="10" HorizontalAlign="Center" PageSize="5" Width="100%" AutoGenerateColumns="False" GridLines="None">
            <Columns>
                <asp:ImageField DataImageUrlField="pic" HeaderText="Image" ControlStyle-Height="50px" ControlStyle-Width="50px"></asp:ImageField>
                <asp:BoundField DataField="pname" HeaderText="Name" SortExpression="pname"></asp:BoundField>
                <asp:BoundField DataField="pcat" HeaderText="Category" SortExpression="pcat"></asp:BoundField>
                <asp:BoundField DataField="perprice" HeaderText="Price" SortExpression="perprice"></asp:BoundField>
                <asp:BoundField DataField="qty" HeaderText="Quantity" SortExpression="qty"></asp:BoundField>
                <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt"></asp:BoundField>
                <asp:BoundField DataField="price" HeaderText="Total Price" SortExpression="price"></asp:BoundField>

                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" class="btn" BackColor="#9834eb" ForeColor="White" CommandName="status" CommandArgument='<%#Eval("pid")%>' Text="Approve" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>--%>

    </div>
    <!-- JAVASCRIPT FILES -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/jquery.sticky.js"></script>
    <script src="js/click-scroll.js"></script>
    <script src="js/custom.js"></script>

</asp:Content>
