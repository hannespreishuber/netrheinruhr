angular.module('App').factory('kurseFactory', function ($resource) {
    return $resource('/api/kurse/:id');
});