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

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = null;
            object tag = ((ToolStripMenuItem)sender).Tag;

            switch (tag.ToString())
            {
                case "UserOwnedGames":
                    childForm = new frmUserOwnedGames();
                    break;

                case "UserWishlist":
                    childForm = new frmUserWishlist();
                    break;

                case "GameManagement":
                    childForm = new frmGameManagement();
                    break;

                case "GameSearch":
                    childForm = new frmGameSearch();
                    break;
            }

            if (childForm != null)
            {
                foreach (Form f in this.MdiChildren)
                {
                    // Determine if the selected form is already intantiated
                    if (f.GetType() == childForm.GetType())
                    {
                        f.Activate();
                    }
                }
            }

            childForm.MdiParent = this;
            childForm.Show();
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
            frmLogin loginForm = new();

            loginForm.StartPosition = FormStartPosition.CenterScreen;

            DialogResult result = loginForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("User cancelled the login");
                this.Close();
            }
            else if (result == DialogResult.OK) 
            {
                MessageBox.Show("You are now authenticated and can use the application.");
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("You failed the login. You shall not pass.");
                this.Close();
            }
        }
    }
}
