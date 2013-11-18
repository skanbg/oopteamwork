using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SanitaryObject : StoreObject, IColorable
    {
        private Color color;
        public SanitaryObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, Color color)
            : base(catalogueNumber, manufacturer, model,null,null, category, price)
        {
            this.color = color;            
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
