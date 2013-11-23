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
        ~DesktopStore()
        {
            try
            {
                SaveStore();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
        public override void LoadStore()
        {
            #region Scrap code
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
            #endregion
            try
            {
                //Loading products from file
                var productReader = new StreamReader("ProductList.txt");
                using (productReader)
                {
                    string productToken = productReader.ReadLine();

                    while (productToken != null)
                    {
                        #region Scrap code
                        //var roughProductsData = productReader.ReadToEnd();
                        ////Each product on new line
                        //var splitedProducts = roughProductsData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        //System.Windows.MessageBox.Show(splitedProducts[0]);
                        //foreach (var productToken in splitedProducts)
                        //{
                        #endregion
                        //System.Windows.MessageBox.Show(productToken);
                        //Splitting product type from product properties
                        var splitedProductProperties = productToken.Split(new string[] { " ~obj~ " }, StringSplitOptions.RemoveEmptyEntries);
                        Type classType = Type.GetType("WarehouseSystem." + splitedProductProperties[0].Trim(), true);
                        //var userSettings = classType;
                        //WD
                        //var userSettings = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == splitedProductProperties[0]);
                        var currentSettings = Activator.CreateInstance(classType);
                        splitedProductProperties = splitedProductProperties[1].Split(new string[] { " ~|~ " }, StringSplitOptions.RemoveEmptyEntries);
                        //System.Windows.MessageBox.Show(splitedProductProperties.Length.ToString());
                        int counter = 0;
                        foreach (var productProperty in splitedProductProperties)
                        {
                            counter++;
                            //System.Windows.MessageBox.Show(counter.ToString());
                            var propertyInfos = productProperty.Split(new string[] { "~~" }, StringSplitOptions.RemoveEmptyEntries);
                            var property = classType.GetProperty(propertyInfos[0]);
                            var type = property.PropertyType;
                            dynamic newValue;
                            //System.Windows.MessageBox.Show(String.Format("{0}: {1}", type.Name, propertyInfos[1]));
                            if (type.Name == "Branch")
                            {
                                newValue = Enum.Parse(typeof(Branch), propertyInfos[1]);
                            }
                            else if (type.Name == "Material")
                            {
                                newValue = Enum.Parse(typeof(Material), propertyInfos[1]);
                            }
                            else if (type.Name == "Color")
                            {
                                newValue = Enum.Parse(typeof(Color), propertyInfos[1]);
                            }
                            else if (type.Name == "Dimensions")
                            {
                                var dimensions = propertyInfos[1].Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);
                                newValue = new Dimensions(double.Parse(dimensions[0]), double.Parse(dimensions[1]));
                            }
                            else
                            {
                                newValue = Convert.ChangeType(propertyInfos[1], type);
                            }
                            property.SetValue(currentSettings, newValue);
                            # region Scrap code
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
                            # endregion
                        }
                        this.AddProduct(currentSettings as StoreObject);
                        productToken = productReader.ReadLine();
                        //this.productCategories.Add(category);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        public override void SaveStore()
        {
            //System.Windows.MessageBox.Show("Count of products on exit(save) is: " + this.productsList.Count().ToString());
            var productsWriter = new StreamWriter("ProductList.txt");
            using (productsWriter)
            {
                foreach (var product in this.productsList)
                {
                    StringBuilder productsStream = new StringBuilder();
                    productsStream.AppendFormat("{0} ~obj~ ", product.GetType().Name);
                    var classType = product.GetType();
                    bool isItFirstProp = true;
                    foreach (var property in classType.GetProperties())
                    {
                        if (isItFirstProp)
                        {
                            productsStream.AppendFormat("{0}~~{1}", property.Name, property.GetValue(product).ToString());
                            isItFirstProp = false;
                        }
                        else
                        {
                            productsStream.AppendFormat(" ~|~ {0}~~{1}", property.Name, property.GetValue(product).ToString());
                        }
                    }
                    productsWriter.Write(productsStream);
                }
            }
        }
    }
}
