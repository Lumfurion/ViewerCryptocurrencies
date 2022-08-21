

using System.Collections.ObjectModel;
using ViewerCryptocurrencies.Models;

namespace ViewerCryptocurrencies.BusinessLogic.Interfaces
{
    public interface IMarketService
    {   /// <summary>
        /// GetMarket-Giting List all supported coins price, market cap, volume, and market related data
        /// </summary>
        /// <param name="currency">The target currency of market data (usd, eur, jpy, etc.)</param>
        /// <param name="ids">
        /// The ids of the coin,comma separated crytocurrency symbols (base). refers to /coins/list.
        /// When left empty, returns numbers the coins observing the params limit and start
        /// </param>
        /// <param name="category">filter by coin category. Refer to /coin/categories/list</param>
        /// <param name="order">
        /// valid values: market_cap_desc, gecko_desc, gecko_asc, market_cap_asc, 
        /// market_cap_desc, volume_asc, volume_desc, id_asc, id_desc sort results by field.
        /// </param>
        /// <param name="perpage">
        /// valid values: 1..250
        /// Total results per page
        /// </param>
        /// <param name="page">
        /// Page through results
        /// </param>
        /// <param name="sparkline">
        /// Include sparkline 7 days data (eg. true, false)
        /// </param>
        /// <param name="price_change_percentage">
        /// Include price change percentage in 1h, 24h, 7d, 14d, 30d, 200d, 1y (eg. '1h,24h,7d' comma-separated, invalid values will be discarded)
        /// </param>
        /// <returns></returns>
        Task<ObservableCollection<Market>> GetMarket(string currency= "usd", string ids="", string category="",string order="market_cap_desc", int perpage=10,int page=1,bool sparkline=false,string price_change_percentage="");
    }
}
