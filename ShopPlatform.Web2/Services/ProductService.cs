using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ShopPlatform.Web2.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("product");
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"product/{id}");
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("product", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"product/{id}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id, int deleteUser = 1)
        {
            var response = await _httpClient.DeleteAsync($"product/{id}?deleteUser={deleteUser}");
            return response.IsSuccessStatusCode;
        }
    }

   
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }
        public bool Deleted { get; set; }

        
        public string FormattedPrice => UnitPrice.ToString("C");

        
        public string Status => Discontinued ? "Discontinued" : "Active";
    }
}
