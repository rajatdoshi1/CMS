var cmsApp = angular.module("cmsApp", ["ui.router", "ui.bootstrap", "ui.bootstrap.typeahead"]);

cmsApp.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.when("", "/main");
    $urlRouterProvider.when("/", "/main");
    $urlRouterProvider.otherwise("/main");

    $stateProvider
        .state("main", {
            url: "/main",
            controller: "mainCtrl",
            templateUrl: getTemplateUrl("Templates/main.html")
        })
        .state("edit", {
            url: "/edit",
            controller: "editCtrl",
            templateUrl: getTemplateUrl("Templates/edit.html")
        });
    //getTemplateUrl("Templates/edit.html");
    function getTemplateUrl(templateName) {
        if (window.location) {
            var pathName = window.location.pathname;
            var url = "";
            if (pathName.lastIndexOf("/") < pathName.length-1) {
                url += pathName.substr(pathName.lastIndexOf("/")  + 1) + "/" + templateName;
                return url;
            }
            return templateName;
        }
    }

}]);

cmsApp.run();