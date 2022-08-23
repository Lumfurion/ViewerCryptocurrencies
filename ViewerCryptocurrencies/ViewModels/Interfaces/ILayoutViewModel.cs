using System.Windows.Input;

namespace ViewerCryptocurrencies.UI.ViewModels.Interfaces
{
    interface ILayoutViewModel : IViewModelBase
    {
        ISideMenuViewModel SideMenuViewModel { get; }
        
        IViewModelBase ContentViewModel { get; }
    }
}
