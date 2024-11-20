using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsApplicationTypeData
    {
        public static int AddApplicationTypes(string TypeTitle, Decimal Fees)
        {
            int _TypeID = -1;
            string query = @"INSERT INTO ApplicationTypes(
                             TypeTitle,
                             Fees,
                             ) VALUES (
                             @TypeTitle,
                             @Fees,
                             );
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TypeTitle", TypeTitle);
            command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    _TypeID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return _TypeID;
        }



        public static bool UpdateApplicationTypesByID(int TypeID, string TypeTitle, Decimal Fees)
        {


            int AffectedRows = 0;

            string query = @"UPDATE ApplicationTypes SET 
                             TypeTitle = @TypeTitle,
                             Fees = @Fees
                             WHERE TypeID = @TypeID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TypeID", TypeID);
            command.Parameters.AddWithValue("@TypeTitle", TypeTitle);
            command.Parameters.AddWithValue("@Fees", Fees);

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



        public static bool DeleteApplicationTypesByID(int TypeID)
        {


            int AffectedRows = 0;

            string query = @"DELETE FROM ApplicationTypes
                                     WHERE TypeID = @TypeID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TypeID", TypeID);

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



        public static bool GetApplicationTypesByID(int TypeID, ref string TypeTitle, ref Decimal Fees)
        {

            bool IsFound = false;

            string query = "SELECT * FROM ApplicationTypes WHERE TypeID = @TypeID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TypeID", TypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TypeTitle = (string)reader["TypeTitle"];
                    Fees = Convert.ToDecimal(reader["Fees"]);

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





        public static bool IsApplicationTypesExistByTypeID(int TypeID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM ApplicationTypes WHERE TypeID = @TypeID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TypeID", TypeID);

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





        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM ApplicationTypes";

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
