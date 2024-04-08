<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchUI.aspx.cs" Inherits="StockManagementWebApp.UI.SearchUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search And View</title>
    <link href="../Scripts/DataTables/datatables.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 55px;
        }
    </style>
</head>
<body>
    <form id="searchForm" runat="server">
    <fieldset>
<legend style="font-family: Algerian; font-size: xx-large; font-weight: 100;">Search And View</legend>
    <div>
        <table >
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Company: " Font-Names="Tahoma"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="companyDropDownList" AutoPostBack="True" runat="server" Height="43px" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" Width="258px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="font-family: Tahoma">
                    <asp:Label ID="Label2" runat="server" Text="Category: "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="categoryDropDownList"  runat="server" Height="32px" Width="255px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                
            </tr>
            <tr>
                <td></td>
                <td >
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Height="38px" style="margin-left: 133px" Width="98px" />
                </td>
            </tr>
        </table>
    </div>
        <a href="MenuUI.aspx" class="nav-link"> Back to Menu </a>
    </fieldset>
        <br/>

        <asp:GridView ID="searchGridView"  AutoGenerateColumns="False" Width="100%" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>   
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>                     
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Name">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("ItemName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Name">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("CompanyName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("CategoryName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Available Quantity">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Quantity") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reorder Level">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("ReorderLevel") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
           
    </form>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/DataTables/datatables.js"></script>
    <script>
        $(function () {
                $("#searchForm").validate({
                    rules: {
                        companyDropDownList: "required",
                        categoryDropDownList: "required"
                    },
                    messages: {
                        companyDropDownList: "Please Select Company First!",
                        categoryDropDownList: "Please Select Category First!"
                    }
                });
                $("#searchGridView").prepend($("<thead></thead>").append($("#searchGridView").find("tr:first"))).DataTable();
            
        });
    </script>
</body>
</html>
