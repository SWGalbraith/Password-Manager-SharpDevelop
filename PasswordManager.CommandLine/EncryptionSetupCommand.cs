using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.IO;
using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using PasswordManager.UI;

namespace PasswordManager.CommandLine
{
    internal class EncryptionSetupCommand : ICommandLineCommand
    {
        public void RunCommand(string[] commandArgs)
        {
            const string SKIP_USER_CHECK_ARG = "-skipUserCheck";
            const string LAUNCH_PASSWORD_MANAGER_ARG = "-launchPM";

            try
            {
                if (commandArgs.Contains(SKIP_USER_CHECK_ARG))
                {
                    SetNewEncryptionKeys();
                }
                else
                {
                    if (DoesUserWantToContinue())
                    {
                        SetNewEncryptionKeys();
                    }
                }

                if (commandArgs.Contains(LAUNCH_PASSWORD_MANAGER_ARG))
                {
                    LaunchPasswordManager();
                }
            }
            catch (Exception ex)
            {
                Console.Write(Environment.NewLine + "Error during Encryption Setup process!"
                     + Environment.NewLine + Environment.NewLine
                     + "Error was:" + Environment.NewLine + ex.Message + Environment.NewLine);
            }
        }

        private void SetNewEncryptionKeys()
        {
            Console.WriteLine("Generating New Encryption Key...");

            UserDataHelper.SetUserDataCryptoKey(CryptoHelper.CreateNewCryptoKey());
            UserDataHelper.RemoveUserDataPassword();

            Console.WriteLine("Done.");
            Console.WriteLine(String.Empty);
        }

        private bool DoesUserWantToContinue()
        {
            bool shouldContinue = false;

            Console.WriteLine(String.Empty);
            Console.WriteLine("********");
            Console.WriteLine("WARNING!");
            Console.WriteLine("********");
            Console.WriteLine(String.Empty);
            Console.WriteLine("Overwriting encryption key will make it impossible to decrypt any data"
                + " encrypted with the current key!");

            string input = String.Empty;

            while (!input.Equals("Y", StringComparison.CurrentCultureIgnoreCase)
                && !input.Equals("N", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine(String.Empty);
                Console.WriteLine("Do you want to overwrite the current encryption key and generate a new one? (Y/N)");

                input = Console.ReadLine();

                if (input.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                {
                    shouldContinue = true;
                }
                else if (input.Equals("N", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Abandoning Encryption Key Overwrite...");
                    Console.WriteLine("Done.");
                    Console.WriteLine(String.Empty);
                    shouldContinue = false;
                }
                else
                {
                    Console.WriteLine("Invalid input - please enter either 'Y' or 'N' (case insensitive)");
                }
            }

            return shouldContinue;
        }

        private void LaunchPasswordManager()
        {
            Console.WriteLine("Launching Password Manager...");
            Console.WriteLine(String.Empty);

            try
            {
                UiFunctions.StartApplication();
            }
            catch (Exception ex)
            {
                throw new Exception("Error launching UI after generating new encryption key! - " + ex.Message);
            }
        }
    }
}
