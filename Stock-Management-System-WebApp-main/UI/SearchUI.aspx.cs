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
    public partial class SearchUI : System.Web.UI.Page
    {
        CategoryManager aCategoryManager = new CategoryManager();
        CompanyManager aCompanyManager = new CompanyManager();
        ItemManager anItemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Company> companyList = aCompanyManager.GetAllCompanies();
                companyDropDownList.DataSource = companyList;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("--Select Company First--", ""));
                categoryDropDownList.Items.Clear();
                categoryDropDownList.Items.Insert(0, new ListItem("--Select Category First--", ""));
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string company = companyDropDownList.SelectedItem.Text;
            string category = categoryDropDownList.SelectedItem.Text;
            List<ItemViewModel> items = anItemManager.GetSearchItems(company, category);
            searchGridView.DataSource = items;
            searchGridView.DataBind();
            companyDropDownList.SelectedIndex = 0;
            categoryDropDownList.Items.Clear();
            categoryDropDownList.Items.Insert(0, new ListItem("--Select Category First--",""));                

        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string company = companyDropDownList.SelectedItem.Text;
            if (company.Equals(""))
            {
                categoryDropDownList.Items.Clear();
                categoryDropDownList.Items.Insert(0, new ListItem("--Select Category First--", ""));

            }
            else
            {
                List<Category> categories = aCategoryManager.GetCategories(company);
                categoryDropDownList.DataSource = categories;
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataTextField = "Name";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Insert(0, new ListItem("--Select Category First--", ""));
            }
        }
    }
}