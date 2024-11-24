using GamesCollectionManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeTeachingAssignments
{
    public partial class frmMDIParent : Form
    {
        private int childFormNumber = 0;

        public frmMDIParent()
        {
            InitializeComponent();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        public string LoggedInUsername { get; set; }

        private void frmMDIParent_Load(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            DialogResult result = loginForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }
            else if (result == DialogResult.OK)
            {
                // Retrieve the logged-in username from the login form
                LoggedInUsername = loginForm.LoggedInUsername;

                // Display the username in the StatusStrip
                toolStripStatusLabel.Text = $"Logged in as: {LoggedInUsername}";
            }
        }

        private void btnUserOwnedGames_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserOwnedGames userOwnedGamesForm = new frmUserOwnedGames
                {
                    StartPosition = FormStartPosition.CenterScreen
                };

                userOwnedGamesForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the User Owned Games form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUserWishlist_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserWishlist userWishlistForm = new frmUserWishlist();
                {
                    StartPosition = FormStartPosition.CenterScreen;
                }

                userWishlistForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the User Owned Games form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGameManagment_Click(object sender, EventArgs e)
        {
            try
            {
                frmGameManagement gameManagmentForm = new frmGameManagement();
                {
                    StartPosition = FormStartPosition.CenterScreen;
                }

                gameManagmentForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the User Owned Games form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedInUsername = null;
                toolStripStatusLabel.Text = "Logged out";

                this.Hide();

                frmLogin logInForm = new frmLogin
                {
                    StartPosition = FormStartPosition.CenterScreen
                };

                DialogResult result = logInForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoggedInUsername = logInForm.LoggedInUsername;
                    toolStripStatusLabel.Text = $"Logged in as: {LoggedInUsername}";

                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the User Owned Games form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
