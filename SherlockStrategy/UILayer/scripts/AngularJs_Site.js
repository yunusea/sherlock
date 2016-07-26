(function (angular) {
    var app = angular.module("app", []);

    app.controller("MainController", ["$scope", "$http", "$log", "$location", function UserController($scope, $http, $log, $location) {
        $scope.loading = true;

        function GetAccount() {
            $http.post("/Account/GetAccountInfo").success(function (data) {
                $scope.AccountInfo = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        GetAccount();

        //Listeleme İşlemi
        function GetUsers() {
            $http.get("/User/GetUserList").success(function (data) {
                $scope.users = data;
            }).error(function (ex) {
                console.log(ex);
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

        function GetUserInBox() {
            $http.get("/Message/GetUserInBox").success(function (data) {
                $scope.InBoxMessages = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        GetUserInBox();

        function GetUserSendBox() {
            $http.get("/Message/GetUserSendBox").success(function (data) {
                $scope.SendBoxMessages = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        GetUserSendBox();

        $scope.ReadMessage = function (Id) {
            if ($("#btnReadMessage").val() == "Oku") {
                window.location = "/MesajOku/" + Id + "";
            }
        };

        $scope.WriteMessage = function (Id) {
            if ($("#btnWriteMessage").val() == "Mesaj Yaz") {
                window.location = "/MesajYaz/" + Id + "";
            }
        };

        $scope.SendMessage = function (SenderId, ReceiverId) {
            if ($("#btnSendMessage").val() == "Mesaj Gönder") {

                var data = { SendUser: SenderId, ReceiverUser: ReceiverId, Subject: $scope.MessageSubject, MessageText: $scope.MessageContent };
                $http.post("/Message/SendMessage",data).success(function () {
                    console.log("Mesaj gönderimi başarılı.");
                    window.location = "/GelenMesaj";
                }).error(function (ex) {
                    console.log(ex);
                    $scope.singUpMessage = "Mesaj Gönderme İşlemi Sırasında Beklenmedik Bir Hata Oluştu !";
                });
            }
        };

        $scope.DeleteMessage = function (Id) {
            var data = { Id: Id };
            $http.post("/Message/DeleteMessage", data).success(function () {
                window.location = "/GelenMesaj";
            }).error(function (ex) {
                console.log(ex);
            })
        };

        $scope.BackToMessageList = function () {
            window.location = "/GelenMesaj";
        };

        $scope.Reply = function (Id) {
            window.location = "/MesajCevapla/" + Id + "";
        };

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