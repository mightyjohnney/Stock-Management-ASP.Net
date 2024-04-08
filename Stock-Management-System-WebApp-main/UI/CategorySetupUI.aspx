<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CategorySetupUI.aspx.cs" Inherits="StockManagementWebApp.UI.CategorySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        label.error {
            color: red;
            font-style: italic;
        }
         .auto-style1 {
             height: 59px;
         }
    </style>
  
</head>
<body>

     <form id="Category" runat="server">
        <div>
     <fieldset>
           <legend  spellcheck="True" style="font-family: Algerian; font-size: xx-large; font-weight: 100;">Category Setup</legend>
         <table >
        <tr>
            <td><asp:HiddenField runat="server" ID="storeIdHiddenField"/></td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name" Font-Bold="False" Font-Size="Larger" style="font-family: Tahoma" class="auto-style1"></asp:Label></td>
            <td class="auto-style1" style="font-family: Tahoma; font-size: 19px">
                <asp:TextBox ID="nameTextBox" runat="server" Width="303px" Height="34px" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"></asp:TextBox></td>
            <td>
                <asp:HiddenField ID="IdHiddenField" runat="server" />
            </td>
        </tr>
            <tr>
               <td style="font-family: Tahoma" class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" Font-Bold="True" Font-Size="Larger" Width="133px" BackColor="#006666" BorderColor="#006600" BorderStyle="Solid" BorderWidth="3px" ForeColor="#66CCFF" Height="46px" style="margin-left: 162px; margin-bottom: 20px" /></td>
            </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="messageLabel" runat="server" Text=" "></asp:Label></td>
        </tr>
    </table>
         </fieldset>
        <table>
             <asp:GridView ID="saveCategoryGridView" OnRowDataBound="saveCategoryGridView_OnRowDataBound" AutoGenerateColumns="False" OnSelectedIndexChanged="saveCategoryGridView_OnSelectedIndexChanged" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                      <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                         <asp:HiddenField runat="server" ID="idHiddenField" Value='<%#Eval("Id")%>'/>
                        <asp:Label ID="nameLabel" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </table>
         <a href="MenuUI.aspx" class="nav-link"> Back to Menu </a>
    </div>
    </form>
     <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
         <script>
             $(function () {
                 $("#Category").validate({
                     rules: {
                         nameTextBox: "required"
                     },
                     messages: {
                         nameTextBox: " Please, Enter a Category Name !!!"
                     }
                 });

             });

         </script>
</body>
</html>
