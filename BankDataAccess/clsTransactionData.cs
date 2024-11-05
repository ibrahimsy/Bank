using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsTransactionData
    {
        public static int AddTransaction(int AccountID, DateTime TransactionDate, byte TransactionType, decimal Amount, decimal BalanceAfterTransaction, int CurrencyID, string Description, byte Status, string ReferenceNumber, string SourceAccountID, string DestinationAccountID, int CreatedBy, DateTime CreatedDate, int UpdatedBy, DateTime UpdatedDate)
        {
            int _TransactionID = -1;
            string query = @"INSERT INTO Transactions(
                                       
                                        AccountID,
                                        TransactionDate,
                                        TransactionType,
                                        Amount,
                                        BalanceAfterTransaction,
                                        Currency,
                                        Description,
                                        Status,
                                        ReferenceNumber,
                                        SourceAccountID,
                                        DestinationAccountID,
                                        CreatedBy,
                                        CreatedDate,
                                        UpdatedBy,
                                        UpdatedDate,
                                        ) VALUES (
                                        
                                        @AccountID,
                                        @TransactionDate,
                                        @TransactionType,
                                        @Amount,
                                        @BalanceAfterTransaction,
                                        @Currency,
                                        @Description,
                                        @Status,
                                        @ReferenceNumber,
                                        @SourceAccountID,
                                        @DestinationAccountID,
                                        @CreatedBy,
                                        @CreatedDate,
                                        @UpdatedBy,
                                        @UpdatedDate,
                                        );
                                                        SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@AccountID", AccountID);
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
            command.Parameters.AddWithValue("@TransactionType", TransactionType);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@BalanceAfterTransaction", BalanceAfterTransaction);
            command.Parameters.AddWithValue("@Currency", CurrencyID);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@ReferenceNumber", ReferenceNumber);
            command.Parameters.AddWithValue("@SourceAccountID", SourceAccountID);
            command.Parameters.AddWithValue("@DestinationAccountID", DestinationAccountID);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
            command.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    _TransactionID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return _TransactionID;
        }



        public static bool UpdateTransactionByID(int TransactionID, int AccountID, DateTime TransactionDate, byte TransactionType, decimal Amount, decimal BalanceAfterTransaction, int CurrencyID, string Description, byte Status, string ReferenceNumber, string SourceAccountID, string DestinationAccountID, int CreatedBy, DateTime CreatedDate, int UpdatedBy, DateTime UpdatedDate)
        {


            int AffectedRows = 0;

            string query = @"UPDATE Transactions SET 
                            TransactionID = @TransactionID,
                            AccountID = @AccountID,
                            TransactionDate = @TransactionDate,
                            TransactionType = @TransactionType,
                            Amount = @Amount,
                            BalanceAfterTransaction = @BalanceAfterTransaction,
                            Currency = @Currency,
                            Description = @Description,
                            Status = @Status,
                            ReferenceNumber = @ReferenceNumber,
                            SourceAccountID = @SourceAccountID,
                            DestinationAccountID = @DestinationAccountID,
                            CreatedBy = @CreatedBy,
                            CreatedDate = @CreatedDate,
                            UpdatedBy = @UpdatedBy,
                            UpdatedDate = @UpdatedDate,
                            WHERE TransactionID = @TransactionID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);
            command.Parameters.AddWithValue("@AccountID", AccountID);
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
            command.Parameters.AddWithValue("@TransactionType", TransactionType);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@BalanceAfterTransaction", BalanceAfterTransaction);
            command.Parameters.AddWithValue("@Currency", CurrencyID);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@ReferenceNumber", ReferenceNumber);
            command.Parameters.AddWithValue("@SourceAccountID", SourceAccountID);
            command.Parameters.AddWithValue("@DestinationAccountID", DestinationAccountID);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
            command.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

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



        public static bool DeleteTransactionByID(int TransactionID)
        {


            int AffectedRows = 0;

            string query = @"DELETE FROM Transactions
                                     WHERE TransactionID = @TransactionID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);

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



        public static bool GetTransactionByID( int TransactionID, ref int AccountID, ref DateTime TransactionDate, ref byte TransactionType, ref decimal Amount, ref decimal BalanceAfterTransaction, ref int CurrencyID, ref string Description, ref byte Status, ref string ReferenceNumber, ref string SourceAccountID, ref string DestinationAccountID, ref int CreatedBy, ref DateTime CreatedDate, ref int UpdatedBy, ref DateTime UpdatedDate)
        {

            bool IsFound = false;

            string query = "SELECT * FROM Transactions WHERE TransactionID = @TransactionID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TransactionID = (int)reader["TransactionID"];
                    AccountID = (int)reader["AccountID"];
                    TransactionDate = (DateTime)reader["TransactionDate"];
                    TransactionType = (byte)reader["TransactionType"];
                    Amount = (decimal)reader["Amount"];
                    BalanceAfterTransaction = (decimal)reader["BalanceAfterTransaction"];
                    CurrencyID = (int)reader["Currency"];
                    Description = (string)reader["Description"];
                    Status = (byte)reader["Status"];
                    ReferenceNumber = (string)reader["ReferenceNumber"];
                    SourceAccountID = (string)reader["SourceAccountID"];
                    DestinationAccountID = (string)reader["DestinationAccountID"];
                    CreatedBy = (int)reader["CreatedBy"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    UpdatedBy = (int)reader["UpdatedBy"];
                    UpdatedDate = (DateTime)reader["UpdatedDate"];

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





        public static bool IsTransactionExistByTransactionID(int TransactionID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Transactions WHERE TransactionID = @TransactionID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);

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





        public static DataTable GetAllTransactions()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Transactions ORDER BY TransactionID DESC";

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
