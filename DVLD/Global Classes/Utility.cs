using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;


namespace DVLD
{
    public class Utility
    {

        public static bool createFolderIsNotExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                    return true;

                }
                catch(Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static string ReplaceFileNameWithGUID(string fileName)
        {
            return GenerateGuid() + Path.GetExtension(fileName);
        }
        public static bool CopyImageToNewFolder(ref string imagePath, string destination = @"C:\Images\")
        {
            if(createFolderIsNotExists(destination))
            {
                if (!File.Exists(imagePath))
                    return false;
              
                string newImagePath = destination + ReplaceFileNameWithGUID(imagePath);


                try
                {
                    File.Copy(imagePath, newImagePath, true);
                    imagePath = newImagePath;
                    return true;
                }
                catch (Exception iox)
                {
                    MessageBox.Show(iox.Message);
                    return false;
                }
              
            }
            return false;
        }

        public static bool DeleteImageFromFolder(string imagePath)
        {
            try
            {
                File.Delete(imagePath);

            }
            catch (Exception iox)
            {
                MessageBox.Show(iox.Message);
                return false;
            }
            return true;
        }

        

    }
}
