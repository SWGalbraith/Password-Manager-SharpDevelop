using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PasswordManager.UI
{
    internal class EditPasswordControl
    {
        internal void UpdatePasswordDetails(
            string oldAppName, string oldUsername, string appName, string username, string password)
        {
            PasswordsDataHelper.UpdateAppInPasswordsData(
                oldAppName, oldUsername, appName, username, Crypto.Encrypt(password));
        }
    }
}
