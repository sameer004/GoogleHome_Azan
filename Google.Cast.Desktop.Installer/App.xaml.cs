using System.Diagnostics;
using System.ServiceProcess;
using System.Windows;
using Google.Cast.ClassLibrary.Service.Models;
using Google.Cast.ClassLibrary.Service.Muslimsalat;
using Google.Cast.Data;
using Google.Cast.Desktop.Installer.Service;
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
            //System.Diagnostics.Debugger.Launch();

            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
            base.OnStartup(e);

            ConfigureContainer();
   
            string[] commandLineArgs = System.Environment.GetCommandLineArgs();

            if (commandLineArgs.Length > 1 && commandLineArgs[1].Equals("-service"))
            {
                ServiceBase.Run(new ServiceClass());
            } else
            {
                ComposeObjects();
                ShutdownMode = ShutdownMode.OnLastWindowClose;
                Current.MainWindow.Show();
            }


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
            Current.MainWindow.Title = "Adhan Player For ChromeCast";
        }
    }
}
