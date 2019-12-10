using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Google.Cast.Desktop.Installer.Service
{
    [RunInstaller(true)]
    public class MyProjectInstaller  : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        /// <summary>
        /// The public constructor that is executed when the
        /// installation is started.
        /// </summary>
        public MyProjectInstaller ()
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = "Google.ChromeCast.Adhan";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
