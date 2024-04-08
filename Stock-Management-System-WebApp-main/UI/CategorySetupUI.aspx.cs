using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class CategorySetupUI : System.Web.UI.Page
    {
        CategoryManager aCategoryManager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGriedView();
            nameTextBox.Focus();
          
        }
        private void PopulateGriedView()
        {
            List<Category> categories = aCategoryManager.GetAllCategories();
            saveCategoryGridView.DataSource = categories;
            saveCategoryGridView.DataBind();
        }

        protected void ValidatationTextBoxForString()
        {
            string categoryName = nameTextBox.Text;
            if (categoryName.Trim() == " ")
            {
                messageLabel.Text = "Enter Valid Name!!!";
                nameTextBox.Text = String.Empty;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(categoryName, "^[a-zA-Z ]"))
            {
                messageLabel.Text = "Enter Valid Name";
                nameTextBox.Text = String.Empty;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ValidatationTextBoxForString();
            Category aCategory = new Category();
            aCategory.Name = nameTextBox.Text;
           
            if (saveButton.Text == "Save")
            {
                messageLabel.Text = aCategoryManager.Save(aCategory);
                PopulateGriedView();
            }
            else if (saveButton.Text == "Update")
            {
                aCategory.Id = Convert.ToInt32(storeIdHiddenField.Value);
                messageLabel.Text = aCategoryManager.UpdateCategoryById(aCategory);
                PopulateGriedView();
                saveButton.Text = "Save";
            }
            nameTextBox.Text = String.Empty;
        }

        protected void saveCategoryGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(saveCategoryGridView,
                    "Select$" + e.Row.RowIndex);
            }

        }


        protected void saveCategoryGridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = saveCategoryGridView.SelectedRow;

            if (row != null)
            {
                Label nameL = (Label)row.FindControl("nameLabel");
                nameTextBox.Text = nameL.Text;
                HiddenField idHiddenF = (HiddenField)row.FindControl("idHiddenField");
                storeIdHiddenField.Value = idHiddenF.Value;
                saveButton.Text = "Update";
            }
        }
    }
}