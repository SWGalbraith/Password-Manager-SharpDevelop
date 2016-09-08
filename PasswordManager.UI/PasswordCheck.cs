using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager.UI
{
    public partial class PasswordCheck : Form
    {
        private PasswordCheckControl control;
        private const string DEFAULT_MESSAGE = "Enter your PasswordManager password:";

        public bool Confirm { get; set; }

        public PasswordCheck() : this(DEFAULT_MESSAGE)
        {
        }

        public PasswordCheck(string message)
        {
            InitializeComponent();

            this.ShowInTaskbar = false;

            control = new PasswordCheckControl();
            lblMessage.Text = message;
            Confirm = false;

            btnContinue.Hide();

            btnView.MouseDown += btnView_MouseDown;
            btnView.MouseUp += btnView_MouseUp;
        }

        private void btnView_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnView_MouseDown(object sender, MouseEventArgs e)
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
                btnContinue.Show();
            }
            else
            {
                btnContinue.Hide();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (control.CheckPassword(txtPassword.Text))
                {
                    Confirm = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The password was incorrect - please try again!");
                    txtPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem validating password!" + Environment.NewLine
                    + "Has the PasswordManager.UI.config file been manually changed?"
                    + Environment.NewLine + Environment.NewLine
                    + "Problem was: " + Environment.NewLine + ex.Message);
            }
        }

    }
}
