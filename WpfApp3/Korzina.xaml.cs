using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.appData;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Korzina.xaml
    /// </summary>
    public partial class Korzina : Page
    {
        private Korzina korzina;

        public Korzina()
        {
            InitializeComponent();
            korzina = App.korzina;
            DataContext = korzina;
            contolProduct = App.ContolProduct; 
            Update();
        }
        ContolProduct contolProduct = App.ContolProduct;

        void Update()
        {
            DGG.ItemsSource = null;
            //var up = ConDB.context.Orders.Select(x=>
            //new
            //{
            //    Q = x.OrderID

            //}).ToList();
            //DGG.ItemsSource = up;
            
            DGG.ItemsSource = contolProduct?.Pr;

        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            contolProduct.RemoveFromCart((Products)DGG.SelectedItem);
            Update();
        }

        private void DGG_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void otchet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
