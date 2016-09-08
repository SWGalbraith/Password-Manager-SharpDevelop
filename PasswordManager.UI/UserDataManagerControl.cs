using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace PasswordManager.UI
{
    internal class UserDataManagerControl
    {        
        internal void UpdateUserPassword(string password)
        {
            UserDataHelper.SetUserDataPassword(Crypto.Encrypt(password));
        }

        internal bool IsUserPasswordUpdated(string password)
        {
            bool passwordUpdated = false;

            if (password != Crypto.Decrypt(UserDataHelper.GetUserDataPassword()))
            {
                passwordUpdated = true;
            }

            return passwordUpdated;
        }

        internal bool ValidatePassword(string password)
        {
            if (UserDataHelper.ValidatePassword(password))
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
