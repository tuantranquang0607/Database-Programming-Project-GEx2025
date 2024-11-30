using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamesCollectionManagment
{
    public partial class frmMDIParent : Form
    {
        public string LoggedInUsername { get; set; }

        public string LoggedInUserId { get; set; }

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
                LoggedInUsername = LoggedInUsername;
                LoggedInUserId = loginForm.LoggedInUserId;

                toolStripStatusLabel.Text = $"Logged in as: {LoggedInUsername}";
            }
        }

        private void btnUserOwnedGames_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserOwnedGames userOwnedGamesForm = new frmUserOwnedGames
                {
                    LoggedInUserId = this.LoggedInUserId,
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
                    LoggedInUserId = this.LoggedInUserId;
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
                frmGameManagment gameManagmentForm = new frmGameManagment();
                {
                    LoggedInUserId = this.LoggedInUserId;
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
                    LoggedInUserId = logInForm.LoggedInUserId;

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
