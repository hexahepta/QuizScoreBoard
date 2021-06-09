using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuizScoreBoard.src
{
    public class Player : INotifyPropertyChanged
    {
        private readonly String name;
        private int points;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Points { get => points; set
            {
                if (!points.Equals(value))
                {
                    points = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Points"));
                }
            }
        }

        public string Name => name;

        [JsonConstructor]
        public Player(String name, int points)
        {
            this.name = name;
            this.Points = points;
        }

        public Player(Player toCopy)
        {
            this.name = toCopy.Name;
            this.Points = toCopy.Points;
        }

        public Player(String name) : this(name, 0) { }

        public void addPoints(int points)
        {
            this.Points += points;
        }

    }
}
