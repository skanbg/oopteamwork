using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GardenObject : StoreObject, IMeasureable
    {
        private string dimensions;
        private double weight;
        public GardenObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, string dimensions, double weight)
            : base(catalogueNumber, manufacturer, model,null,null, category, price)
        {
            this.dimensions = dimensions;
            this.weight = weight;
        }

        public string Dimensions
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double Weight
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
