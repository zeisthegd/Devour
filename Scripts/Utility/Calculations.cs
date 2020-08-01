using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Calculations
    {
        public static int RoundOff(int i)
        {
            return ((int)Math.Round(i / 10.0)) * 10;
        }
    }
}
