using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsCurrencyData
    {
        public static int AddNewCurrency( string CountryName, string CurrencyCode, string CurrencyName, float Rate)
        {
            int _CurrencyID = -1;
            string query = @"INSERT INTO Currencies(
                CountryName,
                CurrencyCode,
                CurrencyName,
                Rate,
                ) VALUES (
                @CountryName,
                @CurrencyCode,
                @CurrencyName,
                @Rate,
                );
                SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);
            command.Parameters.AddWithValue("@CurrencyName", CurrencyName);
            command.Parameters.AddWithValue("@Rate", Rate);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    _CurrencyID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return _CurrencyID;
        }



        public static bool UpdateCurrencyByID(int CurrencyID, string CountryName, string CurrencyCode, string CurrencyName,float Rate)
        {


            int AffectedRows = 0;

            string query = @"UPDATE Currencies SET 
                            CountryName = @CountryName,
                            CurrencyCode = @CurrencyCode,
                            CurrencyName = @CurrencyName,
                            Rate = @Rate,
                            WHERE CurrencyID = @CurrencyID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);
            command.Parameters.AddWithValue("@CurrencyName", CurrencyName);
            command.Parameters.AddWithValue("@Rate", Rate);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return AffectedRows > 0;
        }



        public static bool DeleteCurrencyByID(int CurrencyID)
        {


            int AffectedRows = 0;

            string query = @"DELETE FROM Currencies
                                     WHERE CurrencyID = @CurrencyID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { connection.Close(); }


            return AffectedRows > 0;
        }



        public static bool GetCurrencyByID(int CurrencyID, ref string CountryName, ref string CurrencyCode, ref string CurrencyName, ref float Rate)
        {

            bool IsFound = false;

            string query = "SELECT * FROM Currencies WHERE CurrencyID = @CurrencyID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                   
                    CountryName = (string)reader["CountryName"];
                    CurrencyCode = (string)reader["CurrencyCode"];
                    CurrencyName = (string)reader["CurrencyName"];
                    Rate = Convert.ToSingle(reader["Rate"]);

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





        public static bool IsCurrencyExistByCurrencyID(int CurrencyID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Currencies WHERE CurrencyID = @CurrencyID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {
                connection.Open();
                object result = command.ExecuteNonQuery();
                if (result != null)
                {
                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }





        public static DataTable GetAllCurrencies()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Currencies ORDER BY CurrencyID DESC";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
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
