using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.ViewModel;

namespace StockManagementWebApp.UI
{
    public partial class ItemSetup : System.Web.UI.Page
    {
        CategoryManager aCategoryManager = new CategoryManager();
        ItemManager aManager = new ItemManager();
        CompanyManager aCompanyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Category> categories = aCategoryManager.GetAllCategories();
                categoryDropDownList.DataSource = categories;
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataTextField = "Name";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Insert(0, new ListItem("--Select Category--", ""));
                companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Item aItem = new Item();
            aItem.Name = itemNameTextBox.Text;
            aItem.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            aItem.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            aItem.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);

            if (aItem.CategoryId != 0 && aItem.CompanyId != 0)
            {
                messageLabel.Text = aManager.SaveItem(aItem);
                Clear();
            }
            else
            {
                categoryDropDownList.Items.Insert(0, new ListItem("--Select Category--", ""));
                companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));
            }
        }

        protected void cetegoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            if (CategoryId != 0)
            {

                List<Company> companies = aCompanyManager.GetCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));

            }
            else
            {
                companyDropDownList.Items.Clear();
                companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));
             
            }
        }

        private void Clear()
        {
            categoryDropDownList.SelectedIndex = 0;
            companyDropDownList.Items.Clear();
            companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));    
            itemNameTextBox.Text = "";

        }

    }
}