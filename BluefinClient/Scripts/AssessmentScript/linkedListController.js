(function () {
    "use strict";

    var app = angular.module("bluefin");
    app.controller("linkedListController", ["$scope", "$http", "$location", "appSettings", linkedListController]); 
    
    function linkedListController($scope, $http, $location, appSettings) {
        $scope.model =
            {
                result: "",
                isBusy: false,
                message: ""
            };

        $scope.submit = function (form) {

            $scope.model.message = "Please wait.";
            $scope.model.isBusy = true;

            $http({ url: appSettings.serverPath + 'api/Assessment/GetElement', method: 'GET' })
            .then(function (res) {
                $scope.model.result = res.data;

            })
            .finally(function () {
                $scope.model.message = "";
                $scope.model.isBusy = false;
            });
        }

        $scope.back = function () {
            $location.path('/');
        };
    };
}());