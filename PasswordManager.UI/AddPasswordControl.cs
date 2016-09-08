using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PasswordManager.UI
{
    internal class AddPasswordControl
    {
        internal void AddNewPassword(string appName, string username, string password)
        {
            PasswordsDataHelper.AddAppToPasswordsData(appName, username, Crypto.Encrypt(password));
        }
    }
}
