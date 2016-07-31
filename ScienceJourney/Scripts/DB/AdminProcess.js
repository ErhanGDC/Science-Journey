
(function() {

    var adminApp = angular.module('adminApp', []);

    adminApp.controller('CtrlGetArtefact', function ($scope, $http) {
        $scope.init = function () {
            GetArtefact();
        };
        var GetArtefact = function () {
            $http.get("/Artefact/GetArtefacts").then(function (response) {
                $scope.artefacts = response.data;
            });
        }
        debugger;
        console.log($scope.artefacts);
        debugger;
    });

    adminApp.controller('CtrlGetMuseums', function ($scope, $http) {
        $scope.init = function () {
            GetMuseums();
        };
        var GetMuseums = function () {
            $http.get("/Admin/GetMuseums").then(function (response) {
                $scope.museums = response.data;
            });
            debugger;
            console.log($scope.museums);
            debugger;
        }
    });

    adminApp.controller('CtrlGetArticles', function ($scope,$http) {
        $scope.init = function () {
            GetArticles();
        };
        var GetArticles = function () {
            $http.get("/Admin/GetArticles").then(function (response) {
                $scope.articles = response.data;})
        }
        debugger;
        console.log($scope.articles);
        debugger;
    })

    adminApp.controller('CtrlGetScientist', function ($scope, $http) {
        $scope.init = function () {
            GetScientist();
        }
        var GetScientist = function () {
            $http.get("/Admin/GetScientist").then(function (response) {
                $scope.scientists = response.data
            });
        }

        $scope.send = function () {
            debugger;
            console.log($scope.scientists);
            debugger;
            $scope.scientists.ScientistID = $scope.scientists.ScientistID;
            $scope.scientists.LastName = $scope.scientists.LastName;
            $scope.scientists.FirstName = $scope.scientists.FirstName;
            $scope.scientists.AddressID = $scope.scientists.AddressID;
            $scope.scientists.Title = $scope.scientists.Title;
            $scope.scientists.MiddleName = $scope.scientists.MiddleName;
            $scope.scientists.Picture = $scope.scientists.Picture;

            $http.post('/Admin/SaveScientist', $scope.scientists).then(function (response) {
                debugger;
                console.log(response);
                $scope.scientists = {};
            })
        }
    })

    adminApp.controller('CtrlGetAddresses', function ($scope,$http) {
        $scope.init=function()
        {
            GetAddresses();
        }
        var GetAddresses = function () {
            $http.get("/Admin/GetAddresses").then(function (response) {
                $scope.addresses = response.data;
            });
            debugger;
            console.log($scope.addresses);
            debugger;
        }
    })

})();

