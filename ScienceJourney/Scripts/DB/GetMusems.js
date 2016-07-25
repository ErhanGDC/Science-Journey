(function ()
{
    var app = angular.module('myApp', []);
    app.controller('CtrlGetMuseum', function ($scope, $http) {
        $scope.init = function () {
            GetMuseum();
        };
        var GetMuseum = function () {
            $http.get("/Museum/GetMuseums").then(function (response) {
                $scope.museums = response.data;
            });
        }
    })
})();