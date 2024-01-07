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
    /// Логика взаимодействия для Registation.xaml
    /// </summary>
    public partial class Registation : Page
    {
       
        public Registation()
        {
            InitializeComponent();
            GenerateCaptcha();
        }
        ControlUser rol = new ControlUser(); 
        private int a, b, c;
        Userr userr = new Userr();
        private int _role = 0;

        void GenerateCaptcha()
        {
            Random r = new Random();
            a = r.Next(0, 99);
            b = r.Next(0, 9999);
            c = r.Next(0, 9999);
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
                CheckCaptcha();
                if (!String.IsNullOrWhiteSpace(LoginBox.Text) && !String.IsNullOrWhiteSpace(PassBox.Password) && _role > 0)
                {
                    var user = userr.CreateNewUser(LoginBox.Text, PassBox.Password, _role);
                    App.users = user;
                    Nav.MFrame.Navigate(new Page2());
                }
                else
                {
                    MessageBox.Show("Не все поля были введены корректно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}","Ошибка!", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void DGG_Loaded(object sender, RoutedEventArgs e)
        {
            var allRoles = rol.GetRole();
            allRoles.Insert(0, new Roles
            {
                RoleName = "Выбор должности"
            });
            CMBB.SelectedIndex = 0;
            CMBB.DisplayMemberPath = "RoleName";
            CMBB.SelectedValuePath = "RoleID";
            CMBB.ItemsSource = allRoles;

        }

        private void CMBB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Roles roles = CMBB.SelectedItem as Roles;
            _role = roles.RoleID;
        }
    }
}
