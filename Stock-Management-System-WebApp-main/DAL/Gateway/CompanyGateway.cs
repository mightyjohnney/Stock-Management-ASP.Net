using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Model;
using StockManagementWebApp.DAL.ViewModel;

namespace StockManagementWebApp.DAL.Gateway
{
    public class CompanyGateway : Gateway
    {
        public List<Company> GetAllCompanies()
        {
            Query = "SELECT * FROM Company";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Company> companies = new List<Company>();
            while (Reader.Read())
            {
                Company aCompany = new Company();
                aCompany.Id = (int)Reader["Id"];
                aCompany.Name = Reader["Name"].ToString();
                companies.Add(aCompany);
            }
            Reader.Close();
            Connection.Close();
            return companies;
        }

        public List<Company> GetCompanies()
        {
        
            Query = "SELECT * FROM Company";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Company> companies = new List<Company>();

            while (Reader.Read())
            {
                Company aCompany = new Company();
                aCompany.Id = Convert.ToInt32(Reader["Id"]);
                aCompany.Name = Reader["Name"].ToString();

                companies.Add(aCompany);
            }

            Connection.Close();
            return companies;
        }

        public bool IsCompanyNameExists(string name)
        {

            Query = "SELECT * FROM Company WHERE Name=@companyName";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("companyName", name);

            Connection.Open();

            Reader = Command.ExecuteReader();
            bool IsExist = Reader.HasRows;

            Connection.Close();
            return IsExist;
        }

        public int CompanySave(Company aCompany)
        {
            Query = "INSERT INTO Company VALUES(@Name)";

            Command= new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aCompany.Name;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
    }
}