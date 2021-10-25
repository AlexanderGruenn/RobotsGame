using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Trap : Element
    {
        
        public Trap (int x, int y) : base ('#', x, y)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
