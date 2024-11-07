using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{



    public class clsBeneficiaryData
    {
        public static int AddBeneficiary( int ClientID, int AccountID, string Name, string MobileNumber, string Nickname, DateTime CreatedDate, byte Status)
        {
            int _BeneficiaryID = -1;
            string query = @"INSERT INTO Beneficiaries(           
                                ClientID,
                                AccountID,
                                Name,
                                MobileNumber,
                                Nickname,
                                CreatedDate,
                                Status
                                ) VALUES (
                                @ClientID,
                                @AccountID,
                                @Name,
                                @MobileNumber,
                                @Nickname,
                                @CreatedDate,
                                @Status
                                );
                                SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountID", AccountID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@MobileNumber", MobileNumber);
            command.Parameters.AddWithValue("@Nickname", Nickname);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@Status", Status);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    _BeneficiaryID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return _BeneficiaryID;
        }



        public static bool UpdateBeneficiaryByID(int BeneficiaryID, int ClientID, int AccountID, string Name, string MobileNumber, string Nickname, DateTime CreatedDate, byte Status)
        {


            int AffectedRows = 0;

            string query = @"UPDATE Beneficiaries SET 
                                BeneficiaryID = @BeneficiaryID,
                                ClientID = @ClientID,
                                AccountID = @AccountID,
                                Name = @Name,
                                MobileNumber = @MobileNumber,
                                Nickname = @Nickname,
                                CreatedDate = @CreatedDate,
                                Status = @Status
                                WHERE BeneficiaryID = @BeneficiaryID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BeneficiaryID", BeneficiaryID);
            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountID", AccountID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@MobileNumber", MobileNumber);
            command.Parameters.AddWithValue("@Nickname", Nickname);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@Status", Status);

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



        public static bool DeleteBeneficiariesByID(int BeneficiaryID)
        {


            int AffectedRows = 0;

            string query = @"DELETE FROM Beneficiaries
                                     WHERE BeneficiaryID = @BeneficiaryID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BeneficiaryID", BeneficiaryID);

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



        public static bool GetBeneficiariesByID(int BeneficiaryID, ref int ClientID, ref int AccountID, ref string Name, ref string MobileNumber, ref string Nickname, ref DateTime CreatedDate, ref byte Status)
        {

            bool IsFound = false;

            string query = "SELECT * FROM Beneficiaries WHERE BeneficiaryID = @BeneficiaryID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BeneficiaryID", BeneficiaryID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ClientID = (int)reader["ClientID"];
                    AccountID = (int)reader["AccountID"];
                    Name = (string)reader["Name"];
                    MobileNumber = (string)reader["MobileNumber"];
                    Nickname = (string)reader["Nickname"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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





        public static bool IsBeneficiariesExistByBeneficiaryID(int BeneficiaryID)
        {
            bool IsFound = false;

            string query = @"SELECT found = 1 FROM Beneficiaries WHERE BeneficiaryID = @BeneficiaryID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BeneficiaryID", BeneficiaryID);

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





        public static DataTable GetAllBeneficiaries()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Beneficiaries ORDER BY BeneficiaryID DESC";

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
