using OpenTK;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using System.Security.Cryptography;

namespace Gratii_Stanislav_TEMA4
{
    internal class Window3D:GameWindow
    {
        private Cub3D cub3D;
        private AxeDeCoorodnate axes;

        private Randomizer rando;
        private KeyboardState previousKey;
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            /*anti-aliasing-ul*/
            VSync = VSyncMode.On;
            cub3D = new Cub3D();
            DisplayMenu();
            rando=new Randomizer();
            axes = new AxeDeCoorodnate(); 
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            /*actvare transparenta*/
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc((BlendingFactor)BlendingFactorSrc.SrcAlpha, (BlendingFactor)BlendingFactorDest.OneMinusSrcAlpha);

            GL.Hint(HintTarget.PointSmoothHint,HintMode.Nicest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
           
            base.OnResize(e);
            /*Setare culoare*/
            GL.ClearColor(Color.LightBlue);
            /*ViewPort*/
            GL.Viewport(0, 0, Width, Height);
            /*Setare perpectiva*/
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, this.Width / this.Height, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            /*Setare camera*/
            Matrix4 camera = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            /*Codul logic*/
            KeyboardState currentKey=Keyboard.GetState();
            if (currentKey[Key.Escape])
            {
                Exit();
            }
            if (currentKey[Key.H] && !previousKey[Key.H]) 
            {
                DisplayMenu();
            }

            if (currentKey[Key.D] && !previousKey[Key.D])
            {
                cub3D.ChangeCub(new Vector3(2,2,2),new Vector3(0,0,0));
            }

            if (currentKey[Key.ControlLeft]&&currentKey[Key.R] && !previousKey[Key.R])
            {
                cub3D.ChangeFaceColor(0, rando.GenerateColor());
                cub3D.ChangeFaceColor(1, rando.GenerateColor());
                cub3D.ChangeFaceColor(2, rando.GenerateColor());
                cub3D.ChangeFaceColor(3, rando.GenerateColor());
                cub3D.ChangeFaceColor(4, rando.GenerateColor());
                cub3D.ChangeFaceColor(5, rando.GenerateColor());
            }if (currentKey[Key.I] && !previousKey[Key.I])
            {
                cub3D.PrintRGBValues();
            }

            previousKey = currentKey;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            cub3D.DrawCube();
            axes.Draw();
            SwapBuffers();
        }
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("========MENU========(H)");
            Console.WriteLine("-----Change Color----(ctrl+R)");
            Console.WriteLine("-----Mareste Cub----(D)");
            Console.WriteLine("-----Info RGB----(I)");
            
        }

    }
}
