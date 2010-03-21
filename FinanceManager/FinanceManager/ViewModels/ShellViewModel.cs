using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.PresentationFramework.RoutedMessaging;
using Caliburn.PresentationFramework.Screens;
using Caliburn.ShellFramework.Results;
using FinanceManager.Framework;
using FinanceManager.Service;

namespace FinanceManager.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel: ScreenConductor<IScreen>, IShellViewModel
    {
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        public IEnumerable<IResult> ShowLatestAdditions()
        {
            var query = new LatestAdditionsQuery(10);
            yield return query;
            yield return new ShowScreenResult<ILatestAdditionsViewModel>(v => v.WithSubject(query.Result));
        }

        public void OpenScreen(IScreen screen)
        {
            OpenScreen(screen, c=>{});
        }
    }
}
