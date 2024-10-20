using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDataAccess
{
    public static class clsPersonData
    {
        public static bool GetPersonByID(int PersonID,ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
                       ref byte Gendor, ref DateTime DateOfBirth, ref int NationalityCountryID, ref string Phone, ref string Email, ref string Address, ref string ImagePath)
        {
            bool IsFound = false;

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID);

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                   
                    if (reader["ThirdName"] == DBNull.Value)
                        ThirdName = "";
                    else
                        ThirdName = (string)reader["ThirdName"];
                    
                    LastName = (string)reader["LastName"];
                    Gendor = (byte)reader["Gendor"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];

                    if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = "";
                    else
                        ImagePath = (string)reader["ImagePath"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound=false;
            }
            finally 
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool GetPersonByNationalNo(ref int PersonID,string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
                       ref short Gendor, ref DateTime DateOfBirth, ref int NationalityCountryID, ref string Phone, ref string Email, ref string Address, ref string ImagePath)
        {
            bool IsFound = false;

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] == DBNull.Value)
                        ThirdName = "";
                    else
                        ThirdName = (string)reader["ThirdName"];

                    LastName = (string)reader["LastName"];
                    Gendor = (byte)reader["Gendor"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];

                    if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = "";
                    else
                        ImagePath = (string)reader["ImagePath"];
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

        public static int AddNewPerson(string NationalNo,string FirstName, string SecondName,string ThirdName, string LastName,
                                        short Gendor, DateTime DateOfBirth, int NationalityCountryID, string Phone, string Email,
                                        string Address, string ImagePath)
        {
            int PersonID = -1;

            string query = @"INSERT INTO People
                           (NationalNo,FirstName,SecondName,ThirdName,LastName,Gendor,DateOfBirth
                           ,NationalityCountryID,Phone,Email,Address,ImagePath)
                     VALUES
                           (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@Gendor,@DateOfBirth
                           ,@NationalityCountryID,@Phone,@Email,@Address,@ImagePath);
                            SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName == "")
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
             else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            if(ImagePath == "")
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
               object result =  command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(),out int Id)) 
                {
                    PersonID = Id;
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                connection.Close();
            }
            return PersonID;
        }


    }
}
