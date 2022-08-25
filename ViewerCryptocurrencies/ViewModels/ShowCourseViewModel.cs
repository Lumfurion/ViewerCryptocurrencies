using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using ViewerCryptocurrencies.BusinessLogic.Interfaces;
using ViewerCryptocurrencies.BusinessLogic.Services;
using ViewerCryptocurrencies.Models;
using ViewerCryptocurrencies.UI.Commands;
using ViewerCryptocurrencies.UI.Services;
using ViewerCryptocurrencies.UI.Stores;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.ViewModels
{
    public class ShowCourseViewModel : NotifyObject, IShowCourseViewModel
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

        private Market _selectedMarket;
        public Market SelectedMarket
        {
            get { return _selectedMarket; }
            set
            {
                _selectedMarket = value;
                OnPropertyChanged("SelectedMarket");
            }
        }

        private MarketStore _marketStore;



        public ICommand NavigationToInfoCryptocurrency { get; }


       
        private RelayCommand _showCryptocurrencyCommand;
        public RelayCommand ShowCryptocurrencyCommand
        {
            get
            {
                return _showCryptocurrencyCommand ??
                  (_showCryptocurrencyCommand = new RelayCommand(obj =>
                  {
                      NavigationToInfoCryptocurrency.Execute(null);
                  }));
            }
        }


        #region FilterByName
        private string _filterByName;
        public string FilterByName
        {
            get { return _filterByName; }
            set
            {
                _filterByName = value;
                FilterMareketNow();
                OnPropertyChanged("FilterByName");
            }
        }

        private ICollectionView _viewMarket;
        public ICollectionView ViewMarket
        {
            get { return _viewMarket; }
            set
            {
                _viewMarket = value;
                OnPropertyChanged("ViewMarket");
            }

        }
        private void FilterMareketNow()
        {
            ViewMarket.Filter = (obj) =>
            {
                Market svm = (Market)obj;
              

                bool propertyName = svm.Name.ToLower().Contains(FilterByName.ToLower());
       
                if (propertyName)
                    return true;

                return false;


            };
        }
        #endregion FilterByName


        public ShowCourseViewModel(INavigationService showCryptocurrencyNavigationService, MarketStore marketStore)
        {
            _marketService = new MarketService();
            NavigationToInfoCryptocurrency = new NavigateCommand(showCryptocurrencyNavigationService);
            _marketStore = marketStore;
            GetData();
        }

       

        private async void GetData()
        {
            Markets = await _marketService.GetMarket(perpage:80);
            ViewMarket = CollectionViewSource.GetDefaultView(Markets);

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
                ViewMarket = null;
            }

        }
        #endregion 
    }
}
