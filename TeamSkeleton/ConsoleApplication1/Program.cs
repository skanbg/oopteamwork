using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle part = new AutoPartObject("0983904", "Valeo", "Lp45", Branch.auto, 34, "Citroen");
        }
    }
}
