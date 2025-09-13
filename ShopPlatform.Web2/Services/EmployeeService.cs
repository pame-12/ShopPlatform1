using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ShopPlatform.Web2.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("employee");
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"employee/{id}");
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("employee", employee);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEmployeeAsync(int id, Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"employee/{id}", employee);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEmployeeAsync(int id, int deleteUser = 1)
        {
            var response = await _httpClient.DeleteAsync($"employee/{id}?deleteUser={deleteUser}");
            return response.IsSuccessStatusCode;
        }
    }

   
    public class Employee
    {
        public int EmpId { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string TitleOfCourtesy { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? MgrId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }
        public bool? Deleted { get; set; }

        
        public string FullName => $"{FirstName} {LastName}";
    }
}
