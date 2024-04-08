<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuUI.aspx.cs" Inherits="StockManagementWebApp.UI.MenuUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../style.css" rel="stylesheet" />
</head>
<body>
   <%-- <form id="form1" runat="server">
    <div>
       
    </div>
    </form>--%>
    <aside id="sidebar">
  <header class="navbar-header">
      <h1 align="center">Stock Management System</h1>
  </header>
  <main class="navbar-body">
      
    <ul>
      <li class="nav-item">
        <a href="CategorySetupUI.aspx" class="nav-link"> Category Setup </a>
      </li>
      <li class="nav-item">
        <a href="CompanySetupUI.aspx" class="nav-link"> Company Setup </a>
      </li>
      <li class="nav-item">
        <a href="ItemSetup.aspx" class="nav-link"> Item Setup </a>
      </li>
        <li class="nav-item">
        <a href="StockInUI.aspx" class="nav-link"> Stock In </a>
      </li>
        <li class="nav-item">
        <a href="StockOutUI.aspx" class="nav-link"> Stock Out</a>
      </li>
        <li class="nav-item">
        <a href="SearchUI.aspx" class="nav-link"> Search And View Item </a>
      </li>
        <li class="nav-item">
        <a href="ViewSalesUI.aspx" class="nav-link"> View Sales </a>
      </li>
      ...
    </ul>
  </main>
</aside>
</body>
</html>
