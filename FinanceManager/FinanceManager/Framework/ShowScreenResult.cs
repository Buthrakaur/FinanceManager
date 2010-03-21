using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.RoutedMessaging;
using Caliburn.PresentationFramework.Screens;
using FinanceManager.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace FinanceManager.Framework
{
    public class ShowScreenResult<TScreen>: IResult
        where TScreen: IScreen
    {
        private readonly Action<TScreen> configureAction;

        public ShowScreenResult() : this(null)
        {
        }

        public ShowScreenResult(Action<TScreen> configureAction)
        {
            this.configureAction = configureAction;
        }

        public void Execute(ResultExecutionContext context)
        {
            var screen = ServiceLocator.Current.GetInstance<TScreen>();
            var shell = ServiceLocator.Current.GetInstance<IShellViewModel>();
            if (configureAction != null)
            {
                configureAction(screen);
            }

            shell.OpenScreen(screen);

            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}
