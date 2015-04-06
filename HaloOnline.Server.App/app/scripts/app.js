(function () {
    var app = angular.module('app', [
        'ngRoute'
    ]);

    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider
            .when('/home', {
                templateUrl: 'views/home.html',
                controller: 'HomeController'
            })
            .otherwise({
                redirectTo: '/home'
            });
    }]);

    app.controller('HomeController', function ($scope) {
        $scope.actions = {}
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
            registeruser: {
                username: '',
                password: '',
                nickname: ''
            }
        }

        $rootScope.$on("currentUserUpdated", function() {
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

    app.factory('endpointService', function () {
        return {
            endpointServer: 'http://localhost:11705',
            loginEndpoint: '/AuthorizationService.svc/SignIn',
            createAccountEndpoint: '/AuthorizationService.svc/CreateAccount'
        };
    });

    app.factory('accountService', ['$rootScope', '$http', '$q', 'endpointService', function ($rootScope, $http, $q, endpointService) {
        var accountService = {}

        accountService = {
            currentUser: {
                username: '',
                nickname: '',
                authorizationToken: '',
                authenticated: false
            },


            logout: function () {
                console.log('logout');
                accountService.currentUser = {
                    username: '',
                    nickname: '',
                    authorizationToken: '',
                    authenticated: false
                };
                $rootScope.$emit("currentUserUpdated");
            },
            login: function (user) {
                console.log('login ' + user.username);

                var request = {
                    Login: user.username,
                    Password: user.password,
                    Provider: '',
                    Signature: {
                        Id: ''
                    }
                }

                var deferred = $q.defer();
                $http.post(endpointService.endpointServer + endpointService.loginEndpoint, request)
                    .success(function (data) {
                        console.log('login success');
                        var returnCode = data.SignInResult.retCode;
                        if (returnCode === 0) {
                            accountService.currentUser.username = user.username;
                            accountService.currentUser.authorizationToken = data.SignInResult.data.AuthorizationToken;
                            accountService.currentUser.authenticated = true;
                            $rootScope.$emit("currentUserUpdated");
                            deferred.resolve();
                        } else {
                            deferred.reject();
                        }
                    })
                    .error(function (data, status) {
                        console.log('login error ' + status);
                        deferred.reject();
                    });

                return deferred.promise;
            },
            register: function (user) {
                console.log('register ' + user.username + ' ' + user.nickname);
                var request = {
                    Username: user.username,
                    Password: user.password,
                    Nickname: user.nickname
                };

                var deferred = $q.defer();
                $http.post(endpointService.endpointServer + endpointService.createAccountEndpoint, request)
                    .success(function (data) {
                        accountService.currentUser.username = user.username;
                        accountService.currentUser.authorizationToken = data;
                        accountService.currentUser.authenticated = true;
                        $rootScope.$emit("currentUserUpdated");
                        deferred.resolve();
                    })
                    .error(function () {
                        deferred.reject();
                    });
                return deferred.promise;
            }
        };

        return accountService;
    }]);


})();