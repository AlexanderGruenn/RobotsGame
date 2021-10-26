using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Simulation
    {
        PlayingField field;
        bool gameOver = false;
        
        



        public Simulation (int robotsNumber, int trapsNumber)
        {
            field = new PlayingField(robotsNumber, trapsNumber);
        }
    }
}
