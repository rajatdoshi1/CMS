(function() {
    cmsApp.service('configService', configService);
    configService.$inject = ['$http', '$q', 'commonUtilityService'];

    function configService($http, $q, commonUtilityService) {

        var service = {
            getContactAlphaNums: getContactAlphaNums,
            getContactsConfig: getContactsConfig
        };

        return service;

        function getContactAlphaNums() {
            var contactAlphaNums = [];

            var i = 'A'.charCodeAt(0), j = 'Z'.charCodeAt(0);
            for (; i <= j; ++i) {
                contactAlphaNums.push(String.fromCharCode(i));
            }

            return contactAlphaNums;
        }

        function getContactsConfig() {
            var apiUrl = commonUtilityService.getApiUrl("config/get");
            var deferred = $q.defer();

            $http.get(apiUrl, {
                    params: {}
                })
                .then(function (response) {
                    deferred.resolve(response.data);
                })
                .catch(function (err) {
                    console.log(err);
                });
            return deferred.promise;
        }
    }
})();