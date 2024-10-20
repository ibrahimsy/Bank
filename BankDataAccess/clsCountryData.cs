using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{
    public class clsCountryData
    {
        public static bool GetCountryByID(int CountryID,ref string CountryName)
        {
            bool IsFound = false;

            string query = @"SELECT * FROM Countries
                             WHERE CountryID = @CountryID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID",CountryID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    CountryName = (string)reader["CountryName"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally 
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool GetCountryByName(string CountryName,ref int CountryID)
        {
            bool IsFound = false;

            string query = @"SELECT * FROM Countries
                             WHERE CountryName = @CountryName";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    CountryID = (int)reader["CountryID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT  * FROM Countries";

            SqlConnection connection = new SqlConnection( clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(@query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }  
            }
            catch (Exception ex) 
            {

            }
            finally 
            {
                connection.Close();
            }
            return dt;
        }
    
    }
}
