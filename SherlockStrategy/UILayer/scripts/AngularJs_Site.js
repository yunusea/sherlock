(function (angular) {
    var app = angular.module("app", []);
    app.controller("UserController", ["$scope", "$http", function UserController($scope, $http) {
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
        }
    }]);

})(angular);