using Gratii_Stanislav_Tema5;

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
        private Randomizer rando;
        private bool isGravity;
        private Color culoare;
        private List<Vector3> Listcoordonate;
        private const int Gravity_Offset = 1;

        private int size_offset;
        private int height_offset;
        private int radius_offset;
        /// <summary>
        /// 'Initializari
        /// </summary>
       public Cub3D()
        {
            rando=new Randomizer();
            culoare = rando.RandomColor();
            Listcoordonate= new List<Vector3>();
            size_offset=rando.RandomInt(3);
            height_offset=rando.RandomInt(25,32);
            radius_offset=rando.RandomInt(15,25 );
            Listcoordonate.Add(new Vector3(0 * size_offset + radius_offset, 0 * size_offset + height_offset, 1* size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(0 * size_offset + radius_offset, 0 * size_offset + height_offset, 0 * size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(1 * size_offset + radius_offset, 0 * size_offset + height_offset, 1 * size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(1 * size_offset + radius_offset, 0 * size_offset + height_offset, 0 * size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(1 * size_offset + radius_offset, 1 * size_offset + height_offset, 1 * size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(1 * size_offset + radius_offset, 1 * size_offset + height_offset, 0 * size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(0 * size_offset + radius_offset, 1 * size_offset + height_offset, 1 * size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(0 * size_offset + radius_offset, 1 * size_offset + height_offset, 0 * size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(0 * size_offset + radius_offset, 0 * size_offset + height_offset, 1 * size_offset + radius_offset));
            Listcoordonate.Add(new Vector3(0 * size_offset + radius_offset, 0 * size_offset + height_offset, 0 * size_offset + radius_offset));

            isGravity = true;
        }
        public void UpdatePosition()
        {
            if (isGravity&& !GroundDeteced())
            {
                for(int i=0;i<Listcoordonate.Count;i++)
                {
                    Listcoordonate[i] = new Vector3(Listcoordonate[i].X, Listcoordonate[i].Y - Gravity_Offset, Listcoordonate[i].Z);
                }
            }
        }
        public bool GroundDeteced()
        {
            foreach (Vector3 v in Listcoordonate)
            {
                if (v.Y <= 0)
                    return true;
            }
            return false;
        }
        public void DrawCube()
        {
            GL.Color3(culoare);
            GL.Begin(PrimitiveType.QuadStrip);
            foreach (Vector3 a in Listcoordonate)
            {
                GL.Vertex3(a);

            }
            GL.End();
        }
        public void ToggleGravity()
        {
            isGravity = !isGravity;
        }
        public void SetGravity()
        {
            isGravity = true;
        }
        public void UnSetGravity()
        {
            isGravity = false;
        }
    }
}
