using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public abstract class Element
    {
        private char Symbol { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        protected Element (char c, int x, int y)
        {
            Symbol = c;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
