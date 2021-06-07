using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizScoreBoard.src
{
    public class Player
    {
        private readonly String name;
        private int points;

        public int Points { get => points; set => points = value; }

        public string Name => name;

        public Player(String name, int points)
        {
            this.name = name;
            this.Points = points;
        }

        public Player(String name)
        {
            this.name = name;
        }

        public void addPoints(int points)
        {
            this.Points += points;
        }

    }
}
