<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="Education.users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>User List</title>

    <!-- CSS FILES -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;600;700&family=Open+Sans&display=swap" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-icons.css" rel="stylesheet">
    <link href="css/templatemo-topic-listing.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="text-black fw-normal hero-section justify-content-center align-items-center" style="display: flex;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" EnableViewState="False">
            <Columns>
<%--            <asp:TemplateField HeaderText="Profile">
                <ItemTemplate>
                    <asp:Image ID="Image1" Height="100" Width="100"
                        ImageUrl='<%#Eval("acc_profile")%>' runat="server"></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Username">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text ='<%#Eval("fname")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("email")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Role">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("profile") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="Button1" class="btn btn-danger" CommandName="Delete" runat="server" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    </section>
</asp:Content>
