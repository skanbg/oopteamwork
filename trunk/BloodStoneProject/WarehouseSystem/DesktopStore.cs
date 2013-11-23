using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows;

namespace WarehouseSystem
{
    public class DesktopStore : Store
    {
        public override void LoadStore()
        {

            //Loading product categories from file
            //var categoriesReader = new StreamReader("ProductCategories.txt");
            //var roughCategoriesData = categoriesReader.ReadToEnd();
            //var splitedCategories = roughCategoriesData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var category in splitedCategories)
            //{
            //    this.productCategories.Add(category);
            //}

            //Loading product categories from enumeration Branch
            //foreach (var category in Enum.GetValues(typeof(Branch)))
            //{
            //    this.productCategories.Add(category.ToString());
            //}

            //Loading products from file
            var productReader = new StreamReader("ProductList.txt");
            var roughProductsData = productReader.ReadToEnd();
            //Each product on new line
            var splitedProducts = roughProductsData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (var productToken in splitedProducts)
                {
                    //Splitting product type from product properties
                    var splitedProductProperties = productToken.Split(new string[] { " ~obj~ " }, StringSplitOptions.RemoveEmptyEntries);
                    Type classType = Type.GetType("WarehouseSystem." + splitedProductProperties[0].Trim(), true);
                    //var userSettings = classType;
                    //Raboti i s dolnoto
                    //var userSettings = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == splitedProductProperties[0]);
                    var currentSettings = Activator.CreateInstance(classType);
                    splitedProductProperties = splitedProductProperties[1].Split(new string[] { " ~|~ " }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var productProperty in splitedProductProperties)
                    {
                        var propertyInfos = productProperty.Split(new string[] { "~~" }, StringSplitOptions.RemoveEmptyEntries);
                        var property = classType.GetProperty(propertyInfos[0]);
                        var type = property.PropertyType;
                        dynamic newValue;
                        if(type.Name=="Branch")
                        {
                            newValue = (Branch)int.Parse(propertyInfos[1]);
                        }
                        else
                        {
                            newValue = Convert.ChangeType(propertyInfos[1], type);
                        }
                        property.SetValue(currentSettings, newValue);
                        
                        //var userSettingsTypeProperties = currentSettings.GetType().GetProperty(propertyInfos[0]).GetValue(currentSettings, null).ToString();
                        //System.Windows.MessageBox.Show(userSettingsTypeProperties);


                        ////PropertyInfo prop = classType.GetProperty(propertyInfos[0]);
                        //var prop = classType.GetType().GetProperty(propertyInfos[0]);
                        //System.Windows.MessageBox.Show(propertyInfos[0]);

                        ////////var property = classType.GetProperty(propertyInfos[0]);
                        ////////var type = property.PropertyType;
                        ////////var newValue = Convert.ChangeType(propertyInfos[1], type);
                        ////////property.SetValue(product, newValue);


                        //////////prop.SetValue(product, propertyInfos[1], null);
                        //////////product.GetType().GetProperty(propertyInfos[0]).SetValue(product, propertyInfos[1], null);
                    }
                    this.AddProduct(currentSettings as StoreObject);
                    //this.productCategories.Add(category);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            //System.Windows.MessageBox.Show(this.productsList.Count.ToString());
            //System.Windows.MessageBox.Show(this.productsList[2].Model);
        }

        public static void LoadProduct()
        {
            throw new NotImplementedException();
        }
    }
}
