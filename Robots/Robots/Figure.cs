using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public abstract class Figure : Element
    {
        protected Figure (char c, int x, int y) : base (c, x, y)
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
