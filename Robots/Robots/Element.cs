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
        private int X { get; set; }
        private int Y { get; set; }

        protected Element (char c)
        {
            Symbol = c;
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
