
(function () {
    var app = angular.module('myApp', []);

    app.controller('CtrlGetArtefact', function ($scope, $http) {
        $scope.init = function () {
            GetArtefact();
        };
        var GetArtefact = function () {
            $http.get("/Artefact/GetArtefacts").then(function (response) {
                $scope.artefacts = response.data;
            });
        }
    })
    
})();