using System;
using System.Windows.Forms;
using FlexRule.License;

namespace FlexRule.Samples.LocalisedPersonValidation
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            UserLicense.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EmailForm());
        }
    }
}
