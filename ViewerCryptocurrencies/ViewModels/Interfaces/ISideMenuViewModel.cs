

using System.Windows.Input;

namespace ViewerCryptocurrencies.UI.ViewModels.Interfaces
{
    public interface ISideMenuViewModel:IViewModelBase
    {
        ICommand NavigateHomeCommand { get; }
        ICommand NavigateShowCourseCommand { get; }
        ICommand NavigateSetingsCommand { get; }
    }
}
