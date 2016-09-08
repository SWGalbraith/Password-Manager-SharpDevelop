using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using PasswordManager.Encryption;
using PasswordManager.CommonUtils;

namespace PasswordManager.ImportExport
{
    public static class ExportHelper
    {
        private const string DEFAULT_EXPORT_FILES_FOLDER_NAME = "\\ExportedPasswordFiles";
        private const string DEFAULT_EXPORT_PASSWORDS_FILENAME = "\\PasswordManager_PasswordsExport_{0}.txt";

        private static string defaultFolderPath = 
            FileUtils.GetApplicationInstallPath() + DEFAULT_EXPORT_FILES_FOLDER_NAME;

        public static void ExportPasswordsToFile(string filepath, bool shouldOpenFile)
        {
            const string TEXT_FILE_EXTENSION = ".txt";

            if (String.IsNullOrEmpty(filepath))
            {
                filepath = GetFullFilename(filepath);

                if (!Directory.Exists(defaultFolderPath))
                {
                    Directory.CreateDirectory(defaultFolderPath);
                }
            }

            string fileContent = GetFileContent();

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            if (!filepath.EndsWith(TEXT_FILE_EXTENSION))
            {
                filepath += TEXT_FILE_EXTENSION;
            }

            File.AppendAllText(filepath, fileContent);

            if (shouldOpenFile)
            {
                Process.Start(filepath);
            }
        }

        private static string GetFullFilename(string filepath)
        {
            string timestamp = DateTime.Now.Minute.ToString()
                + DateTime.Now.Hour.ToString()
                + "_" + DateTime.Now.Day.ToString()
                + "-" + DateTime.Now.Month.ToString()
                + "-" + DateTime.Now.Year.ToString();

            if (String.IsNullOrEmpty(filepath))
            {
                return defaultFolderPath + String.Format(DEFAULT_EXPORT_PASSWORDS_FILENAME, timestamp);
            }
            else
            {
                return filepath + String.Format(DEFAULT_EXPORT_PASSWORDS_FILENAME, timestamp);
            }
        }

        private static string GetFileContent()
        {
            string content = String.Empty;

            string separator = "********************";
            string newLine = Environment.NewLine;
            string appNameHeading = ImportExportConstants.AppNameIdentifer;
            string usernameHeading = ImportExportConstants.UsernameIdentifer;
            string passwordHeading = ImportExportConstants.PasswordIdentifer;

            content += "WARNING! THE PASSWORDS AND USER INFORMATION IN THIS FILE ARE UNENCRYPTED, AND CARE MUST BE TAKEN" 
                + " OVER THE USE AND STORAGE OF THIS FILE!" + newLine + newLine;

            foreach (Dictionary<string, string> appDefinitionDictionary 
                in PasswordsDataHelper.GetAllAppDetailsDictionaryList())
            {
                string appName = appDefinitionDictionary[PasswordsDataHelper.AppNameKey];
                string username = appDefinitionDictionary[PasswordsDataHelper.UsernameKey];
                string decryptedPassword = 
                    Crypto.Decrypt(appDefinitionDictionary[PasswordsDataHelper.PasswordKey]);

                content += separator + newLine
                    + appNameHeading + appName + newLine
                    + usernameHeading + username + newLine
                    + passwordHeading + decryptedPassword + newLine
                    + separator + newLine + newLine;
            }

            return content;
        }
    }
}
