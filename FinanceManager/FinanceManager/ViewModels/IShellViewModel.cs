using Caliburn.PresentationFramework.Screens;

namespace FinanceManager.ViewModels
{
    public interface IShellViewModel
    {
        bool IsBusy { get; set; }
        void OpenScreen(IScreen screen);
    }
}