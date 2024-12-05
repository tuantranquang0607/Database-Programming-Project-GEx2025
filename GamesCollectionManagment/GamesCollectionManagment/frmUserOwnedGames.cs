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
    public partial class frmUserOwnedGames : Form
    {
        public string LoggedInUserId { get; internal set; }


        public frmUserOwnedGames()
        {
            InitializeComponent();
        }


        private void frmUserOwnedGames_Load(object sender, EventArgs e)
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
            btnFirst.Enabled = currentGameId != firstGameId;
            btnLast.Enabled = currentGameId != lastGameId;
        }


        private void NavigationState(bool enableState)
        {
            btnFirst.Enabled = enableState;
            btnLast.Enabled = enableState;
            btnNext.Enabled = enableState;
            btnPrevious.Enabled = enableState;
        }


        private void SetNavigationIds(int currentId, DataTable dt)
        {
            var rows = dt.AsEnumerable().Select(row => Convert.ToInt32(row["Id"])).ToList();
            int currentIndex = rows.IndexOf(currentId);

            previousGameId = currentIndex > 0 ? rows[currentIndex - 1] : (int?)null;
            nextGameId = currentIndex < rows.Count - 1 ? rows[currentIndex + 1] : (int?)null;

            firstGameId = rows.First();
            lastGameId = rows.Last();
        }


        private bool isSearchMode = false;


        private void ExitSearchMode()
        {
            isSearchMode = false;
            btnSearch.Enabled = true;

            ResetToReadOnlyMode();
            LoadFirstGame();  
            NavigationState(true); 
        }


        private void ClearTextFields()
        {
            txtGameId.Clear();
            txtGameTitle.Clear();
            txtGamePublisher.Clear();
            txtGameReleaseDate.Clear();
            txtGameGenres.Clear();
            txtGamePlatforms.Clear();
        }


        private void Navigation_Handler(object sender, EventArgs e)
        {
            try
            {
                if (isSearchMode)
                {
                    ExitSearchMode();
                }

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
                string sql = $@"
                    SELECT g.Id, g.GameTitle, g.GamePublisher, g.GameReleaseDate, g.GameGenres, g.GamePlatforms
                    FROM UserOwnedGame uog
                    INNER JOIN GameManagment g ON uog.Id = g.Id
                    WHERE uog.UserID = {LoggedInUserId}
                    ORDER BY g.GameTitle";

                DataTable dt = DataAccess.GetData(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow game = dt.AsEnumerable().FirstOrDefault(row => Convert.ToInt32(row["Id"]) == currentGameId);

                    if (game != null)
                    {
                        txtGameId.Text = game["Id"].ToString();
                        txtGameTitle.Text = game["GameTitle"].ToString();
                        txtGamePublisher.Text = game["GamePublisher"].ToString();
                        txtGameReleaseDate.Text = game["GameReleaseDate"] != DBNull.Value ? Convert.ToDateTime(game["GameReleaseDate"]).ToString("yyyy-MM-dd") : string.Empty;
                        txtGameGenres.Text = game["GameGenres"].ToString();
                        txtGamePlatforms.Text = game["GamePlatforms"].ToString();

                        SetNavigationIds(currentGameId, dt);
                    }
                }
                else
                {
                    MessageBox.Show("No games found for this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string sql = $@"
                    SELECT g.Id, g.GameTitle, g.GamePublisher, g.GameReleaseDate, g.GameGenres, g.GamePlatforms
                    FROM UserOwnedGame uog
                    INNER JOIN GameManagment g ON uog.Id = g.Id
                    WHERE uog.UserID = {LoggedInUserId}
                    ORDER BY g.GameTitle";

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

                    currentGameId = Convert.ToInt32(game["Id"]);

                    firstGameId = Convert.ToInt32(dt.Rows[0]["Id"]);
                    lastGameId = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Id"]);

                    SetNavigationIds(currentGameId, dt);
                    NextPreviousButtonManagement();
                }
                else
                {
                    MessageBox.Show("No games found for this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading first game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtGameId.Text))
                {
                    MessageBox.Show("No game selected to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int gameId = Convert.ToInt32(txtGameId.Text);

                string sql = $@"
                    DELETE FROM UserOwnedGame
                    WHERE UserID = {LoggedInUserId} AND Id = {gameId}";

                int rowsAffected = DataAccess.ExecuteNonQuery(sql);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Game successfully removed from your Owned Games.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGameDetails();
                }
                else
                {
                    MessageBox.Show("Failed to delete the game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGameDetails();
                ExitSearchMode();

                btnDelete.Enabled = true;
                btnSearch.Enabled = true;

                NavigationState(true);
                NextPreviousButtonManagement();
                ResetToReadOnlyMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                isSearchMode = true;

                EnableSearchMode();
                ClearTextFields();

                string searchTitle = txtGameTitle.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTitle))
                {
                    MessageBox.Show("Please enter a game title to search.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = $@"
                    SELECT g.Id, g.GameTitle, g.GamePublisher, g.GameReleaseDate, g.GameGenres, g.GamePlatforms
                    FROM UserOwnedGame uog
                    INNER JOIN GameManagment g ON uog.Id = g.Id
                    WHERE uog.UserID = {LoggedInUserId} AND g.GameTitle LIKE '%{searchTitle}%'";

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
                }
                else
                {
                    MessageBox.Show("No matching owned games found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UIUtilities.ClearControls(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
