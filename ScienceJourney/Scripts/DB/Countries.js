(function () {
    var app = angular.module('myApp', []);
    app.controller('myCtrl', function ($scope, $http) {
        this.message = "Sign Up";
        var countries = [];
        $http.get("/Home/GetCountries")
        .then(function (response) {
            angular.forEach(response.data, function (value, index) {
                countries.push({ "id": index, "name": value.name });
            })
        });
        this.countries = countries;
    });
})();
