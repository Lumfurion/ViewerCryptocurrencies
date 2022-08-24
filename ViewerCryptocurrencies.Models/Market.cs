using Newtonsoft.Json;

namespace ViewerCryptocurrencies.Models
{
    public class Market
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Name of cryptocurrency
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Image of cryptocurrency
        /// </summary>
        [JsonProperty("image")]
        public Uri Image { get; set; }

        /// <summary>
        /// CurrentPrice of cryptocurrency
        /// </summary>
        [JsonProperty("current_price")]
        public double CurrentPrice { get; set; }

        /// <summary>
        /// Рыночная капитализация
        /// </summary>
        [JsonProperty("market_cap")]
        public long MarketCap { get; set; }

        [JsonProperty("market_cap_rank")]
        public long MarketCapRank { get; set; }
        /// <summary>
        /// Рыночная капитализация при полной эмиссии
        /// </summary>
        [JsonProperty("fully_diluted_valuation")]
        public long? FullyDilutedValuation { get; set; }
        /// <summary>
        /// Объем(24 ч)
        /// </summary>
        [JsonProperty("total_volume")]
        public long TotalVolume { get; set; }

        [JsonProperty("high_24h")]
        public double High24H { get; set; }

        [JsonProperty("low_24h")]
        public double Low24H { get; set; }

        [JsonProperty("price_change_24h")]
        public double PriceChange24H { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public double PriceChangePercentage24H { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public double MarketCapChange24H { get; set; }

        [JsonProperty("market_cap_change_percentage_24h")]
        public double MarketCapChangePercentage24H { get; set; }
       
        #region supply
        /// <summary>
        /// Циркулирующее предложение
        /// </summary>
        [JsonProperty("circulating_supply")]
        public double CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public double? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public long? MaxSupply { get; set; }
        #endregion

        /// <summary>
        /// ethereum change percentage
        /// </summary>
        [JsonProperty("ath")]
        public double Ath { get; set; }

        /// <summary>
        /// ethereum change percentage
        /// </summary>
        [JsonProperty("ath_change_percentage")]
        public double AthChangePercentage { get; set; }

        [JsonProperty("ath_date")]
        public DateTimeOffset AthDate { get; set; }
        /// <summary>
        /// ATLANT(Atl)
        /// </summary>
        [JsonProperty("atl")]
        public double Atl { get; set; }
        /// <summary>
        /// ATLANT(Atl) change percentage
        /// </summary>
        [JsonProperty("atl_change_percentage")]
        public double AtlChangePercentage { get; set; }

        [JsonProperty("atl_date")]
        public DateTimeOffset AtlDate { get; set; }

        [JsonProperty("roi")]
        public Roi Roi { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}
