(function () {
    "use strict";

    var app = angular.module("bluefin");
    app.controller("reverseWordsController", ["$scope", "$http", "$location", "appSettings", reverseWords]);
    
    function reverseWords($scope, $http, $location, appSettings) {

        $scope.model =
            {
                inputString: "",
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
            $http({ url: appSettings.serverPath + 'api/Assessment/ReverseWords', params: { inputString: $scope.model.inputString }, method: 'GET' })
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