using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PasswordManager.CommonUtils;
using PasswordManager.Encryption;

namespace PasswordManager.ImportExport
{
    public static class ImportHelper
    {
        public static void ImportPasswordsFromFile(string filepath)
        {
            if (File.Exists(filepath) && IsFileValidForImport(filepath))
            {
                List<Dictionary<string, string>> importedAppDetailsDictionaryList = 
                    GetImportedAppDetailsDictionaryList(filepath);

                foreach (Dictionary<string, string> importedAppDetailDictionary
                    in importedAppDetailsDictionaryList)
                {
                    try
                    {
                        string appName = importedAppDetailDictionary[PasswordsDataHelper.AppNameKey];
                        string username = importedAppDetailDictionary[PasswordsDataHelper.UsernameKey];
                        string encryptedPassword = 
                            Crypto.Encrypt(importedAppDetailDictionary[PasswordsDataHelper.PasswordKey]);

                        PasswordsDataHelper.AddAppToPasswordsData(appName, username, encryptedPassword);
                    }
                    catch (ArgumentException)
                    {
                        // Duplicate details; continue processing and skip the current entry
                        continue;
                    }
                }
            }
        }

        public static bool IsFileValidForImport(string filepath)
        {
            string fileContents = File.ReadAllText(filepath);

            if (fileContents.Contains(ImportExportConstants.AppNameIdentifer)
                && fileContents.Contains(ImportExportConstants.UsernameIdentifer)
                && fileContents.Contains(ImportExportConstants.PasswordIdentifer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static List<Dictionary<string, string>> GetImportedAppDetailsDictionaryList(string filepath)
        {
            List<Dictionary<string, string>> importedAppDetailsDictionaryList =
                new List<Dictionary<string, string>>();

            List<string> lines = File.ReadAllLines(filepath).ToList();

            for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
            {
                if (lines[lineIndex].StartsWith(ImportExportConstants.AppNameIdentifer)
                        && lines[lineIndex + 1].StartsWith(ImportExportConstants.UsernameIdentifer)
                        && lines[lineIndex + 2].StartsWith(ImportExportConstants.PasswordIdentifer))
                {
                    Dictionary<string, string> importedAppDetailsDictionary =
                        new Dictionary<string, string>();

                    string appName = GetValueFromLine(lines[lineIndex]);
                    string username = GetValueFromLine(lines[lineIndex + 1]);
                    string password = GetValueFromLine(lines[lineIndex + 2]);

                    importedAppDetailsDictionary.Add(PasswordsDataHelper.AppNameKey, appName);
                    importedAppDetailsDictionary.Add(PasswordsDataHelper.UsernameKey, username);
                    importedAppDetailsDictionary.Add(PasswordsDataHelper.PasswordKey, password);

                    importedAppDetailsDictionaryList.Add(importedAppDetailsDictionary);

                    lineIndex = lineIndex + 2;
                }
            }

            return importedAppDetailsDictionaryList;
        }

        private static string GetValueFromLine(string line)
        {
            string value = null;

            string titleEnd = ImportExportConstants.TitleEndIdentifer;
            int titleEndLength = titleEnd.Length;

            if (line.StartsWith(ImportExportConstants.AppNameIdentifer)
                || line.StartsWith(ImportExportConstants.UsernameIdentifer)
                || line.StartsWith(ImportExportConstants.PasswordIdentifer))
            {
                value = line.Substring(line.IndexOf(titleEnd) + titleEndLength); 
            }

            return value;
        }
    }
}
