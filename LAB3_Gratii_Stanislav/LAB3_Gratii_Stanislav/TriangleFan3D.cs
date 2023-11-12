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
    internal class TriangleFan3D
    {
        private Vector3 pointA;
        private Vector2 pointB;
        private Vector2 pointC;
        private Vector2 pointD;
        private Vector2 pointE;
        private Color color;
        private float linewidth;
        private float pointsize;

        public TriangleFan3D()
        {
            //setare coordonate,grosime,marime,culoare
            //Varful central
            this.pointA = new Vector3(0, 0, 0);
            //varfurile periferice
            this.pointB = new Vector2(-2, 3);
            this.pointC = new Vector2(2, 3);
            this.pointD = new Vector2(2, -3);
            this.pointE = new Vector2(-2, -3);
            linewidth = 3.0f;
            pointsize = 3.0f;
            color = Color.HotPink;


        }

        public void Draw()
        {
            GL.PointSize(pointsize);
            GL.LineWidth(linewidth);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(color);
            GL.Vertex3(pointA);
            GL.Vertex2(pointB);
            GL.Vertex2(pointC);
            GL.Vertex2(pointD);
            GL.Vertex2(pointE);
            GL.End();
        }

    }
}
