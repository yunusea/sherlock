(function (angular) {
    var app = angular.module("app", ['ngSanitize', 'ngAnimate']);

    app.controller("MainController", ["$scope", "$http", "$log", "$location", "$sce", function MainController($scope, $http, $log, $location, $sce) {
        $scope.loading = true;

        function CurrentPageUrl() {
            var currentUrl = window.location.pathname;
            $scope.Url = currentUrl;
        };
        CurrentPageUrl();

        function GetAccount() {
            $http.post("/Account/GetAccountInfo").success(function (data) {
                $scope.AccountInfo = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        GetAccount();

        //XOX Game Start
        //Oyun Listesinden Oyuna Tıklandığında Oyun Sayfasına Yönlendirme
        $scope.GotoGame = function (Id) {
            window.location = "/OyunOyna/" + Id;
        };

        $scope.GotoContinueGame = function (Id) {
            window.location = "/OyunaDevamEt/" + Id;
        };

        $scope.GetTemp = function (Et, Id) {
            var data = { Et: Et, Id: Id };
            $http.post("/Game/EncounterSave", data).success(function (returnData) {
                $scope.EncounterId = returnData.Id;
                var gameData = { Id: Id };
                $http.post("/Game/GetGameInfo", gameData).success(function (returnData) {
                    $scope.templates = [{ name: '/GameTemplates/' + returnData.TempPath, url: '/GameTemplates/' + returnData.TempPath }];
                    $scope.template = $scope.templates[0];
                    var range = [];
                    for (var i = 0; i < 3; i++) {
                        range.push(i);
                    }
                    $scope.range = range;
                    $scope.GameName = returnData.GameName;
                }).error(function (ex) {
                    console.log(ex);
                });
            }).error(function (ex) {
                console.log(ex);
            });
        };

        $scope.GetTempContinue = function (Id) {
            $scope.EncounterId = Id;
            var data = { Id: Id };
            $http.post("/Game/GetCotinueGame", data).success(function (returnData) {
                $scope.templates = [{ name: '/GameTemplates/' + returnData.TempPath, url: '/GameTemplates/' + returnData.TempPath }];
                $scope.template = $scope.templates[0];
                var range = [];
                for (var i = 0; i < 3; i++) {
                    range.push(i);
                }
                $scope.range = range;
                $scope.GameName = returnData.GameName;

                $http.post("/Game/GetLabeledCell", data).success(function (returnData) {
                    $scope.Moves = returnData;
                    for (var j = 0; j < returnData.length + 1; j++) {
                        for (var i = 0; i < 3; i++) {
                            for (var a = 0; a < 3; a++) {
                                if (returnData[j].MoveCellx == i && returnData[j].MoveCelly == a) {
                                    $("#cell" + i + a + "").val("" + returnData[j].CellValue + "");
                                }
                            }
                        }
                    }
                }).error(function (ex) {
                    console.log(ex);
                });
            }).error(function (ex) {
                console.log(ex);
            })
        };

        $scope.GotoOngoingGameList = function () {
            window.location = "/DevamEdenOyunlar";
        };

        $scope.fillCell = function (x1, x2) {
            if ($scope.FinishStatus != 1) {
                var value = $("#cell" + x1 + x2 + "").val();
                if (value == "") {
                    var data = { eId: $scope.EncounterId, MoveCellx: x1, MoveCelly: x2, Value: "X" };
                    $http.post("/Game/SaveMove", data).success(function (returnData) {
                        $("#cell" + x1 + x2 + "").val("X");
                        $scope.GameFinishControl("Oyuncu");
                        
                        if ($scope.FinishStatus != 1) {

                            CellFinishControl();
                            if ($scope.CellFinishReturn == true) {
                                $scope.OpponentMove();
                            }
                        }
                        else {
                            FinishDisableButtons();
                            EncounterStatusUpdate();
                        }
                    }).error(function (ex) {
                        console.log(ex);
                        $("#cell" + x1 + x2 + "").val("");
                    });
                }
            }
            else {
                FinishDisableButtons();
            }
        };

        function FinishDisableButtons() {
            $(".xoxCell").attr("disabled", "disabled");
        }

        function EncounterStatusUpdate() {
            var data = { eId: $scope.EncounterId, winnerInfo: $scope.WinnerPlayler };
            $http.post("/Game/EncounterUpdate", data).success(function (returnData) {
                console.log(returnData);
            }).error(function (ex) {
                console.log(ex);
            });
        };

        function CellFinishControl() {
            var count = 0;
            $(".xoxCell").each(function () {
                if ($(this).val() == "") {
                    count += 1;
                }
            });

            if (count == 0) {
                $scope.CellFinishReturn = false;
                FinishDisableButtons();
                $scope.WinMessage = "Beraberlik kazandı !";
                $scope.WinnerPlayler = 3;
                EncounterStatusUpdate();
            }
            else
            {
                $scope.CellFinishReturn = true;
            }
        };

        $scope.OpponentMove = function () {

            var status;
            var x1, x2;

            CellFinishControl();
            if ($scope.CellFinishReturn == true) {
                for (var i = 0; i < 3; i++) {

                    if (status == true) {
                        $scope.GameFinishControl("Bilgisayar");
                        break;
                    }

                    if (($("#cell" + i + "0").val() != "" && $("#cell" + i + "1").val() != "") && ($("#cell" + i + "0").val() == $("#cell" + i + "1").val()) && $("#cell" + i + "2").val() == "") {
                        $("#cell" + i + "2").val("O");
                        x1 = i; x2 = 2;
                        status = true;
                    }
                    else if (($("#cell0" + i + "").val() != "" && $("#cell1" + i + "").val() != "") && ($("#cell0" + i + "").val() == $("#cell1" + i + "").val()) && $("#cell2" + i + "").val() == "") {
                        $("#cell2" + i + "").val("O");
                        x1 = 2; x2 = i;
                        status = true;
                    }
                    else if (($("#cell" + i + "0").val() != "" && $("#cell" + i + "2").val() != "") && ($("#cell" + i + "0").val() == $("#cell" + i + "2").val()) && $("#cell" + i + "1").val() == "") {
                        $("#cell" + i + "1").val("O");
                        x1 = i; x2 = 1;
                        status = true;
                    }
                    else if (($("#cell0" + i + "").val() != "" && $("#cell2" + i + "").val() != "") && ($("#cell0" + i + "").val() == $("#cell2" + i + "").val()) && $("#cell1" + i + "").val() == "") {
                        $("#cell1" + i + "").val("O");
                        x1 = 1; x2 = i;
                        status = true;
                    }
                    else if (($("#cell" + i + "2").val() != "" && $("#cell" + i + "1").val() != "") && ($("#cell" + i + "2").val() == $("#cell" + i + "1").val()) && $("#cell" + i + "0").val() == "") {
                        $("#cell" + i + "0").val("O");
                        x1 = i; x2 = 0;
                        status = true;
                    }
                    else if (($("#cell2" + i + "").val() != "" && $("#cell1" + i + "").val() != "") && ($("#cell2" + i + "").val() == $("#cell1" + i + "").val()) && $("#cell0" + i + "").val() == "") {
                        $("#cell0" + i + "").val("O");
                        x1 = 0; x2 = i;
                        status = true;
                    }
                    else if (($("#cell00").val() != "" && $("#cell11").val() != "") && ($("#cell00").val() == $("#cell11").val()) && $("#cell22").val() == "") {
                        $("#cell22").val("O");
                        x1 = 2; x2 = 2;
                        status = true;
                    }
                    else if (($("#cell00").val() != "" && $("#cell22").val() != "") && ($("#cell00").val() == $("#cell22").val()) && $("#cell11").val() == "") {
                        $("#cell11").val("O");
                        x1 = 1; x2 = 1;
                        status = true;
                    }
                    else if (($("#cell22").val() != "" && $("#cell11").val() != "") && ($("#cell22").val() == $("#cell11").val()) && $("#cell00").val() == "") {
                        $("#cell00").val("O");
                        x1 = 0; x2 = 0;
                        status = true;
                    }
                    else if (($("#cell02").val() != "" && $("#cell11").val() != "") && ($("#cell02").val() == $("#cell11").val()) && $("#cell20").val() == "") {
                        $("#cell20").val("O");
                        x1 = 2; x2 = 0;
                        status = true;
                    }
                    else if (($("#cell02").val() != "" && $("#cell20").val() != "") && ($("#cell02").val() == $("#cell20").val()) && $("#cell11").val() == "") {
                        $("#cell11").val("O");
                        x1 = 1; x2 = 1;
                        status = true;
                    }
                    else if (($("#cell20").val() != "" && $("#cell11").val() != "") && ($("#cell20").val() == $("#cell11").val()) && $("#cell02").val() == "") {
                        $("#cell02").val("O");
                        x1 = 0; x2 = 2;
                        status = true;
                    }
                    if (i == 2) {
                        if (status != true) {
                            x = Math.floor((Math.random() * 2));
                            y = Math.floor((Math.random() * 2));
                            if ($("#cell" + x + y + "").val() == "") {
                                $("#cell" + x + y + "").val("O");
                                x1 = x; x2 = y;
                                status = true;
                            } else {
                                i = 0;
                            }
                        }
                    }
                }
            }
                    var data = { eId: $scope.EncounterId, MoveCellx: x1, MoveCelly: x2, Value: "O" };
                    $http.post("/Game/SaveMove", data).success(function (returnData) {
                        console.log("Save Move Success !");
                    }).error(function (ex) {
                        console.log(ex);
                        $("#cell" + x1 + x2 + "").val("");
                    });
                

            if ($scope.FinishStatus != null && $scope.FinishStatus == 1) {
                FinishDisableButtons();
                EncounterStatusUpdate();
            }
        };

        $scope.GameFinishControl = function (player) {

            for (var a = 0; a < 3; a++) {
                if (($("#cell" + a + "0").val() == $("#cell" + a + "1").val() && $("#cell" + a + "1").val() == $("#cell" + a + "2").val()) && ($("#cell" + a + "0").val() != "" && $("#cell" + a + "1").val() != "" && $("#cell" + a + "2").val() != "")) {
                    $scope.WinMessage = player + " kazandı !";
                    $scope.FinishStatus = 1;
                    break;
                }
                else if (($("#cell0" + a + "").val() == $("#cell1" + a + "").val() && $("#cell1" + a + "").val() == $("#cell2" + a + "").val()) && ($("#cell0" + a + "").val() != "" && $("#cell1" + a + "").val() != "" && $("#cell2" + a + "").val() != "")) {
                    $scope.WinMessage = player + " kazandı !";
                    $scope.FinishStatus = 1;
                    break;
                }
            }

            if (($("#cell00").val() == $("#cell11").val() && $("#cell11").val() == $("#cell22").val()) && ($("#cell00").val() != "" && $("#cell11").val() != "" && $("#cell22").val() != "")) {
                $scope.WinMessage = player + " kazandı !";
                $scope.FinishStatus = 1;
            }

            if (($("#cell02").val() == $("#cell11").val() && $("#cell11").val() == $("#cell20").val()) && ($("#cell02").val() != "" && $("#cell11").val() != "" && $("#cell20").val() != "")) {
                $scope.WinMessage = player + " kazandı !";
                $scope.FinishStatus = 1;
            }

            if ($scope.WinMessage == "Bilgisayar") {
                $scope.WinnerPlayler = 1;
            } else if ($scope.WinMessage == "Oyuncu") {
                $scope.WinnerPlayler = 2;
            }
        };

        function GetOngoingGameList() {
            $http.post("/Game/GetOngoingGameList").success(function (returnData) {
                $scope.GetOngoingGameList = returnData;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        if ($scope.Url == "/DevamEdenOyunlar") {
            GetOngoingGameList();
        }
        //XOX Game End

        //Listeleme İşlemi
        function GetUsers() {
            $http.post("/User/GetUserList").success(function (data) {
                $scope.users = data;
            }).error(function (ex) {
                console.log(ex);
            })
        };
        if ($scope.Url == "/Kullanicilar") {
            GetUsers();
        }

        //Kayıt Sözleşmesini Getir
        function SingupContract() {
            $http.post("/Account/GetSingupContract").success(function (data) {
                $scope.SingupContractMessage = data;
            }).error(function (ex) {
                $log.info(ex);
            })
        };
        if ($scope.Url == "/SingupContract") {
            SingupContract();
        }

        //Profil Bilgilerini Getir
        function GetProfilInfo() {
            $http.post("/User/GetProfilInfo").success(function (data) {
                $scope.UserName = data.UserName;
            }).error(function (ex) {
                $log.console(ex);
            });
        }
        if ($scope.Url == "/Profil") {
            GetProfilInfo();
        }

        //Kayıt sözleşme metni getir
        function GetSingupContractText() {
            $http.post("/Setting/GetContractText").success(function (data) {
                $scope.SingUpContractText = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        GetSingupContractText();

        //Gelen Mesaj Listesini Getir
        function GetUserInBox() {
            $http.post("/Message/GetUserInBox").success(function (data) {
                $scope.InBoxMessages = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        if ($scope.Url == "/GelenMesaj") {
            GetUserInBox();
        }

        //Gönderilen Mesaj Listesini Getir
        function GetUserSendBox() {
            $http.post("/Message/GetUserSendBox").success(function (data) {
                $scope.SendBoxMessages = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        if ($scope.Url == "/GidenMesaj") {
            GetUserSendBox();
        }

        //İletişim Formundan Gelen Mesajları Listele
        function GetContactFormMessage() {
            $http.post("/Contact/GetContactFormMessage").success(function (returnData) {
                $scope.ContactFormMessages = returnData;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        if ($scope.Url == "/IletisimMesajlari") {
            GetContactFormMessage();
        }

        //Oyun Listesi
        function GetAllGameList() {
            $http.post("/Game/GetGameList").success(function (returnData) {
                $scope.GetGameList = returnData;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        if ($scope.Url == "/Oyunlar") {
            GetAllGameList();
        }

        //Cevap mesajı gönderme
        $scope.ReplySendMessage = function (Id) {
            if ($("#btnReplyMessage").val() == "Cevapla") {

                var data = { messageId: Id, ReplyContent: $scope.ReplyText };

                $http.post("/Message/ReplyMessageSave", data).success(function (returnData) {
                    $scope.Return = returnData;
                }).error(function (ex) {
                    console.log(ex);
                });
            }
        };

        //Mesaj Okuma sayfasına yönlendirme
        $scope.ReadMessage = function (Id) {
            if ($("#btnReadMessage").val() == "Oku") {
                window.location = "/MesajOku/" + Id + "";
            }
        };

        //Mesaj Yazma sayfasına yönlendirme
        $scope.WriteMessage = function (Id) {
            if ($("#btnWriteMessage").val() == "Mesaj Yaz") {
                window.location = "/MesajYaz/" + Id + "";
            }
        };

        //Mesaj Gönderme
        $scope.SendMessage = function (SenderId, ReceiverId) {
            if ($("#btnSendMessage").val() == "Mesaj Gönder") {

                var data = { SendUser: SenderId, ReceiverUser: ReceiverId, Subject: $scope.MessageSubject, MessageText: $scope.MessageContent };
                $http.post("/Message/SendMessage", data).success(function () {
                    console.log("Mesaj gönderimi başarılı.");
                    window.location = "/GelenMesaj";
                }).error(function (ex) {
                    console.log(ex);
                    $scope.singUpMessage = "Mesaj Gönderme İşlemi Sırasında Beklenmedik Bir Hata Oluştu !";
                });
            }
        };

        //Mesaj Silme
        $scope.DeleteMessage = function (Id) {
            var data = { Id: Id };
            $http.post("/Message/DeleteMessage", data).success(function () {
                window.location = "/GelenMesaj";
            }).error(function (ex) {
                console.log(ex);
            })
        };

        //Gelen Kutusuna Geri Dönme Butonuna Tıklandığında Çalışacak Yönlendirme
        $scope.BackToMessageList = function () {
            window.location = "/GelenMesaj";
        };

        //Mesaj Cevaplama sayfasına yönlendirme
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

        //İletişim Formu Gönder
        $scope.SendContactMessage = function () {
            if ($("#btnSendContactMessage").val() == "Gönder") {

                var data = { Subject: $scope.subject, Message: $scope.contactMessage };

                $http.post("/Contact/SendContactMessage", data).success(function (resultData) {
                    $scope.ResultMessage = resultData;
                }).error(function (ex) {
                    console.log(ex)
                });
            }
        };

        //İletişim Formundan Geri Dön
        $scope.BackToHome = function () {
            window.location = "/Anasayfa";
        };
    }]);

    app.directive('dir', function ($compile, $parse) {
        return {
            restrict: 'E',
            link: function (scope, element, attr) {
                scope.$watch(attr.content, function () {
                    element.html($parse(attr.content)(scope));
                    $compile(element.contents())(scope);
                }, true);
            }
        }
    });
})(angular);