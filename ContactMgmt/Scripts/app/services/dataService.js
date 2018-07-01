(function () {
    cmsApp.service('dataService', dataService);
    dataService.$inject = ['$http', '$q', 'commonUtilityService'];

    function dataService($http, $q, commonUtilityService) {
        var service = {
            getAllStartsWithData: getAllStartsWithData,
            getLoadingContact: getLoadingContact,
            getEmptyContact: getEmptyContact,
            getFullContactInfo: getFullContactInfo,
            save: save,
            deleteContact: deleteContact,
            doSearch: doSearch
        };

        return service;

        function getAllStartsWithData(searchTerm) {

            var apiUrl = commonUtilityService.getApiUrl("contact/startsWith/" + searchTerm);
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

        function getFullContactInfo(contactId) {
            var apiUrl = commonUtilityService.getApiUrl("contact/get/" + contactId);
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

        function getLoadingContact() {
            var emptyContact = getEmptyContact();
            emptyContact.PrimaryContact = "We are loading";
            emptyContact.Photo = "web/Content/loader.gif";
            return emptyContact;
        }

        function getEmptyContact() {
            return {
                ContactId: -1,
                FirstName: "",
                LastName: "",
                PrimaryContact: "",
                Email: "",
                Photo: null
            }
        }

        function save(contact, customTags) {

            var fullContactInformation = contact;
            fullContactInformation.TagValues = [];

            for (var tag in customTags) {
                fullContactInformation.TagValues.push({ TagTypeId: tag, Value: customTags[tag], TagName: "" });
            }

            var apiUrl = commonUtilityService.getApiUrl("contact/save" );
            var deferred = $q.defer();
            $http.post(apiUrl, fullContactInformation)
                .then(function (response) {
                    deferred.resolve(response.data);
                })
                .catch(function (err) {
                    console.log(err);
                });
            return deferred.promise;
        }

        function deleteContact(contactId) {
            var apiUrl = commonUtilityService.getApiUrl("contact/delete/" + contactId);
            var deferred = $q.defer();
            $http.delete(apiUrl)
                .then(function (response) {
                    deferred.resolve(response.data);
                })
                .catch(function (err) {
                    console.log(err);
                });
            return deferred.promise;
        }

        function doSearch(searchParam) {
            var apiUrl = commonUtilityService.getApiUrl("contact/search/" + searchParam);
            var deferred = $q.defer();
            $http.get(apiUrl)
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