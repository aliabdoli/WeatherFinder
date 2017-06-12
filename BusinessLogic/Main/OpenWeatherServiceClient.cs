using BusinessLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data;
using RestSharp;

namespace BusinessLogic.Main
{
    public class OpenWeatherServiceClient : IOpenWeatherServiceClient
    {
        public WeatherOpenServiceResponse GetWeather(string cityName)
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5");

            var request = new RestRequest("weather?q={cityName}", Method.GET);
            request.AddParameter("APPID", "09ff83a85aee590fbce9a46dcf401f0e"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("cityName", cityName); // replaces matching token in request.Resource

            var response = client.Execute<WeatherOpenServiceResponse>(request);
            var name = response.Data.Name;

            return response.Data;
        }
    }
}
