app.factory('SingleContactService', ['$http', function ($http,$routeParams) {

    var urlBase = 'http://localhost:53378/api';
    var SingleContactService = {};
    SingleContactService.getContact = function ($id) {
      
        return $http.get(urlBase + '/contacts/'+$id);
    };

    return SingleContactService;
}]);