app.controller('searchController', function ($scope,$http) {
    $scope.Selectors = ["Name", "LastName", "Tags"];

    $scope.SelectedCriteria = ""; 
    $scope.filterValue = ""; 

});