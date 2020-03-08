var authentication = angular.module('authApp', []);
authentication.controller('authController', ['$scope', function($scope) {
    $scope.clicked = function() {   // Authentication verified
        window.location = "\kioskInitial.html";
    }
}]);

var VLogin = angular.module('startApp', []);
VLogin.controller('initialController', ['$scope', function($scope) {
    $scope.clicked = function() {
        window.location = "\kioskSignin.html";
    }
}]);

var submit = angular.module('kioskSigninApp', []);
submit.controller('signinController', ['$scope', function($scope) {
    $scope.clicked = function() {   // If Pre-qualified
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