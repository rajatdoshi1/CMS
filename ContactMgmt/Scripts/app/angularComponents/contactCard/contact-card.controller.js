(function () {
    function contactCardController() {

        var self = this;

        self.getPhotoText = function () {
            var photoText = "";
            if (self.contact.FirstName.length > 0)
                photoText = self.contact.FirstName[0];
            if (self.contact.LastName.length > 0)
                photoText += self.contact.LastName[0];
            return photoText;
        }

        self.copyToClipboard = function () {

        }

    }

    contactCardController.$inject = [];

    cmsApp.controller("contactCardController", contactCardController);
})();