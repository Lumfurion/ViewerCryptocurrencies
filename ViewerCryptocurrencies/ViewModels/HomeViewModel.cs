

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


        public void Dispose()
        {
            
        }
    }
}
