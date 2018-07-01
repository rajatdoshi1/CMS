(function () {
    cmsApp.controller('mainCtrl', mainCtrl);

    mainCtrl.$inject = ['$scope', '$http', 'configService', 'dataService'];

    function mainCtrl($scope, $http, configService, dataService) {
        $scope.states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California', 'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana', 'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota', 'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire', 'New Jersey', 'New Mexico', 'New York', 'North Dakota', 'North Carolina', 'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island', 'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont', 'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'];

        $scope.contactAlphaNums = configService.getContactAlphaNums();
        $scope.allContacts = [];
        $scope.contactConfig = {};
        $scope.selectedContact = dataService.getEmptyContact();
        $scope.customTagsModel = { };

        $scope.getAllContactsWhichStartsWith = function (startsWithTerm) {
            $scope.allContacts = [dataService.getLoadingContact()];
            dataService.getAllStartsWithData(startsWithTerm).then(function (response) {
                $scope.allContacts = response;
            });
        }

        $scope.doSearch = function(val) {
            return dataService.doSearch(val).then(function(contacts) {
                if (contacts && contacts.length > 0) {
                    return contacts.map(function (contact) {
                        var searchLine = "";
                        if (contact.FirstName)
                            searchLine = contact.FirstName;
                        if (contact.LastName)
                            searchLine += " " + contact.LastName;
                        if (contact.PrimaryContact)
                            searchLine += ", " + contact.PrimaryContact;
                        return contact.ContactId + " :: " +  searchLine;
                    });
                }
            });
        }

        $scope.selectAndFetchContact = function(label) {
            console.log(label);
        }

        $scope.getLocation = function (val) {
            return $http.get('//maps.googleapis.com/maps/api/geocode/json', {
                params: {
                    address: val,
                    sensor: false
                }
            }).then(function (response) {
                return response.data.results.map(function (item) {
                    return item.formatted_address;
                });
            });
            
        };

        $scope.getContactConfig = function () {
            configService.getContactsConfig().then(function (response) {
                $scope.contactConfig = response;
            });
        }

        $scope.getPhotoText = function (contact) {
            var photoText = "";
            if (contact.FirstName.length > 0)
                photoText = contact.FirstName[0];
            if (contact.LastName.length > 0)
                photoText += contact.LastName[0];
            return photoText;
        }

        $scope.adjustLists = function () {
            var table2 = angular.element('#table2');
            var table1Body = angular.element('#table1 > tbody');
            table1Body.css('max-height', table2.height());
        }

        $scope.fetchSelectedContact = function (contact) {
            $scope.selectedContact = contact;
            $scope.customTagsModel = {};
            dataService.getFullContactInfo(contact.ContactId)
                .then(function (response) {
                    $scope.selectedContact['TagValues'] = response.TagValues;
                    if ($scope.selectedContact.TagValues && $scope.selectedContact.TagValues.length) {
                        $scope.selectedContact.TagValues.some(function(tag) {
                            $scope.customTagsModel[tag.TagTypeId] = tag.Value;
                        });
                    }
                });
        }

        $scope.getCustomTagValue = function (tagTypeId) {
            if ($scope.selectedContact && $scope.selectedContact.TagValues) {
                for (var i = 0; i < $scope.selectedContact.TagValues.length; i++)
                    if ($scope.selectedContact.TagValues[i].TagTypeId == tagTypeId)
                        return $scope.selectedContact.TagValues[i].Value;
            }
            return "";
        }

        $scope.saveContact = function() {
            var contactToSave = angular.copy($scope.selectedContact);
            var customTags = angular.copy($scope.customTagsModel);

            dataService.save(contactToSave, customTags).then(function(response) {

            });
        }

        $scope.newContact = function() {
            $scope.selectedContact = dataService.getEmptyContact();
        }

        $scope.deleteContact = function() {
            if ($scope.selectedContact.ContactId == -1) return;

            dataService.deleteContact($scope.selectedContact.ContactId).then(function () {
                //myFish.splice(3, 1);
                var index = $scope.allContacts.findIndex(function(contact) {
                    return contact.ContactId == $scope.selectedContact.ContactId;
                });
                if (index > -1) {
                    $scope.allContacts.splice(index, 1);
                    $scope.selectedContact = dataService.getEmptyContact();
                }
            });
        }

        $scope.typeAheadOnSelect = function ($item, $model, $label, $event) {
            var contactId = $item.split("::")[0].trim();

            dataService.getFullContactInfo(contactId)
                .then(function (response) {
                    if ($scope.selectedContact.ContactId == -1)
                        $scope.selectedContact = response;
                    else {
                        $scope.selectedContact['TagValues'] = response.TagValues;
                        if ($scope.selectedContact.TagValues && $scope.selectedContact.TagValues.length) {
                            $scope.selectedContact.TagValues.some(function(tag) {
                                $scope.customTagsModel[tag.TagTypeId] = tag.Value;
                            });
                        }
                    }
                });
        }

        function init() {
            $scope.getAllContactsWhichStartsWith('a');
            $scope.getContactConfig();
        }

        init();
    }
})();