namespace GamesCollectionManagment
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
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            btnLogin = new Button();
            btnGameManagment = new Button();
            btnUserWishlist = new Button();
            btnUserOwnedGames = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 363);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(308, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.RightToLeft = RightToLeft.No;
            toolStripStatusLabel.Size = new Size(262, 17);
            toolStripStatusLabel.Spring = true;
            toolStripStatusLabel.Text = "toolStripStatusLabel";
            toolStripStatusLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 270);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(281, 82);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "LOG OUT";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnGameManagment
            // 
            btnGameManagment.Location = new Point(14, 182);
            btnGameManagment.Name = "btnGameManagment";
            btnGameManagment.Size = new Size(281, 82);
            btnGameManagment.TabIndex = 9;
            btnGameManagment.Text = "Game Managment";
            btnGameManagment.UseVisualStyleBackColor = true;
            btnGameManagment.Click += btnGameManagment_Click;
            // 
            // btnUserWishlist
            // 
            btnUserWishlist.Location = new Point(12, 94);
            btnUserWishlist.Name = "btnUserWishlist";
            btnUserWishlist.Size = new Size(281, 82);
            btnUserWishlist.TabIndex = 8;
            btnUserWishlist.Text = "Wishlist";
            btnUserWishlist.UseVisualStyleBackColor = true;
            btnUserWishlist.Click += btnUserWishlist_Click;
            // 
            // btnUserOwnedGames
            // 
            btnUserOwnedGames.Location = new Point(12, 6);
            btnUserOwnedGames.Name = "btnUserOwnedGames";
            btnUserOwnedGames.Size = new Size(281, 82);
            btnUserOwnedGames.TabIndex = 7;
            btnUserOwnedGames.Text = "Your Games";
            btnUserOwnedGames.UseVisualStyleBackColor = true;
            btnUserOwnedGames.Click += btnUserOwnedGames_Click;
            // 
            // frmMDIParent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 385);
            Controls.Add(statusStrip1);
            Controls.Add(btnLogin);
            Controls.Add(btnGameManagment);
            Controls.Add(btnUserWishlist);
            Controls.Add(btnUserOwnedGames);
            IsMdiContainer = true;
            Name = "frmMDIParent";
            Text = "Menu";
            Load += frmMDIParent_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Button btnLogin;
        private Button btnGameManagment;
        private Button btnUserWishlist;
        private Button btnUserOwnedGames;
    }
}