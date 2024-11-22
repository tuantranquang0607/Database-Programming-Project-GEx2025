namespace GamesCollectionManagment
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblUser = new Label();
            txtUser = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkShowPlainText = new CheckBox();
            btnLogin = new Button();
            btnCancel = new Button();
            btnRegister = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(12, 9);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(33, 15);
            lblUser.TabIndex = 1;
            lblUser.Text = "User:";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(12, 27);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(283, 23);
            txtUser.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 72);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 90);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(283, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkShowPlainText
            // 
            chkShowPlainText.AutoSize = true;
            chkShowPlainText.Font = new Font("Segoe UI", 17F);
            chkShowPlainText.Location = new Point(12, 119);
            chkShowPlainText.Name = "chkShowPlainText";
            chkShowPlainText.Size = new Size(293, 35);
            chkShowPlainText.TabIndex = 7;
            chkShowPlainText.Text = "Show Plain Text Password";
            chkShowPlainText.UseVisualStyleBackColor = true;
            chkShowPlainText.CheckedChanged += chkShowPlainText_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 170);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(89, 35);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(200, 170);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 35);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(107, 170);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(87, 35);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 210);
            Controls.Add(btnRegister);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(chkShowPlainText);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Name = "frmLogin";
            Text = "Login";
            Load += frmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private TextBox txtUser;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkShowPlainText;
        private Button btnLogin;
        private Button btnCancel;
        private Button btnRegister;
        private ErrorProvider errorProvider;
    }
}
