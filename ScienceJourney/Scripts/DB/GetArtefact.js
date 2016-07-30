
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
    });

    app.controller('CtrlSaveArtefact', function ($scope, $http) {

        $scope.send = function () {
            debugger;
            console.log($scope.artefacts);
            debugger;
            $scope.artefacts.ArtefactDescription = $scope.artefacts.ArtefactDescription;
            $scope.artefacts.ArtefactName = $scope.artefacts.ArtefactName;
            $scope.artefacts.MuseumID = $scope.artefacts.MuseumID;

            $http.post('/Artefact/SaveArtefact', $scope.artefacts).then(function (response) {
                debugger;
                console.log(response);
                $scope.artefacts = {};
            })
        }


        $scope.init = function () {
            GetMuseum();
        };
        var GetMuseum = function () {
            $http.get("/Artefact/GetMuseums").then(function (response) {
                $scope.museums = response.data;
            });
        };
    });

})();