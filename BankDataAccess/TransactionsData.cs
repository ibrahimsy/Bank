using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{
                


    public class TransactionsData
    {
    public static int AddTransactionsByID( int AccountID, DateTime TransactionDate, byte TransactionType, decimal Amount,
                decimal BalanceAfterTransaction, string Currency, string Description, byte Status, string ReferenceNumber,
                string SourceAccountID, string DestinationAccountID, int CreatedBy,
                DateTime CreatedDate, int UpdatedBy, DateTime UpdatedDate)
    {
            // Code to insert into Transactions
            return -1;
    }


    public static bool UpdateTransactionsByID(int TransactionID, int AccountID, DateTime TransactionDate, byte TransactionType, decimal Amount,
        decimal BalanceAfterTransaction, string Currency, string Description, byte Status, string ReferenceNumber,
        string SourceAccountID, string DestinationAccountID, int CreatedBy, DateTime CreatedDate, int UpdatedBy, DateTime UpdatedDate)
    {
            // Code to update Transactions by ID
            return true;
    }


    public static bool DeleteTransactionsByID(int id)
    {
            // Code to delete from Transactions by ID
            return true;
    }


    public static bool GetTransactionsById(ref int TransactionID, ref int AccountID, ref DateTime TransactionDate,
        ref byte TransactionType, ref decimal Amount, ref decimal BalanceAfterTransaction, ref string Currency,
        ref string Description, ref byte Status, ref string ReferenceNumber, ref string SourceAccountID, ref string DestinationAccountID, ref int CreatedBy, ref DateTime CreatedDate, ref int UpdatedBy, ref DateTime UpdatedDate)
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
                            Currency = (string)reader["Currency"];
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
 
    
    }
}
