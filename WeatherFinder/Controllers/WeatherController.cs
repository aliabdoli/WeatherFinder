using BusinessLogic.Core;
using BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WeatherFinder.Controllers
{
    public class WeatherController : ApiController
    {
        private IWeatherModel _model;

        public WeatherController(IWeatherModel model)
        {
            _model = model;
        }

        [Route("api/country/{countryCode}/city/{cityCode}/weather")]
        public Weather Get(string countryCode, string cityCode)
        {
            return _model.GetWeather(cityCode, countryCode);
        }
    }
}
