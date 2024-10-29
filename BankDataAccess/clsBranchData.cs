using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{
    public class clsBranchData
    {    
        public static bool GetBranchByID(int BranchID, ref string BranchName, ref string Address,ref string PhoneNumber,ref string Email,ref string OpeningHours,ref byte Status)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Branches WHERE BranchID = @BranchID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BranchID", BranchID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    BranchName = (string)reader["BranchName"];
                    Address = (string)reader["Address"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    Email = (string)reader["Email"];
                    OpeningHours = (string)reader["OpeningHours"];
                    Status = (byte)reader["Status"];
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

        public static bool GetBranchByBranchName(string BranchName ,ref int BranchID, ref string Address, ref string PhoneNumber, ref string Email, ref string OpeningHours, ref byte Status)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Branchs WHERE BranchName = @BranchName";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BranchName", BranchName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    BranchID = (int)reader["BranchID"];
                    Address = (string)reader["Address"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    Email = (string)reader["Email"];
                    OpeningHours = (string)reader["OpeningHours"];
                    Status = (byte)reader["Status"];
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


        public static bool UpdateBranchByID(int BranchID,  string BranchName,  string Address,  string PhoneNumber,  string Email,  string OpeningHours,  byte Status)
        {
            int AffectedRows = 0;

            string query = @"UPDATE Branches
                              SET BranchName = @BranchName
                                  ,Address = @Address
                                  ,PhoneNumber = @PhoneNumber
                                  ,Email = @Email
                                  ,OpeningHours = @OpeningHours
                                  ,Status = @Status
                             WHERE BranchID = @BranchID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BranchName", BranchName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@OpeningHours", OpeningHours);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@BranchID", BranchID);

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

        public static bool DeleteBranchByID(int BranchID)
        {
            int AffectedRows = 0;

            string query = @"DELETE FROM Branchs
                             WHERE BranchID = @BranchID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BranchID", BranchID);

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

        public static bool IsBranchExistByBranchID(int BranchID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Branchs WHERE BranchID = @BranchID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BranchID", BranchID);

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

        public static bool IsBranchExistByBranchName(string BranchName)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Branchs WHERE BranchName = @BranchName";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BranchName", BranchName);
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

        public static DataTable GetAllBranchs()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Branches";

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
