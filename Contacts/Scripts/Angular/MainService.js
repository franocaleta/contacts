app.factory('MainService', ['$http', function ($http) {

    var urlBase = 'http://localhost:53378/api';
    var MainService = {};
    MainService.getContacts = function () {
        return $http.get(urlBase + '/contacts');
    };

    return MainService;
}]);