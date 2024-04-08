<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesUI.aspx.cs" Inherits="StockManagementWebApp.UI.ViewSalesUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Sale</title>
    <link href="../Scripts/jquery-ui-1.12.1.custom/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Scripts/DataTables/datatables.min.css" rel="stylesheet" />
</head>
<body>
    <form id="viewSalesForm" runat="server">
    <fieldset>
    <legend style="font-family: Algerian; font-size: xx-large; font-weight: 100;">View Sales</legend>
    <div>
    <table >
        <tr>
            <td>
                <asp:Label ID="Label1" Text="From Date" runat="server" Font-Names="Tahoma"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="fromDateTextBox" runat="server" Height="35px" Width="308px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" Text="To Date" runat="server" Font-Names="Tahoma"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="toDateTextBox" runat="server" Height="35px" Width="304px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="searchButton" Text="Search" runat="server" OnClick="searchButton_Click" Font-Bold="True" Font-Names="Akhbar MT" style="margin-left: 102px" Width="130px"/>
            </td>
        </tr>
    </table>
    </div>
 <a href="MenuUI.aspx" class="nav-link"> Back to Menu </a>

    </fieldset>
        <br/>
        <asp:GridView ID="salesGridView" AutoGenerateColumns="False" Width="100%" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %> 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sale Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
            

    </form>
        <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/DataTables/datatables.min.js"></script>
<script>
    $(function () {
        $("#viewSalesForm").validate({
            rules: {
                fromDateTextBox: "required",
                toDateTextBox: "required"
    },
            messages: {
                fromDateTextBox: "Please Select a Date!",
                toDateTextBox: "Please Select a Date!"
            }
        });
        $("#fromDateTextBox").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'yy/mm/dd',
            minDate: "-30Y",
            maxDate: "+30Y",
            yearRange: "1920:2100"
           
        });
        $("#toDateTextBox").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'yy/mm/dd',
            minDate: "-30Y",
            maxDate: "+30Y",
            yearRange: "1920:2100"
            
        });
        $("#salesGridView").prepend($("<thead></thead>").append($("#salesGridView").find("tr:first"))).DataTable();

    });
  </script>    
</body>
</html>
