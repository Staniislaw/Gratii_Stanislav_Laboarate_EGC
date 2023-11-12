using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Drawing;

namespace LAB3_Gratii_Stanislav
{
    internal class TriangleStrip3D
    {
        private Vector3[] vertices;
        private Color color;
        private float linewidth;
        private float pointsize;
        private Randomizer _r;
        private Color[] colors;
        public TriangleStrip3D()
        {// setare coordonate,grosime,marime,culoare
            _r = new Randomizer();
            vertices = new Vector3[]
            {
                new Vector3(0+4, 0, 0),   // Vârful A
                new Vector3(-2+4, 3, 0),  // Vârful B
                new Vector3(2+4, 3, 0),   // Vârful C
                new Vector3(2+4, -3, 0),  // Vârful D
                new Vector3(-2+4, -3, 0)  // Vârful E
            };
            linewidth = 3.0f;
            pointsize = 3.0f;
            color = Color.HotPink;
            
            colors = new Color[]
            {
                _r.GenerateColor(),
                _r.GenerateColor(),
                 _r.GenerateColor(),
                _r.GenerateColor(),
                _r.GenerateColor()
            };
        }
        
        public void Draw()
        {
            GL.PointSize(pointsize);
            GL.LineWidth(linewidth);
            GL.Begin(PrimitiveType.TriangleStrip);
            // Desenarea triunghiului strip folosind vârfurile
            for (int i = 0; i < vertices.Length; i++)
            {
                GL.Color3(colors[i]);
                GL.Vertex3(vertices[i]);
            }

            GL.End();
        }
        public void ChangeColor()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                colors[i] = _r.GenerateColor();
            }
        }
        public void MoveRight(KeyboardState key1)
        {
            if (key1[Key.D])
            {
                for (int i = 0; i < vertices.Length; i++)
                {
                    vertices[i] = new Vector3(vertices[i].X + 2, vertices[i].Y, vertices[i].Z);
                    //daca este apasata tasta D deplasam cu 2 untiati la dreapta
                }
            }
            else if (key1[Key.A])
            {
                for (int i = 0; i < vertices.Length; i++)
                {
                    vertices[i] = new Vector3(vertices[i].X - 2, vertices[i].Y, vertices[i].Z);
                    //daca este apasata tasta A deplasam cu 2 untiati la stanga
                }
            }
            
        }

        public Vector3[] GetVertices
        {
            get { return vertices; }
        }

        public Color[] GetColors
        {
            get { return colors; }
        }
    }
}
