using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ShopPlatform.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;

        public ApiService(IConfiguration config)
        {
            _http = new HttpClient();
            _baseUrl = config["ApiSettings:BaseUrl"]!;
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _http.GetStringAsync(_baseUrl + endpoint);
            return JsonConvert.DeserializeObject<T>(response);
        }

        public async Task<bool> PostAsync<T>(string endpoint, T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(_baseUrl + endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync<T>(string endpoint, T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _http.PutAsync(_baseUrl + endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            var response = await _http.DeleteAsync(_baseUrl + endpoint);
            return response.IsSuccessStatusCode;
        }
    }
}

