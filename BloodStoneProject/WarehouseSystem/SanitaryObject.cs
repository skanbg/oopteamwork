using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem
{
    public class SanitaryObject : StoreObject, IColorable
    {
        private Color color;

        public SanitaryObject()
        {

        }


        public SanitaryObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, Color color)
            : base(catalogueNumber, manufacturer, model,null,null, category, price)
        {
            this.color = color;            
        }
    
        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
    }
}
