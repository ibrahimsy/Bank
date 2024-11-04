using BankDataAccess;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Code_Generator
{
    internal class Program
    {
        public class ColumnInfo
        {
            public string Name { get; set; }
            public string DataType { get; set; }
        }

        public static class CodeGenerator
        {
            public static List<ColumnInfo> GetTableColumns(string connectionString, string tableName)
            {
                var columns = new List<ColumnInfo>();
                string query = @"SELECT COLUMN_NAME, DATA_TYPE 
                         FROM INFORMATION_SCHEMA.COLUMNS 
                         WHERE TABLE_NAME = @TableName";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@TableName", tableName);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            columns.Add(new ColumnInfo
                            {
                                Name = reader["COLUMN_NAME"].ToString(),
                                DataType = MapSqlTypeToCSharpType(reader["DATA_TYPE"].ToString())
                            });
                        }
                    }
                } catch (Exception ex) 
                {
                    
                }

                return columns;
            }

            private static string MapSqlTypeToCSharpType(string sqlType)
            {
                switch (sqlType)
                {
                    case "int":return "int";
                    case "nvarchar": return "string";
                    case "varchar": return "string";
                    case "datetime": return "DateTime";
                    case "bit": return "bool";
                    case "decimal": return "decimal";
                    case "Default":return "string";
                    case "tinyint":return "byte";
                    case "char":return "string";
                   
                }
                return "";
            }

            //Default CRUD Operations
            private static string _GetDataByID(string TableName, List<ColumnInfo> columns)
            {
                StringBuilder GetDataByIDcode = new StringBuilder();

                GetDataByIDcode.AppendLine($"    public static int Get{TableName}ById({GenerateMethodParameters(columns, "Get")})");
                GetDataByIDcode.AppendLine("    {");
                GetDataByIDcode.AppendLine($@" 
                bool IsFound = false;

                string query = ""SELECT * FROM {TableName} WHERE {columns[0].Name} = @{columns[0].Name}"";

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(""@{columns[0].Name}"", {columns[0].Name});

                try
                {{
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                 {{
                        IsFound = true;
                        ");
                foreach (ColumnInfo colInfo in columns)
                {
                    {
                        GetDataByIDcode.AppendLine($@"{colInfo.Name} = ({colInfo.DataType})reader[""{colInfo.Name}""];");
                    }
                }
                GetDataByIDcode.AppendLine($@"
                }}
                reader.Close();
                }}
                catch (Exception ex)
                {{
                    IsFound = false;
                }}
                finally
                {{
                    connection.Close();
                }}
            
                                ");
                GetDataByIDcode.AppendLine($" return IsFound;"); // Placeholder return statement
                GetDataByIDcode.AppendLine("    }");

                return GetDataByIDcode.ToString();
            }

            private static string _DeleteByID(string TableName, List<ColumnInfo> columns)
            {

                StringBuilder DeleteCode = new StringBuilder();
                DeleteCode.AppendLine($"    public static bool Delete{TableName}ById({columns[0].DataType} {columns[0].Name})");
                DeleteCode.AppendLine("    {");
                DeleteCode.AppendLine($@"

                    int AffectedRows = 0;

                    string query = @""DELETE FROM Accounts
                                     WHERE AccountID = @AccountID"";
                    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue(""@AccountID"", AccountID);

                    try
                    {{
                        connection.Open();

                        AffectedRows = command.ExecuteNonQuery();
                    }}
                    catch (Exception ex)
                    {{
                        return false;
                    }}
                    finally {{ connection.Close(); }}

                        ");
                DeleteCode.AppendLine($"  return AffectedRows > 0;"); // Placeholder return statement
                DeleteCode.AppendLine("    }");

                return DeleteCode.ToString();
            }

            private static string _UpdateByID(string TableName, List<ColumnInfo> columns)
            {
                StringBuilder UpdateCode = new StringBuilder();
                UpdateCode.AppendLine($"    public static int Get{TableName}ById({GenerateMethodParameters(columns)})");
                UpdateCode.AppendLine("    {");
                UpdateCode.AppendLine($@" 

                    int AffectedRows = 0;
             
            string query = @""UPDATE {TableName} SET ");

                 foreach (ColumnInfo colInfo in columns)
                {
                    UpdateCode.AppendLine($"{colInfo.Name} = @{colInfo.Name},");
                }

                UpdateCode.AppendLine($@" WHERE {columns[0]} = @{columns[0]}"";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);
                ");

                foreach (ColumnInfo colInfo in columns)
                {
                    UpdateCode.AppendLine($@"command.Parameters.AddWithValue(""@{colInfo.Name}"", {colInfo.Name});");
                }

                UpdateCode.AppendLine($@" 
                        try
                        {{
                            connection.Open();

                            AffectedRows = command.ExecuteNonQuery();
                        }}
                        catch (Exception ex)
                        {{
                            return false;
                        }}
                        finally
                        {{
                            connection.Close();
                        }}
                    ");
          
                UpdateCode.AppendLine($"  return AffectedRows > 0;"); // Placeholder return statement
                UpdateCode.AppendLine("    }");

                return UpdateCode.ToString();
            }
            private static string _AddData(string TableName, List<ColumnInfo> columns)
            {
                StringBuilder AddCode = new StringBuilder();

            }

            public static string GenerateDataAccessCode(string tableName, List<ColumnInfo> columns)
            {
                StringBuilder code = new StringBuilder();

                // Generate Class Definition
                code.AppendLine($@"using System;
                using System.Collections.Generic;
                using System.Data.SqlClient;
                using System.Data;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace BankDataAccess
                {{
                ");
                code.AppendLine("\n");
                code.AppendLine($"public class {tableName}Data");
                code.AppendLine("{");

                // Generate Insert Method
                code.AppendLine($"    public static bool Add{tableName}ByID({GenerateMethodParameters(columns)})");
                code.AppendLine("    {");
                code.AppendLine($"        // Code to insert into {tableName}");
                code.AppendLine("    }");

                code.AppendLine("\n");
                // Generate Update Method
                code.AppendLine($"    public static bool Update{tableName}ByID({GenerateMethodParameters(columns)})");
                code.AppendLine("    {");
                code.AppendLine($"        // Code to update {tableName} by ID");
                code.AppendLine("    }");

                code.AppendLine("\n");
                // Generate Delete Method
                _DeleteByID(tableName, columns);

                code.AppendLine("\n");
                // Generate GetById Method
                _GetDataByID(tableName, columns);

                code.AppendLine("}}");

                return code.ToString();
            }

            private static string GenerateMethodParameters(List<ColumnInfo> columns,string ProccessName = "")
            {
                StringBuilder parameters = new StringBuilder();

                foreach (var column in columns)
                {
                    if(ProccessName == "Get")
                        parameters.Append($"ref {column.DataType} {column.Name}, ");
                    else
                        parameters.Append($"{column.DataType} {column.Name}, ");
                }

                // Remove trailing comma and space
                if (parameters.Length > 0)
                {
                    parameters.Length -= 2;
                }

                return parameters.ToString();
            }

            public static void CreateClassFile(string className, string directoryPath,string ClassContent)
            {
                // Create the directory if it doesn't exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Define the path for the new class file
                string filePath = Path.Combine(directoryPath, $"{className}.cs");

                // Generate the class content
                string classContent = ClassContent;

                // Write the content to the .cs file
                File.WriteAllText(filePath, classContent);
                Console.WriteLine($"Class file '{className}.cs' has been created at {directoryPath}");
            }
            
        }
        static void Main(string[] args)
        {
            string connectionString = clsDataAccessSettings.ConnectionString;
            string tableName = "Transactions";

            
            var columns = CodeGenerator.GetTableColumns(connectionString, tableName);
            string code = CodeGenerator.GenerateDataAccessCode(tableName, columns);

            //Console.WriteLine(code);

            string className = tableName + "Data";

            string directoryPath = @"D:\Development\C#\My-Github\Bank\BankDataAccess"; // Set your desired directory path
           
            CodeGenerator.CreateClassFile(className, directoryPath, code);
            

            Console.ReadLine();
        }
    }
}
