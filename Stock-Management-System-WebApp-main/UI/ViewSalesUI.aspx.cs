using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.ViewModel;

namespace StockManagementWebApp.UI
{
    public partial class ViewSalesUI : System.Web.UI.Page
    {
        ItemManager anItemManager=new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Text);
            DateTime toDate = Convert.ToDateTime(toDateTextBox.Text);
            List<Item> items = anItemManager.GetSoldItems(fromDate, toDate);
            salesGridView.DataSource = items;
            salesGridView.DataBind();
            fromDateTextBox.Text=String.Empty;
            toDateTextBox.Text=String.Empty;
        }
    }
}