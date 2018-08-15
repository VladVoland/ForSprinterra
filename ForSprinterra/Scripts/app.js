'use strict';

var app = angular.module('myApp', [
    'ngRoute',
    'ngResource'
]);
app.config(function ($routeProvider) {
    $routeProvider.when('/storeToken', { templateUrl: 'Views/storeToken.html', controller: 'storeToken' });
    $routeProvider.when('/productsView', { templateUrl: 'Views/productsView.html', controller: 'productsView' });
    $routeProvider.when('/concreteProduct/:id', { templateUrl: 'Views/concreteProduct.html', controller: 'concreteProduct' });
    $routeProvider.otherwise({ redirectTo: '/storeToken' });
});