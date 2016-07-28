
(function () {
    var app = angular.module('myApp', []);

    app.controller('CtrlGetArtefact', function ($scope, $http) {
        $scope.init = function () {
            GetArtefactsByMuseumId();
        };
        var GetArtefactsByMuseumId = function () {
            $http.get("/Artefact/GetArtefactsByMuseumId?museumId=" + $scope.museums.MuseumID).then(function (response) {
                $scope.artefacts = response.data;
            });
        }
    });
   
    app.controller('CtrlGetMuseum', function ($scope, $http) {
        $scope.init = function () {
            GetMuseum();
        };
        var GetMuseum = function () {
            $http.get("/Artefact/GetMuseums").then(function (response) {
                $scope.museums = response.data;
            });
        }});
    
})();