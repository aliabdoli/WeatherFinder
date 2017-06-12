
var loadingSpinnerDirective = function ($http) {
    return {
        restrict: 'E',
        replace: true,
        templateUrl: 'js/angular/common/loading-spinner.html',
        link: function (scope, elem, attrs) {
            scope.isLoading = function () {
                return $http.pendingRequests.length > 0;
            }
        }
    }
};
var formMessageDirective = function($http) {
    var messageFormats = [
        {
            //success
            severity: 0,
            format: {
                mainDivClass: "messageSuccess",
                source: "img/iconSuccess.png",
                fieldValidationClass: "field-validation-success"
            }
        },
        {
            //info
            severity: 1,
            format: {
                mainDivClass: "messageInfo",
                source: "img/iconInfo.png",
                fieldValidationClass: "field-validation-info"
            }
        },
        {
            //warning
            severity: 2,
            format: {
                mainDivClass: "messageWarning",
                source: "img/iconWarning.png",
                fieldValidationClass: "field-validation-warning"
            }
        },
        {
            //error
            severity: 3,
            format: {
                mainDivClass: "alert alert-danger",
                source: "img/iconError.png",
                fieldValidationClass: "alert alert-danger"
            }
        }
    ];

    return {
        restrict: 'E',
        scope: {
            severity: "=",
            message: "="
        },
        //TODO: why replace true!!!! does it merge scopes!!!!
        replace: true,
        templateUrl: 'js/angular/common/form-message.html?8',
        link: function(scope, elem, attrs) {
            scope.messageFormats = messageFormats;
            
            scope.isPending = function() {
                return $http.pendingRequests.length > 0;
            };

            scope.$watch(scope.isPending, function (nVal) {
                scope.message = (nVal) ? "" : scope.message;
            });

            //just show the last http request message
            scope.$watch(scope.isPending, function (nVal) {
                scope.message = (nVal) ? "" : scope.message;
            });
        }
    }
};

angular.module("mainApp.common")
    .directive('loadingSpinner', ['$http', loadingSpinnerDirective])
    .directive('formMessage', ['$http', formMessageDirective]);


