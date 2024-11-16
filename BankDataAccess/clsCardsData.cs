using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsCardData
    {
        public static int AddCard(int AccountID, string CardNumber, string PinCode, string CVV, DateTime ExpirationDate, byte Status, int CardTypeID, DateTime IssueDate)
        {
            int _CardID = -1;
            string query = @"INSERT INTO Cards(
                            AccountID,
                            CardNumber,
                            PinCode,
                            CVV,
                            ExpirationDate,
                            Status,
                            CardTypeID,
                            IssueDate,
                            ) VALUES (
                            @AccountID,
                            @CardNumber,
                            @PinCode,
                            @CVV,
                            @ExpirationDate,
                            @Status,
                            @CardTypeID,
                            @IssueDate,
                            );
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", AccountID);
            command.Parameters.AddWithValue("@CardNumber", CardNumber);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@CVV", CVV);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    _CardID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return _CardID;
        }



        public static bool UpdateCardByID(int CardID, int AccountID, string CardNumber, string PinCode, string CVV, DateTime ExpirationDate, byte Status, int CardTypeID, DateTime IssueDate)
        {


            int AffectedRows = 0;

            string query = @"UPDATE Cards SET 
                            CardID = @CardID,
                            AccountID = @AccountID,
                            CardNumber = @CardNumber,
                            PinCode = @PinCode,
                            CVV = @CVV,
                            ExpirationDate = @ExpirationDate,
                            Status = @Status,
                            CardTypeID = @CardTypeID,
                            IssueDate = @IssueDate,
                            WHERE CardID = @CardID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardID", CardID);
            command.Parameters.AddWithValue("@AccountID", AccountID);
            command.Parameters.AddWithValue("@CardNumber", CardNumber);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@CVV", CVV);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);

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



        public static bool DeleteCardByID(int CardID)
        {


            int AffectedRows = 0;

            string query = @"DELETE FROM Cards
                                     WHERE CardID = @CardID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardID", CardID);

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



        public static bool GetCardByID(int CardID, ref int AccountID, ref string CardNumber, ref string PinCode, ref string CVV, ref DateTime ExpirationDate, ref byte Status, ref int CardTypeID, ref DateTime IssueDate)
        {

            bool IsFound = false;

            string query = "SELECT * FROM Cards WHERE CardID = @CardID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardID", CardID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    AccountID = (int)reader["AccountID"];
                    CardNumber = (string)reader["CardNumber"];
                    PinCode = (string)reader["PinCode"];
                    CVV = (string)reader["CVV"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Status = (byte)reader["Status"];
                    CardTypeID = (int)reader["CardTypeID"];
                    IssueDate = (DateTime)reader["IssueDate"];

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





        public static bool IsCardExistByCardID(int CardID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Cards WHERE CardID = @CardID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CardID", CardID);

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





        public static DataTable GetAllCards()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Cards ORDER BY CardID DESC";

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
