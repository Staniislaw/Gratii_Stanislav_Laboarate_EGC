using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Drawing;

namespace LAB3_Gratii_Stanislav
{
    internal class LineLoop3D
    {
        private float grosime;
        private Vector3 cordonataA;
        private Vector3 cordonataB;
        private Vector3 cordonataC; // Adăugat un al treilea punct
        private Color culoare;

        public LineLoop3D()
        {
            //setare coordonate,grosime,culoare
            cordonataA = new Vector3(0, 0, 0);
            cordonataB = new Vector3(-2, -3, 0);
            cordonataC = new Vector3(2, -3, 0); // Coordonata C
            this.grosime = 6.0f;
            culoare = Color.Black;
        }

        public void DrawLineLoop()
        {
            GL.LineWidth(grosime);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(culoare);
            GL.Vertex3(cordonataA);
            GL.Vertex3(cordonataB);
            GL.Vertex3(cordonataC); // Adăugat coordonata C

            GL.End();
        }
    }
}
