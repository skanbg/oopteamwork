using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseSystem
{
    public interface IMeasureable
    {
        Dimensions Dimensions { get; set; }

        double Weight { get; set; }
    }
}
