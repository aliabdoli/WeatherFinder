using BusinessLogic.Core;
using BusinessLogic.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Controllers;

namespace WeatherApp.Test.WeatherFinder
{
    public class WeatherControllerTest
    {
        
        [Test]
        public void CheckIfReturnWeatherIfPrimaryFinderReturnsNull()
        {
            //Arrange
            Mock<IWeatherModel> model = new Mock<IWeatherModel>();
            

            var weather = new Weather()
            {
                DewPoint = "dewPoint",
                Location = "Location"
            };

            model.Setup(x => x.GetWeather(It.IsAny<string>(), It.IsAny<string>())).Returns<string, string>((citycode, countryCode) => weather);
            
            var controller = new WeatherController(model.Object);

            //Act
            var result = controller.Get("United Kingdom", "London");

            //Asset
            Assert.AreEqual(result.DewPoint, weather.DewPoint, "Dew Point does not match.");
            Assert.AreEqual(result.Location, weather.Location, "Location not match.");
        }
    }
    
}