using BusinessLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data;

namespace BusinessLogic.Main
{
    public class WeatherModel : IWeatherModel
    {
        public WeatherModel(IWeatherFinder primaryWeatherFinder, IWeatherFinder alternativeWeatherFinder)
        {
            PrimaryWeatherFinder = primaryWeatherFinder;
            AlternativeWeatherFinder = alternativeWeatherFinder;
        }

        public IWeatherFinder AlternativeWeatherFinder { get; private set; }
        public IWeatherFinder PrimaryWeatherFinder { get; private set; }

        public IEnumerable<Country> GetAllCountries()
        {
            return PrimaryWeatherFinder.GetCountries();
        }

        public IEnumerable<City> GetCity(string countryCode)
        {
            return PrimaryWeatherFinder.GetCities(countryCode);
        }
        
        public Weather GetWeather(string cityCode, string countryCode)
        {
            var weather = PrimaryWeatherFinder.GetWeather(cityCode, countryCode);
            if (weather == null)
                weather = AlternativeWeatherFinder.GetWeather(cityCode, countryCode);
            return weather;
        }
    }
}
