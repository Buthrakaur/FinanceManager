using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Caliburn.Core.Configuration;
using Caliburn.Core.Logging;
using Caliburn.PresentationFramework.ApplicationModel;
using FinanceManager.ViewModels;

namespace FinanceManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : CaliburnApplication
    {
        public App()
        {
            var log = new ConsoleLog();
            LogManager.Initialize(t => log);
        }

        protected override Microsoft.Practices.ServiceLocation.IServiceLocator CreateContainer()
        {
            var container = new CompositionContainer(new AssemblyCatalog(GetType().Assembly));
            return new Caliburn.MEF.MEFAdapter(container);
        }

        protected override object CreateRootModel()
        {
            return Container.GetInstance<IShellViewModel>();
        }
    }

    public class ConsoleLog : ILog
    {
        private void WriteOut(string type, string message)
        {
            Console.Out.WriteLine(String.Format("{0}: {1}", type, message));
        }

        public void Info(string message)
        {
            WriteOut("INFO", message);
        }

        public void Warn(string message)
        {
            WriteOut("WARN", message);
        }

        public void Error(Exception exception)
        {
            WriteOut("ERROR", exception.GetType().Name + ": " + exception.Message + Environment.NewLine + exception.StackTrace);
        }
    }
}
