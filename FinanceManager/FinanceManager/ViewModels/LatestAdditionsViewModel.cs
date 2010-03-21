using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace FinanceManager.ViewModels
{
    [Export(typeof(ILatestAdditionsViewModel))]
    public class LatestAdditionsViewModel: Screen<IEnumerable<LatestAdditionItemViewModel>>, ILatestAdditionsViewModel
    {
        public LatestAdditionsViewModel()
        {
            LatestAdditions = new ObservableCollection<LatestAdditionItemViewModel>();
        }

        public ObservableCollection<LatestAdditionItemViewModel> LatestAdditions { get; private set; }

        public override IScreen<IEnumerable<LatestAdditionItemViewModel>> WithSubject(IEnumerable<LatestAdditionItemViewModel> subject)
        {
            LatestAdditions.Clear();
            foreach (var item in subject)
            {
                LatestAdditions.Add(item);
            }
            return base.WithSubject(subject);
        }

        protected override void OnShutdown()
        {
            LatestAdditions.Clear();

            base.OnShutdown();
        }
    }
}
