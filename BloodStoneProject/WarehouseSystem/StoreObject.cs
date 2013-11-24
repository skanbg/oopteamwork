using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem
{
    public abstract class StoreObject : IStoreObject
    {

        #region AbstractClassProperties
        public string CatalogueNumber { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
        public Branch Category { get; set; }

        public decimal Price { get; set; }
        #endregion

        #region AbstractClassConstructors
        protected StoreObject()
        {

        }
        public StoreObject(string catalogueNumber, string manufacturer, string model, string description, int quantity, Branch category, decimal price)
        {
            this.CatalogueNumber = catalogueNumber;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Description = description;
            this.Category = category;
            this.Quantity = quantity;
            this.Price = price;
        }
        #endregion

        public override string ToString()
        {
            var result = new StringBuilder();

            var props = this.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (prop != null)
                {
                    result.AppendLine(new string(' ', 3) + prop.Name +": "+ prop.GetValue(this, null));
                }
            }

            return result.ToString();
        }
    }
}
