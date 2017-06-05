var PropApp = angular.module('PropApp', ['ngRoute', 'PropControllers']);

PropApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
    {
        templateUrl: 'templates/list.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        templateUrl: 'templates/edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: 'templates/edit.html',
        controller: 'EditController'
    }).
    when('/delete/:id',
    {
        templateUrl: 'templates/delete.html',
        controller: 'DeleteController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });
}]);