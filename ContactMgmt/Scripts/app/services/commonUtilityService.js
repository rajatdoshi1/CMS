(function () {
    cmsApp.service('commonUtilityService', commonUtilityService);
    commonUtilityService.$inject = [];

    function commonUtilityService() {

        var service = { getApiUrl: getApiUrl };
        return service;

    }

    function getApiUrl(url) {
        return "api/" + url;
    }

})();