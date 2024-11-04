﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public class CodeGenerator
        {
            public List<ColumnInfo> GetTableColumns(string connectionString, string tableName)
            {
                var columns = new List<ColumnInfo>();
                string query = @"SELECT COLUMN_NAME, DATA_TYPE 
                         FROM INFORMATION_SCHEMA.COLUMNS 
                         WHERE TABLE_NAME = @TableName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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
                }
                return columns;
            }

            private string MapSqlTypeToCSharpType(string sqlType)
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

            public string GenerateDataAccessCode(string tableName, List<ColumnInfo> columns)
            {
                StringBuilder code = new StringBuilder();

                // Generate Class Definition
                code.AppendLine($"public class {tableName}Data");
                code.AppendLine("{");

                // Generate Insert Method
                code.AppendLine($"    public static bool Add{tableName}ByID({GenerateMethodParameters(columns)})");
                code.AppendLine("    {");
                code.AppendLine($"        // Code to insert into {tableName}");
                code.AppendLine("    }");

                code.AppendLine("\n");
                // Generate Update Method
                code.AppendLine($"    public static bool Update{tableName}ByID(int id, {GenerateMethodParameters(columns)})");
                code.AppendLine("    {");
                code.AppendLine($"        // Code to update {tableName} by ID");
                code.AppendLine("    }");

                code.AppendLine("\n");
                // Generate Delete Method
                code.AppendLine($"    public static bool Delete{tableName}ByID(int id)");
                code.AppendLine("    {");
                code.AppendLine($"        // Code to delete from {tableName} by ID");
                code.AppendLine("    }");

                code.AppendLine("\n");
                // Generate GetById Method
                code.AppendLine($"    public static int Get{tableName}ById(int id)");
                code.AppendLine("    {");
                code.AppendLine($@" 
                        bool IsFound = false;

            string query = ""SELECT * FROM Accounts WHERE AccountID = @AccountID"";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(""@AccountID"", AccountID);

            try
            {{
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {{
                    IsFound = true;

                   
                   
                            
                        
                    
                    ClientID  = (int)reader[""ClientID""];
                    AccountNumber = (string)reader[""AccountNumber""];
                    IsPrimary = (bool)reader[""IsPrimary""];
                    AccountTypeID = (int)reader[""AccountTypeID""];
                    Balance = Convert.ToDouble(reader[""Balance""]);
                    AccountStatus = (byte)reader[""AccountStatus""];
                    DateOpened = (DateTime)reader[""DateOpened""];
                    DateClosed = (DateTime)reader[""DateClosed""];
                    BranchID = (int)reader[""BranchID""];
                    LastTransactionDate = (DateTime)reader[""LastTransactionDate""];
                    Notes = (string)reader[""Notes""];
                    CreatedBy = (int)reader[""CreatedBy""];

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
                code.AppendLine($"       return IsFound;"); // Placeholder return statement
                code.AppendLine("    }");

                code.AppendLine("}");

                return code.ToString();
            }

            private string GenerateMethodParameters(List<ColumnInfo> columns)
            {
                StringBuilder parameters = new StringBuilder();

                foreach (var column in columns)
                {
                    parameters.Append($"{column.DataType} {column.Name}, ");
                }

                // Remove trailing comma and space
                if (parameters.Length > 0)
                {
                    parameters.Length -= 2;
                }

                return parameters.ToString();
            }



        }
        static void Main(string[] args)
        {
            string connectionString = "Server =.;Database= BankDB;User Id =sa;Password=sa123456";
            string tableName = "Transactions";

            var generator = new CodeGenerator();
            var columns = generator.GetTableColumns(connectionString, tableName);
            string code = generator.GenerateDataAccessCode(tableName, columns);

            Console.WriteLine(code);

            Console.ReadLine();
        }
    }
}