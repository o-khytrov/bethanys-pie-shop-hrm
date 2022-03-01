using System.Net.Http.Json;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Services;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategory(int jobCategoryId);
}

public class JobCategoryDataService : IJobCategoryDataService
{
    private HttpClient _httpClient;

    public JobCategoryDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<JobCategory>>($"api/jobcategory");
    }

    public async Task<JobCategory> GetJobCategory(int jobCategoryId)
    {
        return await _httpClient.GetFromJsonAsync<JobCategory>($"api/jobcategory/{jobCategoryId}");
    }
}