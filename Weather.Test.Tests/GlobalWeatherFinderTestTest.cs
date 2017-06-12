// <copyright file="GlobalWeatherFinderTestTest.cs">Copyright ©  2017</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Test.BusinessLogic;

namespace WeatherApp.Test.BusinessLogic.Tests
{
    [TestClass]
    [PexClass(typeof(GlobalWeatherFinderTest))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GlobalWeatherFinderTestTest
    {

        [PexMethod(MaxBranches = 20000)]
        public void IfReturnListOfCities([PexAssumeUnderTest]GlobalWeatherFinderTest target)
        {
            target.IfReturnListOfCities();
            // TODO: add assertions to method GlobalWeatherFinderTestTest.IfReturnListOfCities(GlobalWeatherFinderTest)
        }
    }
}
