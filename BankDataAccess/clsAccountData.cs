using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{
    //int AccountID,int ClientID,string AccountNumber,int AccountID,short PinCode,double Balance,
    //byte AccountStatus,DateTime DateOpened,DateTime DateClosed,int BranchID,DateTime LastTransactionDate,string Notes,int CreatedBy

    /*
        int         AccountID
        int         ClientID
        string      AccountNumber
        int         AccountID
        short       PinCode
        double      Balance
        byte        AccountStatus
        DateTime    DateOpened
        DateTime    DateClosed
        int         BranchID
        DateTime    LastTransactionDate
        string      Notes
        int         CreatedBy
     */
    public class clsAccountData
    {
        public static bool GetAccountByID(int AccountID,ref int ClientID,ref string AccountNumber,ref int AccountType,ref short PinCode,ref double Balance,
                               ref byte AccountStatus,ref DateTime DateOpened,ref DateTime DateClosed,ref int BranchID,ref DateTime LastTransactionDate,ref string Notes,ref int CreatedBy)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Accounts WHERE AccountID = @AccountID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountID", AccountID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                   
                    ClientID  = (int)reader["ClientID"];
                    AccountNumber = (string)reader["AccountNumber"];
                    AccountID = (int)reader["AccountID"];
                    PinCode = (short)reader["PinCode"];
                    Balance = Convert.ToDouble(reader["Balance"]);
                    AccountStatus = (byte)reader["AccountStatus"];
                    DateOpened = (DateTime)reader["DateOpened"];
                    DateClosed = (DateTime)reader["DateClosed"];
                    BranchID = (int)reader["BranchID"];
                    LastTransactionDate = (DateTime)reader["LastTransactionDate"];
                    Notes = (string)reader["AccouNotesntID"];
                    CreatedBy = (int)reader["CreatedBy"];

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

        public static bool GetAccountByAccountNumber(string AccountNumber ,ref int AccountID, ref int ClientID, ref int AccountType, ref short PinCode, ref double Balance,
                               ref byte AccountStatus, ref DateTime DateOpened, ref DateTime DateClosed, ref int BranchID, ref DateTime LastTransactionDate, ref string Notes, ref int CreatedBy)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Accounts WHERE AccountNumber = @AccountNumber";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ClientID = (int)reader["ClientID"];
                    AccountID = (int)reader["AccountID"];
                    PinCode = (short)reader["PinCode"];
                    Balance = Convert.ToDouble(reader["Balance"]);
                    AccountStatus = (byte)reader["AccountStatus"];
                    DateOpened = (DateTime)reader["DateOpened"];
                    DateClosed = (DateTime)reader["DateClosed"];
                    BranchID = (int)reader["BranchID"];
                    LastTransactionDate = (DateTime)reader["LastTransactionDate"];
                    Notes = (string)reader["AccouNotesntID"];
                    CreatedBy = (int)reader["CreatedBy"];
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


        public static int AddNewAccount(string AccountNumber,  int AccountTypeID,  int ClientID,  int AccountType,  short PinCode,  double Balance,
                                byte AccountStatus,  DateTime DateOpened,  DateTime DateClosed,  int BranchID,  DateTime LastTransactionDate,  string Notes,  int CreatedBy)
        {
            int AccountID = -1;

            string query = @"INSERT INTO Accounts
                               (ClientID,AccountNumber,AccountTypeID,PinCode,Balance,AccountStatus,DateOpened
                               ,DateClosed,BranchID,LastTransactionDate,Notes,CreatedBy)
                         VALUES
                               (@ClientID,@AccountNumber,@AccountTypeID,@PinCode,@Balance,@AccountStatus,@DateOpened
                               ,@DateClosed,@BranchID,@LastTransactionDate,@Notes,@CreatedBy);
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@AccountStatus", AccountStatus);

            command.Parameters.AddWithValue("@DateOpened", DateOpened);
            command.Parameters.AddWithValue("@DateClosed", DateClosed);
            command.Parameters.AddWithValue("@BranchID", BranchID);
            command.Parameters.AddWithValue("@LastTransactionDate", LastTransactionDate);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("@AccountID", AccountID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    AccountID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return AccountID;
        }

        public static bool IsAccountExistByAccountID(int AccountID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Accounts WHERE AccountID = @AccountID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountID", AccountID);

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

        public static bool IsAccountExistByAccountNumber(int AccountNumber)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Accounts WHERE AccountNumber = @AccountNumber";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

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
        
        public static bool UpdateAccountByID(int AccountID, int ClientID, string AccountNumber, int AccountTypeID, short PinCode, double Balance,
                                byte AccountStatus,DateTime DateOpened,DateTime DateClosed,int BranchID,DateTime LastTransactionDate,string Notes,int CreatedBy)
        {
            int AffectedRows = 0;

            string query = @"UPDATE Accounts
                             SET ClientID = @ClientID
                                  ,AccountNumber = @AccountNumber
                                  ,AccountTypeID = @AccountTypeID
                                  ,PinCode = @PinCode
                                  ,Balance = @Balance
                                  ,AccountStatus = @AccountStatus
                                  ,DateOpened = @DateOpened
                                  ,DateClosed = @DateClosed
                                  ,BranchID = @BranchID
                                  ,LastTransactionDate = @LastTransactionDate
                                  ,Notes = @Notes
                                  ,CreatedBy = @CreatedBy
                             WHERE AccountID = @AccountID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@AccountStatus", AccountStatus);

            command.Parameters.AddWithValue("@DateOpened", DateOpened);
            command.Parameters.AddWithValue("@DateClosed", DateClosed);
            command.Parameters.AddWithValue("@BranchID", BranchID);
            command.Parameters.AddWithValue("@LastTransactionDate", LastTransactionDate);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("@AccountID", AccountID);
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

        public static bool DeleteAccountByID(int AccountID)
        {
            int AffectedRows = 0;

            string query = @"DELETE FROM Accounts
                             WHERE AccountID = @AccountID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountID", AccountID);

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

        public static DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Accounts";

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
