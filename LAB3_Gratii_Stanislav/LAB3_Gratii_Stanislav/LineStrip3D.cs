using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Drawing;

namespace LAB3_Gratii_Stanislav
{
    internal class LineStrip3D
    {
        private float grosime;
        private Vector3 cordonataA;
        private Vector3 cordonataB;
        private Vector3 cordonataC;
        private Color culoare;

        public LineStrip3D()
        {
            //setare coordonate,grosime,culoare
            cordonataA = new Vector3(0, 0, 0);
            cordonataB = new Vector3(-2, 3, 0);
            cordonataC = new Vector3(-2, -3, 0);
            this.grosime = 6.0f;
            culoare = Color.Green;
        }

        public void DrawLineStrip()
        {
            GL.LineWidth(grosime);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(culoare);
            GL.Vertex3(cordonataA);
            GL.Color3(Color.Black);
            GL.Vertex3(cordonataB);
            GL.Color3(Color.Red);
            GL.Vertex3(cordonataC);

            GL.End();
        }
    }
}
