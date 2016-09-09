/// <reference path="F:\MyWorkSpace\NexusCore4\TravelCentreClapham\TravelCentreClapham.FlyAfricaDirect.Web\Flight.html" />
(function() {
    'use strict';

    angular.module('nexusCore.Web').controller('sample', function($scope, apiCall, dataConverter, dialogs) {
        $scope.init = function() {
            $scope.enquiryForm = {
                value: {},
                error: {},
                submited: false
            };
            apiCall([
                { url: "/ModelBuilder/AfricanWebsiteOffer01" }
            ]).then(function(data) {
                $scope.enquiryForm.value = data[0];
                $scope.enquiryForm.value.PreferredDestination = "";
                $scope.resetValidation();
            });
        };

        $scope.submit = function() {
            if ($scope.validate()) {
                console.log($scope.enquiryForm.value);
                apiCall([
                    { postMethod: "POST", url: "/Enquiry/AfricanWebsiteOffer01", data: $scope.enquiryForm.value }
                ]).then(function (data) {
                    $scope.result = data[0];
                    $scope.success();
                });
            }
        };

        $scope.validate = function () {
            $scope.resetValidation();
            var isValid = true;
            if (angular.isUndefined($scope.enquiryForm.value.FirstName) || $scope.enquiryForm.value.FirstName == null) {
                $scope.enquiryForm.error.firstNameRequired = true;
                isValid = false;
            }
            if (angular.isUndefined($scope.enquiryForm.value.LastName) || $scope.enquiryForm.value.LastName == null) {
                $scope.enquiryForm.error.lastNameRequired = true;
                isValid = false;
            }
            if (angular.isUndefined($scope.enquiryForm.value.PreferredDestination) || $scope.enquiryForm.value.PreferredDestination == "" || $scope.enquiryForm.value.PreferredDestination == null) {
                $scope.enquiryForm.error.preferredDestinationRequired = true;
                isValid = false;
            }
            if (angular.isUndefined($scope.enquiryForm.value.MobilePhoneNumber) || $scope.enquiryForm.value.MobilePhoneNumber == null) {
                $scope.enquiryForm.error.mobilePhoneNumberRequired = true;
                isValid = false;
            }
            if (angular.isUndefined($scope.enquiryForm.value.Email) || $scope.enquiryForm.value.Email == null) {
                $scope.enquiryForm.error.emailRequired = true;
                isValid = false;
            }
            if (!$scope.validateEmail($scope.enquiryForm.value.Email)) {
                $scope.enquiryForm.error.emailValid = true;
                isValid = false;
            }
            return isValid;
        };

        $scope.validateEmail = function (email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }

        $scope.resetValidation = function() {
            $scope.enquiryForm.error = {
                    firstNameRequired: false,
                    lastNameRequired: false,
                    preferredDestinationRequired: false,
                    mobilePhoneNumberRequired: false,
                    emailRequired: false,
                    emailValid: false
            };
        }

        $scope.success = function() {
            $scope.enquiryForm.submited = true;
        }
    });
})();