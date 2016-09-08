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
    public partial class AddPassword : Form
    {
        private AddPasswordControl control;

        public AddPassword()
        {
            InitializeComponent();
            control = new AddPasswordControl();

            this.ShowInTaskbar = false;

            btnAdd.Hide();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                control.AddNewPassword(txtAppName.Text, txtUsername.Text, txtPassword.Text);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem adding password! Problem was: " + Environment.NewLine + ex.Message);
            }
        }

        private void AreFieldsComplete()
        {
            if (String.IsNullOrEmpty(txtAppName.Text)
                || String.IsNullOrEmpty(txtUsername.Text)
                || String.IsNullOrEmpty(txtPassword.Text)
                || (!txtConfirmPassword.Text.Equals(txtPassword.Text)))
            {
                btnAdd.Hide();
            }
            else
            {
                btnAdd.Show();
            }
        }

        private void txtAppName_TextChanged(object sender, EventArgs e)
        {
            AreFieldsComplete();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            AreFieldsComplete();
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
    }
}
