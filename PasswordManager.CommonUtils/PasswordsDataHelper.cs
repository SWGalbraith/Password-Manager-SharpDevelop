using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace PasswordManager.CommonUtils
{
    public static class PasswordsDataHelper
    {
        private const string APP_NAME_ATTRIBUTE = "name";
        private const string APP_NODE_NAME = "application";
        private const string USERNAME_NODE_NAME = "userName";
        private const string PASSWORD_NODE_NAME = "password";
        private const string APP_NAME_DICT_KEY = "AppName";
        private const string USER_NAME_DICT_KEY = "Username";
        private const string PASSWORD_DICT_KEY = "Password";

        public static string AppNameKey { get { return APP_NAME_DICT_KEY; } }
        public static string UsernameKey { get { return USER_NAME_DICT_KEY; } }
        public static string PasswordKey { get { return PASSWORD_DICT_KEY; } }

        public static void CreatePasswordsDataFile()
        {
            FileUtils.CreatePasswordsDataFile();
        }

        public static bool DoesPasswordDataFileExist()
        {
            return File.Exists(FileUtils.PasswordsDataFullPath);
        }

        public static List<Dictionary<string, string>> GetAllAppDetailsDictionaryList()
        {
            List<Dictionary<string, string>> allAppDetails = new List<Dictionary<string, string>>();
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(FileUtils.PasswordsDataFullPath);

            foreach (XmlNode appNode in xmlDoc.FirstChild.ChildNodes)
            {
                Dictionary<string, string> appDetails = new Dictionary<string, string>();

                if (appNode.Name.Equals(APP_NODE_NAME))
                {
                    appDetails.Add(AppNameKey, appNode.Attributes[APP_NAME_ATTRIBUTE].Value);

                    foreach (XmlNode childNode in appNode.ChildNodes)
                    {
                        if (childNode.Name.Equals(USERNAME_NODE_NAME))
                        {
                            appDetails.Add(UsernameKey, childNode.InnerXml);
                        }
                        else if (childNode.Name.Equals(PASSWORD_NODE_NAME))
                        {
                            appDetails.Add(PasswordKey, childNode.InnerXml);
                        }
                    }
                }

                allAppDetails.Add(appDetails);
            }

            return allAppDetails;
        }

        public static Dictionary<string, string> GetAppDetailsDictionary(string appName, string username)
        {
            return GetAppDetailDictionaryFromXml(appName, username);
        }

        public static bool IsAppDuplicate(string appName, string username)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string passwordsDataPath = FileUtils.PasswordsDataFullPath;

            xmlDoc.Load(passwordsDataPath);

            foreach (XmlNode appNode in xmlDoc.FirstChild.ChildNodes)
            {
                if (IsRequiredNode(appNode, appName, username))
                {
                    return true;
                }
            }

            return false;
        }

        public static void AddAppToPasswordsData(string appName, string username, string password)
        {
            const string DUPLICATE_APP_EXCEPTION_MESSAGE = 
                "An entry already exists with this Application Name and Username!";

            if (!IsAppDuplicate(appName, username))
            {
                XmlDocument xmlDoc = new XmlDocument();
                string passwordsDataPath = FileUtils.PasswordsDataFullPath;

                xmlDoc.Load(passwordsDataPath);

                // Create the new App Node
                XmlNode newAppNode = xmlDoc.CreateNode(XmlNodeType.Element, APP_NODE_NAME, null);

                // Add the app name to the new App Node
                XmlAttribute appNameAttribute = xmlDoc.CreateAttribute(APP_NAME_ATTRIBUTE);
                appNameAttribute.Value = appName;
                newAppNode.Attributes.Append(appNameAttribute);

                // Add the username node to the new App Node
                XmlNode usernameNode = xmlDoc.CreateNode(XmlNodeType.Element, USERNAME_NODE_NAME, null);
                usernameNode.InnerXml = username;
                newAppNode.AppendChild(usernameNode);

                // Add the password node to the new App Node
                XmlNode passwordNode = xmlDoc.CreateNode(XmlNodeType.Element, PASSWORD_NODE_NAME, null);
                passwordNode.InnerXml = password;
                newAppNode.AppendChild(passwordNode);

                // Add the complete new App Node to the Root Node of the document
                xmlDoc.FirstChild.AppendChild(newAppNode);

                xmlDoc.Save(passwordsDataPath);
            }
            else
            {
                throw new ArgumentException(DUPLICATE_APP_EXCEPTION_MESSAGE);
            }
        }

        public static void RemoveAppFromPasswordsData(string appName, string username)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string passwordsDataPath = FileUtils.PasswordsDataFullPath;

            xmlDoc.Load(passwordsDataPath);

            foreach (XmlNode appNode in xmlDoc.FirstChild.ChildNodes)
            {
                if (IsRequiredNode(appNode, appName, username))
                {
                    xmlDoc.FirstChild.RemoveChild(appNode);
                    xmlDoc.Save(passwordsDataPath);
                }
            }
        }

        public static void UpdateAppInPasswordsData(
            string oldAppName, string oldUsername, string appName, string username, string password)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string passwordsDataPath = FileUtils.PasswordsDataFullPath;

            xmlDoc.Load(passwordsDataPath);

            foreach (XmlNode appNode in xmlDoc.FirstChild.ChildNodes)
            {
                if (IsRequiredNode(appNode, oldAppName, oldUsername))
                {
                    if (appNode.Name.Equals(APP_NODE_NAME))
                    {
                        foreach (XmlNode childNode in appNode.ChildNodes)
                        {
                            if (childNode.Name.Equals(USERNAME_NODE_NAME))
                            {
                                childNode.InnerXml = username;
                            }
                            else if (childNode.Name.Equals(PASSWORD_NODE_NAME))
                            {
                                childNode.InnerXml = password;
                            }
                        }

                        appNode.Attributes[APP_NAME_ATTRIBUTE].Value = appName;
                    }
                }
            }

            xmlDoc.Save(passwordsDataPath);
        }

        public static void MoveAppDataUp(string appName, string username)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string passwordsDataPath = FileUtils.PasswordsDataFullPath;

            xmlDoc.Load(passwordsDataPath);

            foreach (XmlNode appNode in xmlDoc.FirstChild.ChildNodes)
            {
                if (IsRequiredNode(appNode, appName, username) && appNode.Name.Equals(APP_NODE_NAME))
                {
                    XmlNode appNodeCopy = appNode.CloneNode(true);
                    appNode.ParentNode.InsertBefore(appNodeCopy, appNode.PreviousSibling);
                    appNode.ParentNode.RemoveChild(appNode);
                }
            }

            xmlDoc.Save(passwordsDataPath);
        }

        public static void MoveAppDataDown(string appName, string username)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string passwordsDataPath = FileUtils.PasswordsDataFullPath;

            xmlDoc.Load(passwordsDataPath);

            foreach (XmlNode appNode in xmlDoc.FirstChild.ChildNodes)
            {
                if (IsRequiredNode(appNode, appName, username) && appNode.Name.Equals(APP_NODE_NAME))
                {
                    XmlNode appNodeCopy = appNode.CloneNode(true);
                    appNode.ParentNode.InsertAfter(appNodeCopy, appNode.NextSibling);
                    appNode.ParentNode.RemoveChild(appNode);
                }
            }

            xmlDoc.Save(passwordsDataPath);
        }

        private static Dictionary<string, string> GetAppDetailDictionaryFromXml(string appName, string username)
        {
            Dictionary<string, string> appDetails = new Dictionary<string, string>();
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(FileUtils.PasswordsDataFullPath);

            foreach (XmlNode appNode in xmlDoc.FirstChild.ChildNodes)
            {
                if (IsRequiredNode(appNode, appName, username))
                {
                    string currentAppName = appNode.Attributes[APP_NAME_ATTRIBUTE].Value;

                    if (appNode.Name.Equals(APP_NODE_NAME))
                    {
                        foreach (XmlNode childNode in appNode.ChildNodes)
                        {
                            if (childNode.Name.Equals(USERNAME_NODE_NAME))
                            {
                                appDetails.Add(UsernameKey, childNode.InnerXml);
                            }
                            else if (childNode.Name.Equals(PASSWORD_NODE_NAME))
                            {
                                appDetails.Add(PasswordKey, childNode.InnerXml);
                            }
                        }

                        appDetails.Add(AppNameKey, currentAppName);
                    }
                }
            }

            return appDetails;
        }

        private static Dictionary<string, string> GetAppDetailDictionaryFromXml(string appName)
        {
            Dictionary<string, string> appDetails = new Dictionary<string, string>();
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(FileUtils.PasswordsDataFullPath);

            foreach (XmlNode appNode in xmlDoc.FirstChild.ChildNodes)
            {
                string currentAppName = appNode.Attributes[APP_NAME_ATTRIBUTE].Value;

                if (appNode.Name.Equals(APP_NODE_NAME) && currentAppName.Equals(appName))
                {
                    appDetails.Add(AppNameKey, currentAppName);

                    foreach (XmlNode childNode in appNode.ChildNodes)
                    {
                        if (childNode.Name.Equals(USERNAME_NODE_NAME))
                        {
                            appDetails.Add(UsernameKey, childNode.InnerXml);
                        }
                        else if (childNode.Name.Equals(PASSWORD_NODE_NAME))
                        {
                            appDetails.Add(PasswordKey, childNode.InnerXml);
                        }
                    }
                }

                if (appDetails.Count >= 3)
                {
                    break;
                }
            }

            return appDetails;
        }

        private static bool IsRequiredNode(XmlNode node, string appName, string username)
        {
            bool isRequiredNode = false;

            if (node.Attributes[APP_NAME_ATTRIBUTE].Value == appName)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name.Equals(USERNAME_NODE_NAME) && childNode.InnerXml.Equals(username))
                    {
                        isRequiredNode = true;
                    }
                }
            }

            return isRequiredNode;
        }

    }
}
