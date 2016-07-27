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


    //app.controller('CtrlGetArteFact', function ($scope, $http) {
    //    $scope.init = function () {
    //        GetArteFact();
    //    };
    //    var GetArtefact = function () {
    //        $http.get("/Museum/GetArteFects").then(function (response) {
    //            $scope.artefacts = response.data;
    //        });
    //    }
    //})
   
})();