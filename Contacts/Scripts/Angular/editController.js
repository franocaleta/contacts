app.controller('editController', function
            ($scope, SingleContactService, $routeParams, $http, $location) {
    $scope.contact;
    getContact();

    //tags
    $scope.addFormField = function () {
        $scope.contact.Tags.push('');
    }

    //emails
    $scope.addEmailField = function () {
        $scope.contact.Emails.push('');
    }
    //phones
    $scope.addPhoneField = function () {
        $scope.contact.PhoneNumbers.push('');
    }
   

    function getContact() {
        SingleContactService.getContact($routeParams.id)
            .success(function (contact) {
             
                $scope.contact = contact;

            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;

            });
    }

    $scope.saveContact = function () {
        var urlBase = 'http://localhost:53378/api'
        console.log($scope.contact);
        return $http({
            method: "put",
            url: urlBase + "/contacts/" + $routeParams.id,
            data: JSON.stringify(($routeParams.id,$scope.contact)),
            dataType: "json"
        })
     .success(function (data) {
         $location.url('/#');
     }).error(function (response) {

         alert("Fail");

     });
    };
});