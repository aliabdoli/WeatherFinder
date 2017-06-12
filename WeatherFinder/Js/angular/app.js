var modules = [
    "ngRoute",
    "ngAnimate",
    "ngSanitize",
    "ngResource",
    "ui.select",
   // "ui.bootstrap",

    "mainApp.weather",
    "mainApp.common"
];

var configure = function ($locationProvider, $routeProvider, $provider, $httpProvider) {
    //no hash-prefix url, html history (state) is used
    $locationProvider.html5Mode(true);

    var route = {
        //controller: 'WeatherCtrl',
        templateUrl: '/Js/angular/weather/weather.html?3'//,
        //resolve: {
        //    "WeatherInit": function (WeatherService) {
        //        return WeatherService.promise;
        //    }
        //}
    };
    $routeProvider.when('/', route);
    //$routeProvider.when('/weather', route);

    //$routeProvider.otherwise({ templateUrl: "Js/angular/common/not-found.html" });

    //less number of digests
    $httpProvider.useApplyAsync(true);

    //Any http request 
    var errorHandlingIntercept = function ($q, $location, ErrorHandlingService) {
        var interceptor = {
            responseError: responseError,
            response: handleResponse
        };

        return interceptor;

        function handleResponse(response) {
            if (!response.data) {
                ErrorHandlingService.noData();
            }
            return response;
        }

        function responseError(rejection) {
            if (rejection.status === 404) {
                ErrorHandlingService.notFound();
                return $q(function () { return null; });
            }
            return $q.reject(rejection);
        }
    }
        
    $provider.factory("errorHandlingIntercept", ["$q", "$location", "ErrorHandling", errorHandlingIntercept]);
}

var mainApp = angular.module("mainApp", modules);
mainApp.config(["$locationProvider", "$routeProvider", "$provide", "$httpProvider", configure]);


angular.module("mainApp.weather", []);
angular.module("mainApp.common", []);

