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

        public static void notifyUser(NotifyIcon nf,string messageToUser, ToolTipIcon icon)
        {
            nf.Icon = SystemIcons.Application;
            nf.Text = messageToUser;
            nf.BalloonTipIcon = icon;
            nf.Visible = true;
            nf.BalloonTipText = messageToUser;
            nf.ShowBalloonTip(3000);
        }

    }
}
