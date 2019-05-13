"use strict";
$application.controller("index", ["$scope", "chatConnection", function ($scope, chatConnection) {
    $scope.messages = "Connected";

    $scope.click = function () {
        chat.send($scope.message);
    };

    chat.received(function (data) {
        $scope.$apply(function () {
            $scope.messages = $scope.messages + "\n" + data;
        });
    });
}]);