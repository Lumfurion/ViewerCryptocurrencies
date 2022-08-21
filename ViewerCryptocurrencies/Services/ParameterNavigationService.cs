using System;
using ViewerCryptocurrencies.UI.Stores;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.Services
{
    /// <summary>
    /// Will take ViewModel and parameter.
    /// </summary>
    public class ParameterNavigationService<TParameter, TViewModel> where TViewModel : IViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TParameter, TViewModel> _createViewModel;
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="navigationStore">Navigation store</param>
        /// <param name="createViewModel">Func to create ViewModel</param>
        public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}
