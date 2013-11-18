using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class AutoPartObject : StoreObject, IVehicle
    {
        private string aboutVehicle;
        public AutoPartObject(string catalogueNumber, string manufacturer, string model, Branch category, decimal price, string aboutVehicle)
            : base(catalogueNumber, manufacturer, model,null,null, category, price)
        {
            this.aboutVehicle = aboutVehicle;           
        }

        public string AboutVehicle
        {
            get { return this.aboutVehicle; }
            set { this.aboutVehicle = value; }
        }
    }
}
