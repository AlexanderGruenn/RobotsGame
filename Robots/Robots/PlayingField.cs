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
        private List<Element> elements = new List<Element>();
        private List<Robot> robots = new List<Robot>();

        private Player player;

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
            foreach (var c in elements)
            {
                Console.SetCursorPosition(c.X, c.Y);
                Console.Write(c.ToString());
            }           
        }
        public void SpawnRobots(int number)
        {
            for (int i = 0; i < number; i++)
            {
                FindNewEmptySpot();
                Robot robot = new Robot(x, y);
                elements.Add(robot);
                robots.Add(robot);
                field[x, y] = robot;
            }
        }
        public void SpawnTraps(int number)
        {
            for (int i = 0; i < number; i++)
            {
                FindNewEmptySpot();
                Trap trap = new Trap(x, y);
                elements.Add(trap);
                field[x, y] = trap;
            }
        }
        public bool MoveRobots ()
        {
            int index = 0;
            foreach (var r in robots)
            {
                Element.direction dir = BestMove(index);
                field[r.X, r.Y] = null;
                switch (dir)
                {
                    case Element.direction.north:
                        r.Y--;
                        break;
                    case Element.direction.south:
                        r.Y++;
                        break;
                    case Element.direction.west:
                        r.X--;
                        break;
                    case Element.direction.east:
                        r.X++;
                        break;

                    case Element.direction.southeast:
                        r.Y++;
                        r.X++;
                        break;
                    case Element.direction.northwest:
                        r.Y--;
                        r.X--;
                        break;
                    case Element.direction.southwest:
                        r.Y++;
                        r.X--;
                        break;
                    case Element.direction.northeast:
                        r.Y--;
                        r.X++;
                        break;
                    default:
                        break;
                }
                if (field[r.X, r.Y] is Player)
                    return true;
                if (field[r.X, r.Y] is Trap)
                {
                    elements.Remove(robots[index]);
                    robots.RemoveAt(index);

                    return false;
                }
                if (field[r.X, r.Y] is Robot)
                {
                    elements.Remove(robots[index]);
                    robots.RemoveAt(index);
                    elements.Remove(field[r.X, r.Y]);
                    robots.Remove(field[r.X, r.Y] as Robot);

                    return false;
                }                             
                field[r.X, r.Y] = r;
                index++;
            }
            return false;
        }
        public bool MovePlayer ()
        {
            field[player.X, player.Y] = null;
            string dir = Console.ReadLine();

            switch (dir)
            {
                case "n":
                    player.Y--;
                    break;
                case "s":
                    player.Y++;
                    break;
                case "w":
                    player.X--;
                    break;
                case "e":
                    player.X++;
                    break;

                case "se":
                    player.Y++;
                    player.X++;
                    break;
                case "nw":
                    player.Y--;
                    player.X--;
                    break;
                case "sw":
                    player.Y++;
                    player.X--;
                    break;
                case "ne":
                    player.Y--;
                    player.X++;
                    break;
                default:
                    break;
            }
            if (field[player.X, player.Y] is Element)
                return true;
            field[player.X, player.Y] = player;

            return false;
        }
        public PlayingField (int robotsNumber, int trapsNumber)
        {
            player = new Player();
            elements.Add(player);
            field[player.X, player.Y] = player;
            SpawnTraps(trapsNumber);
            SpawnRobots(robotsNumber);
            Print();
        }


        private void FindNewEmptySpot()
        {
            while (field[X, Y] != null)
            {
                int x = rng.Next(0, Console.WindowWidth);
                int y = rng.Next(0, Console.WindowHeight);
            }
        }
        private Element.direction BestMove (int index)
        {
            Robot robot = robots[index];
            Element.direction dir = Element.direction.east;
            if (robot.X == player.X)
            {
                if (robot.Y > player.Y)
                    return Element.direction.north;
                if (robot.Y < player.Y)
                    return Element.direction.south;
            }
            if (robot.Y == player.Y)
            {
                if (robot.X > player.X)
                    return Element.direction.west;
                if (robot.X < player.X)
                    return Element.direction.east;
            }
            if (robot.X < player.X)
            {
                if (robot.Y < player.Y)
                    return Element.direction.southeast;
                if (robot.Y > player.Y)
                    return Element.direction.northeast;
            }
            if (robot.X > player.X)
            {
                if (robot.Y < player.Y)
                    return Element.direction.southwest;
                if (robot.Y > player.Y)
                    return Element.direction.northwest;
            }

            return dir;
        }

    }
}
