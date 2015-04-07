(function () {
    "use strict";
    var app = angular.module('app');

    app.directive('hoNavigation', function() {
        return {
            scope: {},
            restrict: 'EA',
            templateUrl: 'partials/navigation.html',
            controller: 'NavigationController'
        };
    });
})();