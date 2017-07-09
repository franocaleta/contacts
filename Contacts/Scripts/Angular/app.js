var app = angular.module('app', ['ngRoute']);

// configure our routes
app.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Scripts/Angular/pages/index.html',
            controller: 'mainController'
        })

        // route for the about page
        .when('/createNew', {
            templateUrl: 'Scripts/Angular/pages/createNew.html',
            controller: 'createNewController'
        })

        // route for the contact page
        .when('/search', {
            templateUrl: 'Scripts/Angular/pages/search.html',
            controller: 'searchController'
        })
        .when('/edit/:id', {
            templateUrl: 'Scripts/Angular/pages/edit.html',
            controller: 'editController'
    });
});

// create the controller and inject Angular's $scope

