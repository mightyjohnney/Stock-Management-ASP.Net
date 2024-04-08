using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.ViewModel;

namespace StockManagementWebApp.BLL
{
    
    public class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();
       
        public List<Company> GetCompanies()
        {
            return aCompanyGateway.GetCompanies();
        }

        public string CompanySave(Company aCompany)
        {
            if (aCompanyGateway.IsCompanyNameExists(aCompany.Name))
            {
                return "Company Name is Exist!!!";
            }
            int rowAffected = aCompanyGateway.CompanySave(aCompany);
            if (rowAffected > 0)
            {
                return "Save Successful!!!";
            }
            return "Save Failed!!!";

        }
        public List<Company> GetAllCompanies()
        {
            return aCompanyGateway.GetAllCompanies();
        }

       
    }
}