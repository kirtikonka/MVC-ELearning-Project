<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="placeorder.aspx.cs" Inherits="Education.placeorder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Place Order</title>

    <!-- CSS FILES -->
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin=""/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;600;700&family=Open+Sans&display=swap" rel="stylesheet"/>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/bootstrap-icons.css" rel="stylesheet"/>
    <link href="css/templatemo-topic-listing.css" rel="stylesheet"/>


    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 286px;
        }

        .auto-style3 {
            width: 403px;
        }

        .auto-style7 {
            width: 538px;
        }

        .auto-style8 {
            width: 538px;
            height: 57px;
        }

        .auto-style9 {
            height: 57px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="padding: 30px; height: 100vh">
        <div style="border: solid 1px black; display: flex; padding: 20px" class="text-black fw-normal d-flex align-items-center hero-section d-flex justify-content-center align-items-center">


            <h2>Available Courses</h2>
            <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCourses_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" 
                                CommandName="AddToCart" CommandArgument='<%# Eval("CourseID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <h2>Your Shopping Cart</h2>
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" 
                                CommandName="Remove" CommandArgument='<%# Eval("CourseID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
            <br />
            <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>


<%--            <asp:Panel ID="Panel1" runat="server" Height="500px">
                <table class="auto-style1" style="">
                    <tr>
                        <td class="auto-style7">Order ID :&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                        <td>Email ID :&nbsp;
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                            <br />

                            Contact no :&nbsp;
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Seller Address:&nbsp;&nbsp;Masstech Business Solutions</td>
                        <td class="auto-style9"><strong>Buyer Address :</strong>&nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server"></asp:Label>
                            <br />
                            <br />

                            <br />
                        </td>

                    </tr>

                    <tr>
                        <td class="auto-style3" colspan="2">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="10" DataSourceID="PaymentData" ForeColor="Black" Height="121px" HorizontalAlign="Center" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="pname" HeaderText="Product Name" SortExpression="pname" />
                                    <asp:BoundField DataField="perprice" HeaderText="Price" SortExpression="perprice" />
                                    <asp:BoundField DataField="qty" HeaderText="Quantity" SortExpression="qty" />
                                    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" />
                                    <asp:BoundField DataField="price" HeaderText="Total Price" SortExpression="price" />
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="PaymentData" runat="server" ConnectionString="<%$ ConnectionStrings:dbconn %>" SelectCommand="SELECT [pname], [price], [qty], [perprice], [dt] FROM [PaymentPlace] WHERE ([suser] = @suser)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="suser" SessionField="MyUser" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>


                    </tr>
                    <tr class="">
                        <td class="auto-style7  " style="padding: 30px">
                            <div style="margin-left: 100px; font-weight: bold; font-size: 20px">
                                Grand Total : 
                            </div>
                        </td>
                        <td>
                            <div style="display: flex; justify-content: flex-end; align-items: center; margin-right: 23%; font-weight: bold; font-size: 20px">
                                <asp:Label ID="Label5" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>

                <br />

            </asp:Panel>
        </div>
        <br />
        <br />
        <div style="display: flex; justify-content: center">
            <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Download Invoice" OnClick="Button1_Click" />--%>


<%--<asp:Button ID="Button2" class="btn btn-secondary" runat="server" Text="Get on mail" OnClick="Button2_Click" />--%>
            <br />
<%--<asp:Label ID="Label7" runat="server" Text="Please download the invoice then u can get it on mail by clicking on the above button"></asp:Label>--%>
        </div>
    </form>
    <!-- JAVASCRIPT FILES -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/jquery.sticky.js"></script>
    <script src="js/click-scroll.js"></script>
    <script src="js/custom.js"></script>

</body>
</html>
