using Newtonsoft.Json;

namespace ViewerCryptocurrencies.Models
{
    public class Roi
    {
        [JsonProperty("times")]
        public double Times { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("percentage")]
        public double Percentage { get; set; }
    }

   
}



