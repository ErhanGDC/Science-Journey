(function () {
    var app = angular.module('myApp', ["ngMessages"]);

    app.controller('CtrlGetCountries', function ($scope, $http) {
        $scope.countries = [];
        $scope.cities = [];

        $scope.init = function () {
            getCountries();
        };

        $scope.getCityByCountryId = function () {
            $scope.cities = [];
            debugger;
            $http.get("/Home/GetCitiesByCountryId?countryId=" + $scope.user.country.id)
            .then(function (response) {
                angular.forEach(response.data, function (value, index) {
                    $scope.cities.push({ "id": index, "name": value.name });
                })
            });
        };

        $scope.send = function () {
            debugger;
            console.log($scope.user);

            $scope.user.password = $scope.user.pw1;
            $scope.user.countryName = $scope.user.country.id;
            $scope.user.cityName = $scope.user.city.id;
            // .post('/someUrl', data, config).then(successCallback, errorCallback);
            $http.post('/Home/Register', $scope.user).then(function (response) {
                debugger;
                console.log(response);
                $scope.user = {};
            });
        };


        var getCountries = function () {
            $http.get("/Home/GetCountries")
            .then(function (response) {
                angular.forEach(response.data, function (value, index) {
                    $scope.countries.push({ "id": index, "name": value.name });
                });
            });
        };
    });

    //For Password Match Validation
    var RegistrationController = function () {
        var model = this;

        model.message = "";

        model.user = {
            username: "",
            password: "",
            confirmPassword: ""
        };

        model.submit = function (isValid) {
            console.log("h");
            if (isValid) {
                model.message = "Submitted " + model.user.username;
            } else {
                model.message = "There are still invalid fields below";
            }
        };

    };

    var compareTo = function () {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compareTo"
            },
            link: function (scope, element, attributes, ngModel) {

                ngModel.$validators.compareTo = function (modelValue) {
                    return modelValue == scope.otherModelValue;
                };

                scope.$watch("otherModelValue", function () {
                    ngModel.$validate();
                });
            }
        };
    };
    app.directive("compareTo", compareTo);
    app.controller("RegistrationController", RegistrationController);
})();