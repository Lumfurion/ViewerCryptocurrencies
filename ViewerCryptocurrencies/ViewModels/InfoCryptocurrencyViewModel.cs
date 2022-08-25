using System;
using System.Windows.Input;
using ViewerCryptocurrencies.Models;
using ViewerCryptocurrencies.UI.Commands;
using ViewerCryptocurrencies.UI.Services;
using ViewerCryptocurrencies.UI.Stores;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.ViewModels
{
    class InfoCryptocurrencyViewModel: NotifyObject,IInfoCryptocurrencyViewModel
    {
        readonly private MarketStore _marketStore;
        public ICommand SubmitCommand { get; }
       

        public InfoCryptocurrencyViewModel(MarketStore marketStore, INavigationService closeNavigationService)
        {
            _marketStore = marketStore;
            SubmitCommand = new NavigateCommand(closeNavigationService);
        }


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
            }

        }
        #endregion 
    }

}
