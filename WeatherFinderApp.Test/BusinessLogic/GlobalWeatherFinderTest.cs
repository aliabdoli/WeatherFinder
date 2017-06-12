using BusinessLogic.Core;
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
    [TestFixture]
    public class GlobalWeatherFinderTest
    {
        [Test]
        public void IfReturnListOfCities()
        {
            //Arrange
            Mock<IGlobalWeatherServiceClient> client = new Mock<IGlobalWeatherServiceClient>();

            var cities = "<NewDataSet><Table> <Country>United Kingdom</Country><City>Belfast</City> </Table> </NewDataSet>";
            client.Setup(x => x.GetCitiesByCountry(It.IsAny<string>())).Returns<string>((code) => cities);
            var finder = new GlobalWeatherFinder(client.Object);

            //Act
            var result = finder.GetCities("United Kingdom");

            //Asset
            Assert.AreEqual(result.Count(), 1, "The length of cities does not match.");
            Assert.AreEqual(result.First().Code, "Belfast", "The length of cities does not match.");
        }

        [Test]
        public void IfReturnNoData()
        {
            //Arrange
            Mock<IGlobalWeatherServiceClient> client = new Mock<IGlobalWeatherServiceClient>();

            var weather = "Data Not Found";
            client.Setup(x => x.GetWeather(It.IsAny<string>(), It.IsAny<string>())).Returns<string, string>((countryCode, cityCode) => weather);
            var finder = new GlobalWeatherFinder(client.Object);

            //Act
            var result = finder.GetWeather("UK", "London");

            //Asset
            Assert.IsNull(result, "Does not null when no data.");
        }
    }
}
