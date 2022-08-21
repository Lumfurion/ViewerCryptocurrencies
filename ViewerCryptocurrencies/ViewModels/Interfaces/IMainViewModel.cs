namespace ViewerCryptocurrencies.UI.ViewModels.Interfaces
{
    public interface IMainViewModel : IViewModelBase
    {
        IViewModelBase CurrentViewModel { get; }
        IViewModelBase CurrentModalViewModel { get; }
        bool IsOpened { get; }
    }
}
