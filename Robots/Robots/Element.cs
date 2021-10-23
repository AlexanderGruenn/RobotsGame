using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public abstract class Element
    {
        public char Symbol { get; private set; }


        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
