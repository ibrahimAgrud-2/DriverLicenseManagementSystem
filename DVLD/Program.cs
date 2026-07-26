using DVLD.Applications.International_License_Applications;
using System;


namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frmAddUpdatePerson());
            System.Windows.Forms.Application.Run(new frmManageInternationalLicesnseApplications());

        }
    }
}
