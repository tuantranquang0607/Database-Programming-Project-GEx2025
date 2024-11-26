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

        private void LoadGameDetails()
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

        private void LoadFirstGame()
        {
            object gameId = DataAccess.GetValue("SELECT TOP (1) Id FROM GameManagment ORDER BY GameTitle");

            if (gameId == null)
            {
                NavigationState(false);

                btnCancel.Enabled = false;
                return;
            }

            NavigationState(true);

            firstGameId = Convert.ToInt32(gameId);
            currentGameId = firstGameId;
            LoadGameDetails();
            NextPreviousButtonManagement();
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

        }
    }
}
