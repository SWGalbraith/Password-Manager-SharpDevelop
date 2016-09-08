namespace PasswordManager.UI
{
    partial class PasswordManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordManager));
            this.lstPasswords = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUserManager = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCopyPassword = new System.Windows.Forms.Button();
            this.btnCopyUsername = new System.Windows.Forms.Button();
            this.chkUnlock = new System.Windows.Forms.CheckBox();
            this.icoSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImportPasswords = new System.Windows.Forms.Button();
            this.btnExportPasswords = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.menuSystemTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPasswords
            // 
            this.lstPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPasswords.BackColor = System.Drawing.SystemColors.Window;
            this.lstPasswords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstPasswords.FullRowSelect = true;
            this.lstPasswords.Location = new System.Drawing.Point(13, 46);
            this.lstPasswords.MultiSelect = false;
            this.lstPasswords.Name = "lstPasswords";
            this.lstPasswords.Size = new System.Drawing.Size(485, 362);
            this.lstPasswords.TabIndex = 1;
            this.lstPasswords.UseCompatibleStateImageBehavior = false;
            this.lstPasswords.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Application Name";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Username";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Password";
            this.columnHeader3.Width = 160;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(13, 414);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 39);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.Location = new System.Drawing.Point(209, 414);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 39);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(394, 414);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(105, 39);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUserManager
            // 
            this.btnUserManager.Location = new System.Drawing.Point(12, 12);
            this.btnUserManager.Name = "btnUserManager";
            this.btnUserManager.Size = new System.Drawing.Size(105, 28);
            this.btnUserManager.TabIndex = 5;
            this.btnUserManager.Text = "Update User Data";
            this.btnUserManager.UseVisualStyleBackColor = true;
            this.btnUserManager.Click += new System.EventHandler(this.btnUserManager_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(206, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(116, 17);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Passwords List";
            // 
            // btnCopyPassword
            // 
            this.btnCopyPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCopyPassword.Location = new System.Drawing.Point(504, 228);
            this.btnCopyPassword.Name = "btnCopyPassword";
            this.btnCopyPassword.Size = new System.Drawing.Size(76, 55);
            this.btnCopyPassword.TabIndex = 7;
            this.btnCopyPassword.Text = "Copy Decrypted Password";
            this.btnCopyPassword.UseVisualStyleBackColor = true;
            this.btnCopyPassword.Click += new System.EventHandler(this.btnCopyPassword_Click);
            // 
            // btnCopyUsername
            // 
            this.btnCopyUsername.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCopyUsername.Location = new System.Drawing.Point(504, 171);
            this.btnCopyUsername.Name = "btnCopyUsername";
            this.btnCopyUsername.Size = new System.Drawing.Size(76, 51);
            this.btnCopyUsername.TabIndex = 8;
            this.btnCopyUsername.Text = "Copy Username";
            this.btnCopyUsername.UseVisualStyleBackColor = true;
            this.btnCopyUsername.Click += new System.EventHandler(this.btnCopyUsername_Click);
            // 
            // chkUnlock
            // 
            this.chkUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUnlock.AutoSize = true;
            this.chkUnlock.Location = new System.Drawing.Point(504, 12);
            this.chkUnlock.Name = "chkUnlock";
            this.chkUnlock.Size = new System.Drawing.Size(82, 17);
            this.chkUnlock.TabIndex = 9;
            this.chkUnlock.Text = "Unlock App";
            this.chkUnlock.UseVisualStyleBackColor = true;
            this.chkUnlock.CheckedChanged += new System.EventHandler(this.chkUnlock_CheckedChanged);
            // 
            // icoSystemTray
            // 
            this.icoSystemTray.ContextMenuStrip = this.menuSystemTray;
            this.icoSystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("icoSystemTray.Icon")));
            this.icoSystemTray.Text = "Password Manager";
            this.icoSystemTray.Visible = true;
            // 
            // menuSystemTray
            // 
            this.menuSystemTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemOpen,
            this.itemExit});
            this.menuSystemTray.Name = "menuSystemTray";
            this.menuSystemTray.Size = new System.Drawing.Size(112, 48);
            // 
            // itemOpen
            // 
            this.itemOpen.Name = "itemOpen";
            this.itemOpen.Size = new System.Drawing.Size(111, 22);
            this.itemOpen.Text = "Open";
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(111, 22);
            this.itemExit.Text = "Exit";
            // 
            // btnImportPasswords
            // 
            this.btnImportPasswords.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnImportPasswords.Location = new System.Drawing.Point(504, 332);
            this.btnImportPasswords.Name = "btnImportPasswords";
            this.btnImportPasswords.Size = new System.Drawing.Size(76, 35);
            this.btnImportPasswords.TabIndex = 10;
            this.btnImportPasswords.Text = "Import Passwords";
            this.btnImportPasswords.UseVisualStyleBackColor = true;
            this.btnImportPasswords.Click += new System.EventHandler(this.btnImportPasswords_Click);
            // 
            // btnExportPasswords
            // 
            this.btnExportPasswords.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExportPasswords.Location = new System.Drawing.Point(504, 373);
            this.btnExportPasswords.Name = "btnExportPasswords";
            this.btnExportPasswords.Size = new System.Drawing.Size(76, 35);
            this.btnExportPasswords.TabIndex = 11;
            this.btnExportPasswords.Text = "Export Passwords";
            this.btnExportPasswords.UseVisualStyleBackColor = true;
            this.btnExportPasswords.Click += new System.EventHandler(this.btnExportPasswords_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMoveDown.Location = new System.Drawing.Point(504, 76);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(76, 24);
            this.btnMoveDown.TabIndex = 13;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMoveUp.Location = new System.Drawing.Point(504, 46);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(76, 24);
            this.btnMoveUp.TabIndex = 12;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // PasswordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 468);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnExportPasswords);
            this.Controls.Add(this.btnImportPasswords);
            this.Controls.Add(this.chkUnlock);
            this.Controls.Add(this.btnCopyUsername);
            this.Controls.Add(this.btnCopyPassword);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnUserManager);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstPasswords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(602, 412);
            this.Name = "PasswordManager";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager";
            this.menuSystemTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstPasswords;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUserManager;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnCopyPassword;
        private System.Windows.Forms.Button btnCopyUsername;
        private System.Windows.Forms.CheckBox chkUnlock;
        private System.Windows.Forms.NotifyIcon icoSystemTray;
        private System.Windows.Forms.ContextMenuStrip menuSystemTray;
        private System.Windows.Forms.ToolStripMenuItem itemOpen;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.Button btnImportPasswords;
        private System.Windows.Forms.Button btnExportPasswords;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;

    }
}

