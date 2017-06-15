using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            WpfApplication1.Program.Main();


            Console.ReadKey();
        }
    }
}
