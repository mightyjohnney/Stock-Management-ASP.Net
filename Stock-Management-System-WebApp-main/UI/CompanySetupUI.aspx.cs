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
    
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManger = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            PopulateGriedView();
        }

        private void PopulateGriedView()
        {
            List<Company> companies = aCompanyManger.GetCompanies();
            CompanyListGridView.DataSource = companies;
            CompanyListGridView.DataBind();
        }

      

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company aCompany = new Company();
            aCompany.Name = companyNameTextBox.Text;


            messageLabel.Text = aCompanyManger.CompanySave(aCompany);
            PopulateGriedView();
            companyNameTextBox.Text = String.Empty;
        }

        

       
    }
}