using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace FinanceManager.ViewModels
{
    public class LatestAdditionItemViewModel
    {
        public LatestAdditionItemViewModel(DateTime timeAdded, string name)
        {
            TimeAdded = timeAdded;
            Name = name;
        }

        public DateTime TimeAdded { get; set; }
        public string Name { get; set; }
    }
}
