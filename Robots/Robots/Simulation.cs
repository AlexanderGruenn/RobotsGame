using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robots
{
    public class Simulation
    {
        PlayingField field;
        bool gameOver = false;
        private int score;
        private int highscore;

            
        public void Run ()
        {
            while (true)
            {
                score++;
                ConsoleReset();

                gameOver = field.MoveRobots();
                if (gameOver)
                    break;

                field.Print();
                gameOver = field.MovePlayer();
                if (gameOver)
                    break;

                field.Print();
            }
            ConsoleReset();

            if (score > highscore)
            {
                string message1 = "CONGRATULATIONS!!!";
                string message2 = $"YOU HAVE ACHIEVED A NEW HIGHSCORE OF {score} SURIVIVED TURNS!";

                Console.SetCursorPosition(Console.WindowWidth / 2 - message1.Length / 2, Console.WindowHeight / 2);
                Console.WriteLine(message1);
                Console.SetCursorPosition(Console.WindowWidth / 2 - message2.Length / 2, Console.WindowHeight / 2 + 2);
                Console.WriteLine(message2);
                SaveHighscore();
            }
            else
            {
                string message1 = "GAME OVER!!!";
                string message2 = $"YOU HAVE SURVIVED {score} TURNS!";

                Console.SetCursorPosition(Console.WindowWidth / 2 - message1.Length / 2, Console.WindowHeight / 2);
                Console.WriteLine(message1);
                Console.SetCursorPosition(Console.WindowWidth / 2 - message2.Length / 2, Console.WindowHeight / 2 + 2);
                Console.WriteLine(message2);
                SaveHighscore();
            }
        }

        public static void ConsoleReset()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ReadHighScore ()
        {
            using (StreamReader reader = new StreamReader("highscore.txt"))
            {
                bool successfull = int.TryParse(reader.ReadToEnd(), out highscore);
                if (!successfull)
                    highscore = 0;              
            }
        }

        public void SaveHighscore ()
        {
            using (StreamWriter writer = new StreamWriter("highscore.txt"))
            {
                writer.Write(score);
            }
        }

        public void CreateHighscoreFile ()
        {
            File.Create("highscore.txt");
        }

        public Simulation (int robotsNumber, int trapsNumber)
        {
            field = new PlayingField(robotsNumber, trapsNumber);
            if (!File.Exists("highscore.txt"))
                CreateHighscoreFile();
            ReadHighScore();
        }
    }
}
