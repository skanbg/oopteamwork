using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseSystem
{
    public class MachineryObject : StoreObject, IMeasureable
    {
        private Dimensions dimensions;
        private double weight;
        public MachineryObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, Dimensions dimensions, double weight)
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
