/// <reference path="G:\dev\AngularJsTodo\AngularJsTodo\Scripts/angular.js" />
var TodoApp = angular.module('TodoApp', ['ngResource', 'ngRoute']);
TodoApp.config(function ($routeProvider) {
    $routeProvider.when('/',
    { templateUrl: '/app/views/list.html', controller: 'ListController' }).
    when('/new', { templateUrl: '/app/views/details.html', controller: 'CreateController' })
        .when('/edit/:editId', { templateUrl: '/app/views/details.html', controller: 'EditController' })
        .otherwise({ redirectTo: '/' });
})