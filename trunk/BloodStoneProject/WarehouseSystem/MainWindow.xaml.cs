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

namespace WarehouseSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        private static List<StoreObject> ItemContainer = new List<StoreObject>();
        public MainWindow()
        {
            InitializeComponent();
			
			
			// Some sample logics
            ItemContainer.Add(new ElectronicObject("34244", "Nokia", "n95", Branch.electronics, 150, Color.Black, 4.2, 120));
            ItemContainer.Add(new ElectronicObject("345fg", "Siemens", "C45", Branch.electronics, 150, Color.Black, 4.2, 120));
            ItemContainer.Add(new GardenObject("dfg343", "ne_znam", "09f", Branch.garden, 34, new Dimensions(45, 200), 3.5));

            List<string> categories = null;
            foreach (var item in ItemContainer)
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

            foreach (var category in categories)
            {
                    Button currentButton = new Button();
                    currentButton.Content = category;
                    currentButton.Width = 100;
                    this.CategoryStackPanel.Children.Add(currentButton);                 
            }
        }
    }
}
