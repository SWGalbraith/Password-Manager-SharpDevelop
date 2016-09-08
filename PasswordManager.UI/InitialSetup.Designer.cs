namespace PasswordManager.UI
{
    partial class InitialSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome1 = new System.Windows.Forms.Label();
            this.lblWelcome2 = new System.Windows.Forms.Label();
            this.lblWelcome3 = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblValidation = new System.Windows.Forms.Label();
            this.lblValid = new System.Windows.Forms.Label();
            this.lblInvalid = new System.Windows.Forms.Label();
            this.lblWelcome4 = new System.Windows.Forms.Label();
            this.btnViewPassword = new System.Windows.Forms.Button();
            this.btnViewConfirmPassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome1
            // 
            this.lblWelcome1.AutoSize = true;
            this.lblWelcome1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome1.Location = new System.Drawing.Point(178, 19);
            this.lblWelcome1.Name = "lblWelcome1";
            this.lblWelcome1.Size = new System.Drawing.Size(189, 13);
            this.lblWelcome1.TabIndex = 3;
            this.lblWelcome1.Text = "Welcome to Password Manager!";
            // 
            // lblWelcome2
            // 
            this.lblWelcome2.AutoSize = true;
            this.lblWelcome2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome2.Location = new System.Drawing.Point(13, 45);
            this.lblWelcome2.Name = "lblWelcome2";
            this.lblWelcome2.Size = new System.Drawing.Size(431, 13);
            this.lblWelcome2.TabIndex = 4;
            this.lblWelcome2.Text = "This application can be used to securely save Usernames and Passwords for applica" +
                "tions.";
            // 
            // lblWelcome3
            // 
            this.lblWelcome3.AutoSize = true;
            this.lblWelcome3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome3.Location = new System.Drawing.Point(13, 67);
            this.lblWelcome3.Name = "lblWelcome3";
            this.lblWelcome3.Size = new System.Drawing.Size(459, 13);
            this.lblWelcome3.TabIndex = 5;
            this.lblWelcome3.Text = "Each Application Name and associated Login Information is stored in an encrypted " +
                "AppData file.";
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(214, 202);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(116, 29);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(16, 136);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(156, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(12, 120);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(303, 13);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Please choose a password for this application (keep this safe!):";
            // 
            // lblValidation
            // 
            this.lblValidation.AutoSize = true;
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidation.Location = new System.Drawing.Point(248, 139);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(293, 13);
            this.lblValidation.TabIndex = 10;
            this.lblValidation.Text = "(Must contain alphanumerics and symbols, min. 8 characters)";
            // 
            // lblValid
            // 
            this.lblValid.AutoSize = true;
            this.lblValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValid.ForeColor = System.Drawing.Color.Green;
            this.lblValid.Location = new System.Drawing.Point(177, 136);
            this.lblValid.Name = "lblValid";
            this.lblValid.Size = new System.Drawing.Size(21, 20);
            this.lblValid.TabIndex = 11;
            this.lblValid.Text = "O";
            // 
            // lblInvalid
            // 
            this.lblInvalid.AutoSize = true;
            this.lblInvalid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalid.ForeColor = System.Drawing.Color.Firebrick;
            this.lblInvalid.Location = new System.Drawing.Point(178, 136);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(20, 20);
            this.lblInvalid.TabIndex = 12;
            this.lblInvalid.Text = "X";
            // 
            // lblWelcome4
            // 
            this.lblWelcome4.AutoSize = true;
            this.lblWelcome4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome4.Location = new System.Drawing.Point(12, 89);
            this.lblWelcome4.Name = "lblWelcome4";
            this.lblWelcome4.Size = new System.Drawing.Size(441, 13);
            this.lblWelcome4.TabIndex = 13;
            this.lblWelcome4.Text = "The key used for the encryption is generated randomly at first use, and stored in" +
                " a config file.";
            // 
            // btnViewPassword
            // 
            this.btnViewPassword.Location = new System.Drawing.Point(204, 136);
            this.btnViewPassword.Name = "btnViewPassword";
            this.btnViewPassword.Size = new System.Drawing.Size(38, 20);
            this.btnViewPassword.TabIndex = 14;
            this.btnViewPassword.Text = "View";
            this.btnViewPassword.UseVisualStyleBackColor = true;
            // 
            // btnViewConfirmPassword
            // 
            this.btnViewConfirmPassword.Location = new System.Drawing.Point(204, 176);
            this.btnViewConfirmPassword.Name = "btnViewConfirmPassword";
            this.btnViewConfirmPassword.Size = new System.Drawing.Size(38, 20);
            this.btnViewConfirmPassword.TabIndex = 16;
            this.btnViewConfirmPassword.Text = "View";
            this.btnViewConfirmPassword.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(16, 176);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(156, 20);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(13, 160);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(140, 13);
            this.lblConfirmPassword.TabIndex = 17;
            this.lblConfirmPassword.Text = "Now confirm your password:";
            // 
            // InitialSetup
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 243);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.btnViewConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnViewPassword);
            this.Controls.Add(this.lblWelcome4);
            this.Controls.Add(this.lblInvalid);
            this.Controls.Add(this.lblValid);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblWelcome3);
            this.Controls.Add(this.lblWelcome2);
            this.Controls.Add(this.lblWelcome1);
            this.MaximizeBox = false;
            this.Name = "InitialSetup";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager Initial Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome1;
        private System.Windows.Forms.Label lblWelcome2;
        private System.Windows.Forms.Label lblWelcome3;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.Label lblValid;
        private System.Windows.Forms.Label lblInvalid;
        private System.Windows.Forms.Label lblWelcome4;
        private System.Windows.Forms.Button btnViewPassword;
        private System.Windows.Forms.Button btnViewConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
    }
}