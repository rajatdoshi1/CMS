(function () {

    cmsApp
        .component('contactCard',
            {
                templateUrl: 'web/Scripts/app/angularComponents/contactCard/contact-card.html',
                controller: 'contactCardController',
                bindings: {
                    contact: '='
                }
            });
})();