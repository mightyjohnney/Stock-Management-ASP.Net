using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.ViewModel;

namespace StockManagementWebApp.DAL.Gateway
{
    public class ItemGateway : Gateway
    {
        
        public int Save(Item aItem)
        {
            Query = "Update StockIn set Quantity = @Quantity where ItemId =@ItemId and CompanyId =@CompanyId ";
            Command= new SqlCommand(Query,Connection);

            Command.Parameters.AddWithValue("Quantity", aItem.Quantity);
            Command.Parameters.AddWithValue("CompanyId", aItem.CompanyId);
            Command.Parameters.AddWithValue("ItemId", aItem.Id);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

 

        public List<ItemViewModel> GetAllItemes(ItemViewModel aItem)
        {
            Query = "SELECT * FROM GetItemCompanyWithQuantity where CompanyName =@CompanyName ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("CompanyName", aItem.CompanyName);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ItemViewModel> items = new List<ItemViewModel>();
            while (Reader.Read())
            {
                aItem = new ItemViewModel();
                aItem.Id = (int)Reader["ItemId"];
                aItem.ItemName = Reader["ItemName"].ToString();
                items.Add(aItem);
            }
            Reader.Close();
            Connection.Close();
            return items;
        }

        public ItemViewModel Show(ItemViewModel aViewModel)
        {
            Query = "Select * From GetItemCompanyWithQuantity where CompanyId=@CompanyId and ItemId=@ItemId";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("CompanyId", aViewModel.CompanyId);
            Command.Parameters.AddWithValue("ItemId", aViewModel.Id);

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                 aViewModel = new ItemViewModel();
                 aViewModel.ReorderLevel = (int)Reader["ReorderLevel"];
                 aViewModel.Id = (int)Reader["ItemId"];
                 aViewModel.CompanyId = (int)Reader["CompanyId"];
                 aViewModel.ItemName = Reader["ItemName"].ToString();
                 aViewModel.CompanyName = Reader["CompanyName"].ToString();
                 aViewModel.Quantity = (int)Reader["Quantity"];
                
            }
            Reader.Close();
            Connection.Close();
            return aViewModel;

        }

        public int UpdateQuantity(ItemViewModel aModel, int quantity)
        {
            Query = "Update StockIn set Quantity =@Quantity where ItemId =@ItemId and CompanyId =@CompanyId ";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("Quantity", quantity);
            Command.Parameters.AddWithValue("CompanyId", aModel.CompanyId);
            Command.Parameters.AddWithValue("ItemId", aModel.Id);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int StockOutTypeEntry(string sell, ItemViewModel aItem)
        {
            Query = "Insert into stockOut values (@ItemId,@ItemName,@CompanyId,@CompanyName,@OutType," +
                    "@OutQuantity,GETDATE())";  
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("ItemId", aItem.Id);
            Command.Parameters.AddWithValue("ItemName", aItem.ItemName);
            Command.Parameters.AddWithValue("CompanyId", aItem.CompanyId);
            Command.Parameters.AddWithValue("CompanyName", aItem.CompanyName);
            Command.Parameters.AddWithValue("OutType", sell);
            Command.Parameters.AddWithValue("OutQuantity", aItem.Quantity);
            

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }


        public bool IsItemExists(Item aItem)
        {
            Query = "Select * from Item where Name=@Name";
            Command = new SqlCommand(Query, Connection);       
            Command.Parameters.AddWithValue("CompanyId", aItem.CompanyId);
            Command.Parameters.AddWithValue("CategoryId", aItem.CategoryId);
            Command.Parameters.AddWithValue("Name", aItem.Name);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Connection.Close();
            return hasRow;
        }

        public int SaveItem(Item aItem)
        {
            Query = "Insert into Item values (@Name,@CompanyId,@CategoryId,@ReorderLevel)";
            Command = new SqlCommand(Query, Connection);
           
            Command.Parameters.AddWithValue("Name", aItem.Name);
            Command.Parameters.AddWithValue("CompanyId", aItem.CompanyId);
            Command.Parameters.AddWithValue("CategoryId", aItem.CategoryId);
            Command.Parameters.AddWithValue("ReorderLevel", aItem.ReorderLevel);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Item> GetSoldItems(DateTime fromDate, DateTime toDate)
        {
            Query = "Select ItemName Name,SUM(OutQuantity) SoldQuantity from StockOut " +
                   "where OutType='Sell' and Date between @fromDate and @toDate group by ItemName";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Add("fromDate", SqlDbType.Date);
            Command.Parameters["fromDate"].Value = fromDate;

            Command.Parameters.Add("toDate", SqlDbType.Date);
            Command.Parameters["toDate"].Value = toDate;

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Item> items = new List<Item>();
            while (Reader.Read())
            {
                Item anItem = new Item();
                anItem.Name = Reader["Name"].ToString();
                anItem.Quantity = Convert.ToInt32(Reader["SoldQuantity"].ToString());

                items.Add(anItem);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        public List<ItemViewModel> GetSearchItems(string company, string category)
        {

            Query = "Select * from GetItemCompanyWithQuantity where CompanyName=@company and CategoryName=@category";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Add("company", SqlDbType.VarChar);
            Command.Parameters["company"].Value = company;

            Command.Parameters.Add("category", SqlDbType.VarChar);
            Command.Parameters["category"].Value = category;

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ItemViewModel> items = new List<ItemViewModel>();
            while (Reader.Read())
            {
                ItemViewModel anItem = new ItemViewModel();
                anItem.ItemName = Reader["ItemName"].ToString();
                anItem.CompanyName = Reader["CompanyName"].ToString();
                anItem.CategoryName = Reader["CategoryName"].ToString();
                anItem.Quantity = Convert.ToInt32(Reader["Quantity"]);
                anItem.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                items.Add(anItem);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }
    }
}