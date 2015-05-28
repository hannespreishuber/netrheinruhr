angular.module('App').controller('kurseController', function ($scope, kurseFactory) {
    $scope.kurse = kurseFactory.query();
    $scope.save = function (vm) {
        vm.datum = new Date(vm.datum);
        kurseFactory.save(vm);

    };
    var sproxy = $.connection.myHub1;
    sproxy.on('freshme', function (kurs) {
        $scope.kurse.push(kurs);
        $scope.$apply();
    });

    $.connection.hub.start();
});