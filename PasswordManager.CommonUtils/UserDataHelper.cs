using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace PasswordManager.CommonUtils
{
    public static class UserDataHelper
    {
        private static string userPasswordXPath = 
            "//" + FileUtils.UserDataRootNodeName + "/" + FileUtils.UserDataPasswordNodeName;
        private static string cryptoKeyXPath =
            "//" + FileUtils.UserDataRootNodeName + "/" + FileUtils.UserDataCryptoKeyNodeName;

        private static readonly char[] SYMBOLS =
            new char[] { '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '{', '}', 
                '[', ']', ':', ';', '@', '\'', '~', '#', '|', '\\', '<', '>', ',', '.', '?', '/', '¬', '`' };

        public static bool ValidatePassword(string input)
        {
            if ((input.IndexOfAny(SYMBOLS) >= 0) && input.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CreateUserDataFile()
        {
            FileUtils.CreateUserDataFile();
        }

        public static bool DoesUserDataFileExist()
        {
            return File.Exists(FileUtils.UserDataFullPath);
        }

        public static string GetUserDataPassword()
        {
            XmlDocument userData = new XmlDocument();

            userData.Load(FileUtils.UserDataFullPath);
            XmlNode userPasswordElement = userData.SelectSingleNode(userPasswordXPath);
            string userPassword = null;
            if (userPasswordElement != null)
            {
                userPassword = userPasswordElement.InnerText;
            } 

            if (!String.IsNullOrEmpty(userPassword))
            {
                return userPassword;
            }
            else
            {
                return null;
            }
        }

        public static void SetUserDataPassword(string password)
        {
            XmlDocument userData = new XmlDocument();

            userData.Load(FileUtils.UserDataFullPath);
            XmlNode userPasswordElement = userData.SelectSingleNode(userPasswordXPath);
            userPasswordElement.InnerText = password;
            userData.Save(FileUtils.UserDataFullPath);
        }

        public static void RemoveUserDataPassword()
        {
            SetUserDataPassword(String.Empty);
        }

        public static string GetCryptoKey()
        {
            XmlDocument userData = new XmlDocument();

            userData.Load(FileUtils.UserDataFullPath);
            XmlNode cryptoKeyElement = userData.SelectSingleNode(cryptoKeyXPath);
            string cryptoKey = null;
            if (cryptoKeyElement != null)
            {
                cryptoKey = cryptoKeyElement.InnerText;
            }

            if (!String.IsNullOrEmpty(cryptoKey))
            {
                return cryptoKey;
            }
            else
            {
                return null;
            }
        }

        public static void SetUserDataCryptoKey(string cryptoKey)
        {
            XmlDocument userData = new XmlDocument();

            userData.Load(FileUtils.UserDataFullPath);
            XmlNode cryptoKeyElement = userData.SelectSingleNode(cryptoKeyXPath);
            cryptoKeyElement.InnerText = cryptoKey;
            userData.Save(FileUtils.UserDataFullPath);
        }
    }
}
