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
    /// Логика взаимодействия для Page_Organizers.xaml
    /// </summary>
    public partial class Page_Organizers : Page
    {

        Organizers _organizers = new Organizers();

        public Page_Organizers(Organizers selectorganizers)
        {
            InitializeComponent();

            if (selectorganizers != null)
            {
                _organizers = selectorganizers;
            }
            DataContext = _organizers;

            var name = _organizers.FIO;
            var F = name.Split(' ');
            mr_ms_txt.Text = F[1] + " " + F[2];

            DateTime now = DateTime.Now;
            var a = $"{now:t}";
            a.Split(':');

            int b = Convert.ToInt32(a[0]);
            if (b > 9)
            {
                priv_txt.Text = "Доброе утро!";
            }
            if (b > 11)
            {
                priv_txt.Text = "Добрый день!";
            }
            if (b > 18)
            {
                priv_txt.Text = "Добрый вечер!";
            }
        }

        private void My_profil_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Page_My_Profile(_organizers));
        }

        private void Events_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Page_Event_Organizers());
        }

        private void Participants_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Окно пустое, задание не подразумевает реализацию данного окна");
        }

        private void Jury_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Окно пустое, задание не подразумевает реализацию данного окна");
        }
    }
}
