using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizScoreBoard.src;
using System.Windows.Forms;

namespace QuizScoreBoard
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Game game = Game.Load();
            if (null == game)
            {
                game = new(new Dictionary<string, Player>());
            }
            ScoreBoard scoreBoard = new(game);
            Application.Run(scoreBoard);
        }
    }
}
