using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IStoreObject
    {
        string CatalogueNumber { get; set; }

        string Manufacturer { get; set; }

        string Model { get; set; }

        string Description { get; set; }

        int? Quantity { get; set; }

        Branch Category { get; set; }

        decimal Price { get; set; }

    }
}
