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
        /*
         ClientID
         PersonID
         PrimaryAccountNumber
         AccountStatus
         CreatedBy
         CreatedDate
         UpdatedDate
         BranchID
         Notes
         */
        public static bool GetClientByID(int ClientID, ref int PersonID, ref string PrimaryAccountNumber, ref byte AccountStatus,
                 ref int CreatedBy, ref DateTime CreatedDate, ref DateTime? UpdatedDate,ref int BranchID,ref string Notes)
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

                    PersonID = (int)reader["PrimaryAccountNumber"];
                    if (reader["PrimaryAccountNumber"] == DBNull.Value)
                    {
                        PrimaryAccountNumber = "";
                    }
                    else
                    {
                        PrimaryAccountNumber = (string)reader["PrimaryAccountNumber"];
                    }
                   
                    AccountStatus = (byte)reader["AccountStatus"];
                    CreatedBy = (int)reader["CreatedBy"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                   
                    if (reader["UpdatedDate"] == DBNull.Value)
                    {
                        UpdatedDate = null;
                    }
                    else
                    {
                        UpdatedDate = (DateTime)reader["UpdatedDate"];
                    }
                    BranchID = (int)reader["BranchID"];
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                    

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

        public static bool GetClientByPersonID(int PersonID, ref int ClientID, ref string PrimaryAccountNumber, ref byte AccountStatus,
                 ref int CreatedBy, ref DateTime CreatedDate, ref DateTime? UpdatedDate, ref int BranchID, ref string Notes)
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
                    ClientID = (int)reader["ClientID"];
                    if (reader["PrimaryAccountNumber"] == DBNull.Value)
                    {
                        PrimaryAccountNumber = "";
                    }
                    else
                    {
                        PrimaryAccountNumber = (string)reader["PrimaryAccountNumber"];
                    }
                    AccountStatus = (byte)reader["AccountStatus"];
                    CreatedBy = (int)reader["CreatedBy"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    if (reader["UpdatedDate"] == DBNull.Value)
                    {
                        UpdatedDate = null;
                    }
                    else
                    {
                        UpdatedDate = (DateTime)reader["UpdatedDate"];
                    }
                    BranchID = (int)reader["BranchID"];
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
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
        
        public static int AddNewClient(int PersonID,  string PrimaryAccountNumber,  byte AccountStatus,
                  int CreatedBy,  DateTime CreatedDate,  DateTime? UpdatedDate,  int BranchID,  string Notes)
        {
            int ClientID = -1;

            string query = @"INSERT INTO Clients
                           (PersonID,PrimaryAccountNumber,AccountStatus,CreatedBy,CreatedDate
                           ,UpdatedDate,BranchID,Notes)
                     VALUES
                           (@PersonID,@PrimaryAccountNumber,@AccountStatus,@CreatedBy,@CreatedDate
                           ,@UpdatedDate,@BranchID,@Notes);
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            if (PrimaryAccountNumber == "")
            {
                command.Parameters.AddWithValue("@PrimaryAccountNumber", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PrimaryAccountNumber", PrimaryAccountNumber);
            }
           
            command.Parameters.AddWithValue("@AccountStatus", AccountStatus);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            if (UpdatedDate == null)
            {
                command.Parameters.AddWithValue("@UpdatedDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            }
           
            command.Parameters.AddWithValue("@BranchID", BranchID);
            if (Notes == "")
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }


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

        public static bool UpdateClientByID(int ClientID,int PersonID, string PrimaryAccountNumber, byte AccountStatus,
                         int CreatedBy, DateTime CreatedDate, DateTime? UpdatedDate, int BranchID, string Notes)
        {
            int AffectedRows = 0;

            string query = @"UPDATE Clients
                             SET PersonID = @PersonID
                                ,PrimaryAccountNumber = @PrimaryAccountNumber
                                ,AccountStatus = @AccountStatus
                                ,CreatedBy = @CreatedBy
                                ,CreatedDate = @CreatedDate
                                ,UpdatedDate = @UpdatedDate
                                ,BranchID = @BranchID
                                ,Notes = @Notes
                              WHERE ClientID = @ClientID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            if (PrimaryAccountNumber == "")
            {
                command.Parameters.AddWithValue("@PrimaryAccountNumber", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PrimaryAccountNumber", PrimaryAccountNumber);
            }
            command.Parameters.AddWithValue("@AccountStatus", AccountStatus);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            if (UpdatedDate == null)
            {
                command.Parameters.AddWithValue("@UpdatedDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            }
            command.Parameters.AddWithValue("@BranchID", BranchID);
            if (Notes == "")
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }

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


        public static DataTable GetAllClients()
        
        {
            DataTable dtClients = new DataTable();

            string query = @"SELECT        
                            ClientID,
                            Clients.PersonID,
                            (People.FirstName +' '+ People.SecondName +' '+ People.ThirdName +' '+ People.LastName) AS FullName,
                            PrimaryAccountNumber,
                            AccountStatus,
                            CreatedBy,
                            CreatedDate,
                            UpdatedDate,
                            BranchID,
                            Notes
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
