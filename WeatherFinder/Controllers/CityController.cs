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
    public class CityController : ApiController
    {
        private IWeatherModel _model;

        public CityController(IWeatherModel model)
        {
            _model = model;
        }
        [Route("api/country/{countryCode}/city")]
        public IEnumerable<City> Get(string countryCode)
        {
            return _model.GetCity(countryCode);
        }
    }
}
