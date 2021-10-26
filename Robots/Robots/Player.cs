using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Player : Figure
    {

        public Player () : base('@', Console.WindowWidth / 2, Console.WindowHeight / 2)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
