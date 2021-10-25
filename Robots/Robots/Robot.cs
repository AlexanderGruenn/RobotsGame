using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Robot : Figure
    {

        public Robot() : base('&')
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
