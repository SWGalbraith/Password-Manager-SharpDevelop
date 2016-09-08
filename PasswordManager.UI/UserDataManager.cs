using PasswordManager.CommonUtils;
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
    public partial class UserDataManager : Form
    {
        private UserDataManagerControl control;

        public UserDataManager()
        {
            InitializeComponent();
            control = new UserDataManagerControl();

            this.ShowInTaskbar = false;

            lblValid.Hide();
            lblInvalid.Hide();
            btnUpdate.Hide();

            lblConfirmPassword.Hide();
            txtConfirmPassword.Hide();
            btnViewConfirmPassword.Hide();

            btnViewPassword.MouseDown += btnViewPassword_MouseDown;
            btnViewPassword.MouseUp += btnViewPassword_MouseUp;

            btnViewConfirmPassword.MouseDown += btnViewConfirmPassword_MouseDown;
            btnViewConfirmPassword.MouseUp += btnViewConfirmPassword_MouseUp;
        }

        private void btnViewPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnViewPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnViewConfirmPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void btnViewConfirmPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to update your details?", 
                    "Confirm Update", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtPassword.Text) && control.IsUserPasswordUpdated(txtPassword.Text))
                    {
                        control.UpdateUserPassword(txtPassword.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem updating password! Problem was: " + Environment.NewLine + ex.Message);
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPassword.Text))
            {
                if (control.ValidatePassword(txtPassword.Text))
                {
                    ShowConfirmationFields();
                }
                else
                {
                    HideConfirmationFields();
                }
            }
            else
            {
                HideConfirmationFields();
            }

            AreFieldsComplete();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            AreFieldsComplete();
        }

        private void AreFieldsComplete()
        {
            if (String.IsNullOrEmpty(txtPassword.Text)
                || String.IsNullOrEmpty(txtConfirmPassword.Text)
                || (!txtConfirmPassword.Text.Equals(txtPassword.Text))
                || (!control.ValidatePassword(txtPassword.Text)))
            {
                btnUpdate.Hide();
            }
            else
            {
                btnUpdate.Show();
            }
        }

        private void ShowConfirmationFields()
        {
            lblValid.Show();
            lblInvalid.Hide();

            lblConfirmPassword.Show();
            txtConfirmPassword.Show();
            btnViewConfirmPassword.Show();
        }

        private void HideConfirmationFields()
        {
            lblInvalid.Show();
            lblValid.Hide();

            lblConfirmPassword.Hide();
            txtConfirmPassword.Hide();
            txtConfirmPassword.Clear();
            btnViewConfirmPassword.Hide();
        }
    }
}
