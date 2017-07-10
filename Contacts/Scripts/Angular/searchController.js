app.controller('searchController', function ($scope, SearchService, $http) {

    $scope.selectors = ["Name", "LastName", "Tags"];
    $scope.type = ""; //The Object used for selecting value from <option>
    $scope.query = ""

    $scope.getContacts = function () {
        SearchService.getContacts($scope.type, $scope.query)
            .success(function (contacts) {
                $scope.contacts = contacts;
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;

            });
    }

});