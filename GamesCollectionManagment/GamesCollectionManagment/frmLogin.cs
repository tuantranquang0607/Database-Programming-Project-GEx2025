using System.Data;

namespace GamesCollectionManagment
{
    public partial class frmLogin : Form
    {
        public string LoggedInUsername { get; set; }

        public string LoggedInUserId { get; set; }


        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = $"GCM - Login/Register";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during form load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidateInputs()
        {
            errorProvider.Clear();

            bool hasError = false;

            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                errorProvider.SetError(txtUser, "Username is required.");
                errorProvider.SetIconPadding(txtUser, -20);

                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Password is required.");
                errorProvider.SetIconPadding(txtPassword, -20);
            }

            return !hasError;
        }


        private void chkShowPlainText_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtPassword.UseSystemPasswordChar = !chkShowPlainText.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error toggling password visibility: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    return; 
                }

                string username = txtUser.Text.Trim();

                string password = txtPassword.Text.Trim();

                string sql = $"SELECT * FROM Users WHERE UserName = '{username}' AND Password = '{password}'";

                DataTable dt = DataAccess.GetData(sql);

                if (dt.Rows.Count > 0)
                {
                    LoggedInUserId = dt.Rows[0]["UserID"].ToString();
                    LoggedInUsername = username; 
                    DialogResult = DialogResult.OK; 
                }
                else
                {
                    errorProvider.SetError(txtUser, "Invalid username or password.");
                    errorProvider.SetError(txtPassword, "Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    return;
                }

                string username = txtUser.Text.Trim();

                string password = txtPassword.Text.Trim();

                string checkUserSql = $"SELECT COUNT(*) FROM Users WHERE UserName = '{username}'";

                DataTable userExists = DataAccess.GetData(checkUserSql);

                if (Convert.ToInt32(userExists.Rows[0][0]) > 0)
                {
                    errorProvider.SetError(txtUser, "Username already exists. Please choose a different username.");

                    return;
                }

                string insertSql = $"INSERT INTO Users (UserName, Password) VALUES ('{username}', '{password}')";

                DataAccess.ExecuteNonQuery(insertSql);

                MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUser.Clear();
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during cancellation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
