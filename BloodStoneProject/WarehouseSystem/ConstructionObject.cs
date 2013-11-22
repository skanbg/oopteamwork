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
            
        public ConstructionObject()
        {

        }

        public ConstructionObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, Dimensions dimensions, double weight)
            : base(catalogueNumber, manufacturer, model,null,null, category, price)
        {
            this.dimensions = dimensions;
            this.weight = weight;
        }

        #region Properties
        public Dimensions Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        } 
        #endregion
    }
}
