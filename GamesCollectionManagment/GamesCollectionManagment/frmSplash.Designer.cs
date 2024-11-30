namespace CollegeTeachingAssignments
{
    partial class frmSplash
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            lblProduct = new Label();
            lblVersion = new Label();
            prgProgress = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            lblAuthor = new Label();
            SuspendLayout();
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.BackColor = Color.Transparent;
            lblProduct.Font = new Font("Segoe UI", 39F, FontStyle.Bold);
            lblProduct.ForeColor = Color.Silver;
            lblProduct.Location = new Point(56, 9);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(688, 70);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Video Games Managament";
            lblProduct.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.Transparent;
            lblVersion.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblVersion.ForeColor = Color.Silver;
            lblVersion.Location = new Point(252, 381);
            lblVersion.Margin = new Padding(3);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(309, 54);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Version: 1.0.0.0";
            lblVersion.TextAlign = ContentAlignment.BottomCenter;
            // 
            // prgProgress
            // 
            prgProgress.Location = new Point(-6, 441);
            prgProgress.Name = "prgProgress";
            prgProgress.Size = new Size(807, 10);
            prgProgress.TabIndex = 3;
            prgProgress.Value = 20;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.BackColor = Color.Transparent;
            lblAuthor.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblAuthor.ForeColor = Color.Silver;
            lblAuthor.Location = new Point(140, 79);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(491, 54);
            lblAuthor.TabIndex = 4;
            lblAuthor.Text = "_Tuan Q. Tran - GEx2025_";
            lblAuthor.TextAlign = ContentAlignment.BottomCenter;
            // 
            // frmSplash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(795, 450);
            Controls.Add(lblAuthor);
            Controls.Add(prgProgress);
            Controls.Add(lblVersion);
            Controls.Add(lblProduct);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmSplash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSplash";
            Load += frmSplash_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProduct;
        private Label lblVersion;
        private ProgressBar prgProgress;
        private System.Windows.Forms.Timer timer1;
        private Label lblAuthor;
    }
}