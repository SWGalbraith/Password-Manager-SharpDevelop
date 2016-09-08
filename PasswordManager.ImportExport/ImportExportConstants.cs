using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordManager.ImportExport
{
    internal static class ImportExportConstants
    {
        private const string TITLE_END_IDENTIFIER = ": ";
        private const string APP_NAME_IDENTIFIER = "Application" + TITLE_END_IDENTIFIER;
        private const string USERNAME_IDENTIFIER = "Username" + TITLE_END_IDENTIFIER;
        private const string PASSWORD_IDENTIFIER = "Password" + TITLE_END_IDENTIFIER;

        internal static string TitleEndIdentifer { get { return TITLE_END_IDENTIFIER; } }
        internal static string AppNameIdentifer { get { return APP_NAME_IDENTIFIER; } }
        internal static string UsernameIdentifer { get { return USERNAME_IDENTIFIER; } }
        internal static string PasswordIdentifer { get { return PASSWORD_IDENTIFIER; } }
    }
}
