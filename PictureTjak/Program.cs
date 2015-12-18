using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using PictureTjak.Properties;

namespace PictureTjak
{
    static class Program
    {
        public const string RegisterCommand = "register";
        public const string RunAsVerb = "runas";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Any(a => a == RegisterCommand))
            {
                try
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\PictureTjak\shell\open\command", null, $"\"{Application.ExecutablePath}\" \"%1\"");
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\.docx", null, "PictureTjak");
                }
                catch
                {
                    MessageBox.Show(Resources.Failed_to_register_file_handler, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Core(args));
        }
    }
}
