"use strict";
$application.controller("login", ["$scope", "$http", function ($scope, $http) {
    $scope.signIn = function () {
        $http({
            method: "POST",
            url: "/SecurityHandler.ashx",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: {
                userName: $scope.userName,
                password: $scope.password
            }
        }).success(function () {
            window.location = "/";
        });
    }
}]);