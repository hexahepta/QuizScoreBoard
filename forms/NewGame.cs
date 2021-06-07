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
    public partial class NewGame : Form
    {

        private readonly Dictionary<String, Player> players = new Dictionary<String, Player>();
        private readonly ScoreBoard scoreBoard;

        private NewGame()
        {
            InitializeComponent();
        }

        public NewGame(ScoreBoard scoreBoard): this()
        {
            this.scoreBoard = scoreBoard;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            String newPlayerName = addPlayerNameTextBox.Text;
            String emptyString = "";

            if (!newPlayerName.Equals(emptyString) && !players.ContainsKey(newPlayerName))
            {
                Player newPlayer = new(newPlayerName);
                players.Add(newPlayerName, newPlayer);
                playerList.Items.Add(newPlayerName);
            }

            addPlayerNameTextBox.Text = emptyString;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {

        }

        private void startGameButton_Click_1(object sender, EventArgs e)
        {
            Game game = new(players);
            scoreBoard.Game = game;
            this.Close();
        }

        private void NewGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            scoreBoard.Enabled = true;
        }
    }
}
