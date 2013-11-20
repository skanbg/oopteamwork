using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseSystem
{
    public abstract class Store
    {
        protected List<StoreObject> productsList = new List<StoreObject>();
        protected List<string> productCategories = new List<string>();

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

        public List<string> GetCategories
        {
            get
            {
                return this.productCategories;
            }
        }

        public abstract void LoadStore();
    }
}
