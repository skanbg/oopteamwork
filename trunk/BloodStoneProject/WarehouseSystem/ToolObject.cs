using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class ToolObject : StoreObject, IMaterial
    {
        private Material material;
        public ToolObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, Material material)
            : base(catalogueNumber, manufacturer, model,null,null, category, price)
        {
            this.material = material;            
        }

        public Material Material
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
