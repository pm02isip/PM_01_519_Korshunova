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
    /// Логика взаимодействия для Main_system_window.xaml
    /// </summary>
    public partial class Main_system_window : Page
    {
        public Main_system_window()
        {
            InitializeComponent();
            List.ItemsSource = DataBaseConnection.entities.Event.ToList();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AuthPage());
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Page_info_events(List.SelectedItem as Event));
        }

        private void DateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DateEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void cs()
        {
            var a = DataBaseConnection.entities.Event.ToList();

            if( DateStart.Text.Length >0)
            {
                var b = Convert.ToDateTime(DateStart.Text);
                a = a.Where(i => i.Date >= b).ToList();
            }

            if (DateStart.Text.Length > 0 && DateEnd.Text.Length > 0)
            {
                var b = Convert.ToDateTime(DateStart.Text);
                var v = Convert.ToDateTime(DateEnd.Text);
                a = a.Where(i => i.Date >= b && i.Date <= v).ToList();
            }
            List.ItemsSource = a;
        }
    }
}
