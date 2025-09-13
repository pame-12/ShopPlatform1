using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ShopPlatform.Web2.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("customer");
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"customer/{id}");
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("customer", customer);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCustomerAsync(int id, Customer customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"customer/{id}", customer);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCustomerAsync(int id, int deleteUser = 1)
        {
            var response = await _httpClient.DeleteAsync($"customer/{id}?deleteUser={deleteUser}");
            return response.IsSuccessStatusCode;
        }
    }

    
    public class Customer
    {
        public int CustId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string ContactTitle { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Fax { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }
        public bool Deleted { get; set; }
    }
}
