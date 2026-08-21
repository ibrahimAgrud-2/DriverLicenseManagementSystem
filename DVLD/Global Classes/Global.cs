using DVLD_BusinessLayer;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using Common;


namespace DVLD
{
    public class Global
    {

        public static User CurrentUser = User.Find(1);

        public static bool DeleteRegistrdLoginInfo()
        {
            string subKeyPath = @"Software\DVLD";
            string valueName = "aa";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyPath, writable: true))
                {
                    if (key == null)
                    {
                        return false;
                    }

                    // GetValueNames() içinde "aa" var mı diye kontrol edelim
                    if (Array.IndexOf(key.GetValueNames(), valueName) >= 0)
                    {
                        key.DeleteValue(valueName);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);
                return false;
            }
        }
     
        
        public static bool RememberUsernameAndPassword(string userName, string password)
        {

            if(userName==""||password=="")
            {
                return DeleteRegistrdLoginInfo();
            }

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string valueName = userName;
            string valueData = password;
           
            try
            {
                Registry.SetValue(keyPath, valueName, valueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);
                return false;
            }

            
            //save to file
            /*
             
            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = Path.Combine(currentDirectory, "loginData.txt");

                if (string.IsNullOrEmpty(userName))
                {
                    File.Delete(filePath);
                    return true;
                }

                string dataToSave = userName + "#//#" + password;

                using (StreamWriter write = new StreamWriter(filePath))
                {
                    write.WriteLine(dataToSave);
                    return true;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
             */

        }



        public static bool GetStoredCredential(ref string userName, ref string passwored)
        {

            string subKeyPath = @"Software\DVLD";
            string valueName = "";

            try
            {

                // 1. Adım: Key'i aç (sadece okuma amaçlı)
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyPath))
                {
                    if (key == null)
                    {
                        return false;

                    }

                    // 2. Adım: Bu key altındaki TÜM value isimlerini al
                    string[] valueNames = key.GetValueNames();

                    if (valueNames.Length == 0)
                    {
                        return false;
                    }

                    // 3. Adım: Her isim için değerini al ve yazdır
                    foreach (string name in valueNames)
                    {
                        object data = key.GetValue(name);
                        userName = name;
                        passwored = data.ToString();
                       
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);
                return false;

            }
          

        }


        //get data from file
        /*

            try
           {
               string currentDirectory = System.IO.Directory.GetCurrentDirectory();

               string filePath = Path.Combine(currentDirectory, "loginData.txt");


               if (File.Exists(filePath))
               {

                   using (StreamReader read = new StreamReader(filePath))
                   {
                       string line;
                       while ((line = read.ReadLine()) != null)
                       {
                           string[] splitedString = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                           userName = splitedString[0];
                           passwored = splitedString[1];

                       }
                       return true;
                   }

               }
               else
               {
                   return false;
               }

           }
           catch (Exception ex)
           {
               MessageBox.Show($"An error occurred: {ex.Message}");
               return false;
           }
         */
    }

    }

