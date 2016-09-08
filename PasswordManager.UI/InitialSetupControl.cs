using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace PasswordManager.UI
{
    internal class InitialSetupControl
    {
        public bool ValidatePassword(string password)
        {
            return UserDataHelper.ValidatePassword(password);
        }

        public void CreateDataFiles(string password)
        {
            const string FILE_CREATION_EXCEPTION_MESSAGE =
                "Unable to create Application Data Files - please check the filepath and try again!";

            try
            {
                UserDataHelper.CreateUserDataFile();
                UserDataHelper.SetUserDataCryptoKey(CryptoHelper.CreateNewCryptoKey());
                UserDataHelper.SetUserDataPassword(Crypto.Encrypt(password));

                PasswordsDataHelper.CreatePasswordsDataFile();
            }
            catch (IOException e)
            {
                throw new InvalidOperationException(FILE_CREATION_EXCEPTION_MESSAGE, e.InnerException);
            }
        }

    }
}
