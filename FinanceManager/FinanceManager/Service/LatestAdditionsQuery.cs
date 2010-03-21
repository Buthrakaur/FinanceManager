using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.RoutedMessaging;
using FinanceManager.ViewModels;

namespace FinanceManager.Service
{
    public class LatestAdditionsQuery: IResult
    {
        public LatestAdditionsQuery(int maxCount)
        {
            this.maxCount = maxCount;
        }

        private readonly int maxCount;
        public IEnumerable<LatestAdditionItemViewModel> Result { get; private set; }

        public void Execute(ResultExecutionContext context)
        {
            var res = new List<LatestAdditionItemViewModel>();
            for(var i=1;i<maxCount;i++)
            {
                res.Add(new LatestAdditionItemViewModel(DateTime.Now.AddDays(-i), "Subject " + i));
            }
            Result = res;
            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}
