using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp3.appData;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Users users = null;
        public static Korzina korzina { get; } = new Korzina();
        public static ContolProduct ContolProduct { get; } = new ContolProduct();

    }
}
