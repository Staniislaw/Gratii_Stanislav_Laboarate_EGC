using OpenTK;
using OpenTK.Graphics.OpenGL;

using System.Drawing;

namespace ConsoleApp4
{
    class Triunghi3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Color color;
        private float linewidth;
        private float pointsize;

     //   private PolygonMode polMode;

        public Triunghi3D()
        {
            //setare coordonate,grosime,marime,culoare
            pointA = new Vector3(0,0,0);
            pointB = new Vector3(-2,-3,0);
            pointC = new Vector3(-2,3,0);
            color = Color.DeepPink;

            Inits();
        }

        private void Inits()
        {
   
            linewidth = 3.0f;
            pointsize = 3.0f;
          
        }

        public void Draw()
        {
           
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
              
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(color);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.Vertex3(pointC);
                GL.End();
            
        }




       

    }
}
