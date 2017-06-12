using BusinessLogic.GobalWeatherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core
{
    public interface IGlobalWeatherServiceClient
    {
        string GetCitiesByCountry(string countryCode);
        string GetWeather(string cityCode, string countryCode);
    }
}
