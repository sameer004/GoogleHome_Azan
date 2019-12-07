using System.Windows;
using Google.Cast.ClassLibrary.Service.Models;
using Google.Cast.ClassLibrary.Service.Muslimsalat;
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
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<IPrayerSetup<Azan>>().To<PrayerSetup<Azan>>().InTransientScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.Title = "NYLA Google Kitchen Compiled Version";
        }
    }
}
