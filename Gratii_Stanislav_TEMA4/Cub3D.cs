using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratii_Stanislav_TEMA4
{
    internal class Cub3D
    {
        private Color4 culoare;  // Am schimbat tipul de la Color la Color4
        private int vertexIndex;
        private Vector3[] vertices = new Vector3[]
        {
            /*cubul nostru*/
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f)
        };
        private Color4[] culoriFete = new Color4[]
         {
            new Color4(1.0f, 0.0f, 0.0f, 0.5f),    // culoarea pentru fata (roșu cu opacitate 0.5)
            new Color4(0.0f, 1.0f, 0.0f, 0.5f),    // culoarea pentru spate (verde cu opacitate 0.5)
            new Color4(0.0f, 0.0f, 1.0f, 0.5f),    // culoarea pentru stanga (albastru cu opacitate 0.5)
            new Color4(1.0f, 1.0f, 0.0f, 0.5f),    // culoarea pentru dreapta (galben cu opacitate 0.5)
            new Color4(1.0f, 1.0f, 1.0f, 0.5f),    // culoarea pentru sus (alb cu opacitate 0.5)
            new Color4(0.5f, 0.5f, 0.5f, 0.5f)     // culoarea pentru jos (gri cu opacitate 0.5)
         };

        private Vector3 vertex;
        private int[][] faces = new int[][]
        {
            new int[] { 0, 1, 2, 3 }, // fata
            new int[] { 4, 5, 6, 7 }, // spate
            new int[] { 0, 4, 7, 3 }, // stanga
            new int[] { 1, 5, 6, 2 }, // dreapta
            new int[] { 0, 1, 5, 4 }, // sus
            new int[] { 2, 3, 7, 6 }  // jos
        };
        public Cub3D()
        {

            this.vertexIndex = 0;
            this.vertex = vertices[vertexIndex];
        }
        public void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            for (int i = 0; i < faces.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    vertexIndex = faces[i][j];
                    vertex = vertices[vertexIndex];
                    GL.Color4(culoriFete[i]); 
                    GL.Vertex3(vertex);
                }
            }

            GL.End();
        }
        public void ChangeCub(Vector3 scale, Vector3 position)
        {

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] *= scale;
                vertices[i] += position;
            }

        }
        public void PrintRGBValues()
        {
           /*Afisare Valori RGB pentru fiecare partea a cubului*/
            Console.Clear();
            Console.WriteLine("======Menu=====(H)"); 
            for (int i = 0; i < culoriFete.Length; i++)
            {
                Color4 culoare = culoriFete[i];
                
                Console.WriteLine($"Parte a cubului: {i + 1} (R, G, B): ({culoare.R}, {culoare.G}, {culoare.B})");
            }
        }
        public void ChangeFaceColor(int faceIndex, Color4 newColor)
        {
            /*Schimbare culori*/
            if (faceIndex >= 0 && faceIndex < culoriFete.Length)
            {
                culoriFete[faceIndex] = newColor;
            }
        }
    }
}
