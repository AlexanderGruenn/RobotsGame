using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robots
{
    public class PlayingField
    {
        private Element[,] field = new Element[Console.WindowWidth, Console.WindowHeight];
        public static Random rng = new Random();

        private int X
        {
            get
            {
                x = rng.Next(0, Console.WindowWidth);
                return x;
            }
        }
        private int x;
        private int Y
        {
            get
            {
                y = rng.Next(0, Console.WindowHeight);
                return y;
            }
        }
        private int y;

        public void Print()
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                for (int y = 0; y < Console.WindowHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    if (field[x, y] == null)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    Console.Write(field[x,y]);
                }
            }
        }
        public void SpawnRobots(int number)
        {
            for (int i = 0; i < number; i++)
            {
                FindNewEmptySpot();
                field[x, y] = new Robot();
            }
        }
        public void SpawnTraps(int number)
        {
            for (int i = 0; i < number; i++)
            {
                FindNewEmptySpot();
                field[x, y] = new Trap();
            }
        }
        private void FindNewEmptySpot()
        {
            while (field[X, Y] != null)
            {
                int x = rng.Next(0, Console.WindowWidth);
                int y = rng.Next(0, Console.WindowHeight);
            } 
        }

        public PlayingField (int robotsNumber, int trapsNumber)
        {
            SpawnTraps(trapsNumber);
            SpawnRobots(robotsNumber);
            Print();
        }
    }
}
