using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.ViewModel;

namespace StockManagementWebApp.BLL
{
    public class ItemManager
    {
        ItemGateway aGateway = new ItemGateway();
        public string Save(Item aItem)
        {
            int rowAffected = aGateway.Save(aItem);
            if (rowAffected > 0)
            {
                return "Item saved successfully !!";
            }
            return "This item isn't saved !!";
        }

      

        public List<ItemViewModel> GetAllItemes(ItemViewModel aItem)
        {
            return aGateway.GetAllItemes(aItem);
        }

        public ItemViewModel Show(ItemViewModel aViewModel)
        {
            return aGateway.Show(aViewModel);
        }


        public string UpdateQuantity(ItemViewModel aModel,int quantity)
        {
            if (aGateway.UpdateQuantity(aModel, quantity) > 0)
            {
                return "Available Quantity Updated";
            } return "Item Not Enough in Stock";
        }

        public string StockOutTypeEntry(string sell, ItemViewModel aItem)
        {
            if (aGateway.StockOutTypeEntry(sell,aItem) > 0)
            {
                return "Item Stocked";

            } return "Item stock Failed";
        }


        public string SaveItem(Item aItem)
        {

            if (!aGateway.IsItemExists(aItem))
            {
                int rowAffected = aGateway.SaveItem(aItem);
                if(rowAffected>0)
                {
                    return "Item saved!!";
                }
                return "Item failed!!";
            }
            return "Item already Exits!!";
        }

        public List<Item> GetSoldItems(DateTime fromDate, DateTime toDate)
        {
            return aGateway.GetSoldItems(fromDate, toDate);
        }

        public List<ItemViewModel> GetSearchItems(string company, string category)
        {
            return aGateway.GetSearchItems(company, category);
        }
    }
}