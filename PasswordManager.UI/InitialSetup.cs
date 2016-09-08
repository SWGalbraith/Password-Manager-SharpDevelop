using PasswordManager.CommonUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PasswordManager.UI
{
    public partial class InitialSetup : Form
    {
        private InitialSetupControl control;

        public bool WasFormClosed { get; set; }

        public InitialSetup()
        {            
            InitializeComponent();
            control = new InitialSetupControl();
            
            Icon icon = new Icon(FileUtils.GetApplicationIconPath());
            this.Icon = icon;

            lblConfirmPassword.Hide();
            txtConfirmPassword.Hide();
            btnViewConfirmPassword.Hide();
            btnContinue.Hide();
            lblValid.Hide();
            lblInvalid.Hide();

            btnViewPassword.MouseDown += btnViewPassword_MouseDown;
            btnViewPassword.MouseUp += btnViewPassword_MouseUp;
            btnViewConfirmPassword.MouseDown += btnViewConfirmPassword_MouseDown;
            btnViewConfirmPassword.MouseUp += btnViewConfirmPassword_MouseUp;

            this.FormClosed += InitialSetup_FormClosed;
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
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            bool top = TopMost;
            TopMost = true;
            TopMost = top;
        }

        private void InitialSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            WasFormClosed = true;
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

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                control.CreateDataFiles(txtPassword.Text);
                this.Close();
                WasFormClosed = false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                btnContinue.Hide();
            }
            else
            {
                btnContinue.Show();
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
