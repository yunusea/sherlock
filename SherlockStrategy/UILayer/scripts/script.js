// Code goes here

angular.module('ionicApp', ['ionic'])

.controller('AppCtrl', function($scope, $ionicModal) {
  
$scope.firstpopup=function(){
  $scope.modal.show()
}
  
  $ionicModal.fromTemplateUrl('templates/modal.html', {
    scope: $scope
  }).then(function(modal) {
    $scope.modal = modal;
  });
  
});