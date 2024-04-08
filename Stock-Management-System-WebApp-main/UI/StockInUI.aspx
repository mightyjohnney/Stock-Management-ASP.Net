<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="StockManagementWebApp.UI.StockInUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        label.error {
            color: red;
            font-style: italic;
        }
    </style>

</head>
<body>
    <form id="StockIn" runat="server">
    <div>
       <fieldset>
           <legend  spellcheck="True" style="font-family: Algerian; font-size: xx-large; font-weight: 100;">Stock In</legend>
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
                    <asp:Label ID="Label5" runat="server" Text="Stock In Quantity"></asp:Label>
                </td>
                <td>
                      <asp:TextBox ID="stockInQuantityTextBox" runat="server"  Width="267px" Height="29px" BorderStyle="Solid" BorderColor="Black"></asp:TextBox>
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
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" Height="40px" style="margin-left: 118px" Width="154px" BackColor="#003300" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Font-Size="Large" ForeColor="#66FFFF" Font-Names="Engravers MT" OnClick="saveButton_Click" />
                 </td>
            </tr>
        </table>
           <a href="MenuUI.aspx" class="nav-link"> Back to Menu </a>
       </fieldset>
  
    </div>
    </form>
          <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
         <script>
             $(function () {
                 $("#StockIn").validate({
                     rules: {
                         companyDropDownList: "required",
                         itemDropDownList: "required",
                         stockInQuantityTextBox: "required"

                     },
                     messages: {
                         companyDropDownList: " Please, Select a Company !!!",
                         itemDropDownList: " Please, Select a Item !!!",
                         stockInQuantityTextBox: " Please, Enter Stock In Quantity !!!"
                     }
                 });

             });

         </script>
</body>
</html>
