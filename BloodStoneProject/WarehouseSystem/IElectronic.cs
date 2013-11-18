using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem
{
    public interface IDigital
    {
        double Display { get; set; }

        int Capacity { get; set; }
    }
}
