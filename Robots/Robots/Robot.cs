using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Robot : Figure
    {

        public Robot (int x, int y) : base('&', x, y)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
