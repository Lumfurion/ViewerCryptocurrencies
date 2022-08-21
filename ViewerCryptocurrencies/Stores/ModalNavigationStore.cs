using System;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.Stores
{
    public class ModalNavigationStore
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
        /// Сhecking if ViewModel is open (is not null).
        /// </summary>
        public bool IsOpen => _currentViewModel != null;
        /// <summary>
        /// Occurs, when ViewModel is changed
        /// </summary>

        public event Action? CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel?.Dispose();
            CurrentViewModel = null;
        }
        /// <summary>
        /// Void method, when current ViewModel changed
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
