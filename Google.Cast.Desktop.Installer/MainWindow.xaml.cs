using Google.Cast.ClassLibrary.Service.Muslimsalat;
using Google.Cast.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Google.Cast.Desktop.Installer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var a = new Dal();
            a.GetPlayer();
        }
        private string playerSelect { get; set; }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartUp();
        }
        /// <summary>
        /// 1 - Updated the SQL Lite with the Selection from DropDown
        /// 2 - Scrapes the Prayes Times API to get Today Times
        /// 3 - Delete All Existing Jobs
        /// 4 - Schedule Job to Run Daily for Scraping
        /// 5 - Schedule are Prayers for Today
        /// </summary>
        private void StartUp()
        {
            var a = new PrayerSetup<Azan, SetAzanSchedule>().SetUp(string.Format("https://muslimsalat.com/{0}/daily/{1}/false.json", "newyork", DateTime.Now.ToString("dd-MM-yyyy"))
                , "0 1 0 1/1 * ? *"
                , playerSelect);
        }

        private void cmb_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            btnSchedule.IsEnabled = true;
            playerSelect = cmbCaster.SelectedValue as string;
        }

        private async void cmbCaster_Loaded(object sender, RoutedEventArgs e)
        {
            var p = new AzanPlayer();
            var players = await p.GoogleCastPlayers();
            cmbCaster.ItemsSource = players;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public static void UpdateStatus(string status)
        {
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSchedule.IsEnabled = false;
        }
    }
}
