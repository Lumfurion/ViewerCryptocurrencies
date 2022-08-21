
using System;
using ViewerCryptocurrencies.UI.Stores;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.Services
{
    /// <summary> 
    /// Service for modal windows(Popups)
    /// </summary>
    /// <typeparam name="TViewModel">Current model</typeparam>
    public class ModalNavigationService<TViewModel> : INavigationService where TViewModel : IViewModelBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="navigationStore">Navigation store</param>
        /// <param name="createViewModel">Func, to create ViewModel</param>
        public ModalNavigationService(ModalNavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        /// <summary>
        /// Navigate to another page
        /// </summary>
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
