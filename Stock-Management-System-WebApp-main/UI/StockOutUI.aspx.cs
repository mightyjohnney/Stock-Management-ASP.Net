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
   
    public partial class StockOutUI : System.Web.UI.Page
    {  
        ItemManager aManager = new ItemManager();
       CompanyManager aCompanyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
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


        
        protected void addButton_Click(object sender, EventArgs e)
        {
            List<ItemViewModel> itemList = new List<ItemViewModel>();
            ItemViewModel aModel = new ItemViewModel();
            aModel.Id = Convert.ToInt32(itemDropDownList.SelectedValue);
            aModel.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            ItemViewModel aViewModel = aManager.Show(aModel);
            int quantity = aViewModel.Quantity;
            aViewModel.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
            if (aViewModel.Quantity < 1)
            {
                
                messageLabel.Text = "Enter Valid Quantity";
                return;
            }
            quantity -= aViewModel.Quantity;
            if (aModel.Id != 0 && aModel.CompanyId != 0)
            {
                if (ViewState["itemList"]==null)
                {
                    if ( quantity>= 0) 
                    {
                        messageLabel.Text = aManager.UpdateQuantity(aModel, quantity);
                        itemList.Add(aViewModel);
                        stockOutGridView.DataSource = itemList;
                        stockOutGridView.DataBind();
                        ViewState["itemList"] = itemList;
                    }                    
                  else
                    {
                    messageLabel.Text = "Not enough stock";
                    }
                }
                else
                {
                    itemList = (List<ItemViewModel>) ViewState["itemList"];
                    int pointer = 0;                                           

                    foreach (ItemViewModel item in itemList)              
                    {
                        if (item.Id == aModel.Id)
                        {
                            
                            item.Quantity += aViewModel.Quantity ;        
                            if (quantity > 0)
                            {
                                messageLabel.Text = String.Empty;
                                pointer++;
                                break;
                            }

                            messageLabel.Text = "Not enough stock";

                        }
                    }

                    if (pointer == 0)                                       
                    {
                        if (quantity > 0)
                        {
                            messageLabel.Text = String.Empty;
                            
                            itemList.Add(aViewModel);
                        }
                        else
                        {
                            messageLabel.Text = "Not enough stock";
                        }
                    }
                    messageLabel.Text = aManager.UpdateQuantity(aModel, quantity);
                    stockOutGridView.DataSource = itemList;
                    stockOutGridView.DataBind();
                    ViewState["itemList"] = itemList;
                }
                Clear();
            }
            else
            {
                companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", ""));
                itemDropDownList.Items.Insert(0, new ListItem("--Select Item--", ""));
            }
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<ItemViewModel> itemList = (List<ItemViewModel>)ViewState["itemList"];
            if (itemList == null)
            {
                Clear();
                messageLabel.Text = "Please Take Something in Cart";
                return;
            }
            foreach (ItemViewModel item in itemList)
            {
                messageLabel.Text = aManager.StockOutTypeEntry("Sell", item);
                ViewState["itemList"] = null;
                stockOutGridView.DataBind();
            }
            Clear();
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            List<ItemViewModel> itemList = (List<ItemViewModel>)ViewState["itemList"];
            if (itemList == null)
            {
                Clear();
                messageLabel.Text = "Please Take Something in Cart";
                return; 
            }
            foreach (ItemViewModel item in itemList)
            {
                messageLabel.Text = aManager.StockOutTypeEntry("Damage", item);
                ViewState["itemList"] = null;
                stockOutGridView.DataBind();
            }
            Clear();
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<ItemViewModel> itemList = (List<ItemViewModel>)ViewState["itemList"];
            if (itemList == null)
            {
                Clear();
                messageLabel.Text = "Please Take Something in Cart";
                return;
            }
            foreach (ItemViewModel item in itemList)
            {
                messageLabel.Text = aManager.StockOutTypeEntry("Lost", item);
                ViewState["itemList"] = null;
                stockOutGridView.DataBind();
            }
            Clear();
        }

        private void Clear()
        {
            companyDropDownList.SelectedIndex = 0;
            itemDropDownList.Items.Clear();
            itemDropDownList.Items.Insert(0, new ListItem("--Select Item--", ""));
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            stockOutQuantityTextBox.Text = "";

        }
        

        

    } 
}
