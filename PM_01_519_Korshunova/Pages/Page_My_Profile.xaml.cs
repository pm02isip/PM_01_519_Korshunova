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

namespace PM_01_519_Korshunova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_My_Profile.xaml
    /// </summary>
    public partial class Page_My_Profile : Page
    {
        Organizers _organizers = new Organizers();
        public Page_My_Profile(Organizers selectorganizers)
        {
            InitializeComponent();
            if (selectorganizers != null)
            {
                _organizers = selectorganizers;
            }
            DataContext = _organizers;
        }

        public int a = 0;
        public int b = 0;
        private void Visual_Click(object sender, RoutedEventArgs e)
        {
            b = b + 1;
            a = a + 1;
            if (a == 1)
            {
                Visual.Background = Brushes.Green;
                SPPass.Visibility = Visibility.Collapsed;
                TBPass1.Text = Pass1.Password;
                TBPass2.Text = Pass2.Password;
                SPVisPass.Visibility = Visibility.Visible;
            }
            if (a > 1)
            {
                Visual.Background = Brushes.Red;
                SPPass.Visibility = Visibility.Visible;
                Pass1.Password = TBPass1.Text;
                Pass2.Password = TBPass2.Text;
                SPVisPass.Visibility = Visibility.Collapsed;
                a = 0;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Pass1.Password == Pass2.Password)
            {
                var a = (from g in DataBaseConnection.entities.Organizers
                         where g.Password == Pass1.Password
                         select g).FirstOrDefault();
                if (a != null)
                {
                    MessageBox.Show("Пароль совпадает с нынешним");
                }
                else
                {
                    _organizers.Password = Pass1.Password;
                }
            }
            else
            {
                MessageBox.Show("Пароль не совпадает");
            }
            DataBaseConnection.entities.SaveChanges();
            MessageBox.Show("УСПЕШНО");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
