using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using QuizScoreBoard.src;

namespace QuizScoreBoard
{
    public partial class ScoreBoard : Form
    {
        private const int CORRECT_ANSWER_COLUMN = 0;
        private const int SCORE_COLUMN = 1;
        private const int WRONG_ANSWER_COLUMN = 2;
        private const int MARKER_CHECK_BOX_COLUMN = 3;

        private Game game;
        private readonly Dictionary<string, PlayerScoreElements> playerScoreElementsList = new();
        private bool isLastCtrl = false;

        public ScoreBoard()
        {
            InitializeComponent();
        }

        public ScoreBoard(Dictionary<string, Player> players) : this()
        {
            this.Game = new Game(players);
        }

        public ScoreBoard(Game game) : this()
        {
            this.Game = game;
        }

        public Game Game { 
            get => game; 
            set 
            { 
                game = value; 
                addPlayersToBoard(); 
            } 
        }

        private void addPlayersToBoard()
        {
            cleanPlayerTable();
            this.playerTableLayoutPanel.RowCount = Game.Players.Count;

            int counter = 0;
            foreach (Player player in Game.Players.Values)
            {
                addPlayerToBoard(player, counter);
                counter++;
            }
        }

        private void cleanPlayerTable()
        {
            foreach (Control control in this.playerTableLayoutPanel.Controls)
            {
                control.Dispose();
            }
            this.playerTableLayoutPanel.Controls.Clear();
            this.playerScoreElementsList.Clear();
        }

        private void addPlayerToBoard(Player player, int rowNumber)
        {
            this.playerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            PlayerScoreElements playerScoreElements = new(player.Name, game);
            playerScoreElementsList.Add(player.Name, playerScoreElements);
            this.playerTableLayoutPanel.Controls.Add(playerScoreElements.CorrectAnswerButton, CORRECT_ANSWER_COLUMN, rowNumber);
            this.playerTableLayoutPanel.Controls.Add(playerScoreElements.ScoreTextBox, SCORE_COLUMN, rowNumber);
            this.playerTableLayoutPanel.Controls.Add(playerScoreElements.WrongAnswerButton, WRONG_ANSWER_COLUMN, rowNumber);
            this.playerTableLayoutPanel.Controls.Add(playerScoreElements.MarkerCheckBox, MARKER_CHECK_BOX_COLUMN, rowNumber);
        }

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            NewGame startGame = new(this);
            this.Enabled = false;
            startGame.Show();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            NewGame newGame = new(this);
            newGame.Show();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            this.game.undo();
            foreach (PlayerScoreElements playerScoreElements in playerScoreElementsList.Values)
            {
                playerScoreElements.reloadCurrentPlayer();
            }
        }

        private class PlayerScoreElements
        {

            private const string WRONG_BUTTON_TEXT = "Falsche Antwort!";
            private readonly string playerName;
            private readonly Game game;
            private Player currentPlayer;

            private Player CurrentPlayer
            {
                get
                {
                    if (null == currentPlayer)
                    {
                        currentPlayer = getCurrentPlayer();
                    }
                    return currentPlayer;
                }
                set
                {
                    currentPlayer = value;
                }
            }

            public Button CorrectAnswerButton { get; private set; }

            public TextBox ScoreTextBox { get; private set; }

            public Button WrongAnswerButton { get; private set; }

            public CheckBox MarkerCheckBox { get; private set; }

            public PlayerScoreElements(string playerName, Game game)
            {
                this.playerName = playerName;
                this.game = game;
                createCorrectAnswerButton();
                createScoreTextBox();
                createWrongAnswerButton();
                createMarkerCheckBox();
            }

            private PlayerScoreElements(Button correctAnswerButton, TextBox scoreTextBox, Button wrongAnswerButton, Game game)
            {
                this.CorrectAnswerButton = correctAnswerButton;
                this.ScoreTextBox = scoreTextBox;
                this.WrongAnswerButton = wrongAnswerButton;
                createMarkerCheckBox();
                this.game = game;
            }

            public void reloadCurrentPlayer()
            {
                CurrentPlayer = null;
                ScoreTextBox.DataBindings.Clear();
                ScoreTextBox.DataBindings.Add("Text", CurrentPlayer, "Points");
            }

            private void createScoreTextBox()
            {
                ScoreTextBox = new();
                ScoreTextBox.Name = playerName + "ScoreTextBox";
                ScoreTextBox.Text = "0";
                ScoreTextBox.AutoSize = true;
                ScoreTextBox.DataBindings.Add(new Binding("Text", CurrentPlayer, "Points"));
                ScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scoreTextBoxTextBox_KeyPress);
            }

            private void createCorrectAnswerButton()
            {
                CorrectAnswerButton = new();
                CorrectAnswerButton.Name = playerName + "CorrectButton";
                CorrectAnswerButton.Text = playerName;
                CorrectAnswerButton.AutoSize = true;
                CorrectAnswerButton.Click += new System.EventHandler(this.correctAnswerButton_Click);
            }

            private void createWrongAnswerButton()
            {
                WrongAnswerButton = new();
                WrongAnswerButton.Name = playerName + "WrongButton";
                WrongAnswerButton.Text = WRONG_BUTTON_TEXT;
                WrongAnswerButton.AutoSize = true;
                WrongAnswerButton.Click += new System.EventHandler(this.wrongAnswerButton_Click);
            }

            private void createMarkerCheckBox()
            {
                MarkerCheckBox = new();
                MarkerCheckBox.Name = playerName + "CheckBox";
            }

            private void scoreTextBoxTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == ((char)Keys.Enter))
                {
                    int points;
                    if (int.TryParse(ScoreTextBox.Text, out points))
                    {
                        CurrentPlayer.Points = points;
                    }
                }
            }

            private void correctAnswerButton_Click(object sender, EventArgs e)
            {
                game.addPoints(CurrentPlayer, true);
            }

            private void wrongAnswerButton_Click(object sender, EventArgs e)
            {
                game.addPoints(CurrentPlayer, false);
            }

            private Player getCurrentPlayer()
            {
                Player currentPlayer;
                game.Players.TryGetValue(playerName, out currentPlayer);
                return currentPlayer;
            }
        }
    }
}
