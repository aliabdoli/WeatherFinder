var weatherSearchDirective = function (service) {
    return {
        restrict: 'E',
        scope: {
            model: "=",
            service: "="
        },
        replace: true,
        templateUrl: 'js/angular/weather/weather-search.html?12',
        link: function (scope, elem, attrs) {

            service.getAllCountries().then(function (data) {
                scope.countries = data;
            });

            scope.getCities = function (country) {
                service.getCities(country).then(function (data) {
                    scope.cities = data;
                })
            }

            scope.getWeather = function (city) {
                service.getWeather(city, scope.model.country).then(function (data) {
                    scope.model.weather = data;
                })
            }
        }
    }
}

var weatherResultDirective = function () {
    return {
        restrict: 'E',
        scope: {
            model: "=",
        },
        replace: true,
        templateUrl: 'js/angular/weather/weather-result.html?2',
        link: function (scope, elem, attrs) {
        }   
    }
}

angular.module("mainApp.weather")
    .directive('weatherSearch', ['weatherService', weatherSearchDirective])
    .directive('weatherResult', weatherResultDirective);
