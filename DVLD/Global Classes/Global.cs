using DVLD_BusinessLayer;
using System;
using System.IO;
using System.Windows.Forms;


namespace DVLD
{
    public class Global
    {

        public static User currentUser=User.Find(1);
    

        public static bool RememberUsernameAndPassword(string userName,string password)
        {
            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = Path.Combine(currentDirectory,"loginData.txt");

                if(string.IsNullOrEmpty(userName))
                {
                    File.Delete(filePath);
                    return true;
                }

                string dataToSave = userName + "#//#" + password;

                using (StreamWriter write =new StreamWriter(filePath))
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
        }

        public static bool GetStoredCredential(ref string userName, ref string passwored)
        {
            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = Path.Combine(currentDirectory, "loginData.txt");

              
                if(File.Exists(filePath))
                {

                    using (StreamReader read = new StreamReader(filePath))
                    {
                        string line;
                        while ((line=read.ReadLine())!=null)
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
        }

    }

}
