var weatherCtrlFactory = function (service) {
    var vm = this;
	_.assign(vm, {
		model: service.model,
		service: service
	});
}

angular.module("mainApp.weather")
    .controller("WeatherCtrl", ["weatherService", weatherCtrlFactory]);