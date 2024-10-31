using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{
    public class clsAccountTypeData
    {
        /*
         int    AccountTypeID
         string AccountTypeName
         float  InterestRate
         double WithdrawalLimit
         double MinimumBalance
         string Description
         */
        public static bool GetAccountTypeByID(int AccountTypeID, ref string AccountTypeName, ref float InterestRate, ref double WithdrawalLimit, ref double MinimumBalance, ref string Description)
        {
            bool IsFound = false;

            string query = "SELECT * FROM AccountTypes WHERE AccountTypeID = @AccountTypeID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
          
                    AccountTypeName = (string)reader["AccountTypeName"];
                    InterestRate = Convert.ToSingle(reader["InterestRate"]);
                    WithdrawalLimit = Convert.ToDouble(reader["WithdrawalLimit"]);
                    MinimumBalance = Convert.ToDouble(reader["MinimumBalance"]);
                    Description = (string)reader["Description"];
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

        public static bool GetAccountTypeByName(string AccountTypeName, ref int AccountTypeID, ref float InterestRate, ref double WithdrawalLimit, ref double MinimumBalance, ref string Description)
        {
            bool IsFound = false;

            string query = "SELECT * FROM AccountTypes WHERE AccountTypeName = @AccountTypeName";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountTypeName", AccountTypeName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    AccountTypeID = (int)reader["AccountTypeID"];
                    InterestRate = Convert.ToSingle(reader["InterestRate"]);
                    WithdrawalLimit = Convert.ToDouble(reader["WithdrawalLimit"]);
                    MinimumBalance = Convert.ToDouble(reader["MinimumBalance"]);
                    Description = (string)reader["Description"];
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

       
        public static bool UpdateAccountTypeByID(int AccountTypeID, string AccountTypeName,  float InterestRate,  double WithdrawalLimit,  double MinimumBalance,  string Description)
        {
            int AffectedRows = 0;

            string query = @"UPDATE AccountTypes
                               SET AccountTypeName = @AccountTypeName
                                  ,InterestRate = @InterestRate
                                  ,WithdrawalLimit = @WithdrawalLimit
                                  ,MinimumBalance = @MinimumBalance
                                  ,Description = @Description
                             WHERE AccountTypeID = @AccountTypeID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountTypeName", AccountTypeName);
            command.Parameters.AddWithValue("@InterestRate", InterestRate);
            command.Parameters.AddWithValue("@WithdrawalLimit", WithdrawalLimit);
            command.Parameters.AddWithValue("@MinimumBalance", MinimumBalance);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

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

        public static bool DeleteAccountTypeByID(int AccountTypeID)
        {
            int AffectedRows = 0;

            string query = @"DELETE FROM AccountTypes
                             WHERE AccountTypeID = @AccountTypeID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

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

        public static DataTable GetAllAccountTypes()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM AccountTypes";

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
