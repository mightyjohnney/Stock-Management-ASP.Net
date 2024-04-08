<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockManagementWebApp.UI.CompanySetupUI" %>

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
    <form id="Company" runat="server">
    <div>
        <fieldset>
           <legend  spellcheck="True" style="font-family: Algerian; font-size: xx-large; font-weight: 100;">Company Setup</legend>
             <table>
         <tr>
             <td style="font-family: Tahoma; font-size: 26px">
                 <asp:Label ID="Label2" runat="server" Text="Name" Font-Size="Larger"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="companyNameTextBox" runat="server" Height="39px" Width="267px" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"></asp:TextBox></td>
         </tr>
                  <tr>
             <td>
                
             </td>
         </tr>
         <tr>
             <td></td>
             <td>
                 <asp:Button ID="Button1" runat="server" Text="Save" OnClick="saveButton_Click" Height="41px" style="margin-left: 123px; margin-right: 0px" Width="149px" BackColor="#006699" BorderColor="#003300" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Font-Size="Larger" ForeColor="#66FFFF" /></td>
         </tr>
         <tr>
             <td>
                 <asp:Label ID="messageLabel" runat="server" Text=" "></asp:Label>
             </td>
         </tr>
            </table>
        </fieldset>
     
        <asp:GridView ID="CompanyListGridView" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
           <Columns>
               <asp:TemplateField HeaderText="SL">
                   <ItemTemplate>
                       <%#Container.DataItemIndex+1 %>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Company Name">
                   <ItemTemplate>
                       <asp:Label runat="server"><%#Eval("Name") %></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns> 
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
         <a href="MenuUI.aspx" class="nav-link"> Back to Menu </a>
    </div>
    </form>
     <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
         <script>
             $(function () {
                 $("#Company").validate({
                     rules: {
                         companyNameTextBox: "required"
                     },
                     messages: {
                         companyNameTextBox: " Please, enter a company name !!!"
                     }
                 });

             });

         </script>
</body>
</html>
