(function ()
{
    var app = angular.module('myApp', []);

    app.controller('CtrlGetMuseum', function ($scope, $http) {
        $scope.init = function () {
            GetMuseum();
            GetPicturePath();
                 };
        var GetMuseum = function () {
            $http.get("/Museum/GetMuseums").then(function (response) {
                $scope.museums = response.data;
            });
        }

        var GetPicturePath = function () {
            $http.get("/Museum/GetPicturePath").then(function (response) {
                $scope.imagePaths = response.data;
                debugger;
                console.log($scope.imagePaths);
                debugger;
            });
        }

    })
})();