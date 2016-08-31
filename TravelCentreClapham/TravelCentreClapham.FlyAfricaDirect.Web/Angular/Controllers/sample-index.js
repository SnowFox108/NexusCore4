(function() {
    'use strict';

    angular.module('nexusCore.Web').controller('sample', function($scope, apiCall, dataConverter, dialogs) {
        $scope.init = function() {
            //apiCall([
            //    { url: "/ModelBuilder/Customer" }
            //]).then(function(data) {
            //    $scope.enquiryForm = data[0];
            //});
            $scope.enquiryForm = {
                FirstName: "",
                LastName: ""
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

        $scope.success = function() {
            
        }
    });
})();