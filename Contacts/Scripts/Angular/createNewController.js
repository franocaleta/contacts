app.controller('createNewController', function ($scope,$http,$location) {

   
    //tags
    $scope.table = { fields: [] };
    $scope.addFormField = function () {
        $scope.table.fields.push('');
    }

    //emails
    $scope.emails = { fields: [] };
    $scope.addEmailField = function () {
       // console.log('maci');
        $scope.emails.fields.push('');
    }

    //phones
    $scope.phones = { fields: [] };
    $scope.addPhoneField = function () {
     
        $scope.phones.fields.push('');
    }
      
    $scope.saveContact = function () {
         var tags = $scope.table.fields.map(function (item) {
            return { 'Name': item }
         })
         var emails = $scope.emails.fields.map(function (item) {
             return { 'email': item }
         })
         var phoneNumbers = $scope.phones.fields.map(function (item) {
             return { 'Number': item }
         })
        var urlBase = 'http://localhost:53378/api'
        $http.post(urlBase+'/contacts', {
            'Name': $scope.contact.Name,
            'LastName': $scope.contact.LastName,
            'Address': $scope.contact.Address,
            'Tags': tags,
            'Emails': emails,
            'PhoneNumbers':phoneNumbers

        })
     .success(function (data) {
         $scope.something = data;
         $location.url('/#');
       }).error(function (response) {

         alert("Fail");

     });
    };
});