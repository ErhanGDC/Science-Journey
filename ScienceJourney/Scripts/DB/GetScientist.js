var myApp = angular.module('myApp', []);

myApp.controller('scientistCtrl', function ($scope, $http) {

    $scope.scientist = "";
    $scope.selectScientist = function (id) {
        $http.post("/Scientist/GetScientistById", { id: id })
        .success(function(result) {
            $scope.scientist = result;
        })
        .error(function(result) {
            console.log(result);
        })
    }
});