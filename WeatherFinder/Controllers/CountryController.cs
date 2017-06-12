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
    public class CountryController : ApiController
    {
        private IWeatherModel _model;

        public CountryController(IWeatherModel model)
        {
            _model = model;
        }
        public IEnumerable<Country> Get()
        {
            return _model.GetAllCountries();
        }
    }
}
