namespace GamesCollectionManagment
{
    partial class frmGameManagment
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
            btnPrevious = new Button();
            btnNext = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            btnFirst = new Button();
            btnLast = new Button();
            btnSearch = new Button();
            label1 = new Label();
            txtGameReleaseDate = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtGameId = new TextBox();
            txtGameTitle = new TextBox();
            txtGamePlatforms = new TextBox();
            txtGameGenres = new TextBox();
            txtGamePublisher = new TextBox();
            btnAddToOwnedGames = new Button();
            btnAddToWishlist = new Button();
            errorProvider = new ErrorProvider(components);
            btnAdjust = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // btnPrevious
            // 
            btnPrevious.CausesValidation = false;
            btnPrevious.Location = new Point(11, 379);
            btnPrevious.Margin = new Padding(4, 3, 4, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(95, 30);
            btnPrevious.TabIndex = 21;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnNext
            // 
            btnNext.CausesValidation = false;
            btnNext.Location = new Point(106, 379);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(109, 30);
            btnNext.TabIndex = 22;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // btnAdd
            // 
            btnAdd.CausesValidation = false;
            btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnAdd.Location = new Point(344, 341);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 32);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.CausesValidation = false;
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnDelete.Location = new Point(457, 341);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 32);
            btnDelete.TabIndex = 25;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnSave.Location = new Point(344, 379);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 33);
            btnSave.TabIndex = 26;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.CausesValidation = false;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnCancel.Location = new Point(457, 378);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(128, 33);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnFirst
            // 
            btnFirst.CausesValidation = false;
            btnFirst.Location = new Point(12, 341);
            btnFirst.Margin = new Padding(4, 3, 4, 3);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(94, 32);
            btnFirst.TabIndex = 28;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // btnLast
            // 
            btnLast.CausesValidation = false;
            btnLast.Location = new Point(106, 341);
            btnLast.Margin = new Padding(4, 3, 4, 3);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(109, 32);
            btnLast.TabIndex = 29;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(188, 299);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(196, 36);
            btnSearch.TabIndex = 30;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(6, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(33, 28);
            label1.TabIndex = 31;
            label1.Text = "Id:";
            // 
            // txtGameReleaseDate
            // 
            txtGameReleaseDate.Location = new Point(139, 160);
            txtGameReleaseDate.Name = "txtGameReleaseDate";
            txtGameReleaseDate.ReadOnly = true;
            txtGameReleaseDate.Size = new Size(446, 23);
            txtGameReleaseDate.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(6, 61);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(53, 28);
            label2.TabIndex = 33;
            label2.Text = "Title:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(6, 110);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 34;
            label3.Text = "Publisher:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(6, 155);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 28);
            label4.TabIndex = 35;
            label4.Text = "Release Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(6, 203);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(76, 28);
            label5.TabIndex = 36;
            label5.Text = "Genres:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(6, 252);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(99, 28);
            label6.TabIndex = 37;
            label6.Text = "Platforms:";
            // 
            // txtGameId
            // 
            txtGameId.Location = new Point(140, 17);
            txtGameId.Name = "txtGameId";
            txtGameId.ReadOnly = true;
            txtGameId.Size = new Size(446, 23);
            txtGameId.TabIndex = 38;
            // 
            // txtGameTitle
            // 
            txtGameTitle.Location = new Point(140, 66);
            txtGameTitle.Name = "txtGameTitle";
            txtGameTitle.ReadOnly = true;
            txtGameTitle.Size = new Size(446, 23);
            txtGameTitle.TabIndex = 39;
            // 
            // txtGamePlatforms
            // 
            txtGamePlatforms.Location = new Point(139, 257);
            txtGamePlatforms.Name = "txtGamePlatforms";
            txtGamePlatforms.ReadOnly = true;
            txtGamePlatforms.Size = new Size(446, 23);
            txtGamePlatforms.TabIndex = 40;
            // 
            // txtGameGenres
            // 
            txtGameGenres.Location = new Point(139, 208);
            txtGameGenres.Name = "txtGameGenres";
            txtGameGenres.ReadOnly = true;
            txtGameGenres.Size = new Size(446, 23);
            txtGameGenres.TabIndex = 41;
            // 
            // txtGamePublisher
            // 
            txtGamePublisher.Location = new Point(139, 112);
            txtGamePublisher.Name = "txtGamePublisher";
            txtGamePublisher.ReadOnly = true;
            txtGamePublisher.Size = new Size(446, 23);
            txtGamePublisher.TabIndex = 42;
            // 
            // btnAddToOwnedGames
            // 
            btnAddToOwnedGames.Location = new Point(12, 299);
            btnAddToOwnedGames.Name = "btnAddToOwnedGames";
            btnAddToOwnedGames.Size = new Size(170, 36);
            btnAddToOwnedGames.TabIndex = 43;
            btnAddToOwnedGames.Text = "Add to Owned Games";
            btnAddToOwnedGames.UseVisualStyleBackColor = true;
            btnAddToOwnedGames.Click += btnAddToOwnedGames_Click;
            // 
            // btnAddToWishlist
            // 
            btnAddToWishlist.Location = new Point(390, 299);
            btnAddToWishlist.Name = "btnAddToWishlist";
            btnAddToWishlist.Size = new Size(196, 36);
            btnAddToWishlist.TabIndex = 44;
            btnAddToWishlist.Text = "Add to Wishlist";
            btnAddToWishlist.UseVisualStyleBackColor = true;
            btnAddToWishlist.Click += btnAddToWishlist_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // btnAdjust
            // 
            btnAdjust.CausesValidation = false;
            btnAdjust.Location = new Point(223, 341);
            btnAdjust.Margin = new Padding(4, 3, 4, 3);
            btnAdjust.Name = "btnAdjust";
            btnAdjust.Size = new Size(113, 70);
            btnAdjust.TabIndex = 45;
            btnAdjust.Text = "Adjust The Information";
            btnAdjust.UseVisualStyleBackColor = true;
            btnAdjust.Click += this.btnAdjust_Click;
            // 
            // frmGameManagment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 426);
            Controls.Add(btnAdjust);
            Controls.Add(btnAddToWishlist);
            Controls.Add(btnAddToOwnedGames);
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
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Name = "frmGameManagment";
            Text = "frmGameManagment";
            Load += frmGameManagment_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrevious;
        private Button btnNext;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSave;
        private Button btnCancel;
        private Button btnFirst;
        private Button btnLast;
        private Button btnSearch;
        private Label label1;
        private TextBox txtGameReleaseDate;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtGameId;
        private TextBox txtGameTitle;
        private TextBox txtGamePlatforms;
        private TextBox txtGameGenres;
        private TextBox txtGamePublisher;
        private Button btnAddToOwnedGames;
        private Button btnAddToWishlist;
        private ErrorProvider errorProvider;
        private Button btnAdjust;
    }
}