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
    public partial class frmGameManagment : Form
    {
        public frmGameManagment()
        {
            InitializeComponent();
        }

        private void frmGameManagment_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFirstGame();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading first game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int currentGameId = 0;
        int firstGameId = 0;
        int lastGameId = 0;
        int? previousGameId;
        int? nextGameId;

        private void EnableSearchMode()
        {
            txtGameTitle.ReadOnly = false;

            txtGameGenres.ReadOnly = true;
            txtGamePlatforms.ReadOnly = true;
            txtGamePublisher.ReadOnly = true;
            txtGameReleaseDate.ReadOnly = true;
        }

        private void EnableAddMode()
        {
            txtGameTitle.ReadOnly = false;
            txtGamePublisher.ReadOnly = false;
            txtGameReleaseDate.ReadOnly = false;
            txtGameGenres.ReadOnly = false;
            txtGamePlatforms.ReadOnly = false;

            txtGameTitle.Clear();
            txtGamePublisher.Clear();
            txtGameReleaseDate.Clear();
            txtGameGenres.Clear();
            txtGamePlatforms.Clear();
        }

        private void ClearFields()
        {
            txtGameId.Clear();
            txtGameTitle.Clear();
            txtGamePublisher.Clear();
            txtGameReleaseDate.Clear();
            txtGameGenres.Clear();
            txtGamePlatforms.Clear();
        }

        private void ResetToReadOnlyMode()
        {
            txtGameId.ReadOnly = true;
            txtGameTitle.ReadOnly = true;
            txtGamePublisher.ReadOnly = true;
            txtGameReleaseDate.ReadOnly = true;
            txtGameGenres.ReadOnly = true;
            txtGamePlatforms.ReadOnly = true;
        }

        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousGameId != null;
            btnNext.Enabled = nextGameId != null;
        }

        private void NavigationState(bool enableState)
        {
            btnFirst.Enabled = enableState;
            btnLast.Enabled = enableState;
            btnNext.Enabled = enableState;
            btnPrevious.Enabled = enableState;
        }

        private void Navigation_Handler(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;

                switch (b.Name)
                {
                    case "btnFirst":
                        currentGameId = firstGameId;
                        break;

                    case "btnLast":
                        currentGameId = lastGameId;
                        break;

                    case "btnPrevious":
                        currentGameId = previousGameId.Value;
                        break;

                    case "btnNext":
                        currentGameId = nextGameId.Value;
                        break;
                }

                LoadGameDetails();
                NextPreviousButtonManagement();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating games: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGameDetails()
        {
            try
            {
                string[] sqlStatements = new string[]
                {
                    $"SELECT * FROM GameManagment WHERE Id = {currentGameId}",

                    $@"
                    SELECT 
                    (
                        SELECT TOP(1) Id as FirstGameId FROM GameManagment ORDER BY GameTitle
                    ) as FirstGameId,
                    q.PreviousGameId,
                    q.NextGameId,
                    (
                        SELECT TOP(1) Id as LastGameId FROM GameManagment ORDER BY GameTitle Desc
                    ) as LastGameId
                    FROM
                    (
                        SELECT Id, GameTitle,
                        LEAD(Id) OVER(ORDER BY GameTitle) AS NextGameId,
                        LAG(Id) OVER(ORDER BY GameTitle) AS PreviousGameId
                        FROM GameManagment
                    ) AS q
                    WHERE q.Id = {currentGameId}
                    ORDER BY q.GameTitle"
                };

                DataSet ds = DataAccess.GetData(sqlStatements);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow selectedGame = ds.Tables[0].Rows[0];

                    txtGameId.Text = selectedGame["Id"].ToString();
                    txtGameTitle.Text = selectedGame["GameTitle"].ToString();
                    txtGamePublisher.Text = selectedGame["GamePublisher"].ToString();
                    txtGameReleaseDate.Text = selectedGame["GameReleaseDate"] != DBNull.Value ? Convert.ToDateTime(selectedGame["GameReleaseDate"]).ToString("yyyy-MM-dd") : string.Empty;
                    txtGameGenres.Text = selectedGame["GameGenres"].ToString();
                    txtGamePlatforms.Text = selectedGame["GamePlatforms"].ToString();

                    firstGameId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstGameId"]);
                    previousGameId = ds.Tables[1].Rows[0]["PreviousGameId"] != DBNull.Value ? Convert.ToInt32(ds.Tables[1].Rows[0]["PreviousGameId"]) : (int?)null;
                    nextGameId = ds.Tables[1].Rows[0]["NextGameId"] != DBNull.Value ? Convert.ToInt32(ds.Tables[1].Rows[0]["NextGameId"]) : (int?)null;
                    lastGameId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastGameId"]);
                }
                else
                {
                    LoadFirstGame();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading game details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFirstGame()
        {
            try
            {
                object gameId = DataAccess.GetValue("SELECT TOP (1) Id FROM GameManagment ORDER BY GameTitle");

                if (gameId == null)
                {
                    NavigationState(false);

                    btnAdd_Click(null, null);
                    btnCancel.Enabled = false;
                    return;
                }

                NavigationState(true);

                firstGameId = Convert.ToInt32(gameId);
                currentGameId = firstGameId;
                LoadGameDetails();
                NextPreviousButtonManagement();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading first game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveGameChanges()
        {
            try
            {
                string sql = $@"
                    UPDATE [dbo].[GameManagment]
                    SET [GameTitle]         = '{txtGameTitle.Text.Trim()}',
                        [GamePublisher]     = '{txtGamePublisher.Text.Trim()}',
                        [GameReleaseDate]   = '{txtGameReleaseDate.Text.Trim()}',
                        [GameGenres]        = '{txtGameGenres.Text.Trim()}',
                        [GamePlatforms]     = '{txtGamePlatforms.Text.Trim()}'
                    WHERE Id = {txtGameId.Text.Trim()}
                ";

                int rowsAffected = DataAccess.ExecuteNonQuery(sql);

                if (rowsAffected == 1)
                {
                    MessageBox.Show($"Game with Id: {txtGameId.Text} changes saved");
                    ResetToReadOnlyMode();
                }
                else
                {
                    MessageBox.Show($"Update to game with Id: {{txtGameId.Text}} was not updated.");
                    ResetToReadOnlyMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string LoggedInUserId { get; set; }

        private void CheckGameStatusInTables(int gameId)
        {
            string checkOwnedSql = $@"
                SELECT COUNT(*) 
                FROM OwnedGames 
                WHERE UserId = {LoggedInUserId} AND GameId = {gameId}";

            int ownedCount = Convert.ToInt32(DataAccess.GetValue(checkOwnedSql));

            string checkWishlistSql = $@"
                SELECT COUNT(*) 
                FROM UserWishlist 
                WHERE UserId = {LoggedInUserId} AND GameId = {gameId}";

            int wishlistCount = Convert.ToInt32(DataAccess.GetValue(checkWishlistSql));

            btnAddToOwnedGames.Enabled = (ownedCount == 0);
            btnAddToWishlist.Enabled = (wishlistCount == 0);
        }

        private void btnAddToOwnedGames_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToWishlist_Click(object sender, EventArgs e)
        {

        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            try
            {
                EnableAddMode();

                btnFirst.Enabled = false;
                btnLast.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnAddToOwnedGames.Enabled = false;
                btnAddToWishlist.Enabled = false;
                btnSearch.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;

                if (btnSave.Text == "Save Adjustments")
                {
                    

                    string gameId = txtGameId.Text.Trim();
                    string gameTitle = txtGameTitle.Text.Trim();
                    string gamePublisher = txtGamePublisher.Text.Trim();
                    string gameReleaseDate = txtGameReleaseDate.Text.Trim();
                    string gameGenres = txtGameGenres.Text.Trim();
                    string gamePlatforms = txtGamePlatforms.Text.Trim();

                    string sql = $@"
                        UPDATE GameManagement
                        SET GameTitle = '{gameTitle}', 
                            GamePublisher = '{gamePublisher}', 
                            GameReleaseDate = '{gameReleaseDate}', 
                            GameGenres = '{gameGenres}', 
                            GamePlatforms = '{gamePlatforms}'
                        WHERE Id = {gameId}";

                    int rowsAffected = DataAccess.ExecuteNonQuery(sql);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Game information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ResetToReadOnlyMode();

                        btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No changes were made to the game information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isInSearchMode = false;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isInSearchMode)
                {
                    isInSearchMode = true;
                    EnableSearchMode();
                    ClearFields();
                    return;
                }

                string searchTitle = txtGameTitle.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTitle))
                {
                    MessageBox.Show("Please enter a game title to search.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = $"SELECT * FROM GameManagment WHERE GameTitle LIKE '%{searchTitle}%'";
                DataTable dt = DataAccess.GetData(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow game = dt.Rows[0];

                    txtGameId.Text = game["Id"].ToString();
                    txtGameTitle.Text = game["GameTitle"].ToString();
                    txtGamePublisher.Text = game["GamePublisher"].ToString();
                    txtGameReleaseDate.Text = game["GameReleaseDate"] != DBNull.Value ? Convert.ToDateTime(game["GameReleaseDate"]).ToString("yyyy-MM-dd") : string.Empty;
                    txtGameGenres.Text = game["GameGenres"].ToString();
                    txtGamePlatforms.Text = game["GamePlatforms"].ToString();

                    firstGameId = Convert.ToInt32(dt.Rows[0]["Id"]);
                    lastGameId = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Id"]);
                    currentGameId = firstGameId;

                    NavigationState(true);
                    ResetToReadOnlyMode();
                    NextPreviousButtonManagement();

                    isInSearchMode = false;
                }
                else
                {
                    MessageBox.Show("No games found with the specified title.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    ResetToReadOnlyMode();
                    NavigationState(true);
                    isInSearchMode = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UIUtilities.ClearControls(this.Controls);

                EnableAddMode();

                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSearch.Enabled = false;
                btnAddToOwnedGames.Enabled = false;
                btnAddToWishlist.Enabled = false;
                btnAdjust.Enabled = false;

                NavigationState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateGame()
        {
            if (string.IsNullOrWhiteSpace(txtGameTitle.Text))
            {
                MessageBox.Show("Game title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = txtGameTitle.Text.Trim();
            string publisher = txtGamePublisher.Text.Trim();
            string releaseDate = txtGameReleaseDate.Text.Trim();
            string genres = txtGameGenres.Text.Trim();
            string platforms = txtGamePlatforms.Text.Trim();

            string sqlInsertGame = $@"
                INSERT INTO GameManagment 
                (GameTitle, GamePublisher, GameReleaseDate, GameGenres, GamePlatforms)
                VALUES
                (
                    '{title}',
                    '{publisher}',
                    {(string.IsNullOrEmpty(releaseDate) ? "NULL" : $"'{releaseDate}'")},
                    '{genres}',
                    '{platforms}'
                )";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlInsertGame);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Game successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnCancel_Click(null, null);
                LoadFirstGame();
                ResetToReadOnlyMode();
            }
            else
            {
                MessageBox.Show("The database reported no rows affected.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetToReadOnlyMode();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteGame();
                ResetToReadOnlyMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteGame()
        {
            string sql = $@" DELETE FROM GameManagment WHERE Id = {currentGameId} ";

            int rowsAffected = DataAccess.ExecuteNonQuery(sql);

            if (rowsAffected == 1)
            {
                MessageBox.Show($"Game with Id: {txtGameId.Text} was deleted");
                LoadFirstGame();
                ResetToReadOnlyMode();
            }
            else if (rowsAffected == 0)
            {
                MessageBox.Show($"game with Id: {txtGameId.Text} does not exist. May already have been delete.");
                LoadFirstGame();
                ResetToReadOnlyMode();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (string.IsNullOrEmpty(txtGameId.Text))
                    {
                        CreateGame();
                        ResetToReadOnlyMode();
                    }
                    else
                    {
                        SaveGameChanges();
                        ResetToReadOnlyMode();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGameDetails();

                btnSave.Text = "Save";

                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSearch.Enabled = true;
                btnAddToOwnedGames.Enabled = true;
                btnAddToWishlist.Enabled = true;
                btnAdjust.Enabled = true;

                NavigationState(true);
                NextPreviousButtonManagement();
                ResetToReadOnlyMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
