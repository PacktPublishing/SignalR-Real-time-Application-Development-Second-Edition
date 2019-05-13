"use strict";
(function (global) {
    function makeClientProxyFunction(callback) {
        return function () {
            callback.apply(this, arguments);
        };
    }

    function client(callback) {
        var client = {};
        callback(client);

        for (var property in client) {
            var value = client[property];
            if (typeof value != "function") {
                continue;
            }

            this.on(property, makeClientProxyFunction(value));
        }
    };

    function registerHubFactory($provide, hubName) {
        $provide.factory(hubName, function () {
            var proxy = $.connection.hub.createHubProxy(hubName);
            proxy.client = client;
            return proxy;
        });
    }

    function __nothing() { }

    function setupAndRegisterProxies($provide) {
        for (var property in $.connection) {
            var value = $.connection[property];
            if (typeof value !== "undefined" && value !== null) {
                if (typeof value.hubName !== "undefined" && value !== null) {
                    var hubName = property;
                    var proxy = $.connection.hub.createHubProxy(hubName);

                    // Remarks about the following line:
                    // - SignalR tells the server what hubs its interested in on startup. 
                    //   If there are no client calls, it won't receive messages
                    proxy.client.__need_this_for_subscription__ = __nothing;

                    registerHubFactory($provide, hubName);
                }
            }
        }
    }

    var application = angular.module("SignalRChat", ["ng"]);
    application.config(["$provide",  
        function ($provide) {
            setupAndRegisterProxies($provide);

            $.connection.hub.start().done(function () {
                console.log("Hub connection up and running");
            });

            var chatConnection = $.connection("/chat");
            chatConnection.start().done(function () {
                console.log("Started");
            });

            $provide.constant("chatConnection", chatConnection);
        }
    ]);

    application.directive("feature", ["$sce", function ($sce) {
        return {
            templateUrl: function (element, attributes) {
                return $sce.trustAsHtml(attributes.feature+".html");
            }
        }
    }]);

    global.$application = application;
})(window);
