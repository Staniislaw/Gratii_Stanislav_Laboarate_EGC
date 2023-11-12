using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using ConsoleApp4;
using OpenTK.Input;

namespace LAB3_Gratii_Stanislav
{
    internal class Window3D:GameWindow
    {
        private KeyboardState previousKey;
        private Punct3D punct;
        private Linie3D linie;
        private LineLoop3D lineLoop;
        private LineStrip3D lineStrip;
        private Triunghi3D triunghi;
        private TriangleFan3D triunghifan;
        private TriangleStrip3D triunghistrip;
        private List<float> coordonate,coordonateLinie;
        private AxedeCoordonate AxeDeCoordonate;
        private Randomizer rando;

        public Window3D() :base(800,600,new GraphicsMode(32,24,0,4))
        
        {
            VSync = VSyncMode.On;
            DisplayHelp();
            rando = new Randomizer();
            coordonate = [0,0,0];
            //initializari
            punct = new Punct3D(coordonate);
            
            coordonateLinie = [0,0,0,2,3,0];
            linie = new Linie3D(coordonateLinie);
            
            lineLoop = new LineLoop3D();

            lineStrip = new LineStrip3D();

            triunghi = new Triunghi3D();
            triunghifan= new TriangleFan3D();
            triunghistrip=new TriangleStrip3D();
            AxeDeCoordonate=new AxedeCoordonate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.ClearColor(Color.LightSkyBlue);

            GL.Viewport(0, 0, this.Width, this.Height);


            // setare perspectiva
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // setare camera
            Matrix4 camera = Matrix4.LookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);


        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //Cod logic
            KeyboardState currentkeyboardState = Keyboard.GetState();
            MouseState mousestate = Mouse.GetState();

            if (currentkeyboardState[Key.Escape])
            {
                Exit();
            }
            if (currentkeyboardState[Key.H] && !previousKey[Key.H])
            {
                DisplayHelp();
            }
            if (currentkeyboardState[Key.C] && !previousKey[Key.C])
            {
                triunghistrip.ChangeColor();
            }
            if (currentkeyboardState[Key.D] && !previousKey[Key.D] || currentkeyboardState[Key.A]  && !previousKey[Key.A])
            {
                triunghistrip.MoveRight(currentkeyboardState);
            }
            if (currentkeyboardState[Key.M] && !previousKey[Key.M])
            {
                Console.Clear();
                Console.WriteLine("     Info Culori RGB");
                for(int i=0;i<triunghistrip.GetVertices.Length;i++)
                {
                    Console.WriteLine("pentru vertex[" + i+1 + "]" + "->RGB: " + triunghistrip.GetColors[i]);
                }
                Console.WriteLine("\n\n     H ---------> Help menu");

            }

            previousKey = currentkeyboardState;
            //end cod logic
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);


            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
           
            
            // RENDER CODE  
            punct.DrawPoint();
            linie.DrawLine();
            lineLoop.DrawLineLoop();
            lineStrip.DrawLineStrip();
            triunghi.Draw();
            triunghifan.Draw();
            triunghistrip.Draw();
            AxeDeCoordonate.DrawAxes();
            // END RENDER CODE

            SwapBuffers();

        }

        private void DisplayHelp()
        {
            Console.Clear();
            Console.WriteLine("         HELP" );
            Console.WriteLine("ESC -------> iesire program");
            Console.WriteLine("H ---------> Help menu");
            Console.WriteLine("C ---------> Change color");
            Console.WriteLine("A ---------> Deplasare Stanga");
            Console.WriteLine("D ---------> Deplasare Dreapta");
            Console.WriteLine("C ---------> Change Color");
            Console.WriteLine("M ---------> Afisare info RGB");

        }
       
    }
}
