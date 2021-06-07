using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizScoreBoard.src;

namespace QuizScoreBoard
{
    public partial class ScoreBoard : Form
    {
        private const int CORRECT_ANSWER_COLUMN = 0;
        private const int SCORE_COLUMN = 1;
        private const int WRONG_ANSWER_COLUMN = 2;

        private Game game;
        private readonly Dictionary<string, PlayerScoreElements> playerScoreElementsList = new();

        public ScoreBoard()
        {
            InitializeComponent();
        }

        public ScoreBoard(Dictionary<string, Player> players) :this()
        {
            this.Game = new Game(players);
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
            this.playerTableLayoutPanel.RowCount = Game.Players.Count;

            int counter = 0;
            foreach (Player player in Game.Players.Values)
            {
                addPlayerToBoard(player, counter);
                counter++;
            }
        }

        private void addPlayerToBoard(Player player, int rowNumber)
        {
            this.playerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            PlayerScoreElements playerScoreElements = new(player.Name, game);
            playerScoreElementsList.Add(player.Name, playerScoreElements);
            this.playerTableLayoutPanel.Controls.Add(playerScoreElements.CorrectAnswerButton, CORRECT_ANSWER_COLUMN, rowNumber);
            this.playerTableLayoutPanel.Controls.Add(playerScoreElements.ScoreTextBox, SCORE_COLUMN, rowNumber);
            this.playerTableLayoutPanel.Controls.Add(playerScoreElements.WrongAnswerButton, WRONG_ANSWER_COLUMN, rowNumber);
        }

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            NewGame startGame = new(this);
            this.Enabled = false;
            startGame.Show();
        }


        private class PlayerScoreElements
        {

            private const string WRONG_BUTTON_TEXT = "Falsche Antwort!";
            private readonly string playerName;
            private readonly Game game;

            public Button CorrectAnswerButton { get; private set; }

            public TextBox ScoreTextBox { get; private set; }

            public Button WrongAnswerButton { get; private set; }

            public PlayerScoreElements(string playerName, Game game)
            {
                this.playerName = playerName;
                this.game = game;
                createCorrectAnswerButton();
                createScoreTextBox();
                createWrongAnswerButton();
            }
            private PlayerScoreElements(Button correctAnswerButton, TextBox scoreTextBox, Button wrongAnswerButton, Game game)
            {
                this.CorrectAnswerButton = correctAnswerButton;
                this.ScoreTextBox = scoreTextBox;
                this.WrongAnswerButton = wrongAnswerButton;
                this.game = game;
            }

            private void createScoreTextBox()
            {
                ScoreTextBox = new();
                ScoreTextBox.Name = playerName + "ScoreTextBox";
                ScoreTextBox.Text = "0";
                ScoreTextBox.AutoSize = true;
                ScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scoreTextBoxTextBox_KeyPress);
            }

            private void createCorrectAnswerButton()
            {
                CorrectAnswerButton = new();
                CorrectAnswerButton.Name = playerName + "CorrectButton";
                CorrectAnswerButton.Text = playerName;
                CorrectAnswerButton.AutoSize = true;
            }

            private void createWrongAnswerButton()
            {
                WrongAnswerButton = new();
                WrongAnswerButton.Name = playerName + "WrongButton";
                WrongAnswerButton.Text = WRONG_BUTTON_TEXT;
                WrongAnswerButton.AutoSize = true;
            }

            private void scoreTextBoxTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == ((char)Keys.Enter))
                {
                    Player currentPlayer;
                    game.Players.TryGetValue(playerName, out currentPlayer);
                    int points;
                    if (int.TryParse(ScoreTextBox.Text, out points))
                    {
                        currentPlayer.Points = points;
                    }
                }
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            NewGame newGame = new(this);
            newGame.Show();
        }
    }
}
