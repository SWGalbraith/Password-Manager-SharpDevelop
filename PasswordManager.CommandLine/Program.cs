using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace PasswordManager.CommandLine
{
    static class Program
    {
        static void Main(string[] args)
        {
            CommandLineFunctions.ProcessCommand(args);
        }
    }
}
