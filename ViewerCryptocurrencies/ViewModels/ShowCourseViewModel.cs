
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using ViewerCryptocurrencies.BusinessLogic.Interfaces;
using ViewerCryptocurrencies.BusinessLogic.Services;
using ViewerCryptocurrencies.Models;
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

       


        private ICollectionView _viewMarket;
        public ICollectionView ViewMarket
        {
            get { return _viewMarket; }
            set 
            { _viewMarket = value;
                OnPropertyChanged("ViewMarket"); 
            }

        }



        public ShowCourseViewModel()
        {
            _marketService = new MarketService();
            GetData();
           

        }
        private async void GetData()
        {
            Markets = await _marketService.GetMarket(perpage:80);
            ViewMarket = CollectionViewSource.GetDefaultView(Markets);
        }


        public void Dispose()
        {

        }
    }
}
