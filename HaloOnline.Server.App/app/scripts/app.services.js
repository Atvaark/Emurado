(function () {
    "use strict";
	var app = angular.module('app');

	app.factory('endpointService', ['endpointServer', function (endpointServer) {
	    return {
			loginEndpoint: endpointServer + '/AuthorizationService.svc/SignIn',
			createAccountEndpoint: endpointServer + '/AuthorizationService.svc/CreateAccount'
		};
	}]);

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
				$http.post(endpointService.loginEndpoint, request)
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
				$http.post(endpointService.createAccountEndpoint, request)
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
