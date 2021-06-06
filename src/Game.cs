using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace QuizScoreBoard.src
{
    class Game
    {
        private readonly Dictionary<String, Player> players = new Dictionary<string, Player>();
        private readonly int correct_answer_points = Properties.Settings.Default.correct_answer_points;
        private readonly int wrong_answer_points = Properties.Settings.Default.wrong_answer_points;
        private readonly String fileName = Properties.Settings.Default.save_file_name;

        public Game(Dictionary<String, Player> players)
        {
            this.players = players;
        }

        public void addPoints(Player player, bool correctAnswer)
        {
            if (correctAnswer)
            {
                correctAnswerAddPoints(player);
            } else
            {
                wrongAnswerAddPoints(player);
            }
            save();
        }

        public void setPoints(Player player, int points)
        {
            player.Points = points;
            save();
        }

        public void correctAnswerAddPoints(Player currentPlayer)
        {
            currentPlayer.addPoints(correct_answer_points);
        }

        public void wrongAnswerAddPoints(Player currentPlayer)
        {
            foreach(Player player in players.Values)
            {
                if (!player.Equals(currentPlayer))
                {
                    player.addPoints(wrong_answer_points);
                }
            }
        }

        public void save()
        {
            //TODO fix copied from https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-5-0
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);

        }
    }
}
