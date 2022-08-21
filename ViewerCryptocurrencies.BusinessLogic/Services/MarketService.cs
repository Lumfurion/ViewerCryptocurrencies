
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using ViewerCryptocurrencies.BusinessLogic.Interfaces;
using ViewerCryptocurrencies.BusinessLogic.Models;
using ViewerCryptocurrencies.Models;

namespace ViewerCryptocurrencies.BusinessLogic.Services
{
    public class MarketService : IMarketService
    {
       
       private readonly IRestClient _restClient;

        public MarketService()
        {
            _restClient = new RestClient();
        }
        
        public async Task<ObservableCollection<Market>> GetMarket(string currency = "usd", string ids = "", string category = "", string order = "market_cap_desc", int perpage = 10, int page = 1, bool sparkline = false, string price_change_percentage = "")
        {   
            string link;
            if(!string.IsNullOrEmpty(category))
            link= $"https://api.coingecko.com/api/v3/coins/markets?vs_currency={currency}&ids={ids}&category={category}&order={order}&per_page={perpage}&page={page}&sparkline={sparkline}&price_change_percentage={price_change_percentage}";
            else link = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency={currency}&ids={ids}&order={order}&per_page={perpage}&page={page}&sparkline={sparkline}&price_change_percentage={price_change_percentage}";

            var response = await _restClient.GetAsync(link);
            var result = JsonConvert.DeserializeObject<ObservableCollection<Market>>(response);
            return result ?? new ObservableCollection<Market>();
        }
    }
}
