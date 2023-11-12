
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*              Grupa
 *              3131B
 * 
 *              
 * 
 *                      Gratii Stanislav
 */
namespace LAB3_Gratii_Stanislav
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (Window3D wnd = new Window3D())
            {
                wnd.Run(30.0, 0.0);
            }
        }
    }
}
