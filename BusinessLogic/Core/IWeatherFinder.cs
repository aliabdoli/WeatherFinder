using BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core
{
    public interface IWeatherFinder
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<City> GetCities(string countryCode);
        Weather GetWeather(string cityCode, string countryCode);
    }
}
