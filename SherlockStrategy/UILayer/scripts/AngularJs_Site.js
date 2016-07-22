﻿(function (angular) {
    var app = angular.module("app", []);

    app.controller("MainController", ["$scope", "$http", "$log", "$location", function UserController($scope, $http, $log, $location) {
        $scope.loading = true;

        //Listeleme İşlemi
        function GetUsers() {
            $http.get("/User/GetUserList").success(function (data) {
                $scope.users = data;
            }).error(function (ex) {
                $log.info(ex);
            })
        };
        GetUsers();

        //Kayıt Sözleşmesini Getir
        function SingupContract() {
            $http.get("/Account/GetSingupContract").success(function (data) {
                $scope.SingupContractMessage = data;
            }).error(function (ex) {
                $log.info(ex);
            })
        };
        SingupContract();

        //Profil Bilgilerini Getir
        function GetProfilInfo() {
            $http.get("/User/GetProfilInfo").success(function (data) {
                $scope.UserName = data.UserName;
            }).error(function (ex) {
                $log.console(ex);
            });
        }
        GetProfilInfo();

        //Kayıt sözleşme metni getir
        function GetSingupContractText() {
            $http.get("/Setting/GetContractText").success(function (data) {
                $scope.SingUpContractText = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        GetSingupContractText();

        //TODO:
        //$scope.GetWriteMessage = function (Id) {
        //    if ($("#btnWriteMessage").val() == "Mesaj Yaz") {
        //        var data = { Id: Id }
        //        $http.post("/Message/GetWriteMessageData", data).success(function (resultData) {
        //                $location.path('/MesajYaz', resultData);
        //        }).error(function (ex) {
        //            console.log(ex);
        //        });
        //    }
        //};
        //$scope.GoWriteMessage = function (Id) {
        //    if ($("#btnWriteMessage").val() == "Mesaj Yaz") {
        //        //var data = { Id: Id };
        //        //$scope.datascope = data;
        //        Result:
        //            {
        //                Id: Id
        //            };
        //        window.location = "/MesajYaz";
        //    }
        //};
        //function GetWriteMessageData() {
        //    var data = $location.search().Id;
        //    $http.post("/Message/GetWriteMessageData", data).success(function (resultData) {
        //        $scope.ReturnData = resultData;
        //    }).error(function (ex) {
        //        $log.console(ex);
        //    });
        //};
        //GetWriteMessageData();

        //Kayıt Sözleşmesi güncellemesi
        $scope.SingUpContractUpdate = function () {

            if ($("#btnSingUpContractUpdate").val() == "Onaylıyorum") {

                $http.post("/Account/SingUpContractUpdateControlChecked").success(function () {
                    console.log("Giriş Başarılı");
                    window.location = "/Anasayfa";
                }).error(function (ex) {
                    console.log(ex);
                    $scope.singUpMessage = "Kayıt işlemi sırasında beklenmedik bir hata oluştu !";
                });
            }
        };

        //Kayıt ekleme işleminin yapıldığı kısım
        $scope.SingUpUser = function () {

            if ($("#btnSingUp").val() == "Kayıt Ol") {

                if ($scope.SuReadContract == true) {
                    if ($scope.SuPassword != $scope.SuPasswordConfirm) {
                        $scope.confirmalert = "Şifreler Eşleşmiyor !";
                    }
                    else {
                        var data = { UserName: $scope.SuUserName, Password: $scope.SuPassword, EMail: $scope.SuEMail };

                        $http.post("/User/SaveUser", data).success(function (newUser) {
                            $scope.data = newUser;
                            $scope.singUpMessage = "Kayıt İşlemi Başarılı Bir Şekilde Gerçekleşti !";
                        }).error(function (ex) {
                            console.log(ex);
                            $scope.singUpMessage = "Kayıt işlemi sırasında beklenmedik bir hata oluştu !";
                        });
                        $scope.confirmalert = "";
                    }
                }
                else {
                    $scope.singUpMessage = "Merak ettin ve okudun, kabul et !";
                }
            }
        };

        //Giriş İşlemi
        $scope.LoginUser = function () {

            if ($("#btnLogin").val() == "Giriş Yap") {
                var data = { UserName: $scope.SiUserName, Password: $scope.SiPassword };

                $http.post("/Account/Login", data).success(function (loginUser) {
                    if (loginUser.UserName == data.UserName && loginUser.Password == data.Password) {
                        if (loginUser.SingUpContractStatus == false) {
                            window.location = "/SingupContractUpdate";
                        }
                        else {
                            $scope.data = loginUser;
                            console.log("Giriş Başarılı");
                            window.location = "/Anasayfa";
                        }
                    }
                    else {
                        console.log(loginUser);
                        $scope.Message = loginUser;
                    }
                }).error(function (ex) {
                    console.log(ex);
                });
            }
        };

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
            var data = { Id: Id };
            $http.post("/User/DeleteUser", data).success(function () {
                GetUsers();
            }).error(function (ex) {
                console.log(ex);
            })
        };

        //Kullanıcı Güncelleme İşlemi
        $scope.UpdateUserInfo = function () {
            if ($("#btnUpdateUserInfo").val() == "Bilgileri Güncelle") {

                if ($scope.NewPassword != $scope.NewPasswordConfirm) {
                    $scope.confirmalert = "Şifreler Eşleşmiyor !";
                }
                else {
                    var data = { UserName: $scope.UserName, Password: $scope.Password, NewPassword: $scope.NewPassword };

                    $http.post("/User/UserUpdate", data).success(function () {
                        window.location = "/Profil";
                    }).error(function (ex) {
                        console.log(ex);
                    });
                }
            }
        };

        //Sözleşme Metni Düzenleme
        $scope.SettingUpdate = function () {
            if ($("#btnSettingUpdate").val() == "Güncelle") {

                var data = { SingUpContractText: $scope.SingUpContractText };

                $http.post("/Setting/ContractTextUpdate", data).success(function (data) {
                    window.location = "/Ayarlar";
                }).error(function (ex) {
                    console.log(ex);
                });
            }
        };

        //Durum Değitir
        $scope.ChangeStatu = function (Id, Status) {
            var data = { Id: Id, Status: Status };
            $http.post("/User/ChangeStatu", data).success(function () {
                GetUsers();
            }).error(function (ex) {
                console.log(ex);
            });
        };
    }]);

})(angular);