

var submit = angular.module('kioskSigninApp', []);
submit.controller('signinController', ['$scope', function($scope) {
    $scope.clicked = function() {   // If Pre-qualified
        var firstname = $scope.ownerFirst;
        var lastname = $scope.ownerLast;
      var email = $scope.emailAdd;
      var phone= $scope.phoneArea + $scope.phoneFirst + $scope.phoneLast;

        window.location = "\kioskIsPrequal.html";
    }
    $scope.clicked = function() {   // If NOT Pre-qualified
        window.location = "\kioskNotPrequal.html";
    }
}]);

var time = angular.module('kiosk_IsPrequalApp', []);
time.controller('is_preQualController', ['$scope', function($scope) {
    // Insert timeout
    $scope.clicked = function() {   // Need more time
        $route.reload();
    }
}]);

var time = angular.module('kiosk_NotPrequalApp', []);
time.controller('not_preQualController', ['$scope', function($scope) {
    // Insert timeout
    $scope.clicked = function() {   // Need more time
        $route.reload();
    }
}]);
