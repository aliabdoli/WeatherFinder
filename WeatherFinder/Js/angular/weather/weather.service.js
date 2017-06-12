var weatherServiceFactory = function ($resource) {

	var getAllCountries = function () {
	    var country = $resource("/api/country");
		return country.query().$promise;
	}

	var getCities = function (country) {
	    var city = $resource("/api/country/:countryCode/city");
		return city.query({"countryCode": country.Code}).$promise;
	}

	var getWeather = function (city, country) {
		var weather = $resource("/api/country/:countryCode/city/:cityCode/weather");
		return weather.get({"countryCode":country.Code, "cityCode": city.Code}).$promise;
	}

	var service = {
	    model: {},
		getAllCountries: getAllCountries,
		getCities: getCities,
		getWeather: getWeather
	};

    
	return service;
}
angular.module("mainApp.weather")
    .factory("weatherService", ["$resource", weatherServiceFactory]);
