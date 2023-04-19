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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        public int a = 0;
        public string ContentKapcha;

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            kapcha();
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            if (UserText_kapcha.Text == ContentKapcha)
            {
                ContentKapcha = "";
                UserText_kapcha.Text = "";
                GridKapcha.Visibility = Visibility.Hidden;
                checkRole();
            }
            else
            {
                kapcha();
            }
        }

        public void kapcha()
        {
            GridKapcha.Visibility = Visibility;
            ContentKapcha = "";
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                ContentKapcha += (char)(r.Next('\u0041', '\u005A'));
            }
            Text_Kapcha.Text = ContentKapcha;
        }

        public async void Timer()
        {
            GridTimer.Visibility = Visibility;
            int i = 10;
            for (int f = 0; f < 11; f++)
            {
                if (i != 0)
                {
                    numerTime.Text = i.ToString();
                    i = i - 1;
                    await Task.Delay(1000);
                }
                else
                {
                    GridTimer.Visibility = Visibility.Hidden;
                }
            }


        }

        public void checkRole()
        {
            int a = Convert.ToInt32(Log.Text);
            Organizers asd = DataBaseConnection.entities.Organizers.Where(i => i.ID_number == a && i.Password == Pass.Password).FirstOrDefault();
            if (a != 2)
            {
                if (asd != null)
                {
                    NavigationService.Navigate(new Pages.Page_Organizers(asd));
                }
                else
                {
                    MessageBox.Show("Erorr");
                    a++;
                }
            }
            else
            {
                Timer();
                a = 0;
            }
        }
    }
}