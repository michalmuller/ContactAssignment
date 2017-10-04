using CentiSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CentiSoft.DAL
{
    public class CompanyRepository
    {
        public List<Company> LoadAllCompanies()
        {
            List<Company> companies = new List<Company>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=localhost;Database=PWECentiSoft;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Company";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Company company = new Company();
                    company.Id = reader.GetInt32(0);
                    company.Name = reader.GetString(1);
                    company.Description = reader.GetString(2);
                    company.PhoneNumber = reader.GetString(3);
                    companies.Add(company);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return companies;
        }

    }
}