using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            update();
        }
        ContolProduct contol = App.ContolProduct;

        void update()
        {
            var up = ConDB.context.Products.ToList();
            string countDb = up.Count.ToString();
            up = up.Where(x => x.ProductName.ToLower().Contains(txtb.Text.ToLower())).ToList();
            switch (CMB.SelectedIndex)
            {
                case 0:
                    up = ConDB.context.Products.ToList();
                    DG.ItemsSource = up;
                    break;
                case 1:
                    up = up.Where(x=> x.ProductID == 1).ToList();
                    DG.ItemsSource = up;
                    break;
                case 2:
                    up = up.Where(x => x.ProductID == 2).ToList();
                    DG.ItemsSource = up;
                    break;
                case 3:
                    up = up.Where(x => x.ProductID == 3).ToList();
                    DG.ItemsSource = up;
                    break;
                case 4:
                    up = up.Where(x => x.ProductID == 4).ToList();
                    DG.ItemsSource = up;
                    break;
                case 5:
                    up = up.Where(x => x.ProductID == 5).ToList();
                    DG.ItemsSource = up;
                    break;

            }
            chifra.Text = "Строк в БД: " + up.Count.ToString() + " из " + countDb;
            DG.ItemsSource = up;
        }
        

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new dobav(null));
        }

        private void redatk_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new dobav(DG.SelectedItem as Products));
        }

        private void udal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var delUser = DG.SelectedItems.Cast<Products>().ToList();
                if (MessageBox.Show("Удалить " + delUser.Count + " записей", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConDB.context.Products.RemoveRange(delUser);
                    MessageBox.Show("Данные удалены");
                    ConDB.context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            update();

        }

        private void txtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void DG_Loaded(object sender, RoutedEventArgs e)
        {
            update();
            vivod.Text = $"Привет, {App.users.Username}";
        }

        private void CMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem is Products selectedProduct)
            {
                App.ContolProduct.AddToCart(selectedProduct);
                update();
            }
        }

        private void vpered_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new Korzina());
        }
    }
}
