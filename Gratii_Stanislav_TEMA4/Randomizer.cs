using OpenTK.Graphics;

using System;
using System.Drawing;

namespace Gratii_Stanislav_TEMA4
{
    internal class Randomizer
    {
        private Color4 culoare;
        private Random rando;

        public Randomizer()
        {
            rando = new Random();
        }

        public Color4 GenerateColor()
        {
            int genR = rando.Next(0, 255);
            int genG = rando.Next(0, 255);
            int genB = rando.Next(0, 255);
            float alpha = 0.5f; // Valoare de transparență

            Color4 culoare = new Color4(genR / 255.0f, genG / 255.0f, genB / 255.0f, alpha);
            return culoare;
        }
    }
}
