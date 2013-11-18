using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem
{
    public class ElectronicObject : StoreObject, IDigital, IColorable
    {
        private double display;
        private int capacity;
        private Color color;
        public ElectronicObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, Color color, double display, int capacity)
            : base(catalogueNumber, manufacturer, model,null,null, category, price)
        {
            this.display = display;
            this.capacity = capacity;
            this.color = color;
        }

        public double Display
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

        public int Capacity
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

        public Color Color
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
