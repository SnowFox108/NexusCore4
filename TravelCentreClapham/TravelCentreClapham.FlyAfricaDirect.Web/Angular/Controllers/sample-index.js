(function() {
    'use strict';

    angular.module('nexusCore.Web').controller('sample', function($scope, apiCall, dataConverter, dialogs) {
        $scope.init = function() {
            //apiCall([
            //    { url: "/ModelBuilder/AfricanWebsiteOffer01" }
            //]).then(function(data) {
            //    $scope.enquiryForm = data[0];
            //});
            $scope.enquiryForm.error = {
                firstNameRequired: false,
                lastNameRequired: false
            };
        };

        $scope.submit = function() {
            //apiCall([
            //    { postMethod: "POST", url: "/Enquiry", data: { customer: $scope.enquiryForm } }
            //]).then(function(data) {
            //    $scope.result = data[0];
            //    $scope.success();
            //});
        };

        $scope.validate = function () {

            if (angular.isUndefined($scope.enquiryForm.FirstName))
                $scope.enquiryForm.error.firstNameRequired = true;
            if (angular.isUndefined($scope.enquiryForm.LastName))
                $scope.enquiryForm.error.firstNameRequired = true;

        };

        $scope.success = function() {
            
        }
    });
})();