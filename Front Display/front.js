var app = ('frontApp',[]);
app.controller('signinController', function($scope, $http) {
    $http.get("kioskSignin.html")
    .then(function(response) {
        $scope.owners = response.data.records;
    });
    // JSON array to show table
    $scope.ownerArray =
    [
        {'phoneLast': '4567', 'ownerLast':'d', 'ownerFirst':'john', 'status':'didnt complete yet'}
    ];

    // Get data from sign-in form and add to table
    $scope.clicked() = function() {
        if($scope.phoneLast != undefined && $scope.ownerLast != undefined && $scope.ownerFirst != undefined && $scope.status != undefined) {
            var owner = [];
            owner.phoneLast = $scope.phoneLast;
            owner.ownerLast = $scope.ownerLast;
            owner.ownerFirst = $scope.ownerFirst;
            owner.status = $scope.status;

            $scope.ownerArray.push(owner);
        }
    };
});