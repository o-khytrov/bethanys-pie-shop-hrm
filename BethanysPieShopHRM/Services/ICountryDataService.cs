using System.Net.Http.Json;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Services;

public interface ICountryDataService
{
    Task<Country> GetCountryById(int countryId);
    Task<IEnumerable<Country>> GetAllCountries();
}

public class CountryDataService : ICountryDataService
{
    private HttpClient _httpClient;

    public CountryDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Country> GetCountryById(int countryId)
    {
        return await _httpClient.GetFromJsonAsync<Country>($"api/country/{countryId}");
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Country>>("api/country");
    }
}