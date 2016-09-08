using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordManager.CommonUtils;
using PasswordManager.Encryption;

namespace PasswordManager.CommandLine
{
    internal static class CommandLineFunctions
    {
        internal static void ProcessCommand(string[] commandArgs)
        {
            const string ENCRYPTION_SETUP_ARG = "-encryptionSetup";
            const string EXPORT_PASSWORDS_ARG = "-exportPasswords";
            const string COMMAND_LINE_HELP_ARG = "-help";

            if (commandArgs.Length > 0)
            {
                ICommandLineCommand command = null;

                if (commandArgs.Contains(ENCRYPTION_SETUP_ARG))
                {
                    command = new EncryptionSetupCommand();
                }
                else if (commandArgs.Contains(EXPORT_PASSWORDS_ARG))
                {
                    command = new ExportPasswordsCommand();
                }
                else if (commandArgs.Contains(COMMAND_LINE_HELP_ARG))
                {
                    command = new HelpCommand();
                }
                else
                {
                    Console.WriteLine(Environment.NewLine 
                        + "Invalid Arguments! Use [-help] flag for help " 
                        + "with Command Line options!");
                }

                if (command != null)
                {
                    command.RunCommand(commandArgs);
                }
            }
            else
            {
                Console.WriteLine(Environment.NewLine
                        + "No options passed! Use [-help] option for help with Command Line options!");
            }
        }

        internal static bool CheckPassword()
        {
            Console.WriteLine(Environment.NewLine
                    + "Please enter your Password Manager password to continue: ");

            return CheckPassword(GetMaskedPasswordFromConsole());
        }

        internal static bool CheckPassword(string password)
        {
            if (Crypto.Decrypt(UserDataHelper.GetUserDataPassword()).Equals(password))
            {
                Console.WriteLine(Environment.NewLine 
                    + "Password validated! - Continuing..." 
                    + Environment.NewLine);
                return true;
            }
            else
            {
                Console.WriteLine(Environment.NewLine
                    + "Password invalid! - Exiting..." 
                    + Environment.NewLine);
                return false;
            }
        }

        private static string GetMaskedPasswordFromConsole()
        {
            string password = null;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);

            return password;
        }
    }
}
