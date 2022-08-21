using System;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.Stores
{
    /// <summary>
    /// An intermediate class that will be responsible for navigation.
    /// </summary>
    public class NavigationStore
    {
        private IViewModelBase? _currentViewModel;
        /// <summary>
        /// Current View Model
        /// </summary>
        public IViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = null;
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        /// <summary>
        /// Will fire every time the ViewModelBase is updated.
        /// </summary>
        public event Action? CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
