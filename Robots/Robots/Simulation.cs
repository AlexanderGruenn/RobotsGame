using System;
using System.Collections.Generic;
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
        
        public void Run ()
        {
            while (true)
            {
                Console.Clear();
                gameOver = field.MoveRobots();
                if (gameOver)
                    break;
                field.Print();
                field.MovePlayer();
                field.Print();

            }
        }



        public Simulation (int robotsNumber, int trapsNumber)
        {
            field = new PlayingField(robotsNumber, trapsNumber);
        }
    }
}
