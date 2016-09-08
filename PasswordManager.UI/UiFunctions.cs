using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using System.Threading;

namespace PasswordManager.UI
{
    public static class UiFunctions
    {
        public static void StartApplication()
        {
            // Mutex is used to make sure only one application instance will run at a time.
            Mutex mutex = new Mutex(true, "PasswordManager.UniqueInstanceID:" + Environment.UserName);

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (IsUserDataSetupComplete())
                {
                    RunPasswordManagerWithPasswordCheck();
                }
                else
                {
                    RunInitialSetup();
                }

                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Password Manager is already running!" + Environment.NewLine + Environment.NewLine
                    + "Please check the System Tray (bottom right) if you cannot find the open instance.");

                NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME,
                    IntPtr.Zero, IntPtr.Zero);
            }
        }

        private static void RunInitialSetup()
        {
            InitialSetup initialSetup = new InitialSetup();
            Application.Run(initialSetup);

            if (!initialSetup.WasFormClosed)
            {
                Application.Run(new PasswordManager());
            }
        }

        private static void RunPasswordManagerWithPasswordCheck()
        {
            const string USER_LOGIN_MESSAGE = "Enter your PasswordManager password to login:";

            PasswordCheck passwordCheck = new PasswordCheck(USER_LOGIN_MESSAGE);
            Application.Run(passwordCheck);

            if (passwordCheck.Confirm == true)
            {
                Application.Run(new PasswordManager());
            }
        }

        private static bool IsUserDataSetupComplete()
        {
            if (PasswordsDataHelper.DoesPasswordDataFileExist()
                && UserDataHelper.DoesUserDataFileExist()
                && UserDataHelper.GetUserDataPassword() != null
                && UserDataHelper.GetCryptoKey() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
