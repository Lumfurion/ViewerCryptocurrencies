using ViewerCryptocurrencies.BusinessLogic.Interfaces;

namespace ViewerCryptocurrencies.BusinessLogic.Models
{
    /// <summary>
    ///REST client implementation
    /// </summary>
    public class RestClient : IRestClient, IDisposable
    {   
       
        public async Task<string> DeleteAsync(string url)
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.DeleteAsync($"{url}");
            return await response.Content.ReadAsStringAsync();
        }

      
        public async Task<string> GetAsync(string url)
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"{url}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string url,string data ="")
        {
            using HttpClient client = new(); 
            HttpContent httpContent = new StringContent(data);
            HttpResponseMessage response = await client.PostAsync($"{url}", httpContent);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PutAsync(string url,string data = "")
        {
            using HttpClient client = new();
            HttpContent httpContent = new StringContent(data);
            HttpResponseMessage response = await client.PutAsync($"{url}", httpContent);
            return await response.Content.ReadAsStringAsync();
        }

        #region Dispose

        public void Dispose()
        {
           
            GC.SuppressFinalize(this);
        }

        

        #endregion
    }
}
