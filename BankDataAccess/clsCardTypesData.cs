using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsCardTypeData
    {
        public static int AddCardType(string CardName, string Description, byte DefaultValidationLength, float IssueFees)
        {
            int _CardTypeID = -1;
            string query = @"INSERT INTO CardTypes(
                             CardName,
                             Description,
                             DefaultValidationLength,
                             IssueFees
                             ) VALUES (
                             @CardName,
                             @Description,
                             @DefaultValidationLength,
                             @IssueFees
                             );
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CardName", CardName);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@DefaultValidationLength", DefaultValidationLength);
            command.Parameters.AddWithValue("@IssueFees", IssueFees);

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

        public static bool UpdateCardTypeByID(int CardTypeID, string CardName, string Description, byte DefaultValidationLength, float IssueFees)
        {


            int AffectedRows = 0;

            string query = @"UPDATE CardTypes SET 
                            CardName = @CardName,
                            Description = @Description,
                            DefaultValidationLength = @DefaultValidationLength,
                            IssueFees = @IssueFees
                            WHERE CardTypeID = @CardTypeID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);
            command.Parameters.AddWithValue("@CardName", CardName);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@DefaultValidationLength", DefaultValidationLength);
            command.Parameters.AddWithValue("@IssueFees", IssueFees);

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

        public static bool DeleteCardTypeByID(int CardTypeID)
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

        public static bool GetCardTypeByID(int CardTypeID, ref string CardName, ref string Description, ref byte DefaultValidationLength, ref float IssueFees)
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
                    CardName = (string)reader["CardName"];
                    Description = (string)reader["Description"];
                    DefaultValidationLength = (byte)reader["DefaultValidationLength"];
                    IssueFees = Convert.ToSingle(reader["IssueFees"]);

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

        public static bool GetCardTypeByTypeName(ref int CardTypeID,string CardName, ref string Description, ref byte DefaultValidationLength, ref float IssueFees)
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
                    DefaultValidationLength = (byte)reader["DefaultValidationLength"];
                    IssueFees = Convert.ToSingle(reader["IssueFees"]);

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
        public static bool IsCardTypeExistByCardTypeID(int CardTypeID)
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

            string query = @"SELECT * FROM CardTypes";

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
