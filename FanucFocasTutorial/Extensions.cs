using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanucFocasTutorial1
{
    public static class Extensions
    {
        public static bool GetBit(this byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;

        }

        public static bool GetBit(this int b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }
    }
}
