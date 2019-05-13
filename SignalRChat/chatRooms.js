"use strict";
$application.controller("chatRooms", ["$scope", "chat", function ($scope, chat) {
    chat.state.currentChatRoom = $scope.currentChatRoom = "Lobby";
    $scope.chatRoom = "";
    $scope.rooms = [];

    $scope.selectionChanged = function (room) {
        $scope.$emit("chatRoomChanged", room);
        chat.server.join(room);
    };

    $scope.createRoom = function () {
        chat.server.createChatRoom($scope.chatRoom);
        $scope.currentChatRoom = $scope.chatRoom;
        $scope.$emit("chatRoomChanged", $scope.chatRoom);
        $scope.chatRoom = "";
    };

    chat.client(function (client) {
        client.addChatRoom = function (room) {
            $scope.$apply(function () {
                $scope.rooms.push(room);
            });
        }
    });
}]);