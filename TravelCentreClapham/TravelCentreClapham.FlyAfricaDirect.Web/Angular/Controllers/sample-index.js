(function() {
    'use strict';

    angular.module('nexusCore.Web').controller('sample', function($scope, apiCall, dataConverter, dialogs) {
        $scope.init = function() {
            $scope.enquiryForm = {
                value: {},
                error: {}
            };
            apiCall([
                { url: "/ModelBuilder/AfricanWebsiteOffer01" }
            ]).then(function(data) {
                $scope.enquiryForm.value = data[0];
                $scope.resetValidation();
                console.log($scope.enquiryForm.value);
            });
        };

        $scope.submit = function() {
            if ($scope.validate()) {
                console.log("good");
                apiCall([
                    { postMethod: "POST", url: "/Enquiry", data: { customer: $scope.enquiryForm.value } }
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

            return isValid;
        };

        $scope.resetValidation = function() {
            $scope.enquiryForm.error = {
                    firstNameRequired: false,
                    lastNameRequired: false
            };
        }

        $scope.success = function() {
            
        }
    });
})();