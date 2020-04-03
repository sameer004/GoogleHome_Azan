using Google.Cast.ClassLibrary.Service.Models;
using Google.Cast.ClassLibrary.Service.Muslimsalat;
using Google.Cast.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Windows;
using System.Windows.Controls;

namespace Google.Cast.Desktop.Installer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dal _dal;
        private List<US_State> states;
        string _player;
        string _state;
        public MainWindow()
        {
     
            InitializeComponent();

            _dal = new Dal(); 
            _player = _dal.GetPlayer();
            _state = _dal.GetState();

            states = new US_State().GetStates();

            loadButtons();            
        }

        private void loadButtons()
        {
            if (string.IsNullOrEmpty(_player))
            {
                btnService.IsEnabled = false;
                btnSchedule.IsEnabled = false;
                btnTest.IsEnabled = false;
                return;
            }
            lblCurrentCasting.Content = "Current Player: " + _player;
            lblCurrentState.Content = "Current State: " + _state;
            btnService.IsEnabled = true;
            btnSchedule.IsEnabled = true;
            btnTest.IsEnabled = true;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartUp();
            loadButtons();
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
            _dal.CreateTable();
            _dal.InsertData();
            _dal.UpdatePlayer(_player);
            _dal.UpdateState(_state);

            // serviceStart("Google.Cast.Adthan");
            //https://muslimsalat.com/{0}/daily/{1}/false.json
            var a = new PrayerSetup<Azan, SetAzanSchedule>().SetUp(string.Format("https://muslimsalat.com/{0}/daily/{1}.json", _state, DateTime.Now.ToString("dd-MM-yyyy"))
                , "0 1 0 1/1 * ? *"
                , _player);
        }




        private void cmb_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            _player = cmbCaster.SelectedValue as string;
            btnSchedule.IsEnabled = true;
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

        private void BtnInstallSvc(object sender, RoutedEventArgs e)
        {
            InstallService();
        }


        private void InstallService()
        {
            try

            {

                ProcessStartInfo procInfo = new ProcessStartInfo();

                procInfo.UseShellExecute = true;

                procInfo.FileName = @"Install.bat";  //The file in that DIR.

                procInfo.WorkingDirectory = @""; //The working DIR.

                procInfo.Verb = "runas";

                Process.Start(procInfo);  //Start that process.

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message.ToString());

            }
        }

        private async void BtnTestService(object sender, RoutedEventArgs e)
        {
            var a = new AzanPlayer(new ChromeCastMediaInfo() {FriendlyName=_player,MediaUrl= "http://remote.khanzone.com:8181/audio/demo.mp3" });
            await a.Play((s) => MessageBox.Show("Media Status: " + s + " ON " + _player));
        }

        private void cmbStates_Loaded(object sender, RoutedEventArgs e)
        {
   

            cmbStates.DisplayMemberPath = "Abbreviations";
            cmbStates.SelectedValuePath = "Name";
            cmbStates.ItemsSource = states;

            cmbStates.SelectedIndex = 1;
        }

        private void CmbStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _state = (cmbStates.SelectedItem as US_State).Abbreviations;
        }



        //private void serviceStart(string svcName)
        //{
        //    var svcExists = this.svcExists(svcName);
        //    if (svcExists)
        //    {
        //        var service = new ServiceController("Google.Cast.Adthan");
        //        if (service.Status == ServiceControllerStatus.Stopped)
        //            service.Start();
        //    }

        //}
        //private bool svcExists(string svcName)
        //{
        //    ServiceController ctl = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == svcName);
        //    if (ctl == null)
        //        return false;
        //    else
        //        return true;
        //}
    }
}
