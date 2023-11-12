using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Gratii_Stanislav_Tema5
{
    internal class Randomizer
    {
        private Random r;
        public Randomizer()
        {
            r= new Random();
        }
        public Color RandomColor()
        {
            int genR = r.Next(0,255);
            int genG = r.Next(0,255);
            int genB = r.Next(0,255);
            Color col=Color.FromArgb(genR,genG,genB);
            return col;
        }
        public int RandomInt(int maxVal)
        {
            return r.Next(maxVal);
        }
        public int RandomInt(int minVal,int maxVal)
        {
            return r.Next(minVal,maxVal);
        }
    }
}
