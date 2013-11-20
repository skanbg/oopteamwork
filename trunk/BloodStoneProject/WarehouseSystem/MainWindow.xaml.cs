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
    }
}
