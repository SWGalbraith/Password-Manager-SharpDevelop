using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordManager.CommandLine
{
    internal interface ICommandLineCommand
    {
        void RunCommand(string[] commandArgs);
    }
}