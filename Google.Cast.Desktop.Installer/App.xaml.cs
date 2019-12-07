using System.Windows;
using Google.Cast.ClassLibrary.Service.Models;
using Google.Cast.ClassLibrary.Service.Muslimsalat;
using Google.Cast.Data;
using Ninject;

namespace Google.Cast.Desktop.Installer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            ShutdownMode = ShutdownMode.OnLastWindowClose;

            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<IPrayerSetup<Azan, SetAzanSchedule>>().To<PrayerSetup<Azan, SetAzanSchedule>>().InTransientScope();
            container.Bind<IDal>().To<Dal>().InTransientScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.Title = "Adhan Player";
        }
    }
}
