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
    public partial class EditPassword : Form
    {
        private EditPasswordControl control;
        private string oldAppName;
        private string oldUsername;

        public EditPassword(string appName, string username)
        {
            InitializeComponent();
            control = new EditPasswordControl();

            this.ShowInTaskbar = false;

            txtAppName.Text = appName;
            txtUsername.Text = username;

            oldAppName = appName;
            oldUsername = username;

            btnUpdate.Hide();
            lblConfirmPassword.Hide();
            txtConfirmPassword.Hide();
            btnViewConfirmPassword.Hide();

            btnViewPassword.MouseDown += btnViewPassword_MouseDown;
            btnViewPassword.MouseUp += btnViewPassword_MouseUp;
            btnViewConfirmPassword.MouseDown += btnViewConfirmPassword_MouseDown;
            btnViewConfirmPassword.MouseUp += btnViewConfirmPassword_MouseUp;
        }

        private void btnViewConfirmPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void btnViewConfirmPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = false;
        }

        private void btnViewPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnViewPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPassword.Text))
            {
                lblConfirmPassword.Show();
                txtConfirmPassword.Show();
                btnViewConfirmPassword.Show();
            }
            else
            {
                lblConfirmPassword.Hide();
                txtConfirmPassword.Hide();
                btnViewConfirmPassword.Hide();
            }

            AreFieldsComplete();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            AreFieldsComplete();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            AreFieldsComplete();
        }

        private void txtAppName_TextChanged(object sender, EventArgs e)
        {
            AreFieldsComplete();
        }

        private void AreFieldsComplete()
        {
            if (String.IsNullOrEmpty(txtAppName.Text)
                || String.IsNullOrEmpty(txtUsername.Text)
                || String.IsNullOrEmpty(txtUsername.Text)
                || String.IsNullOrEmpty(txtConfirmPassword.Text)
                || (!txtConfirmPassword.Text.Equals(txtPassword.Text)))
            {
                btnUpdate.Hide();
            }
            else
            {
                btnUpdate.Show();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                control.UpdatePasswordDetails(
                    oldAppName, oldUsername, txtAppName.Text, txtUsername.Text, txtConfirmPassword.Text);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem updating details! Problem was: " + Environment.NewLine + ex.Message);
            }
        }
    }
}
