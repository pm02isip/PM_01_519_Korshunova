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
    /// Логика взаимодействия для Page_info_events.xaml
    /// </summary>
    public partial class Page_info_events : Page
    {
        Event _event = new Event();
        public Page_info_events(Event selectedEvent)
        {
            InitializeComponent();
            if(selectedEvent !=null)
            {
                _event = selectedEvent;
            }

            DataContext = _event;
            Activity_Grid.ItemsSource = (from a in DataBaseConnection.entities.Activity
                                         where a.ID_event == _event.ID
                                         select a).ToList();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Main_system_window());
        }
    }
}
