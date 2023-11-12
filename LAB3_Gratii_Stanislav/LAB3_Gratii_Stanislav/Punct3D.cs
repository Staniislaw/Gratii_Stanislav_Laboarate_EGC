using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace LAB3_Gratii_Stanislav
{
    internal class Punct3D
    {
        private Vector3 pozitie;
        private Color culoare;
        private float size;
        public Punct3D(List<float>cordonate) 
        {
            //setare coordonate,culoare,marime
            pozitie= new Vector3(cordonate[0], cordonate[1], cordonate[2]);
            culoare = Color.Black;
            this.size = 15.0f;
        }
        public void DrawPoint()
        {
            GL.PointSize(size);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(culoare);
            GL.Vertex3(pozitie);
            GL.End();


        }
    }
}
