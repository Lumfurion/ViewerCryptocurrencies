using System;
using System.Collections.ObjectModel;
using ViewerCryptocurrencies.BusinessLogic.Interfaces;
using ViewerCryptocurrencies.BusinessLogic.Services;
using ViewerCryptocurrencies.Models;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.ViewModels
{
    class HomeViewModel : NotifyObject, IHomeViewModel
    {

        private IMarketService _marketService;

        private ObservableCollection<Market> _markets;
        public ObservableCollection<Market> Markets
        {
            get { return _markets; }
            set
            {
                _markets = value;
                OnPropertyChanged("Markets");
            }
        }

        public HomeViewModel()
        {
            _marketService = new MarketService();
            GetData();
        }
        private async void GetData()
        {
            Markets = await _marketService.GetMarket(perpage:10);
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
                Markets = null;
            }

        }
        #endregion 
    }
}
