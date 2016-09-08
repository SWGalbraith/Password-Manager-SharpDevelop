using PasswordManager.CommonUtils;
using PasswordManager.Encryption;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PasswordManager.UI
{
    public partial class PasswordManager : Form
    {
        private PasswordManagerControl control;
        private bool unlockApp = false;
        private bool shouldFormClose = false;
        private int minimiseCount = 0;

        public PasswordManager()
        {
            InitializeComponent();
            
            Icon icon = new Icon(FileUtils.GetApplicationIconPath());
            this.Icon = icon;

            control = new PasswordManagerControl();
            control.PopulatePasswordList(lstPasswords);

            icoSystemTray.Visible = true;
            icoSystemTray.MouseDoubleClick += icoSystemTray_MouseDoubleClick;

            itemOpen.Click += itemOpen_Click;
            itemExit.Click += itemExit_Click;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }

            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            bool top = TopMost;
            TopMost = true;
            TopMost = top;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPassword addPasswordForm = new AddPassword();
            addPasswordForm.ShowDialog();
            control.PopulatePasswordList(lstPasswords);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            const string EDIT_PASSWORD_MESSAGE = "Enter your PasswordManager password to edit this item:";

            if (lstPasswords.SelectedItems.Count > 0)
            {
                if (CheckPassword(new PasswordCheck(EDIT_PASSWORD_MESSAGE)))
                {
                    EditPassword editPasswordForm =
                        new EditPassword(lstPasswords.SelectedItems[0].Text, lstPasswords.SelectedItems[0].SubItems[1].Text);
                    editPasswordForm.ShowDialog();
                    control.PopulatePasswordList(lstPasswords);
                }
            }
            else
            {
                MessageBox.Show("Please choose an item to edit!");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            const string REMOVE_PASSWORD_MESSAGE = "Enter your PasswordManager password to remove this item:";

            if (lstPasswords.SelectedItems.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to remove this item?", 
                    "Confirm Removal", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (CheckPassword(new PasswordCheck(REMOVE_PASSWORD_MESSAGE)))
                    {
                        try
                        {
                            control.DeletePassword(
                                lstPasswords.SelectedItems[0].Text, lstPasswords.SelectedItems[0].SubItems[1].Text);
                            control.PopulatePasswordList(lstPasswords);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Problem removing item! Problem was: " + Environment.NewLine + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose an item to remove!");
            }
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            const string USER_DATA_ACCESS_MESSAGE = "Enter your PasswordManager password to edit User Data:";

            if (CheckPassword(new PasswordCheck(USER_DATA_ACCESS_MESSAGE)))
            {
                UserDataManager userDataManager = new UserDataManager();
                userDataManager.ShowDialog();
            }
        }

        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
            const string COPY_PASSWORD_MESSAGE = "Enter your PasswordManager password to copy this item:";

            if (lstPasswords.SelectedItems.Count > 0)
            {
                if (CheckPassword(new PasswordCheck(COPY_PASSWORD_MESSAGE)))
                {
                   try
                   {
                       control.CopyPasswordToClipboard(
                               lstPasswords.SelectedItems[0].Text, lstPasswords.SelectedItems[0].SubItems[1].Text);
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show("Problem decrypting password!" + Environment.NewLine
                       + "Have the PasswordsData.xml or PasswordManager.UI.config files been manually edited?"
                       + Environment.NewLine + Environment.NewLine
                       + "Problem was: " + Environment.NewLine + ex.Message);
                   }
                }
            }
            else
            {
                MessageBox.Show("Please select an item!");
            }
        }

        private void btnCopyUsername_Click(object sender, EventArgs e)
        {
            if (lstPasswords.SelectedItems.Count > 0)
            {
                control.CopyUsernameToClipboard(lstPasswords.SelectedItems[0].SubItems[1].Text);
            }
            else
            {
                MessageBox.Show("Please select an item!");
            }
        }

        private void btnImportPasswords_Click(object sender, EventArgs e)
        {
            const string IMPORT_PASSWORDS_MESSAGE = "Enter your Password Manager password to"
                + "\nimport passwords from an export text file:";

            if (CheckPassword(new PasswordCheck(IMPORT_PASSWORDS_MESSAGE)))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Choose a Passwords File";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    control.ImportPasswordsFile(openFileDialog.FileName);
                    control.PopulatePasswordList(lstPasswords);
                }
            }
        }

        private void btnExportPasswords_Click(object sender, EventArgs e)
        {
            const string EXPORT_PASSWORDS_MESSAGE = "Enter your Password Manager password to" 
                + "\nexport your passwords as a text file:";

            if (CheckPassword(new PasswordCheck(EXPORT_PASSWORDS_MESSAGE)))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    control.ExportPasswordsFile(saveFileDialog.FileName);
                }
            }
        }

        private void chkUnlock_CheckedChanged(object sender, EventArgs e)
        {
            const string UNLOCK_APP_MESSAGE = "Checking this box will suppress further Password Checks."
                + "\nEnter your PasswordManager password to continue:";

            if (chkUnlock.Checked)
            {
                if (CheckPassword(new PasswordCheck(UNLOCK_APP_MESSAGE)))
                {
                    unlockApp = true;
                }
                else
                {
                    chkUnlock.Checked = false;
                }
            }
            else
            {
                unlockApp = false;
            }
        }

        private void icoSystemTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void itemExit_Click(object sender, EventArgs e)
        {
            shouldFormClose = true;
            this.Close();
        }

        private void itemOpen_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private bool CheckPassword(PasswordCheck passwordCheck)
        {
            if (!unlockApp)
            {
                passwordCheck.ShowDialog();

                return passwordCheck.Confirm;
            }
            else
            {
                return true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown || shouldFormClose)
            {
                return;
            }
            else
            {
                e.Cancel = true;

                chkUnlock.Checked = false;

                this.WindowState = FormWindowState.Minimized;
                icoSystemTray.Visible = true;
                this.ShowInTaskbar = false;

                if (minimiseCount < 1)
                {
                    icoSystemTray.BalloonTipTitle = "Password Manager";
                    icoSystemTray.BalloonTipText = "Password Manager is still running - click here to Open or Exit";
                    icoSystemTray.ShowBalloonTip(3000);
                }

                minimiseCount += 1;
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstPasswords.SelectedItems.Count == 1)
            {
                try
                {
                    string appName = lstPasswords.SelectedItems[0].Text;
                    string username = lstPasswords.SelectedItems[0].SubItems[1].Text;

                    control.MovePasswordDataUp(appName, username);
                    control.PopulatePasswordList(lstPasswords);
                    SelectListViewItem(appName, username);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem moving password data!"
                    + Environment.NewLine + Environment.NewLine
                    + "Problem was: " + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select one item to move!");
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstPasswords.SelectedItems.Count == 1)
            {
                try
                {
                    string appName = lstPasswords.SelectedItems[0].Text;
                    string username = lstPasswords.SelectedItems[0].SubItems[1].Text;

                    control.MovePasswordDataDown(appName, username);
                    control.PopulatePasswordList(lstPasswords);
                    SelectListViewItem(appName, username);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem moving password data!"
                    + Environment.NewLine + Environment.NewLine
                    + "Problem was: " + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select one item to move!");
            }
        }

        private void SelectListViewItem(string appName, string username)
        {
            foreach (ListViewItem item in lstPasswords.Items)
            {
                if (item.Text == appName && item.SubItems[1].Text == username)
                {
                    item.Selected = true;
                    item.ListView.Select();
                }
            }
        }
    }
}
