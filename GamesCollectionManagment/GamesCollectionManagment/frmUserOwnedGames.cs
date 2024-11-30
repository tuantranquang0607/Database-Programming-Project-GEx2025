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
        public frmUserOwnedGames()
        {
            InitializeComponent();
        }

        private void frmUserOwnedGames_Load(object sender, EventArgs e)
        {
            LoadFirstGame();
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

        public string LoggedInUserId { get; internal set; }

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
                string sql = $@"
                    SELECT g.Id, g.GameTitle, g.GamePublisher, g.GameReleaseDate, g.GameGenres, g.GamePlatforms
                    FROM UserOwnedGame uog
                    INNER JOIN GameManagment g ON uog.Id = g.Id
                    WHERE uog.UserID = {LoggedInUserId}";

                DataTable dt = DataAccess.GetData(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow firstGame = dt.Rows[0];

                    txtGameId.Text = firstGame["Id"].ToString();
                    txtGameTitle.Text = firstGame["GameTitle"].ToString();
                    txtGamePublisher.Text = firstGame["GamePublisher"].ToString();
                    txtGameReleaseDate.Text = firstGame["GameReleaseDate"] != DBNull.Value ? Convert.ToDateTime(firstGame["GameReleaseDate"]).ToString("yyyy-MM-dd") : string.Empty;
                    txtGameGenres.Text = firstGame["GameGenres"].ToString();
                    txtGamePlatforms.Text = firstGame["GamePlatforms"].ToString();

                    currentGameId = Convert.ToInt32(firstGame["Id"]);
                }
                else
                {
                    MessageBox.Show("No owned games found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading owned games: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    WHERE uog.UserID = {LoggedInUserId} AND g.Id = {currentGameId}";

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

                    NextPreviousButtonManagement();
                }
                else
                {
                    MessageBox.Show("Game not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading game details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                EnableSearchMode();

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
