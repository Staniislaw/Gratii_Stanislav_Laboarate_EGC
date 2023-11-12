using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;

namespace LAB3_Gratii_Stanislav
{
    internal class Randomizer
    {
        
        private Random r;
        public Randomizer() 
        {
            r=new Random();
        }
        public Color GenerateColor()
        {
            int genR=r.Next(0,255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);
            Color culoare =Color.FromArgb(genR, genG, genB);
            return culoare;
        }
       
       
    }
}
