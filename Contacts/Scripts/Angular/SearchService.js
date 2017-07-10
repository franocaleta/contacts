app.factory('SearchService', ['$http', function ($http) {

    var urlBase = 'http://localhost:53378';
    var SearchService = {};
    SearchService.getContacts = function ($type,$query) {
        return $http.get(urlBase + '/search/'+$type+'/'+$query);
    };

    return SearchService;
}]);