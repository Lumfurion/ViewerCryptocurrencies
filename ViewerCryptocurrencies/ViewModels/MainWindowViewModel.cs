using ViewerCryptocurrencies.Models;
using ViewerCryptocurrencies.UI.Stores;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;
using System;

namespace ViewerCryptocurrencies.UI.ViewModels
{
    /// <summary>
    /// Main page ViewModel
    /// </summary>
    class MainWindowViewModel : NotifyObject, IMainViewModel
    {
        #region Private fields
        /// <summary>
        /// Navigation store
        /// </summary>
        private readonly NavigationStore _navigationStore;
        /// <summary>
        /// Modal navigation store
        /// </summary>
        private readonly ModalNavigationStore _modalNavigationStore;
        #endregion


        #region Public fields
        /// <summary>
        /// Current ViewModel
        /// </summary>
        public IViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        /// <summary>
        /// Current Modal ViewModel
        /// </summary>
        public IViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        /// <summary>
        /// State of page (is opened, or not)
        /// </summary>
        public bool IsOpened => _modalNavigationStore.IsOpen;
        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="navigationStore">Navigation store</param>
        /// <param name="modalNavigationStore">Modal navigation store</param>
        public MainWindowViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;
            // When these events are raised, binding will be updated too
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;
        }
        #endregion

        #region Events
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void OnCurrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsOpened));
        }
        #endregion


       

        #region IDisposable Members
        public event EventHandler? Disposed;
        private bool _disposed = false;

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void OnDispose(EventArgs e)
        {
            Disposed?.Invoke(this, e);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                OnDispose(EventArgs.Empty);
                _disposed = true;
                CurrentModalViewModel?.Dispose();
                CurrentViewModel?.Dispose();
            }

        }
        #endregion 




    }
}
