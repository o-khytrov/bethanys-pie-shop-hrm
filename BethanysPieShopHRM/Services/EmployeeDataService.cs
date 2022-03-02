using System.Net.Http.Json;
using System.Text.Json;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Services;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee>?> GetAllEmployees();
    Task<IEnumerable<Employee>?> GetLongEmployeeList();
    Task<Employee?> GetEmployeeDetails(int employeeId);
    Task<Employee> AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
}

public class EmployeeDataService : IEmployeeDataService
{
    private HttpClient _httpClient;

    public EmployeeDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Employee>?> GetAllEmployees()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employee");
    }

    public async Task<IEnumerable<Employee>?> GetLongEmployeeList()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employee/long");
    }

    public async Task<Employee?> GetEmployeeDetails(int employeeId)
    {
        return await _httpClient.GetFromJsonAsync<Employee>($"api/employee/{employeeId}");
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var response = await _httpClient.PostAsJsonAsync<Employee>("api/employee", employee);
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Employee>(content);
    }

    public async Task UpdateEmployee(Employee employee)
    {
        await _httpClient.PutAsJsonAsync("api/employee", employee);
    }

    public async Task DeleteEmployee(int employeeId)
    {
        await _httpClient.DeleteAsync($"api/employee/{employeeId}");
    }
}