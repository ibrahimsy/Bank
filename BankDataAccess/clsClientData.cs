using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{
    public static class clsClientData
    {
        public static bool GetClientByID(int ClientID, ref int PersonID, ref string AccountNumber,ref short PinCode ,ref double Balance, ref bool IsActive, ref int CreatedBy)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Clients WHERE ClientID = @ClientID";

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
                    PersonID = (int)reader["PersonID"];
                    AccountNumber = (string)reader["AccountNumber"];
                    PinCode = (short)reader["PinCode"];
                    Balance = Convert.ToDouble(reader["Balance"]);
                    IsActive = (bool)reader["IsActive"];
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

        public static bool GetClientByPersonID(ref int ClientID, int PersonID, ref string AccountNumber, ref short PinCode, ref double Balance,ref bool IsActive,ref int CreatedBy)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Clients WHERE PersonID = @PersonID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ClientID = (int)reader["ClientID"];
                    AccountNumber = (string)reader["AccountNumber"];
                    PinCode = (short)reader["PinCode"];
                    Balance = Convert.ToDouble(reader["Balance"]);
                    IsActive = (bool)reader["IsActive"];
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

        public static bool GetClientByAccountNumber(ref int ClientID,ref int PersonID,string AccountNumber, ref short PinCode, ref double Balance, ref bool IsActive, ref int CreatedBy)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Clients WHERE AccountNumber = @AccountNumber";

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
                    PersonID = (int)reader["PersonID"];
                    PinCode = (short)reader["PinCode"];
                    Balance = Convert.ToDouble(reader["Balance"]);
                    IsActive = (bool)reader["IsActive"];
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
        
        public static int AddNewClient( int PersonID,  string AccountNumber,  short PinCode,  double Balance,bool IsActive,int CreatedByID)
        {
            int ClientID = -1;

            string query = @"INSERT INTO Clients
                           (PersonID,AccountNumber,PinCode,Balance,IsActive,CreatedBy)
                     VALUES
                           (@PersonID,@AccountNumber,@PinCode,@Balance,@IsActive,@CreatedBy);
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedBy", CreatedByID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    ClientID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ClientID;
        }

        public static bool UpdateClientByID(int ClientID, int PersonID, string AccountNumber, short PinCode, double Balance,bool IsActive, int CreatedByID)
        {
            int AffectedRows = 0;

            string query = @"UPDATE Clients
                             SET PersonID = @PersonID
                                ,AccountNumber = @AccountNumber
                                ,PinCode = @PinCode
                                ,Balance = @Balance
                                ,IsActive = @IsActive
                                ,CreatedBy = @CreatedBy
                             WHERE ClientID = @ClientID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedBy", CreatedByID);

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

        public static bool DeleteClientByID(int ClientID)
        {
            int AffectedRows = 0;

            string query = @"DELETE FROM Clients
                             WHERE ClientID = @ClientID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);

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

        public static bool IsClientExistByClientID(int ClientID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Clients WHERE ClientID = @ClientID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
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

        public static bool IsClientExistByAccountNo(string AccountNumber)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Clients WHERE AccountNumber = @AccountNumber";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
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

        public static bool IsClientExistByAccountNoAndPinCode(string AccountNumber,short PinCode)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Clients 
                             WHERE AccountNumber = @AccountNumber AND PinCode = @PinCode";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@PinCode", PinCode);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
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
       
        public static bool IsClientExistByPersonID(int PersonID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Clients WHERE PersonID = @PersonID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

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

        public static bool IsClientActiveByAccountNumber(string AccountNumber)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Clients WHERE AccountNumber = @AccountNumber AND IsActive = 1";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
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

        public static DataTable GetAllClients()
        {
            DataTable dtClients = new DataTable();

            string query = @"SELECT        
                            ClientID,
                            Clients.PersonID,
                            (People.FirstName +' '+ People.SecondName +' '+ People.ThirdName +' '+ People.LastName) AS FullName,
                            AccountNumber,
                            pinCode,
                            Balance,
                            IsActive
                            FROM   Clients INNER JOIN
                                   People ON Clients.PersonID = People.PersonID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtClients.Load(reader);
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
            return dtClients;
        }

    }
}
