using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WarehouseSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public static List<StoreObject> ItemContainer = new List<StoreObject>();
        public MainWindow()
        {
            InitializeComponent();
            DesktopStore desktopStore = new DesktopStore();
            this.DataContext = desktopStore;
            ItemContainer = desktopStore.GetAllProducts();

            LoadCategoryTabs();
            LoadCategories(desktopStore);
        }

        private void LoadCategories(DesktopStore desktopStore)
        {
            this.productCategories.ItemsSource = desktopStore.GetCategories();

            
        }

        private void LoadCategoryTabs()
        {
            List<string> categories = null;
            foreach (var item in MainWindow.ItemContainer)
            {
                if (categories == null)
                {
                    categories = new List<string>();
                }

                if (!categories.Contains(item.Category.ToString()))
                {
                    categories.Add(item.Category.ToString());
                }
            }

            CreateInnerTabsWithContent(categories);
        }

        private void CreateInnerTabsWithContent(List<string> categories)
        {
            foreach (var category in categories)
            {
                TabItem currentItem = new TabItem();
                currentItem.Header = category;
                var categoryStackPannel = new StackPanel();
                var categoryFilter =
                    from x in ItemContainer
                    where x.Category.ToString() == category.ToString()
                    select x;

                foreach (var item in categoryFilter)
                {
                    categoryStackPannel.Children.Add(new Label() { Content = item.ToString() });
                }
                currentItem.Content = categoryStackPannel;
                this.CategorySubContainer.Items.Add(currentItem);


                //Button currentButton = new Button();
                //currentButton.Content = category;
                //currentButton.Margin = new Thickness(3);
                //currentButton.Width = 100;
                //this.CategoryStackPanel.Children.Add(currentButton);
            }
        }

        private void ChangeValue(object sender, SelectionChangedEventArgs e)
        {
            
            switch (this.productCategories.SelectedIndex)
            {
                case 1: ElectronicObject eo = new ElectronicObject();
                    GenerateInputFields(eo);
                   break;
                case 2: ConstructionObject co = new ConstructionObject();
                   GenerateInputFields(co);
                   break;
                case 3: GardenObject go = new GardenObject();
                   GenerateInputFields(go);
                   break;
                case 4: SanitaryObject so = new SanitaryObject();
                   GenerateInputFields(so);
                   break;
                case 5: ToolObject to = new ToolObject();
                   GenerateInputFields(to);
                   break;
                case 6: MachineryObject mo = new MachineryObject();
                   GenerateInputFields(mo);
                   break;
                case 7: AutoPartObject ao = new AutoPartObject();
                   GenerateInputFields(ao);
                   break;                
                default:
                    break;
            } 
            
        }

        private void GenerateInputFields(StoreObject obj)
        {
            AddTabChildStack.Children.RemoveRange(1, AddTabChildStack.Children.Count -1);
            var list =  obj.GetType().GetProperties();
            

            foreach (var item in list)
	        {
                this.AddTabChildStack.Children.Add(new Label { Content = item.Name });
                if(item.PropertyType.Name == "Branch")
                {
                    this.AddTabChildStack.Children.Add(new TextBox { Text = this.productCategories.SelectedItem.ToString(), Width = 150, 
                        HorizontalAlignment = HorizontalAlignment.Left , Margin = new Thickness(10,0,0,3)});
                }
                else if(item.PropertyType.Name == "Color")
                {
                    var colors = new List<string>();
                    
                    foreach (var color in Enum.GetValues(typeof(Color)))
                    {
                        colors.Add(color.ToString());
                    }
                    this.AddTabChildStack.Children.Add(new ComboBox { ItemsSource = colors,Width = 150, 
                        HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10,0,0,3) });
                }
                else if (item.PropertyType.Name == "Material")
                {
                    var materials = new List<string>();

                    foreach (var material in Enum.GetValues(typeof(Material)))
                    {
                        materials.Add(material.ToString());
                    }
                    this.AddTabChildStack.Children.Add(new ComboBox { ItemsSource = materials, Width = 150, 
                        HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10,0,0,3)});
                }
                else
                {
                    this.AddTabChildStack.Children.Add(new TextBox
                    {   MaxLength = 20,       
                        Width = 150,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(10, 0, 0, 3)
                    });
                }
	        }
        }
    }
}
