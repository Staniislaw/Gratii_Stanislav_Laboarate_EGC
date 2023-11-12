using ConsoleApp3;

using Gratii_Stanislav_TEMA4;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gratii_Stanislav_Tema5
{
    internal class Window3D : GameWindow
    {
        private readonly Color DEFAULT_BKG_COLOR = Color.FromArgb(49, 50, 51);
        private Axes axe;
       
        private MouseState previousMouse;

        private List<Cub3D> listCuburi;

        private Vector3 position = new Vector3(80, 50, 50);
        private Vector3 front = new Vector3(0.0f, 0.0f, -1.0f); // Vectorul front pentru direcția camerei
        private float speed = 5.0f;
        private Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);



        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 4))
        {
            DipslayHELP();
            VSync = VSyncMode.On;
            axe = new Axes();
            
            listCuburi=new List<Cub3D>();

        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.ClearColor(DEFAULT_BKG_COLOR);
            /*ViewPort*/
            GL.Viewport(0, 0, Width, Height);
            /*Setare perpectiva*/
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, this.Width / this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // Actualizează matricea de vizualizare cu poziția camerei și vectorul front
            front = Vector3.Normalize(new Vector3(0, 0, 0) - position);
            Matrix4 camera = Matrix4.LookAt(position, position + front, new Vector3(0, 1, 0));
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState currentKey = Keyboard.GetState();
            MouseState currentMouse= Mouse.GetState();
            if (currentKey[Key.Escape])
            {
                Exit();
            }
            if (currentKey.IsKeyDown(Key.W))
            {
                position += front * speed * (float)e.Time; // Înainte
            }
            if (currentKey.IsKeyDown(Key.S))
            {
                position -= front * speed * (float)e.Time; // Înapoi
            }
            if (currentKey.IsKeyDown(Key.A))
            {
                Vector3 right = Vector3.Normalize(Vector3.Cross(front, new Vector3(0, 1, 0)));
                position -= right * speed * (float)e.Time; // Stânga
            }
            if (currentKey.IsKeyDown(Key.D))
            {
                Vector3 right = Vector3.Normalize(Vector3.Cross(front, new Vector3(0, 1, 0)));
                position += right * speed * (float)e.Time; // Dreapta
            }

            if (currentKey.IsKeyDown(Key.Left))
            {
                float rotationSpeed = 0.5f; // Definește viteza de rotație
                float rotationAngle = rotationSpeed * (float)e.Time; // Calculează unghiul de rotație bazat pe timp

                // Rotirea camerei în jurul axei Y  
                Vector3 newFront = Vector3.Transform(front, Matrix3.CreateFromAxisAngle(up, rotationAngle));

                front = newFront;
            }
            if (currentKey.IsKeyDown(Key.Right))
            {
                float rotationSpeed = 0.5f; // Definește viteza de rotație
                float rotationAngle = rotationSpeed * (float)e.Time; // Calculează unghiul de rotație bazat pe timp

                // Rotirea camerei în sens invers în jurul axei Y
                Vector3 newFront = Vector3.Transform(front, Matrix3.CreateFromAxisAngle(up, -rotationAngle));

                front = newFront;
            }
            if (currentKey[Key.X])
            {
                DisplayCameraInfo();
            }
            if (currentKey.IsKeyDown(Key.Plus))
            {
                //Camera Position: 36,67327, 26,69757, 37,73595
                // Camera Direction: -0,589917, -0,4, -0,6099164
                position = new Vector3(36.67327f, 26.69757f, 37.73595f);
                front = new Vector3(-0.55f,-0.6f,-0.6f);
            }
            if (currentKey.IsKeyDown(Key.Minus))
            {
                /*
                 * Camera Position: 69.6734, 62.69749, 73.73573
                    Camera Direction: -0.55, -0.6, -0.6
                 */
                position = new Vector3(69.6734f, 62.69749f, 73.73573f);
                front = new Vector3(-0.55f, -0.6f, -0.6f);
            }
            if (currentMouse[MouseButton.Left]&& !previousMouse[MouseButton.Left])
            {
                listCuburi.Add(new Cub3D());
            }
            foreach(Cub3D cub in listCuburi)
            {
                cub.UpdatePosition();
            }
            previousMouse = currentMouse;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            Vector3 target = position + front;
            axe.Draw();
            


            foreach (Cub3D cub in listCuburi)
            {
                cub.DrawCube();
            }
            
            Matrix4 view = Matrix4.LookAt(position, position + front, up);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref view);
            SwapBuffers();
        }
        private void DipslayHELP()
        {
            Console.Clear();
            Console.WriteLine("==================== HELP ====================");
            Console.WriteLine("=======Modificare Camera (W,A,S,D,<-,->)======");
            Console.WriteLine("=======Generare Cub nou (click Mouse stanga)==");
            Console.WriteLine("=======Repoziționare camera “aproape” (+)==");
            Console.WriteLine("=======Repoziționare camera “aproape” (-)==");
        



        }
        private void DisplayCameraInfo()
        {
            Console.WriteLine($"Camera Position: {position.X}, {position.Y}, {position.Z}");
            Console.WriteLine($"Camera Direction: {front.X}, {front.Y}, {front.Z}");
        }

    }
}
