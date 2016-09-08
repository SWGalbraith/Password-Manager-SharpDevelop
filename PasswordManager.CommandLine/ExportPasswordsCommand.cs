using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordManager.ImportExport;
using System.IO;

namespace PasswordManager.CommandLine
{
    internal class ExportPasswordsCommand : ICommandLineCommand
    {
        public void RunCommand(string[] commandArgs)
        {
            if (commandArgs.Length >= 2)
            {
                try
                {
                    if (commandArgs.Length >= 4)
                    {
                        string password = commandArgs[3];

                        if (CommandLineFunctions.CheckPassword(password))
                        {
                            PerformPasswordsExport(commandArgs);
                        }
                    }
                    else
                    {
                        Console.WriteLine(Environment.NewLine
                            + "No password was passed into the application!");

                        if (CommandLineFunctions.CheckPassword())
                        {
                            PerformPasswordsExport(commandArgs);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(Environment.NewLine + "Error during Passwords Export process!"
                        + Environment.NewLine + Environment.NewLine
                        + "Error was:" + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Add the {path} option to export your passwords!"
                    + Environment.NewLine
                    + "Example: PasswordManager.CommandLine.exe -exportPasswords C:\\Example\\example.txt"
                    + Environment.NewLine);
            }
        }

        private void PerformPasswordsExport(string[] exportPasswordArgs)
        {
            const string TEXT_FILE_EXTENSION = ".txt";

            string successMessage = Environment.NewLine
                        + "Passwords file exported to " + exportPasswordArgs[1];

            string filepath = null;

            if (exportPasswordArgs.Length >= 2)
            {
                filepath = exportPasswordArgs[1];
            }

            if (!String.IsNullOrEmpty(filepath) && IsDirectoryPathValid(filepath))
            {
                ExportHelper.ExportPasswordsToFile(filepath, false);
            }
            else
            {
                throw new ArgumentException("Directory/Filepath '" + filepath + "' was invalid!");
            }

            if (successMessage.EndsWith(TEXT_FILE_EXTENSION))
            {
                Console.WriteLine(successMessage);
            }
            else
            {
                Console.WriteLine(successMessage + TEXT_FILE_EXTENSION);
            }
        }

        private bool IsDirectoryPathValid(string filepath)
        {
            const string DIRECTORY_INDICATOR = @"\";

            if (filepath.Contains(DIRECTORY_INDICATOR))
            {
                string directory = filepath.Remove(filepath.LastIndexOf(DIRECTORY_INDICATOR));

                if (Directory.Exists(directory))
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
