using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{

    public class CategoryGateway : Gateway
    {
        public List<Category> GetAllCategories()
        {
            Query = "SELECT * FROM Category";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (Reader.Read())
            {
                Category aCategory = new Category();
                aCategory.Id = (int) Reader["Id"];
                aCategory.Name = Reader["Name"].ToString();
                categories.Add(aCategory);
            }
            Reader.Close();
            Connection.Close();
            return categories;
        }


        public bool IsCategoryExists(Category aCategory)
        {

            Query = "SELECT * FROM Category WHERE Name=@name ";

            Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("name", aCategory.Name);


            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;

            Connection.Close();
            return isExist;
        }

        public int Save(Category aCategory)
        {
      

            Query = "INSERT INTO Category VALUES(@name)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aCategory.Name;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public int UpdateCategoryById(Category aCategory)
        {

           
            Query = "UPDATE Category SET Name=@Name WHERE Id=@Id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("Name", aCategory.Name);
            Command.Parameters.AddWithValue("Id", aCategory.Id);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

        public List<Category> GetCategories(string company)
        {
            Query = "Select Distinct CategoryId,CategoryName from GetItemCompanyWithQuantity where CompanyName=@company";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("company", SqlDbType.VarChar);
            Command.Parameters["company"].Value = company;

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (Reader.Read())
            {
                Category aCategory = new Category();
                aCategory.Id = Convert.ToInt32(Reader["CategoryId"]);
                aCategory.Name = Reader["CategoryName"].ToString();
                categories.Add(aCategory);
                
                 

            }

            Reader.Close();
            Connection.Close();

            return categories;
        }
    }
}