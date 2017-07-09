app.controller('mainController', function ($scope, MainService,$http) {

    getContacts();

    function getContacts() {
        MainService.getContacts()
            .success(function (contacts) {
                $scope.contacts = contacts;
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;

            });
    }

    $scope.delete = function ($id) {
        $http.delete('/api/Contacts/' + $id).success(function (data) {
               getContacts();
        }).error(function (data) {
            $scope.error = "An Error has occured while Deleting! " + data;
        });
    };
});
