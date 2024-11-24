namespace CollegeTeachingAssignments
{
    partial class frmMDIParent
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
            btnUserOwnedGames = new Button();
            btnUserWishlist = new Button();
            btnGameManagment = new Button();
            btnLogin = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnUserOwnedGames
            // 
            btnUserOwnedGames.Location = new Point(12, 12);
            btnUserOwnedGames.Name = "btnUserOwnedGames";
            btnUserOwnedGames.Size = new Size(281, 82);
            btnUserOwnedGames.TabIndex = 2;
            btnUserOwnedGames.Text = "Your Games";
            btnUserOwnedGames.UseVisualStyleBackColor = true;
            btnUserOwnedGames.Click += btnUserOwnedGames_Click;
            // 
            // btnUserWishlist
            // 
            btnUserWishlist.Location = new Point(12, 100);
            btnUserWishlist.Name = "btnUserWishlist";
            btnUserWishlist.Size = new Size(281, 82);
            btnUserWishlist.TabIndex = 3;
            btnUserWishlist.Text = "Wishlist";
            btnUserWishlist.UseVisualStyleBackColor = true;
            btnUserWishlist.Click += btnUserWishlist_Click;
            // 
            // btnGameManagment
            // 
            btnGameManagment.Location = new Point(14, 188);
            btnGameManagment.Name = "btnGameManagment";
            btnGameManagment.Size = new Size(281, 82);
            btnGameManagment.TabIndex = 4;
            btnGameManagment.Text = "Game Managment";
            btnGameManagment.UseVisualStyleBackColor = true;
            btnGameManagment.Click += btnGameManagment_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 276);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(281, 82);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LOG OUT";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 369);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(307, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.RightToLeft = RightToLeft.No;
            toolStripStatusLabel.Size = new Size(261, 17);
            toolStripStatusLabel.Spring = true;
            toolStripStatusLabel.Text = "toolStripStatusLabel";
            toolStripStatusLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // frmMDIParent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 391);
            Controls.Add(statusStrip1);
            Controls.Add(btnLogin);
            Controls.Add(btnGameManagment);
            Controls.Add(btnUserWishlist);
            Controls.Add(btnUserOwnedGames);
            IsMdiContainer = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmMDIParent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu";
            Load += frmMDIParent_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUserOwnedGames;
        private Button btnUserWishlist;
        private Button btnGameManagment;
        private Button btnLogin;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}



