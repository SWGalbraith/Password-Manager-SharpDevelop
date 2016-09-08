using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordManager.UI
{
    internal class PasswordCheckControl
    {
        internal bool CheckPassword(string password)
        {
            if (password.Equals(Crypto.Decrypt(UserDataHelper.GetUserDataPassword())))
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
