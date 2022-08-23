using System;
using ViewerCryptocurrencies.UI.Stores;
using ViewerCryptocurrencies.UI.ViewModels;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : IViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<ISideMenuViewModel> _createSideMenuViewModel;
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="navigationStore">Navigation store</param>
        /// <param name="createViewModel">Func, to create ViewModel</param>
        /// <param name="createSideMenuViewModel">Func, to create sideMenu ViewModel</param>
        public LayoutNavigationService(NavigationStore navigationStore,
            Func<TViewModel> createViewModel,
            Func<ISideMenuViewModel> createSideMenuViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createSideMenuViewModel = createSideMenuViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createSideMenuViewModel(), _createViewModel());
        }
    }
}
