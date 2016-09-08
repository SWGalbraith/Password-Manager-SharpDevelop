using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PasswordManager.ImportExport;

namespace PasswordManager.UI
{
    internal class PasswordManagerControl
    {
        internal void PopulatePasswordList(ListView passwordList)
        {
            passwordList.Clear();

            passwordList.Columns.Add("Application", 160, HorizontalAlignment.Left);
            passwordList.Columns.Add("Username", 160, HorizontalAlignment.Left);
            passwordList.Columns.Add("Password", 160, HorizontalAlignment.Left);

            List<Dictionary<string, string>> passwordDataList = 
                PasswordsDataHelper.GetAllAppDetailsDictionaryList();

            int x = 0;

            foreach (Dictionary<string, string> passwordDataEntry in passwordDataList)
            {
                passwordList.Items.Add(passwordDataEntry[PasswordsDataHelper.AppNameKey]);
                passwordList.Items[x].SubItems.Add(passwordDataEntry[PasswordsDataHelper.UsernameKey]);
                passwordList.Items[x].SubItems.Add(GetPasswordCharacters(passwordDataEntry[PasswordsDataHelper.PasswordKey]));
                x++;
            }
        }

        internal void DeletePassword(string appName, string username)
        {
            PasswordsDataHelper.RemoveAppFromPasswordsData(appName, username);
        }

        internal void CopyPasswordToClipboard(string appName, string username)
        {
            Clipboard.SetText(Crypto.Decrypt(
                PasswordsDataHelper.GetAppDetailsDictionary(appName, username)[PasswordsDataHelper.PasswordKey]));
        }

        internal void CopyUsernameToClipboard(string username)
        {
            Clipboard.SetText(username);
        }

        internal void ImportPasswordsFile(string filepath)
        {
            try
            {
                if (ImportHelper.IsFileValidForImport(filepath))
                {
                    ImportHelper.ImportPasswordsFromFile(filepath);
                }
                else
                {
                    MessageBox.Show("Please select a valid Password Manager import file!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing data! Data may not have imported, or have partially imported!" 
                    + Environment.NewLine + "Error was: " + Environment.NewLine 
                    + Environment.NewLine + ex.Message);
            }
        }

        internal void ExportPasswordsFile(string filepath)
        {
            ExportHelper.ExportPasswordsToFile(filepath, true);
        }

        internal void MovePasswordDataUp(string appName, string username)
        {
            PasswordsDataHelper.MoveAppDataUp(appName, username);
        }

        internal void MovePasswordDataDown(string appName, string username)
        {
            PasswordsDataHelper.MoveAppDataDown(appName, username);
        }

        private string GetPasswordCharacters(string encryptedPassword)
        {
            const string PASSWORD_CHAR = "*";

            string passwordCharacters = null;
            int x = 0;

            int passwordLength = Crypto.Decrypt(encryptedPassword).Length;

            while (x < passwordLength)
            {
                passwordCharacters += PASSWORD_CHAR;
                x++;
            }

            return passwordCharacters;
        }
    }
}
