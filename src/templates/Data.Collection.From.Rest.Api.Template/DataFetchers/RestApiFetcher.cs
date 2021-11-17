using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Utkeyrslukerfi.API.Services.Helpers;

namespace Data.Collection.From.Rest.Api.Template.DataFetchers
{
    public class RestApiFetcher<T>
    {
        private readonly HttpClient _client;
        public RestApiFetcher(HttpClient client) 
        {
            _client = client;
        }

        private async Task<IEnumerable<T>> GetMultipleItemsAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await HttpResponseMessageExtensions.DeserializeJsonToList<T>(response, "items");
        }

        private async Task<T> GetSingleItemAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await HttpResponseMessageExtensions.DeserializeJsonToObject<T>(response, "items");
        }

        public async Task<IEnumerable<T>> GetMultipleItems(string url)
        {
            return await GetMultipleItemsAsync(url);
        }   

        public async Task<T> GetSingleItem(string url)
        {
            return await GetSingleItemAsync(url);
        }
    }
}