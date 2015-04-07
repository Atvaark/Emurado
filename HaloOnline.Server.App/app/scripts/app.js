(function () {
    "use strict";
    var app = angular.module('app', [
        'ngRoute'
    ]);

    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider
            .when('/', {
                templateUrl: 'views/home.html',
                controller: 'HomeController'
            })
            .when('/config', {
                templateUrl: 'views/config.html',
                controller: 'ConfigController'
            })
            .when('/chat', {
                templateUrl: 'views/chat.html',
                controller: 'ChatController'
            })
            .otherwise({
                redirectTo: '/home'
            });
    }]);
})();