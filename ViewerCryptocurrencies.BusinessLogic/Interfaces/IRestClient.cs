namespace ViewerCryptocurrencies.BusinessLogic.Interfaces
{
    public interface IRestClient
    {
        Task<string> DeleteAsync(string url);
        Task<string> GetAsync(string url);
        Task<string> PostAsync(string url, string data = "");
        Task<string> PutAsync(string url, string data = "");
    }
}
