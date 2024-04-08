using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class CategoryManager
    {
        CategoryGateway aCategoryGateway = new CategoryGateway();
        public List<Category> GetAllCategories()
        {
            return aCategoryGateway.GetAllCategories();
        }


        public string Save(Category aCategory)
        {
            if (aCategoryGateway.IsCategoryExists(aCategory))
            {
                return "Category is already exits!!!";
            }
            int rowAffected = aCategoryGateway.Save(aCategory);
            if (rowAffected > 0)
            {
                return "Save Succesful";
            }
            return "Save Failed"; 
        }

        public string UpdateCategoryById(Category aCategory)
        {
            if (aCategoryGateway.IsCategoryExists(aCategory))
            {
                return "Exist";
            }
            int rowAffected = aCategoryGateway.UpdateCategoryById(aCategory);
            if (rowAffected > 0)
            {
                return "Succesful";
            }
            return "Failed";
        }


        public List<Category> GetCategories(string company)
        {
            return aCategoryGateway.GetCategories(company);
        }
    }
}