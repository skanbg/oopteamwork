using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseSystem
{
    public class AutoPartObject : StoreObject, IVehicle
    {
        private string aboutVehicle { get; set; }

        public AutoPartObject()
        {

        }

        public AutoPartObject(string catalogueNumber, string manufacturer, string model, string description, int quantity, Branch category, decimal price, string aboutVehicle)
            : base(catalogueNumber, manufacturer, model, description, quantity, category, price)
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
