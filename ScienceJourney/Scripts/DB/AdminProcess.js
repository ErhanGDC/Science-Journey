
(function() {

    var adminApp = angular.module('adminApp', []);

    adminApp.controller('CtrlSaveData', function ($scope, $http) {

        $scope.init = function () {
            GetArtefact();
            GetMuseums();
            GetArticles();
            GetScientist();
            GetAddresses();
        };

        var GetArtefact = function () {
            $http.get("/Admin/GetArtefacts").then(function (response) {
                $scope.artefacts = response.data;
            });
            debugger;
            console.log($scope.artefacts);
            debugger;
        }
        var GetMuseums = function () {
            $http.get("/Admin/GetMuseums").then(function (response) {
                $scope.museums = response.data;
            });
            debugger;
            console.log($scope.museums);
            debugger;
        }
        var GetArticles = function () {
            $http.get("/Admin/GetArticles").then(function (response) {
                $scope.articles = response.data;
            })
        }
        var GetScientist = function () {
            $http.get("/Admin/GetScientist").then(function (response) {
                $scope.scientists = response.data
            });
        }
        var GetAddresses = function () {
            $http.get("/Admin/GetAddresses").then(function (response) {
                $scope.addresses = response.data;
            });
        }

        $scope.sendArtefacts = function () {
            $scope.artefacts.ArtefactDescription = $scope.artefacts.ArtefactDescription;
            $scope.artefacts.ArtefactName = $scope.artefacts.ArtefactName;
            $scope.artefacts.MuseumID = $scope.artefacts.MuseumID;

            $http.post('/Admin/SaveArtefact', $scope.artefacts).then(function (response) {
                debugger;
                console.log(response);
                $scope.artefacts = {};
            })
        }

        $scope.sendScientist = function () {
            debugger;
            console.log(('send scientist calisti'));
            //$scope.scientists  //// bu şekilde action'daki AdminModel model'e denk geliyor.
            $http.post('/Admin/SaveScientist', $scope.model).then(function (response) {
                debugger;
                console.log(response);
                $scope.scientists = {};
            })
            window.location = window.location;
        }

        $scope.sendMuseums = function () {
            //$scope.scientists  //// bu şekilde action'daki AdminModel model'e denk geliyor.
            $http.post('/Admin/SaveMuseums', $scope.model).then(function (response) {
                debugger;
                console.log(response);
                $scope.museums = {};
            })
            window.location = window.location;
        }

        $scope.sendArticles = function () {
            //$scope.scientists  //// bu şekilde action'daki AdminModel model'e denk geliyor.
            $http.post('/Admin/SaveArticles', $scope.model).then(function (response) {
                debugger;
                console.log(response);
                $scope.articles = {};
            })
            window.location = window.location;
        }

        $scope.sendAddresses = function () {
            //$scope.scientists  //// bu şekilde action'daki AdminModel model'e denk geliyor.
            $http.post('/Admin/SaveAddresses', $scope.model).then(function (response) {
                debugger;
                console.log(response);
                $scope.addresses = {};
            })
            window.location = window.location;
        }
    });


    adminApp.controller('CtrlFileUpload', function ($scope, FileUploadService) {
        // Variables
        $scope.Message = "";
        $scope.FileInvalidMessage = "";
        $scope.SelectedFileForUpload = null;
        $scope.FileDescription = "";
        $scope.IsFormSubmitted = false;
        $scope.IsFileValid = false;
        $scope.IsFormValid = false;

        //Form Validation
        $scope.$watch("f1.$valid", function (isValid) {
            $scope.IsFormValid = isValid;
        });

      

        // THIS IS REQUIRED AS File Control is not supported 2 way binding features of Angular
        // ------------------------------------------------------------------------------------
        //File Validation
        $scope.ChechFileValid = function (file) {
            var isValid = false;
            if ($scope.SelectedFileForUpload != null) {
                if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                    $scope.FileInvalidMessage = "";
                    isValid = true;
                }
                else {
                    $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
                }
            }
            else {
                $scope.FileInvalidMessage = "Image required!";
            }
            $scope.IsFileValid = isValid;
        };

        //File Select event 
        $scope.selectFileforUpload = function (file) {
            $scope.SelectedFileForUpload = file[0];
        }
        //----------------------------------------------------------------------------------------

        //Save File
        $scope.SaveFile = function () {
            $scope.IsFormSubmitted = true;
            $scope.Message = "";
            $scope.ChechFileValid($scope.SelectedFileForUpload);
            if ($scope.IsFormValid && $scope.IsFileValid) {
                FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription).then(function (d) {
                    alert(d.Message);
                    ClearForm();
                }, function (e) {
                    alert(e);
                });
            }
            else {
                $scope.Message = "All the fields are required.";
            }
        };             

        //Clear form 
        function ClearForm() {
            $scope.FileDescription = "";
            //as 2 way binding not support for File input Type so we have to clear in this way
            //you can select based on your requirement
            angular.forEach(angular.element("input[type='file']"), function (inputElem) {
                angular.element(inputElem).val(null);
            });

            $scope.f1.$setPristine();
            $scope.IsFormSubmitted = false;
        }

    })
    .factory('FileUploadService', function ($http, $q) { // explained abour controller and service in part 2

    var fac = {};
    fac.UploadFile = function (file, description) {
        debugger;
        console.log('upload file çalıştı');
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("description", description);

        var defer = $q.defer();
        $http.post("/Admin/SaveFiles", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("File Upload Failed!");
        });

        return defer.promise;

    }
    return fac;

    });


    fileupload = function () {

        upload(file, function (response) {

            if (response.uploadcomplate) {

                saveUser();


            }

        });

    }

})();

