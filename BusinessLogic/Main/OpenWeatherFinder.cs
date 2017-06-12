using BusinessLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data;
using System.Net.Http;


namespace BusinessLogic.Main
{
    public class OpenWeatherFinder : GlobalWeatherFinder
    {
        private readonly IOpenWeatherServiceClient _openClient;

        public OpenWeatherFinder(IGlobalWeatherServiceClient globalClient, IOpenWeatherServiceClient openClient): base(globalClient)
        {
            _openClient = openClient;
        }
        public override Weather GetWeather(string cityCode, string countryCode)
        {
            var response = _openClient.GetWeather(cityCode);
            return ConverToWeather(response);
        }

        public Weather ConverToWeather(WeatherOpenServiceResponse data)
        {
            var separator = " -- ";
            var weather = new Weather()
            {
                Time = data.Dt,
                Location = data.Coord?.Lat + separator + data.Coord?.Lon,
                Wind = data.Wind?.Degree + separator + data.Wind?.Speed,
                Visibility = data.visibility,
                SkyConditions = data.Weather?.Select(x => x.Description + separator + x.Main).Aggregate((i, j) => i + separator + j),
                Temprature = (data.Main == null) ? 0 : data.Main.Temp,
                DewPoint = data.Main?.TempMin + separator + data.Main?.TempMax,
                RelativeHumidity = (data.Main == null) ? 0 : data.Main.Humidity,
                Pressure = (data.Main == null) ? 0 : data.Main.Pressure
            };
            return weather;
        }
    }
}
