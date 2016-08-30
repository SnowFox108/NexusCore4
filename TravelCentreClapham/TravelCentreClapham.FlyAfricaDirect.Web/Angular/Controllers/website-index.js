﻿(function () {
    'use strict';

    angular.module('nexusCore.Web').controller("website", function ($scope, apiCall, dataConverter, dialogs, messageBuilder, tableFilter) {

        $scope.table = {
            Columns: ["FriendlyId", "Name", "CreatedDate", "UpdatedDate"],
            FriendlyId: "",
            Name: "",
            CreatedDate: "",
            UpdatedDate: ""
        };

        $scope.init = function () {
            apiCall([
                { url: "/ModelBuilder/WebsiteSearchFilter" }
            ]).then(function (data) {
                $scope.searchFilter = data[0];
                $scope.sortOrderInit();
                $scope.querySearch();
            });
        };

        $scope.applySearchFilter = function () {
            $scope.querySearch();
        };

        $scope.querySearch = function () {
            apiCall([
                { postMethod: "POST", url: "/Websites/GetWebsiteList", data: { searchFilter: $scope.searchFilter } }
            ]).then(function (data) {
                $scope.model = data[0];
                $scope.friendlyDisplay();
                console.log($scope.model);
            });
        };

        $scope.friendlyDisplay = function () {
            var i = $scope.model.Websites.length;
            while (i-- > 0) {
                $scope.model.Websites[i].Website.CreatedDate = dataConverter.date($scope.model.Websites[i].Website.CreatedDate);
                $scope.model.Websites[i].Website.UpdatedDate = dataConverter.date($scope.model.Websites[i].Website.UpdatedDate);
                $scope.model.Websites[i].Status = {
                    Text: $scope.model.Websites[i].Website.IsUnderMaintenance ? "Under Maintenance"
                        : $scope.model.Websites[i].Website.IsActive ? "Active"
                        : "InActive",
                    Css: $scope.model.Websites[i].Website.IsUnderMaintenance ? "label-warning"
                        : $scope.model.Websites[i].Website.IsActive ? "label-success"
                        : "label-danger"
                }

            }
        };

        $scope.manageDomains = function(website) {
            var dlg = dialogs.create('/Angular/Views/Domains/index.html', 'domainDialog', website, 'lg');
            dlg.result.then(function(data) {
                console.log("returned");
            }, function() {
                console.log("Canceled");
            });
        };

        // Table Paging and Sorting        
        $scope.itemPerPageSetPage = function () {
            tableFilter.itemPerPageSetPage($scope.searchFilter.Filter.Paging, $scope.model.Paging.ItemsPerPage);
            $scope.querySearch();
        };

        $scope.paginationSetPage = function () {
            tableFilter.paginationSetPage($scope.searchFilter.Filter.Paging, $scope.model.Paging.CurrentPage);
            $scope.querySearch();
        };

        $scope.sortOrderInit = function () {
            tableFilter.sortOrderResetPage($scope.table);
            tableFilter.sortOrderInit($scope.table, $scope.searchFilter.Filter.Sorting);
        };

        $scope.sortOrderSetPage = function(column) {
            tableFilter.sortOrderResetPage($scope.table);
            if (tableFilter.sortOrder($scope.table, $scope.searchFilter.Filter.Sorting, column)) {
                $scope.querySearch();
            }
        };
    });

    // Domain popup
    angular.module('nexusCore.Web').controller("domainDialog", function ($scope, apiCall, dataConverter, dialogs, messageBuilder, $modalInstance, tableFilter, data) {
        $scope.website = data;
        $scope.addModel = {
            submitted: false
        };

        $scope.init = function () {
            apiCall([
                {
                    url: "/ModelBuilder/DomainViewModel"
                }
            ]).then(function(data) {
                $scope.viewModel = data[0];
                $scope.viewModel.WebsiteId = $scope.website.Id;
                $scope.querySearch();
            });
        };

        $scope.querySearch = function() {
            apiCall([
                { url: "/DomainServices", params: { websiteId: $scope.website.Id } }
            ]).then(function(data) {
                $scope.model = data[0];
                $scope.friendlyDisplay();
            });
        };

        $scope.close = function() {
            $modalInstance.dismiss("Close");
        };

        $scope.friendlyDisplay = function () {
            var i = $scope.model.length;
            while (i-- > 0) {
                $scope.model[i].Status = {
                    Text: $scope.model[i].IsActive ? "Active"
                        : "InActive",
                    Css: $scope.model[i].IsActive ? "label-success"
                        : "label-danger"
                }
                $scope.model[i].Primary = {
                    Text: $scope.model[i].Id == $scope.website.ActivedDomainId ? "Primary"
                        : "Sub",
                    Css: $scope.model[i].Id == $scope.website.ActivedDomainId ? "label-success"
                        : "label-warning"
                }
            }
        };


        $scope.addNew = function (model, isFormValid) {
            $scope.addModel.submitted = true;
            if (!isFormValid)
                return;

            // TODO: ready to add new domain
            $scope.viewModel.Name = model.Name;
            $scope.viewModel.IsActive = model.IsActive;

            apiCall([
                { postMethod: "POST", url: "/DomainServices/CreateDomain", data: { model: $scope.viewModel } }
            ]).then(function (data) {
                dialogs.notify("Infomation", data[0]);
                $scope.querySearch();
            }, function (error) {
                dialogs.error("Error", messageBuilder.modalErrorSummary(error));
            });

            console.log($scope.viewModel, isFormValid);

            // TODO: success updated
            model.Name = "";
            $scope.addNewVisible = false;
            $scope.addModel.submitted = false;
        };

        $scope.init();

    });
})();