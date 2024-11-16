using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsCardTypesData
    {
        public static int AddCardTypes( string CardName, string Description)
        {
            int _CardTypeID = -1;
            string query = @"INSERT INTO CardTypes(                       
                            CardName,
                            Description,
                            ) VALUES (
                            @CardName,
                            @Description,
                            );
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CardName", CardName);
            command.Parameters.AddWithValue("@Description", Description);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    _CardTypeID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return _CardTypeID;
        }



        public static bool UpdateCardTypesByID(int CardTypeID, string CardName, string Description)
        {


            int AffectedRows = 0;

            string query = @"UPDATE CardTypes SET 
                             CardTypeID = @CardTypeID,
                             CardName = @CardName,
                             Description = @Description,
                             WHERE CardTypeID = @CardTypeID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);
            command.Parameters.AddWithValue("@CardName", CardName);
            command.Parameters.AddWithValue("@Description", Description);

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



        public static bool DeleteCardTypesByID(int CardTypeID)
        {


            int AffectedRows = 0;

            string query = @"DELETE FROM CardTypes
                                     WHERE CardTypeID = @CardTypeID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);

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



        public static bool GetCardTypesByID(int CardTypeID, ref string CardName, ref string Description)
        {

            bool IsFound = false;

            string query = "SELECT * FROM CardTypes WHERE CardTypeID = @CardTypeID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CardTypeID = (int)reader["CardTypeID"];
                    CardName = (string)reader["CardName"];
                    Description = (string)reader["Description"];

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

        public static bool GetCardTypesByCardName(ref int CardTypeID, string CardName, ref string Description)
        {

            bool IsFound = false;

            string query = "SELECT * FROM CardTypes WHERE CardName = @CardName";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardName", CardName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CardTypeID = (int)reader["CardTypeID"];
                    Description = (string)reader["Description"];

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



        public static bool IsCardTypesExistByCardTypeID(int CardTypeID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM CardTypes WHERE CardTypeID = @CardTypeID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);

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





        public static DataTable GetAllCardTypes()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM CardTypes ORDER BY CardTypeID DESC";

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
