using BusinessLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data;
using BusinessLogic.GobalWeatherService;
using System.Xml.Serialization;
using System.IO;

namespace BusinessLogic.Main
{
    
    public class GlobalWeatherFinder : IWeatherFinder
    {
        protected List<Country> Countries {get; }
        private readonly IGlobalWeatherServiceClient _client;
        
        private const string NotFoundContent = "Data Not Found";
        public GlobalWeatherFinder(IGlobalWeatherServiceClient client)
        {
            Countries = new List<Country> {
                new Country { Code = "United Kingdom", Name="United Kingdom"},
                new Country { Code = "Australia", Name="Australia"},
                new Country { Code = "Poland", Name="Poland"},
            };

            _client = client;
        }
        public IEnumerable<City> GetCities(string countryCode)
        {
            var result = _client.GetCitiesByCountry(countryCode);
            return ConvertToCity(result);
        }

        public IEnumerable<Country> GetCountries()
        {
            return Countries;
        }

        public virtual Weather GetWeather(string cityCode, string countryCode)
        {
            var result = _client.GetWeather(cityCode.Denormalise(), countryCode);
            if (result == null || result.Trim() == NotFoundContent)
                return null;
            return ConvertToWeather(result);
        }

        /// <summary>
        /// Unfortunately I am not able to find the weather for any city in Global Weather Service. 
        /// So, I assumed that they have the same structure as Data.Weather.cs.
        /// </summary>

        private Weather ConvertToWeather(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CityGlobalServiceResponse));
            using (TextReader reader = new StringReader(data))
            {
                WeatherGlobalServiceResponse globalWeather = serializer.Deserialize(reader) as WeatherGlobalServiceResponse;
                var weather = new Weather()
                {
                    City = globalWeather.City,
                    Code = globalWeather.Code,
                    DewPoint = globalWeather.DewPoint,
                    Location = globalWeather.Location,
                    Pressure = globalWeather.Pressure,
                    RelativeHumidity = globalWeather.RelativeHumidity,
                    SkyConditions = globalWeather.SkyConditions,
                    Temprature = globalWeather.Temprature,
                    Time = globalWeather.Time,
                    Visibility = globalWeather.Visibility,
                    Wind = globalWeather.Wind
                };
                return weather;    
            }
        }
        private IEnumerable<City> ConvertToCity(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CityGlobalServiceResponse));
            using (TextReader reader = new StringReader(data))
            {
                CityGlobalServiceResponse globalWeather = serializer.Deserialize(reader) as CityGlobalServiceResponse;
                var cities = globalWeather.Table.Select(t => new City()
                {
                    Code = t.CityName.Normalise(),
                    Name = t.CityName,
                    Country = new Country()
                    {
                        Code = t.CountryName,
                        Name = t.CountryName
                    }
                });
                return cities;
            }
        }
    }
}
