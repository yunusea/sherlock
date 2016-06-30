(function (angular) {

    var app = angular.module("app", []);
    app.controller("Controller", ["$scope", "$http", function Controller($scope, $http) {

        if ($("#btnSingUp").val() == "Kayıt Ol")
        {
            var data = [];
            angular.forEach($scope.Users, function (user) {
                if (user.Id == null) {
                    data.push(site);
                }
            });

            console.log("New Users data=" + JSON.stringify(data));

            $http.post("/Account/SaveUser", data).success(function (userList) {
                $scope.Users = userList;
            }).error(function (ex) {
                console.log(ex);
            })
        }

    }]);
})(angular);