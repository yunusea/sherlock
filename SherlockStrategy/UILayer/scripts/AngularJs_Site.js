(function (angular) {
    var app = angular.module("app", []);
<<<<<<< HEAD
    app.controller("MainController", ["$scope", "$http", "$log", "$location", function UserController($scope, $http, $log, $location) {
        $scope.loading = true;

        //Listeleme İşlemi
        function GetUsers() {
            $http.get("/User/GetUserList").success(function (data) {
                $scope.users = data;
            }).error(function (ex) {
                $log.info(ex);
            })
        }

        GetUsers();
       
        //Kayıt İşlemi
=======
    app.controller("UserController", ["$scope", "$http", "$log", function UserController($scope, $http, $log) {

        $http.get("/Account/GetUserList").success(function (data) {
            $log.info("All User Repos Data Taken!");
            $scope.users = data;
        }).error(function (ex) {
            $log.info(ex);
        })
       
        $scope.DeleteUser = function (Id) {
            var data = { Id: Id};
            $http.post("/Account/DeleteUser", data).success(function () {
                console.log("Delete User Data Success");

                }).error(function (ex) {
                    console.log(ex);
                })
        };

        //Kayıt ekleme işleminin yapıldığı kısım
>>>>>>> 18615c89d86d5dc0f66dd1a2b7d6877109f0de27
        $scope.SingUpUser = function () {

            if ($("#btnSingUp").val() == "Kayıt Ol") {

                if ($scope.SuPassword != $scope.SuPasswordConfirm) {
                    $scope.confirmalert = "Şifreler Eşleşmiyor !";
                }
                else
                {
                    var data = { UserName: $scope.SuUserName, Password: $scope.SuPassword, EMail: $scope.SuEMail };

                    $http.post("/User/SaveUser", data).success(function (newUser) {
                        $scope.data = newUser;
                        $scope.singUpMessage = "Kayıt İşlemi Başarılı Bir Şekilde Gerçekleşti !";
                    }).error(function (ex) {
                        console.log(ex);
                    });
                    $scope.confirmalert = "";
                }
            }
        };

        //Giriş İşlemi
        $scope.LoginUser = function () {

            if ($("#btnLogin").val() == "Giriş Yap") {
                var data = { UserName: $scope.SiUserName, Password: $scope.SiPassword };

                $http.post("/Account/Login", data).success(function (loginUser) {
                    if (loginUser.UserName == data.UserName && loginUser.Password == data.Password) {
                        $scope.data = loginUser;
                        console.log("Giriş Başarılı");
                        window.location = "/Anasayfa";
                    }
                    else
                    {
                        console.log(loginUser);
                        $scope.Message = loginUser;
                    }
                }).error(function (ex) {
                    console.log(ex);
                });
            }
        };

<<<<<<< HEAD
        //Çıkış İşlemi
        $scope.LogoutUser = function () {

                $http.post("/Account/Logout").success(function () {
                    window.location = "/SingupAndSignin";
                }).error(function (ex) {
                    console.log(ex);
                });
        };
        
        //Silme İşlemi
        $scope.DeleteUser = function (Id) {
            var data = { Id: Id};
            $http.post("/User/DeleteUser", data).success(function () {
                GetUsers();
                }).error(function (ex) {
                    console.log(ex);
                })
        };

        //Kullanıcı Güncelleme İşlemi
        $scope.UpdateUser = function (Id) {
            var data = { Id: Id };
            $http.post("/User/UserUpdate", data).success(function () {
                GetUsers();
            }).error(function (ex) {
                console.log(ex);
            });
        };

=======
>>>>>>> 18615c89d86d5dc0f66dd1a2b7d6877109f0de27
    }]);

})(angular);