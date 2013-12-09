
namespace WarehouseSystem
{
    using System;
    using System.Windows;
    public partial class MainWindow : Window
    {
        public static DesktopStore InstanceStore = new DesktopStore();

        public MainWindow()
        {
            InitializeComponent();            
            Renderer renderer = new Renderer(this);
            renderer.Render();
        }
    }
}
