using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Drawing;

namespace LAB3_Gratii_Stanislav
{
    internal class AxedeCoordonate
    {
        private float lineWidth;
        private Vector3 xAxisStart;
        private Vector3 xAxisEnd;
        private Vector3 yAxisStart;
        private Vector3 yAxisEnd;
        private Vector3 zAxisStart;
        private Vector3 zAxisEnd;
        private Color xAxisColor;
        private Color yAxisColor;
        private Color zAxisColor;

        public AxedeCoordonate()
        {
            
            xAxisStart = new Vector3(-10, 0, 0);
            xAxisEnd = new Vector3(10, 0, 0);
            yAxisStart = new Vector3(0, -10, 0);
            yAxisEnd = new Vector3(0, 10, 0);
            zAxisStart = new Vector3(0, 0, -10);
            zAxisEnd = new Vector3(0, 0, 10);

            lineWidth = 2.0f; 
            xAxisColor = Color.Red;
            yAxisColor = Color.Green;
            zAxisColor = Color.Blue;
        }

        public void DrawAxes()
        {
            GL.LineWidth(lineWidth);
            GL.Begin(PrimitiveType.LineStrip);

            // Desenarea axei X
            GL.Color3(xAxisColor);
            GL.Vertex3(xAxisStart);
            GL.Vertex3(xAxisEnd);

            // Desenarea axei Y
            GL.Color3(yAxisColor);
            GL.Vertex3(yAxisStart);
            GL.Vertex3(yAxisEnd);

            // Desenarea axei Z
            GL.Color3(zAxisColor);
            GL.Vertex3(zAxisStart);
            GL.Vertex3(zAxisEnd);

            GL.End();
        }
    }
}
