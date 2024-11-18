using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsNewCardApplicationData
    {
        public static int AddNewCardApplicationByID(int ApplicationID, int CardTypeID)
        {
            int _NewCardApplicationID = -1;
            string query = @"INSERT INTO NewCardApplications(
                            ApplicationID,
                            CardTypeID
                            ) VALUES (
                            @ApplicationID,
                            @CardTypeID
                            );
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    _NewCardApplicationID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return _NewCardApplicationID;
        }

        public static bool UpdateNewCardApplicationsByID(int NewCardApplicationID, int ApplicationID, int CardTypeID)
        {


            int AffectedRows = 0;

            string query = @"UPDATE NewCardApplications SET 
                             ApplicationID = @ApplicationID,
                             CardTypeID = @CardTypeID
                             WHERE NewCardApplicationID = @NewCardApplicationID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NewCardApplicationID", NewCardApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);

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

        public static bool DeleteNewCardApplicationsByID(int NewCardApplicationID)
        {

            int AffectedRows = 0;

            string query = @"DELETE FROM NewCardApplications
                                     WHERE NewCardApplicationID = @NewCardApplicationID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NewCardApplicationID", NewCardApplicationID);

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

        public static bool GetNewCardApplicationsByID(int NewCardApplicationID, ref int ApplicationID, ref int CardTypeID)
        {

            bool IsFound = false;

            string query = "SELECT * FROM NewCardApplications WHERE NewCardApplicationID = @NewCardApplicationID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NewCardApplicationID", NewCardApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    CardTypeID = (int)reader["CardTypeID"];

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

        public static bool IsNewCardApplicationsExistByID(int NewCardApplicationID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM NewCardApplications WHERE NewCardApplicationID = @NewCardApplicationID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NewCardApplicationID", NewCardApplicationID);

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

        public static DataTable GetAllNewCardApplications()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM NewCardApplications_View ORDER BY NewCardApplicationID DESC";

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
