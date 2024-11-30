namespace GamesCollectionManagment
{
    partial class frmUserWishlist
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
            label7 = new Label();
            txtGamePublisher = new TextBox();
            txtGameGenres = new TextBox();
            txtGamePlatforms = new TextBox();
            txtGameTitle = new TextBox();
            txtGameId = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtGameReleaseDate = new TextBox();
            label1 = new Label();
            btnSearch = new Button();
            btnLast = new Button();
            btnFirst = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F);
            label7.Location = new Point(37, 303);
            label7.Name = "label7";
            label7.Size = new Size(725, 32);
            label7.TabIndex = 88;
            label7.Text = "You can only add a game to your Wishlist from Game Managment.";
            // 
            // txtGamePublisher
            // 
            txtGamePublisher.Location = new Point(145, 117);
            txtGamePublisher.Name = "txtGamePublisher";
            txtGamePublisher.ReadOnly = true;
            txtGamePublisher.Size = new Size(446, 23);
            txtGamePublisher.TabIndex = 87;
            // 
            // txtGameGenres
            // 
            txtGameGenres.Location = new Point(145, 213);
            txtGameGenres.Name = "txtGameGenres";
            txtGameGenres.ReadOnly = true;
            txtGameGenres.Size = new Size(446, 23);
            txtGameGenres.TabIndex = 86;
            // 
            // txtGamePlatforms
            // 
            txtGamePlatforms.Location = new Point(145, 262);
            txtGamePlatforms.Name = "txtGamePlatforms";
            txtGamePlatforms.ReadOnly = true;
            txtGamePlatforms.Size = new Size(446, 23);
            txtGamePlatforms.TabIndex = 85;
            // 
            // txtGameTitle
            // 
            txtGameTitle.Location = new Point(146, 71);
            txtGameTitle.Name = "txtGameTitle";
            txtGameTitle.ReadOnly = true;
            txtGameTitle.Size = new Size(446, 23);
            txtGameTitle.TabIndex = 84;
            // 
            // txtGameId
            // 
            txtGameId.Location = new Point(146, 22);
            txtGameId.Name = "txtGameId";
            txtGameId.ReadOnly = true;
            txtGameId.Size = new Size(446, 23);
            txtGameId.TabIndex = 83;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(12, 257);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(99, 28);
            label6.TabIndex = 82;
            label6.Text = "Platforms:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(12, 208);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(76, 28);
            label5.TabIndex = 81;
            label5.Text = "Genres:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(12, 160);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 28);
            label4.TabIndex = 80;
            label4.Text = "Release Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(12, 115);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 79;
            label3.Text = "Publisher:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(12, 66);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(53, 28);
            label2.TabIndex = 78;
            label2.Text = "Title:";
            // 
            // txtGameReleaseDate
            // 
            txtGameReleaseDate.Location = new Point(145, 165);
            txtGameReleaseDate.Name = "txtGameReleaseDate";
            txtGameReleaseDate.ReadOnly = true;
            txtGameReleaseDate.Size = new Size(446, 23);
            txtGameReleaseDate.TabIndex = 77;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(33, 28);
            label1.TabIndex = 76;
            label1.Text = "Id:";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(612, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(204, 45);
            btnSearch.TabIndex = 75;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLast
            // 
            btnLast.CausesValidation = false;
            btnLast.Location = new Point(716, 73);
            btnLast.Margin = new Padding(4, 3, 4, 3);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(100, 71);
            btnLast.TabIndex = 74;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnFirst
            // 
            btnFirst.CausesValidation = false;
            btnFirst.Location = new Point(613, 73);
            btnFirst.Margin = new Padding(4, 3, 4, 3);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(95, 71);
            btnFirst.TabIndex = 73;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // btnCancel
            // 
            btnCancel.CausesValidation = false;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnCancel.Location = new Point(716, 213);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 72);
            btnCancel.TabIndex = 72;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.CausesValidation = false;
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnDelete.Location = new Point(613, 213);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(95, 72);
            btnDelete.TabIndex = 71;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnSearch_Click;
            // 
            // btnNext
            // 
            btnNext.CausesValidation = false;
            btnNext.Location = new Point(716, 150);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(100, 57);
            btnNext.TabIndex = 70;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // btnPrevious
            // 
            btnPrevious.CausesValidation = false;
            btnPrevious.Location = new Point(613, 150);
            btnPrevious.Margin = new Padding(4, 3, 4, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(95, 57);
            btnPrevious.TabIndex = 69;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // frmUserWishlist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 345);
            Controls.Add(label7);
            Controls.Add(txtGamePublisher);
            Controls.Add(txtGameGenres);
            Controls.Add(txtGamePlatforms);
            Controls.Add(txtGameTitle);
            Controls.Add(txtGameId);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtGameReleaseDate);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(btnLast);
            Controls.Add(btnFirst);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Name = "frmUserWishlist";
            Text = "Your Wishlist";
            Load += frmUserWishlist_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox txtGamePublisher;
        private TextBox txtGameGenres;
        private TextBox txtGamePlatforms;
        private TextBox txtGameTitle;
        private TextBox txtGameId;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtGameReleaseDate;
        private Label label1;
        private Button btnSearch;
        private Button btnLast;
        private Button btnFirst;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnNext;
        private Button btnPrevious;
    }
}