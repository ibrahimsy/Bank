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
        public static int AddTransaction(int AccountID, DateTime TransactionDate, byte TransactionType, decimal Amount, decimal BalanceAfterTransaction, int CurrencyID, string Description, byte Status, int SourceAccountID, int DestinationAccountID, int CreatedBy, DateTime CreatedDate)
        {
            int _TransactionID = -1;
            string query = @"INSERT INTO Transactions(         
                                        AccountID,
                                        TransactionDate,
                                        TransactionType,
                                        Amount,
                                        BalanceAfterTransaction,
                                        CurrencyID,
                                        Description,
                                        Status,
                                        SourceAccountID,
                                        DestinationAccountID,
                                        CreatedBy,
                                        CreatedDate
                                        ) VALUES (
                                        @AccountID,
                                        @TransactionDate,
                                        @TransactionType,
                                        @Amount,
                                        @BalanceAfterTransaction,
                                        @CurrencyID,
                                        @Description,
                                        @Status,
                                        @SourceAccountID,
                                        @DestinationAccountID,
                                        @CreatedBy,
                                        @CreatedDate
                                        );
                                        SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@AccountID", AccountID);
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
            command.Parameters.AddWithValue("@TransactionType", TransactionType);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@BalanceAfterTransaction", BalanceAfterTransaction);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Status", Status);
          
            
            if (SourceAccountID == -1)
                command.Parameters.AddWithValue("@SourceAccountID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SourceAccountID", SourceAccountID);
            

            if (DestinationAccountID == -1)
                command.Parameters.AddWithValue("@DestinationAccountID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@DestinationAccountID", DestinationAccountID);
            

            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);


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



        public static bool UpdateTransactionByID(int TransactionID, int AccountID, DateTime TransactionDate, byte TransactionType, decimal Amount, decimal BalanceAfterTransaction, int CurrencyID, string Description, byte Status, int SourceAccountID, int DestinationAccountID, int CreatedBy, DateTime CreatedDate)
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
                          
                            SourceAccountID = @SourceAccountID,
                            DestinationAccountID = @DestinationAccountID,
                            CreatedBy = @CreatedBy,
                            CreatedDate = @CreatedDate,
                           
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
            
            command.Parameters.AddWithValue("@SourceAccountID", SourceAccountID);
            command.Parameters.AddWithValue("@DestinationAccountID", DestinationAccountID);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
           

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



        public static bool GetTransactionByID( int TransactionID, ref int AccountID, ref DateTime TransactionDate, ref byte TransactionType, ref decimal Amount, ref decimal BalanceAfterTransaction, ref int CurrencyID, ref string Description, ref byte Status, ref string ReferenceNumber, ref int SourceAccountID, ref int DestinationAccountID, ref int CreatedBy, ref DateTime CreatedDate)
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
                    SourceAccountID = (int)reader["SourceAccountID"];
                    DestinationAccountID = (int)reader["DestinationAccountID"];
                    CreatedBy = (int)reader["CreatedBy"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                 

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
