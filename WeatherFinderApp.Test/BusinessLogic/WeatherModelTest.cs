using BusinessLogic.Core;
using BusinessLogic.Data;
using BusinessLogic.Main;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Test.BusinessLogic
{
    public class WeatherModelTest
    {
        [Test]
        public void CheckIfReturnWeatherIfPrimaryFinderReturnsNull()
        {
            //Arrange
            Mock<IWeatherFinder> pFinder = new Mock<IWeatherFinder>();
            Mock<IWeatherFinder> altFinder = new Mock<IWeatherFinder>();

            var weather = new Weather() {
                DewPoint = "dewPoint",
                Location = "Location"
            };
           
            pFinder.Setup(x => x.GetWeather(It.IsAny<string>(), It.IsAny<string>())).Returns<string, string>((citycode, countryCode) => null);
            altFinder.Setup(x => x.GetWeather(It.IsAny<string>(), It.IsAny<string>())).Returns<string, string>((citycode, countryCode) => weather);

            var finder = new WeatherModel(pFinder.Object, altFinder.Object);

            //Act
            var result = finder.GetWeather("United Kingdom", "London");

            //Asset
            Assert.AreEqual(result.DewPoint, weather.DewPoint, "Dew Point does not match.");
            Assert.AreEqual(result.Location, weather.Location, "Location not match.");
        }
    }
}
