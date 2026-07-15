using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace DVLD
{
    public class Utility
    {
        public static bool IsEmailValid(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            return regex.IsMatch(email);
        }

        public static bool copyImageToNewFolder(ref string imagePath, string destination = @"C:\Images\")
        {
            string newImagePath = destination + Guid.NewGuid() + ".jpg";
            if (!File.Exists(imagePath))
                return false;

            File.Copy(imagePath, newImagePath, true);
            imagePath = newImagePath;
            return true;
        }

        public static bool DeleteImageFromFolder(string imagePath)
        {
            try
            {
                File.Delete(imagePath);

            }
            catch (IOException)
            {
                MessageBox.Show("Previous image could not deleted");
                return false;
            }
            return true;
        }

        

    }
}
