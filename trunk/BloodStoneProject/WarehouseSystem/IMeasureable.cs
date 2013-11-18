using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public interface IMeasureable
    {
        string Dimensions { get; set; }

        double Weight { get; set; }
    }
}
