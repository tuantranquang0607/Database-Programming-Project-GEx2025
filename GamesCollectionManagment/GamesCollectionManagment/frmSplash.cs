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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        frmLogin frm = new();

        private void frmSplash_Load(object sender, EventArgs e)
        {
            lblProduct.Text = ProductName;

            frm.FormClosed += new FormClosedEventHandler(frmClose);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (prgProgress.Value < 100)
            {
                prgProgress.Increment(5);
            }
            else
            {
                timer1.Enabled = false;

                frmMDIParent frm = new();

                frm.Show();
                this.Hide();

                frm.FormClosed += new FormClosedEventHandler(frmClose);
            }
        }

        private void frmClose(object? sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
