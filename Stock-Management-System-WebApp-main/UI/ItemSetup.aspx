<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetup.aspx.cs" Inherits="StockManagementWebApp.UI.ItemSetup" %>

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
    <form id="ItemSetup" runat="server">
    <div>
        <fieldset>
           <legend  spellcheck="True" style="font-family: Algerian; font-size: xx-large; font-weight: 100;">Item Setup</legend>
           <table>
            <tr>
                <td style="font-family: Tahoma;">
                    <asp:Label ID="Label1" runat="server" Text="Cetegory"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="categoryDropDownList" runat="server" Width="274px" Height="29px" BackColor="White" AutoPostBack="True" OnSelectedIndexChanged="cetegoryDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>           
               
            </tr>
            <tr>
                <td style="font-family: Tahoma;">
                    <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="companyDropDownList" runat="server" Width="274px" Height="33px" BackColor="White" AutoPostBack="True"></asp:DropDownList>
                </td>
               
            </tr>
               <tr>
                <td style="font-family: Tahoma;">
                    <asp:Label ID="Label6" runat="server" Text="Item Name"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="itemNameTextBox" runat="server" Width="267px" Height="29px" BorderStyle="Solid" BackColor="White" BorderColor="Black"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="font-family: Tahoma;" aria-orientation="vertical">
                    <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="reorderLevelTextBox" runat="server" Width="267px" Height="29px" BorderColor="Black" BorderStyle="Solid" BackColor="White">0</asp:TextBox>
        
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
           <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
         <script>
             $(function () {
                 $("#ItemSetup").validate({
                     onsubmit : true,
                     rules: {
                         categoryDropDownList: "required",
                         companyDropDownList: "required",
                         itemNameTextBox: "required",
                         reorderLevelTextBox: "required"
                         
                           
                     },
                     messages: {
                         itemNameTextBox: " Please, enter a Item name !!!",
                         reorderLevelTextBox: " Please, enter reorder level !!!",
                         categoryDropDownList: " Please,Select a Category !!!",
                         companyDropDownList:" Please,Select a Company !!!"
                     }
                 });

             });

         </script>
    </form>
</body>
</html>
