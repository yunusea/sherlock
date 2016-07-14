(function (angular) {
    var app = angular.module("app", []);
    app.controller("UserController", ["$scope", "$http", "$log", function UserController($scope, $http, $log) {
        $scope.loading = true;

        //Listeleme İşlemi
        function GetUsers() {
            $http.get("/Account/GetUserList").success(function (data) {
                $scope.users = data;
            }).error(function (ex) {
                $log.info(ex);
            })
        }

        GetUsers();

        //Kayıt İşlemi
        $scope.SingUpUser = function () {

            if ($("#btnSingUp").val() == "Kayıt Ol") {

                var data = { UserName: $scope.SuUserName, Password: $scope.SuPassword, EMail: $scope.SuEMail };

                $http.post("/Account/SaveUser", data).success(function (newUser) {
                    $scope.data = newUser;
                    GetUsers();
                }).error(function (ex) {
                    console.log(ex);
                });
            }
        };

        //Giriş İşlemi
        $scope.LoginUser = function () {

            if ($("#btnLogin").val() == "Giriş Yap") {
                var data = { UserName: $scope.SiUserName, Password: $scope.SiPassword };

                $http.post("/Account/Login", data).success(function (loginUser) {
                    $scope.data = loginUser;
                    console.log("Giriş Başarılı");
                    $location.absUrl() = "/Account/Index";
                }).error(function (ex) {
                    console.log(ex);
                });
            }
        };
        
        //Silme İşlemi
        $scope.DeleteUser = function (Id) {
            var data = { Id: Id};
            $http.post("/Account/DeleteUser", data).success(function () {
                GetUsers();
                }).error(function (ex) {
                    console.log(ex);
                })
        };

    }]);

})(angular);