
using DVLD.Applications;
using DVLD.Applications.Application_Types;
using DVLD.Applications.New_Local_Driving_License_Application;
using DVLD.Drivers;
using DVLD.People;
using DVLD.People.Controls;
using DVLD.Test.Test_Types;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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
            System.Windows.Forms.Application.Run(new frmLogin());

        }
    }
}
