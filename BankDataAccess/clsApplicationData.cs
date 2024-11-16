using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsApplicationData
    {
        public static int AddNewApplication(int ApplicantAccountID, int ApplicationTypeID, DateTime ApplicationDate, byte Status,Decimal PaidFees, int CreatedBy)
        {
            int _ApplicationID = -1;
            string query = @"INSERT INTO Applications(
                            ApplicantAccountID,
                            ApplicationTypeID,
                            ApplicationDate,
                            Status,
                            PaidFees,
                            CreatedBy
                            ) VALUES (
                            @ApplicantAccountID,
                            @ApplicationTypeID,
                            @ApplicationDate,
                            @Status,
                            @PaidFees,
                            @CreatedBy
                            );
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
           
            command.Parameters.AddWithValue("@ApplicantAccountID", ApplicantAccountID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    _ApplicationID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return _ApplicationID;
        }



        public static bool UpdateApplicationByID(int ApplicationID, int ApplicantAccountID, int ApplicationTypeID, DateTime ApplicationDate, byte Status, Decimal PaidFees, int CreatedBy)
        {


            int AffectedRows = 0;

            string query = @"UPDATE Applications SET 
                             ApplicationID = @ApplicationID,
                             ApplicantAccountID = @ApplicantAccountID,
                             ApplicationTypeID = @ApplicationTypeID,
                             ApplicationDate = @ApplicationDate,
                             Status = @Status,
                             PaidFees = @PaidFees,
                             CreatedBy = @CreatedBy,
                             WHERE ApplicationID = @ApplicationID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicantAccountID", ApplicantAccountID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedBy", CreatedBy);

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



        public static bool DeleteApplicationByID(int ApplicationID)
        {


            int AffectedRows = 0;

            string query = @"DELETE FROM Applications
                                     WHERE ApplicationID = @ApplicationID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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



        public static bool GetApplicationByID(int ApplicationID, ref int ApplicantAccountID, ref int ApplicationTypeID, ref DateTime ApplicationDate, ref byte Status, ref Decimal PaidFees, ref int CreatedBy)
        {

            bool IsFound = false;

            string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    
                    ApplicantAccountID = (int)reader["ApplicantAccountID"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    Status = (byte)reader["Status"];
                    PaidFees = (Decimal)reader["PaidFees"];
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





        public static bool IsApplicationExistByApplicationID(int ApplicationID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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





        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Applications ORDER BY ApplicationID DESC";

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
