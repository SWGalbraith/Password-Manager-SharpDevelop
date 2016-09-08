using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordManager.CommandLine
{
    internal class HelpCommand : ICommandLineCommand
    {
        public void RunCommand(string[] commandArgs)
        {
            const string INDENT = "         ";

            string commandLineOptions =
                Environment.NewLine +
                "Password Manager Command Line flags are: "
                + Environment.NewLine
                + Environment.NewLine
                + "[-encryptionSetup]"
                + Environment.NewLine
                + "[-exportPasswords]"
                + Environment.NewLine
                + Environment.NewLine
                + Environment.NewLine
                + "-encryptionSetup : "
                + Environment.NewLine
                + INDENT + "> Sets up/resets encryption for the Password Manager application."
                + Environment.NewLine
                + INDENT + "> Add the [-skipUserCheck] flag to skip the check asking if you want"
                + Environment.NewLine
                + INDENT + "  to proceed."
                + Environment.NewLine
                + INDENT + "> Add the [-launchPM] flag to launch Password Manager once the "
                + Environment.NewLine
                + INDENT + "  encryption keys have been set/reset."
                + Environment.NewLine
                + Environment.NewLine
                + "-exportPasswords {path} : "
                + Environment.NewLine
                + INDENT + "> Exports stored passwords to a file of your choice."
                + Environment.NewLine
                + INDENT + "> Requires the {path} to be entered after the command to set the file"
                + Environment.NewLine
                + INDENT + "  you want to output to."
                + Environment.NewLine
                + INDENT + "> Add the [-password] {password} flag to export data without being"
                + Environment.NewLine
                + INDENT + "  prompted for your Password Manager password."
                + Environment.NewLine
                + INDENT + "> Example: pmcmd.exe -exportPasswords"
                + Environment.NewLine
                + INDENT + "  C:\\Test\\Test.txt -password P@55w0rd"
                + Environment.NewLine;

            Console.Write(commandLineOptions);
        }
    }
}
