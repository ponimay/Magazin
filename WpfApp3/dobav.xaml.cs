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
    /// Логика взаимодействия для dobav.xaml
    /// </summary>
    public partial class dobav : Page
    {
        bool isCheck;
        Products pa;
        public dobav(Products m)
        {
            InitializeComponent();
            if (m == null ) 
            { 
                m = new Products();
                isCheck = true;
            }
            else
                isCheck = false;
            DataContext = pa = m;
        }

        private void btrnn_Click(object sender, RoutedEventArgs e)
        {
            if (isCheck)
            {
                ConDB.context.Products.Add(pa);
            }
            try
            {
                ConDB.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            Nav.MFrame.GoBack();
        }
    }
}
