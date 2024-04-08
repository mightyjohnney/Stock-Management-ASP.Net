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
    public partial class StockInUI : System.Web.UI.Page
    {
        ItemManager aManager = new ItemManager();
        CompanyManager aCompanyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDeopDownBoxse();
        }

        private void PopulateDeopDownBoxse()
        {
            if (!IsPostBack)
            {
                List<Company> companies = aCompanyManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));
                itemDropDownList.Items.Insert(0, new ListItem("--Select Item--", ""));
            }
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemViewModel aItem = new ItemViewModel();
            aItem.CompanyName = companyDropDownList.SelectedItem.Text;
            if (aItem.CompanyName != "")
            {

                List<ItemViewModel> items = aManager.GetAllItemes(aItem);
                itemDropDownList.DataSource = items;
                itemDropDownList.DataValueField = "Id";
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, new ListItem("--Select Item--", ""));
            }
            else
            {
                itemDropDownList.Items.Clear();
                itemDropDownList.Items.Insert(0, new ListItem("--Select Item--", ""));

            }
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemViewModel aViewModel = new ItemViewModel();
            aViewModel.Id = Convert.ToInt32(itemDropDownList.SelectedValue);
            aViewModel.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            if (aViewModel.CompanyId != 0 && aViewModel.Id != 0)
            {
                aViewModel = aManager.Show(aViewModel);
                reorderLevelTextBox.Text = aViewModel.ReorderLevel.ToString();
                availableQuantityTextBox.Text = aViewModel.Quantity.ToString();
            }
            else
            {
                itemDropDownList.Items.Clear();
                itemDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));
              
            }

        }


        protected void saveButton_Click(object sender, EventArgs e)
        {
            Item aItem = new Item();
            aItem.Id = Convert.ToInt32(itemDropDownList.SelectedValue);
            aItem.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            aItem.Quantity = Convert.ToInt32(availableQuantityTextBox.Text) + Convert.ToInt32(stockInQuantityTextBox.Text);
            if (aItem.CompanyId != 0 && aItem.Id != 0)
            {
                messageLabel.Text = aManager.Save(aItem);
                Clear();
            }
            else
            {
                companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));
                itemDropDownList.Items.Insert(0, new ListItem("--Select Item--", ""));
            }
        }

        private void Clear()
        {
            companyDropDownList.SelectedIndex = 0;
            itemDropDownList.Items.Clear();
            itemDropDownList.Items.Insert(0, new ListItem("--Select Item--", ""));
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            stockInQuantityTextBox.Text = "";
        
        }
    }
}