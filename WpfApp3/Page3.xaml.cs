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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }
        void Update()
        {
            var up = ConDB.context.Orders.Select(x =>
            new
            {
                x.OrderID,x.OrderDate,
                X = x.Users,
                Q = x.Users.Roles
            }).ToList();
            DG.ItemsSource = up;
        }
        private void DG_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }
    }
}
