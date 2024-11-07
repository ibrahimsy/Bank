using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{
    //int AccountID,int ClientID,string AccountNumber,int AccountID,decimal Balance,
    //byte AccountStatus,DateTime DateOpened,DateTime DateClosed,int BranchID,DateTime LastTransactionDate,string Notes,int CreatedBy

    /*
        int         AccountID
        int         ClientID
        string      AccountNumber
        int         AccountTypeID
        decimal      Balance
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
        public static bool GetAccountByID(int AccountID,ref int ClientID,ref string AccountNumber,ref bool IsPrimary,ref int AccountTypeID,ref decimal Balance,
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
                    IsPrimary = (bool)reader["IsPrimary"];
                    AccountTypeID = (int)reader["AccountTypeID"];
                    Balance = Convert.ToDecimal(reader["Balance"]);
                    AccountStatus = (byte)reader["AccountStatus"];
                    DateOpened = (DateTime)reader["DateOpened"];
                    
                    if (reader["DateClosed"] == DBNull.Value)
                    {
                        DateClosed = DateTime.MaxValue;
                    }
                    else
                    {
                        DateClosed = (DateTime)reader["DateClosed"];
                    }
                    
                    BranchID = (int)reader["BranchID"];
                    

                    if (reader["LastTransactionDate"] == DBNull.Value)
                    {
                        LastTransactionDate = DateTime.MaxValue;
                    }
                    else
                    {
                        LastTransactionDate = (DateTime)reader["LastTransactionDate"];
                    }
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                   
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

        public static bool GetAccountByAccountNumber(string AccountNumber ,ref int AccountID, ref int ClientID,ref bool IsPrimary, ref int AccountTypeID, ref decimal Balance,
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

                    AccountID = (int)reader["AccountID"];
                    ClientID = (int)reader["ClientID"];
                    IsPrimary = (bool)reader["IsPrimary"];
                    AccountTypeID = (int)reader["AccountTypeID"];
                  
                    Balance = Convert.ToDecimal(reader["Balance"]);
                    AccountStatus = (byte)reader["AccountStatus"];
                    DateOpened = (DateTime)reader["DateOpened"];
                    if (reader["DateClosed"] == DBNull.Value)
                    {
                        DateClosed = DateTime.MaxValue;
                    }
                    else
                    {
                        DateClosed = (DateTime)reader["DateClosed"];
                    }
                    BranchID = (int)reader["BranchID"];
                    
                    if (reader["LastTransactionDate"] == DBNull.Value)
                    {
                        LastTransactionDate = DateTime.MaxValue;
                    }
                    else
                    {
                        LastTransactionDate = (DateTime)reader["LastTransactionDate"];
                    }
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
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

        public static bool GetPrimaryAccountByClientID(int ClientID, ref int AccountID, ref string AccountNumber, ref bool IsPrimary, ref int AccountTypeID, ref decimal Balance,
                               ref byte AccountStatus, ref DateTime DateOpened, ref DateTime DateClosed, ref int BranchID, ref DateTime LastTransactionDate, ref string Notes, ref int CreatedBy)
        {
            bool IsFound = false;

            string query = @"SELECT *
                            FROM          Accounts INNER JOIN
                                          Clients ON Accounts.ClientID = Clients.ClientID
                            WHERE Clients.ClientID = @ClientID And Accounts.IsPrimary = 1";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID",ClientID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    AccountID = (int)reader["AccountID"];
                    AccountNumber = (string)reader["AccountNumber"];
                    IsPrimary = (bool)reader["IsPrimary"];
                    AccountTypeID = (int)reader["AccountTypeID"];

                    Balance = Convert.ToDecimal(reader["Balance"]);
                    AccountStatus = (byte)reader["AccountStatus"];
                    DateOpened = (DateTime)reader["DateOpened"];
                    if (reader["DateClosed"] == DBNull.Value)
                    {
                        DateClosed = DateTime.MaxValue;
                    }
                    else
                    {
                        DateClosed = (DateTime)reader["DateClosed"];
                    }
                    BranchID = (int)reader["BranchID"];
                    
                    if (reader["LastTransactionDate"] == DBNull.Value)
                    {
                        LastTransactionDate = DateTime.MaxValue;
                    }
                    else
                    {
                        LastTransactionDate = (DateTime)reader["LastTransactionDate"];
                    }
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                    CreatedBy = (int)reader["CreatedBy"];
                }
                reader.Close();

            }
            catch(Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool GetAccountByClientID(int ClientID, ref int AccountID, ref string AccountNumber, ref bool IsPrimary, ref int AccountTypeID, ref decimal Balance,
                               ref byte AccountStatus, ref DateTime DateOpened, ref DateTime DateClosed, ref int BranchID, ref DateTime LastTransactionDate, ref string Notes, ref int CreatedBy)
        {
            bool IsFound = false;

            string query = @"SELECT *
                            FROM  Accounts INNER JOIN
                                  Clients ON Accounts.ClientID = Clients.ClientID
                            WHERE Clients.ClientID = @ClientID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    AccountID = (int)reader["AccountID"];
                    AccountNumber = (string)reader["AccountNumber"];
                    IsPrimary = (bool)reader["IsPrimary"];
                    AccountTypeID = (int)reader["AccountTypeID"];
                    Balance = Convert.ToDecimal(reader["Balance"]);
                    AccountStatus = (byte)reader["AccountStatus"];
                    DateOpened = (DateTime)reader["DateOpened"];
                    if (reader["DateClosed"] == DBNull.Value)
                    {
                        DateClosed = DateTime.MaxValue;
                    }
                    else
                    {
                        DateClosed = (DateTime)reader["DateClosed"];
                    }
                    BranchID = (int)reader["BranchID"];

                    if (reader["LastTransactionDate"] == DBNull.Value)
                    {
                        LastTransactionDate = DateTime.MaxValue;
                    }
                    else
                    {
                        LastTransactionDate = (DateTime)reader["LastTransactionDate"];
                    }
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
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

        public static int AddNewAccount(int ClientID, string AccountNumber,bool IsPrimary,  int AccountTypeID,  decimal Balance,
                                byte AccountStatus,  DateTime DateOpened,  int BranchID, string Notes,  int CreatedBy)
        {
            int AccountID = -1;

            string query = @"INSERT INTO Accounts
                               (ClientID,AccountNumber,IsPrimary,AccountTypeID,Balance,AccountStatus,DateOpened
                               ,BranchID,Notes,CreatedBy)
                         VALUES
                               (@ClientID,@AccountNumber,@IsPrimary,@AccountTypeID,@Balance,@AccountStatus,@DateOpened
                               ,@BranchID,@Notes,@CreatedBy);
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@IsPrimary", IsPrimary);
            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
           
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@AccountStatus", AccountStatus);

            command.Parameters.AddWithValue("@DateOpened", DateOpened);
            
            command.Parameters.AddWithValue("@BranchID", BranchID);
           

            if (Notes == null)
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            
            
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

        public static bool IsAccountExistByAccountNumber(string AccountNumber)
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
        
        public static bool UpdateAccountByID(int AccountID, int ClientID, string AccountNumber,bool IsPrimary, int AccountTypeID, decimal Balance,
                                byte AccountStatus,DateTime DateOpened,DateTime DateClosed,int BranchID,DateTime LastTransactionDate,string Notes,int CreatedBy)
        {
            int AffectedRows = 0;

            string query = @"UPDATE Accounts
                             SET ClientID = @ClientID
                                  ,AccountNumber = @AccountNumber
                                  ,IsPrimary = @IsPrimary
                                  ,AccountTypeID = @AccountTypeID
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
            command.Parameters.AddWithValue("@IsPrimary", IsPrimary);
            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@AccountStatus", AccountStatus);

            command.Parameters.AddWithValue("@DateOpened", DateOpened);
            
            if (DateClosed == DateTime.MaxValue)
            {
                command.Parameters.AddWithValue("@DateClosed", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@DateClosed", DateClosed);
            }
            command.Parameters.AddWithValue("@BranchID", BranchID);
            if (LastTransactionDate == null)
            {
                command.Parameters.AddWithValue("@LastTransactionDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@LastTransactionDate", LastTransactionDate);
            }

            if (Notes == null)
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
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

        public static DataTable GetAllAccountsByClientID(int ClientID)
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Accounts_View WHERE ClientID = @ClientID ORDER BY AccountID DESC";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);
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

        public static DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Accounts_View ORDER BY AccountID DESC";

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
