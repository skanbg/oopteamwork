using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem
{
    public class ConstructionObject : StoreObject, IMeasureable
    {
        private Dimensions dimensions;
        private double weight;
            
        public ConstructionObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, Dimensions dimensions, double weight)
            : base(catalogueNumber, manufacturer, model,null,null, category, price)
        {
            this.dimensions = dimensions;
            this.weight = weight;
        }

        public Dimensions Dimensions
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
