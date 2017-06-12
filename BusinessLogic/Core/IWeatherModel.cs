using BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core
{
    public interface IWeatherModel
    {
        IWeatherFinder AlternativeWeatherFinder { get; }
        IWeatherFinder PrimaryWeatherFinder { get; }

        Weather GetWeather(string cityCode, string countryCode);
        IEnumerable<Country> GetAllCountries();
        IEnumerable<City> GetCity(string countryCode);
    }
}
