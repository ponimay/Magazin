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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private int a,b,c;
        Userr Userr = new Userr();
        public Page1()
        {
            InitializeComponent();
            GenerateCaptcha();
        }
        void GenerateCaptcha()
        {
            Random r = new Random();    
            a = r.Next(0,99);
            b = r.Next(0,9999);
            c = r.Next(0,9999);
            cap.Text = $"Решите капчу {a}x + {b} = {c}";
        }
        void CheckCaptcha()
        {
            if (captxt.Text == "")
            {
                MessageBox.Show("Решите простейшее уравнение!");
                return;
            }
            if (int.TryParse(captxt.Text, out int otvet))
            {

                if (otvet == ((c - b) / a))
                {
                    MessageBox.Show("Капча пройдена. Доступ разрешен");
                }
                else
                {
                    MessageBox.Show("Попробуйте еще раз.");
                    captxt.Clear();
                    GenerateCaptcha();
                }

            }
            else
            {
                MessageBox.Show("Введите корректный ответ!");
            }
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(LoginBox.Text) && !String.IsNullOrWhiteSpace(PassBox.Password))
                {
                    CheckCaptcha();
                    var u = Userr.SingUp(LoginBox.Text.Trim().ToLower(), PassBox.Password.Trim().ToLower());
                    App.users = u;
                    Nav.MFrame.Navigate(new Page2());
                }
                else
                {
                    MessageBox.Show("Заполненны не все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Пользователь не существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new Registation());
        }
    }
}
