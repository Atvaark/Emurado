(function () {
    "use strict";
    var app = angular.module('app');

    app.controller('HomeController', function ($scope) {
        $scope.actions = {}
    });

    app.controller('ConfigController', function ($scope) {
        $scope.actions = {}
        $scope.data = {}
    });

    app.controller('ChatController', function ($scope) {
        $scope.actions = {}
        $scope.data = {}
    });

    app.controller('NavigationController', ['$rootScope', '$scope', 'accountService', function ($rootScope, $scope, accountService) {
        var actions = $scope.actions = {}
        var data = $scope.data =
        {
            user: {
                authenticated: false,
                username: '',
                nickname: ''
            },
            loginuser: {
                username: '',
                password: ''
            },
            loginerror: '',
            registeruser: {
                username: '',
                password: '',
                nickname: ''
            },
            registererror: ''
        }

        $rootScope.$on("currentUserUpdated", function () {
            data.user = {
                authenticated: accountService.currentUser.authenticated,
                username: accountService.currentUser.username,
                nickname: accountService.currentUser.nickname
            }
        });

        actions.logout = function () {
            accountService.logout();
        };

        actions.resetLoginUser = function () {
            data.loginuser = {
                username: '',
                password: ''
            };
        };

        actions.resetRegisterUser = function () {
            data.registeruser = {
                username: '',
                password: '',
                nickname: ''
            };
        };

        actions.login = function () {
            accountService.login(data.loginuser)
                .then(function () {
                    actions.resetLoginUser();
                }, function () {
                    alert('Login failed');
                    actions.resetLoginUser();
                });
        };

        actions.register = function () {
            accountService.register(data.registeruser)
                .then(function () {
                    $('#registerModal').modal('hide');
                    actions.resetRegisterUser();
                }, function () {
                    alert('Registration failed');
                    actions.resetRegisterUser();
                });
        };

    }]);

})();


