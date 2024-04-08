<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementWebApp.UI.StockOutUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Out</title>
     <style>
        label.error {
            color: red;
            font-style: italic;
        }
    </style>
    <link href="../Scripts/DataTables/datatables.min.css" rel="stylesheet" />
</head>
<body>
    <form id="StockOut" runat="server">
    <div>
         <fieldset>
           <legend  spellcheck="True" style="border-width: medium; font-family: Algerian; font-size: xx-large; font-weight: 100;">Stock Out</legend>
           <table>
            <tr>
                <td style="font-family: Tahoma;">
                    <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="companyDropDownList" runat="server" Width="274px" Height="29px" BackColor="White" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </td>
               
            </tr>
            <tr>
                <td style="font-family: Tahoma;">
                    <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="itemDropDownList" runat="server" Width="274px" Height="29px" BackColor="White" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </td>
           
            </tr>
              <tr>
                <td style="font-family: Tahoma;" aria-orientation="vertical">
                    <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="reorderLevelTextBox" runat="server" Width="267px" Height="29px" BorderColor="Black" BorderStyle="Solid" Enabled="False" BackColor="White"></asp:TextBox>
        
                </td>
            </tr>
              <tr>
                <td style="font-family: Tahoma;">
                    <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="availableQuantityTextBox" runat="server" Width="267px" Height="29px" BorderStyle="Solid" Enabled="False" BackColor="White" BorderColor="Black"></asp:TextBox>
                </td>
            </tr>
              <tr> 
                <td style="font-family: Tahoma;">
                    <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity"></asp:Label>
                </td>
                <td>
                      <asp:TextBox ID="stockOutQuantityTextBox" runat="server"  Width="267px" Height="29px" BorderStyle="Solid" BorderColor="Black"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td>  
                </td>
                <td> 
                    <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
              <tr>
                <td>  
                </td>
                <td style="border-width: medium">
                    <asp:Button ID="addButton" runat="server" Text="ADD" Height="40px" style="margin-left: 118px" Width="154px" BackColor="#003300" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Font-Size="Large" ForeColor="#66FFFF" Font-Names="Engravers MT" OnClick="addButton_Click" />
                    <br />
                 </td>
            </tr>
        </table>
             <asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                 <AlternatingRowStyle BackColor="#DCDCDC" />
                 <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                       <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label runat="server"><%#Eval("ItemName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
            </Columns>
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#0000A9" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#000065" />
             </asp:GridView>
             <table>
                  <tr>
                 <td></td>
                       </tr>
                 <tr>
                     <td><asp:Button ID="sellButton" runat="server" Text="Sell" style="margin-left: 344px" Width="125px" Height="47px" OnClick="sellButton_Click" BackColor="#999999" BorderColor="#0099FF" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="Black" Font-Names="engravers mt, large" /></td>
                     <td></td>
                     <td><asp:Button ID="damageButton" runat="server" Text="Damage" Width="138px" Height="47px" OnClick="damageButton_Click" BackColor="#999966" BorderColor="#006666" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Names="engravers mt,large" style="margin-left: 0px" /></td>
                      <td></td>
                     <td><asp:Button ID="lostButton" runat="server" Text="Lost" Width="117px" Height="47px" OnClick="lostButton_Click" BackColor="#999966" BorderColor="#000099" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="Black" Font-Names="engravers mt, large" /></td>
                 </tr>
             </table>
               <a href="MenuUI.aspx" class="nav-link"> Back to Menu </a>
       </fieldset>
           

    </div>
    </form>
           <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/DataTables/datatables.min.js"></script>
         <script>
           
             $(function () {
                 $("#addButton").click(function() {
                 $("#StockOut").validate({
                     
                     rules: {
                         companyDropDownList: "required",
                         itemDropDownList: "required",
                         stockOutQuantityTextBox: "required"
                     },
                     messages: {
                         companyDropDownList: " Please, Select a Company !!!",
                         itemDropDownList: " Please, Select a Item !!!",
                         stockOutQuantityTextBox: " Please, Enter Stock out Quantity !!!"
                         
                     }
                 });
                 });
                 $("#stockOutGridView").prepend($("<thead></thead>").append($("#stockOutGridView").find("tr:first"))).DataTable();
             });

         </script>
</body>
</html>
