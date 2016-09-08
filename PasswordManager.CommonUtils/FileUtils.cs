using PasswordManager.CommonUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace PasswordManager.CommonUtils
{
    public static class FileUtils
    {
    	private const string APPLICATION_ICON_FILENAME = "\\PM-Icon.ico";
        private const string APPLICATION_DATA_FOLDER_NAME = "\\ApplicationData";
        private const string PASSWORDS_DATA_FILENAME = "\\PasswordsData.xml";
        private const string USER_DATA_FILENAME = "\\UserData.xml";
        private const string PASSWORDS_ROOT_NODE_NAME = "passwords";
        private const string USER_DATA_ROOT_NODE_NAME = "userData";
        private const string USER_DATA_PASSWORD_NODE_NAME = "userPassword";
        private const string USER_DATA_CRYPTO_KEY_NODE_NAME = "cryptoKey";

        private static string exeInstallPath = GetApplicationInstallPath();

        internal static string PasswordsDataFullPath 
        { 
            get 
            { 
                return exeInstallPath + APPLICATION_DATA_FOLDER_NAME + PASSWORDS_DATA_FILENAME; 
            } 
        }

        internal static string UserDataFullPath
        {
            get
            {
                return exeInstallPath + APPLICATION_DATA_FOLDER_NAME + USER_DATA_FILENAME;
            }
        }

        internal static string UserDataRootNodeName
        {
            get
            {
                return USER_DATA_ROOT_NODE_NAME;
            }
        }

        internal static string UserDataPasswordNodeName
        {
            get
            {
                return USER_DATA_PASSWORD_NODE_NAME;
            }
        }

        internal static string UserDataCryptoKeyNodeName
        {
            get
            {
                return USER_DATA_CRYPTO_KEY_NODE_NAME;
            }
        }

        public static string GetApplicationInstallPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
        
        public static string GetApplicationIconPath()
        {
        	return exeInstallPath + APPLICATION_ICON_FILENAME;
        }

        internal static bool DoesAppDataFolderExist()
        {
            return Directory.Exists(
                exeInstallPath + APPLICATION_DATA_FOLDER_NAME);
        }

        internal static void CreateAppDataFolder()
        {
            Directory.CreateDirectory(
                exeInstallPath + APPLICATION_DATA_FOLDER_NAME);
        }

        internal static void CreatePasswordsDataFile()
        {
            CreateFile(PasswordsDataFullPath);
            AddRootXmlElement(PasswordsDataFullPath, PASSWORDS_ROOT_NODE_NAME);
        }

        internal static void CreateUserDataFile()
        {
            CreateFile(UserDataFullPath);
            AddRootXmlElement(UserDataFullPath, USER_DATA_ROOT_NODE_NAME);

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(UserDataFullPath);
            
            XmlNode userPasswordNode = 
                xmlDoc.CreateNode(XmlNodeType.Element, USER_DATA_PASSWORD_NODE_NAME, String.Empty);
            XmlNode cryptoKeyNode =
                xmlDoc.CreateNode(XmlNodeType.Element, USER_DATA_CRYPTO_KEY_NODE_NAME, String.Empty);

            xmlDoc.FirstChild.AppendChild(userPasswordNode);
            xmlDoc.FirstChild.AppendChild(cryptoKeyNode);

            xmlDoc.Save(UserDataFullPath);
        }

        internal static void UpdatePasswordsDataFile(XmlDocument updatedFile)
        {
            updatedFile.Save(PasswordsDataFullPath);
        }

        internal static void UpdateUserDataFile(XmlDocument updatedFile)
        {
            updatedFile.Save(UserDataFullPath);
        }

        private static void CreateFile(string path)
        {
            if (!DoesAppDataFolderExist())
            {
                CreateAppDataFolder();
            }

            File.Create(path);
        }

        private static void AddRootXmlElement(string xmlFilePath, string rootNodeName)
        {
            const string INVALID_FILE_PATH_EXCEPTION = 
                "FileUtils.AddRootXmlElement() - XML File was not available to edit!";
            const string XML_ROOT_ELEMENT_TEXT = "<{0}>\n</{0}>";

            bool isFileAvailable = true;

            do
            {
                isFileAvailable = true;

                try
                {
                    if (File.Exists(xmlFilePath))
                    {
                        File.WriteAllText(xmlFilePath, String.Format(XML_ROOT_ELEMENT_TEXT, rootNodeName));
                    }
                    else
                    {
                        throw new ArgumentException(INVALID_FILE_PATH_EXCEPTION);
                    }
                }
                catch (IOException)
                {
                    isFileAvailable = false;
                }
            }
            while (!isFileAvailable);
        }

    }
}
