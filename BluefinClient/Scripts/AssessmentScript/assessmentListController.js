(function () {
    "use strict";

    var app = angular.module("bluefin");
    app.controller("assessmentListController", ["$scope", "$http", "$location", "$log", assessmentListController]);

    function assessmentListController($scope, $http, $location, $log)
    {
        $scope.reverseWord = function () {
            $location.path('/reverseWords');
        };

        $scope.triangle = function () {
            $location.path('/trianble');
        };

        $scope.linkedList = function () {
            $location.path('/linkedList');
        };
    };
}());