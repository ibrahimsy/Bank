using BankBussiness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Global_Classes
{
    public class clsGlobalSettings
    {
        public static clsUser CurrentUser = new clsUser();

        public static bool RememberUserNameAndPassword(string Username, string Password)
        {
             //string FilePath = @"D:\Devlopment\C#\My-Github\Bank\Login.txt";
            string FilePath = @"C:\My-Github\Bank\Login.txt";
            if (Username != "")
            {
                string LoginInfo = $"{Username}#//#{Password}";

                try
                {
                    File.WriteAllText(FilePath, LoginInfo);
                    return true;

                }
                catch (IOException ex)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    File.Delete(FilePath);
                }
                catch (IOException ex)
                {
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    
        public static bool GetRestoredUserNameAndPassword(ref string Username,ref string Password)
        {
            //string FilePath = @"D:\Devlopment\C#\My-Github\Bank\Login.txt";
            string FilePath = @"C:\My-Github\Bank\Login.txt";
            if (File.Exists(FilePath))
            {
                try
                {
                   string LoginInfo =  File.ReadAllText(FilePath);
                    if (!string.IsNullOrEmpty(LoginInfo)) 
                    {
                        string[] Result = LoginInfo.Split(new string[]{ "#//#" },StringSplitOptions.None); 
                        Username = Result[0];
                        Password = Result[1];

                        return true;
                    }

                }catch (IOException ex) {
                    return false;
                }
            }
            return false;
        }
    
    }
}
