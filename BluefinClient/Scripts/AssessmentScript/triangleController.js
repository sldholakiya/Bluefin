(function () {
    "use strict";

    var app = angular.module("bluefin");
    app.controller("triangleController", ["$scope", "$http", "$location", "appSettings", triangleController]);
        
    function triangleController($scope, $http, $location, appSettings)
    {
        $scope.model =
            {
                sideA: "",
                sideB: "",
                sideC: "",
                result: "",
                isBusy: false,
                message: ""
            };

        $scope.submit = function (form) {

            if (!form.$valid) {
                alert('form is not valid');
                return;
            }
            $scope.model.message = "Please wait.";
            $scope.model.isBusy = true;

            var data = {
                a: $scope.model.sideA,
                b: $scope.model.sideB,
                c: $scope.model.sideC,
            };
            $http({ url: appSettings.serverPath + 'api/Assessment/Triangle', params: data, method: 'GET' })
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