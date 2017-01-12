
(function () {
    "use strict";

    var app = angular.module("bluefin", ["ngRoute", "ngResource"])
                                .constant("appSettings",
                                {
                                    serverPath: "http://localhost:49458/"
                                });

    app.config(["$routeProvider", function ($routeProvider) {
        $routeProvider
            .when('/',
            {
                controller: 'assessmentListController',
                templateUrl: '/Assessment/AssessmentList'
            })
            .when('/reverseWords',
            {
                controller: 'reverseWordsController',
                templateUrl: '/Assessment/ReverseWords'
            })
            .when('/trianble',
            {
                controller: 'triangleController',
                templateUrl: '/Assessment/Triangle'
            })
            .when('/linkedList',
            {
                controller: 'linkedListController',
                templateUrl: '/Assessment/LinkedList'
            })
            .otherwise({ redirectTo: '/' });
    }]);
}());