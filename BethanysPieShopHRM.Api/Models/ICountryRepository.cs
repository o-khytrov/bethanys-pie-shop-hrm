using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
