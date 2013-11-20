using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseSystem
{
    public abstract class Store
    {
        protected List<StoreObject> productsList = new List<StoreObject>();
        protected List<string> productCategories = GetCategories();

        public Store()
        {
            LoadStore();
        }

        public void AddProduct(StoreObject product)
        {
            this.productsList.Add(product);
        }

        public List<StoreObject> GetAllProducts()
        {
            return this.productsList;
        }

        public static List<string> GetCategories()
        {
            var result = new List<string>();
            foreach (var item in Enum.GetValues(typeof(Branch)))
            {
                result.Add(item.ToString());
            }
         
            return result;
            
        }

        public abstract void LoadStore();
    }
}
