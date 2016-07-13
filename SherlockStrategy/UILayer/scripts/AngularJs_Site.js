(function (angular) {
    var app = angular.module("app", []);
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
        $scope.SingUpUser = function () {
            if ($("#btnSingUp").val() == "Kayıt Ol") {

                var data = { UserName: $scope.UserName, Password: $scope.Password, EMail: $scope.EMail };

                console.log("New User data=" + JSON.stringify(data));

                $http.post("/Account/SaveUser", data).success(function (newUser) {
                    $scope.data = newUser;
                    console.log("New User data success=" + JSON.stringify(newUser));
                }).error(function (ex) {
                    console.log(ex);
                });
            }
        };

    }]);

})(angular);