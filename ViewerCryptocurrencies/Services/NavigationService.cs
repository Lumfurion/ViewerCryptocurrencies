using System;
using ViewerCryptocurrencies.UI.Stores;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.Services
{
    public class NavigationService<TViewModel> : INavigationService where TViewModel : IViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel>? _createViewModel;
        private readonly TViewModel? _viewModel;
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="navigationStore">Navigation store</param>
        /// <param name="viewModel">ViewModel instance via interface</param>
        public NavigationService(NavigationStore navigationStore, TViewModel viewModel)
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
        }
        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        /// <summary>
        /// Navigate to specified page
        /// </summary>

        public void Navigate()
        {
            if (_viewModel is not null)
            {
                _navigationStore.CurrentViewModel = _viewModel;
                _viewModel?.Dispose();
                return;
            }
            if (_createViewModel is not null)
            {
                _navigationStore.CurrentViewModel = _createViewModel();
            }
        }
    }
}
