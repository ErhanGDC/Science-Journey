
(function () {
    var app = angular.module('myApp', []);
    app.controller('CtrlGetScientist', function ($scope,$http) {
        $scope.init = function () {
            GetScientist();
        };
        var GetScientist = function () {
            $http.get("/Scientist/GetScientist").then(function (response) {

                $scope.scientists = response.data;
            });
        }
    })

})();


//(function () {
//    var app = angular.module('myApp', []);
//    debugger;
//    app.controller('CtrlGetScientist', function ($scope, $http) {
//        debugger;
//        $scope.init = function () {
//            debugger;
//            GetScientist();
//        };
//        debugger;
//        var GetScientist = function () {
//            debugger;
//            $http.get("/Scientist/GetScientist")
//            .then(function (response) {
//                debugger;
//                $scope.scientists = response.data;
//                //angular.forEach(response.data, function (value, index) {
//                //    debugger;
//                //    $scope.scientists.push({
//                //        "FirstName": value.FirstName,
//                //        "MiddleName": value.MiddleName,
//                //        "LastName": value.LastName,
//                //        "Title": value.Title
//                //    });
//                //    debugger;
//                //});
//            });
//        };
//    });
//})();













//myApp.controller('scientistCtrl', function ($scope, $http) {

//    $scope.scientist = "";
//    $scope.selectScientist = function (id) {
//        $http.post("/Scientist/GetScientistById", { id: id })
//        .success(function(result) {
//            $scope.scientist = result;
//        })
//        .error(function(result) {
//            console.log(result);
//        })
//    }
//});

//myApp.controller('scientistCtrl', function ($scope, $http) {
//    $http.get("/Scientist/GetScientistById")
//    .then(function (response) { $scope.scientists = response.data.records; });
//});

//var myApp = angular.module('myApp', []);

//var getMessages = function findAll() {
//    db.transaction(
//        function(tx) {
//            var sql = "SELECT (nome) as nomes FROM clientes";
//            tx.executeSql(sql, [],
//                function(tx, results) {
//                    var len = results.rows.length,
//                        clientes = [],
//                        i = 0;
//                    for (; i < len; i = i + 1) {
//                        clientes[i] = results.rows.item(i).nomes;
//                    }
//                    log(clientes + ' rowsss found');
//                    deferred.resolve(clientes);

//                }
//            );
//        },txErrorHandler,
//        function () { }
//    );
//    return deferred.promise;

//};

//return {
//    showClientes: getMessages
//};