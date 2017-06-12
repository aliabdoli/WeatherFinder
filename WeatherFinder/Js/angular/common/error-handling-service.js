var ErrorHandlingServiceFactory = function ($rootScope) {
    var result = {
        errorHandling: $rootScope.errorHandling,
        notFound: function() {
            $rootScope.errorHandling = {
                severity: "3",
                message: "Cannot find the resource"
            };
        },
        noData: function() {
            $rootScope.errorHandling = {
                severity: "3",
                message: "No data found"
            };
        },
        ClearError: function() {
            $rootScope.errorHandling = {
                severity: "0",
                message: null
            };
        }
    };
    return result;
}

angular.module("mainApp.common")
.factory("ErrorHandlingService", ["$rootScope", ErrorHandlingServiceFactory])