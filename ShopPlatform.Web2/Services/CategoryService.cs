using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ShopPlatform.Web2.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        // Ya no necesitamos _baseUrl, usamos BaseAddress de HttpClient
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            // Solo la ruta relativa, concatenada con BaseAddress
            return await _httpClient.GetFromJsonAsync<List<Category>>("category");
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"category/{id}");
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync("category", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            var response = await _httpClient.PutAsJsonAsync($"category/{id}", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"category/{id}");
            return response.IsSuccessStatusCode;
        }
    }

    // Modelo de Category
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

       
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }

        
        public bool Deleted { get; set; }
    }
}
