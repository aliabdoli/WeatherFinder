using BusinessLogic.Core;
using BusinessLogic.GobalWeatherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Main
{
    public class GlobalWeatherServiceClient : IGlobalWeatherServiceClient
    {
        private readonly GlobalWeatherSoapClient _client;
        private const string ConfigKey = "GlobalWeatherSoap12";
        public GlobalWeatherServiceClient()
        {
            _client = new GlobalWeatherSoapClient(ConfigKey);
        }

        public string GetCitiesByCountry(string countryCode)
        {
            return _client.GetCitiesByCountry(countryCode);
        }

        public string GetWeather(string cityCode, string countryCode)
        {
            return _client.GetWeather(cityCode, countryCode);
        }
    }
}
