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
    public class OpenWeatherFinderTest
    {
        [Test]
        public void IfReturnWeather()
        {
            //Arrange
            Mock<IOpenWeatherServiceClient> client = new Mock<IOpenWeatherServiceClient>();
            Mock<IGlobalWeatherServiceClient> globalClient = new Mock<IGlobalWeatherServiceClient>();

            var weather = new WeatherOpenServiceResponse() { Dt = DateTime.Now, Coord = new Coord() { Lat = 1, Lon = 2 }, visibility = "Good" };
            client.Setup(x => x.GetWeather(It.IsAny<string>())).Returns<string>((code) => weather);
            
            var finder = new OpenWeatherFinder(globalClient.Object, client.Object);

            //Act
            var result = finder.GetWeather("United Kingdom", "London");

            //Asset
            Assert.AreEqual(result.Time, weather.Dt, "Time does not match.");
            Assert.IsTrue(result.Location.Contains(weather.Coord.Lat.ToString()), "Coordination does not match.");
            Assert.IsTrue(result.Visibility == weather.visibility , "Visibility does not match");
        }
    }
}
