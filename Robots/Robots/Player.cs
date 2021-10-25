using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Player : Figure
    {

        public Player (int x, int y) : base('P', x, y)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
