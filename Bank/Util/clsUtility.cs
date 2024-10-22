﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank.Util
{
    public class clsUtility
    {
        public static bool IsValidEmail(string Email)
        {
            string Patern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(Patern);
            return regex.IsMatch(Email);     
        }

        static string _GenerateGUID()
        {
            Guid guid = new Guid();

            return guid.ToString();
        }

        static string _RenameImage(string SourceFile)
        {
            FileInfo fileInfo = new FileInfo(SourceFile);
            string Extention = fileInfo.Extension;

            return _GenerateGUID() + Extention;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string ImagesFolder = Directory.GetCurrentDirectory() + "\\Images\\";
            
            if (!Directory.Exists(ImagesFolder)) 
            {
                Directory.CreateDirectory(ImagesFolder);

                string DestinationFile = ImagesFolder + _RenameImage(SourceFile);
                try
                {
                    File.Copy(SourceFile, DestinationFile, true);   
                }
                catch (Exception ex) 
                {
                    return false;
                }
                SourceFile = DestinationFile;
            }
            return true;
        }

    }
}
