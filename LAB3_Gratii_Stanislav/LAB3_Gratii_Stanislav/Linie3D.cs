using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3_Gratii_Stanislav
{
    internal class Linie3D
    {
        private float grosime;
        private Vector3 cordonataA;
        private Vector3 cordonataB;
        private Color culoare;
        public Linie3D(List<float> coordonate)
        {
            //setare coordonate,grosime,culoare
            cordonataA = new Vector3(coordonate[0], coordonate[1], coordonate[2]);
            cordonataB = new Vector3(coordonate[3], coordonate[4], coordonate[5]);
            this.grosime = 6.0f;
            culoare = Color.MediumVioletRed;
        }

        public void DrawLine()
        {

            GL.LineWidth(grosime);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(culoare);
            GL.Vertex3(cordonataA);
            GL.Vertex3(cordonataB);
           
            GL.End();
        }
    }
}
