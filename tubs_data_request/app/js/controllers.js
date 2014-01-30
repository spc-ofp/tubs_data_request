/* 
 * Copyright (C) 2013 Secretariat of the Pacific Community (SPC)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Afferro General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Afferro General Public License for more details.
 *
 * You should have received a copy of the GNU Afferro General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

'use strict';

/* Controllers */
var controllers = angular.module('tubsdatarequest.controllers', []);

controllers.controller("IndexCtrl", function ($q, $scope, $location, $routeParams, filterFilter,Programs) {
    $scope.programs = Programs.query();
    return $scope;
});


controllers.controller("RequestListCtrl", function ($q, $scope, $location, $routeParams, RequestHeader) {
    $scope.items = [];
    $scope.isLoading = false;
    $scope.filterCriteria = {
        pageNumber: 1,
        pageSize: 50
    };

    $scope.headers = [
        { title: 'Trip No.', value: 'TripNo' },
        { title: 'Program Trip No', value: 'PrgTripNo' },
        { title: 'OBS Program Code', value: 'ObsprgCode' },
    ];

    //call back function that we passed to our custom directive sortBy, will be called when clicking on any field to sort
    $scope.onSort = function (sortedBy, sortDir) {
        $scope.filterCriteria.sortDir = sortDir;
        $scope.filterCriteria.sortedBy = sortedBy;
        $scope.filterCriteria.pageNumber = 1;
        $scope.fetchResult().then(function () {
            //The request fires correctly but sometimes the ui doesn't update, that's a fix
            $scope.filterCriteria.pageNumber = 1;
        });
    };

    //The function that is responsible of fetching the result from the server and setting the grid to the new result
    $scope.fetchResult = function () {
        //$scope.filterCriteria.offset = ($scope.filterCriteria.pageNumber - 1) * $scope.filterCriteria.pageSize;
        $scope.isLoading = true;
        return $q.all([
            RequestHeader.query($scope.filterCriteria).$promise,
            RequestHeader.getCount($scope.filterCriteria).$promise
        ]).then(function (data) {
            $scope.items = data[0];
            $scope.totalItems = data[1].count;
            $scope.isLoading = false;
        }, function () {
            $scope.items = [];
            $scope.totalItems = 0;
            $scope.isLoading = false;
        });
    };


    $scope.fetchResult();
});

controllers.controller("RequestEditCtrl", function ($q, $scope, $location, $routeParams) {
    $scope.sqlEditorOptions = {
        lineWrapping : true,
        lineNumbers: true,
        matchBrackets: true,
        indentWithTabs: true,
        smartIndent: true,        
        mode: 'text/x-sql'
    };
    $scope.reportGroups = ReportGroup.query();
    $scope.params = getParams();
    $scope.validateForm = function () { return true; }
    $scope.gearTypes = getGearTypes();
    $scope.checkSql = function () { checkSql($scope.item, $scope.params); $scope.isOrderByOk = isOrderByOk($scope.item.reportQuery) };
    $scope.checkColumnCountOk = function () { $scope.isColumnCountOk = isColumnCountOk($scope.item.columnSqlNames, $scope.item.columnTitles) };
    $scope.checkSqlParameter = function (p) { checkSqlParameter($scope.item, p) };
    $scope.gears = [];
    $scope.toggleGearSelection = function (gear) { toggleGearSelection($scope.gears, gear) };

    $scope.isClean = function () {
        return angular.equals(self.original, $scope.item)
                && angular.equals(self.originalGears, $scope.gears);
    };

    $scope.save = function () {
        $scope.item.Gears = $scope.gears.join();
        ReportDef.update({ id: $scope.item.id }, $scope.item, function () {
            $location.path('/admin');
        }, function () { toastr.error("Failed!"); }
        );
    };

    $q.all([
        ReportDef.get({ reportId: $routeParams.id }).$promise
    ]).then(function (data) {
        self.original = data[0];
        if (self.original.Gears) {
            self.originalGears = self.original.Gears.split(",");
            $scope.gears = self.original.Gears.split(",");
        }
        $scope.item = new ReportDef(self.original);
        $scope.checkSql();
        $scope.checkColumnCountOk();
    });
});

controllers.controller("RequestCreateCtrl", function ($q, $scope, $location, $routeParams)
{
    $scope.sqlEditorOptions = {
        lineWrapping : true,
        lineNumbers: true,
        matchBrackets: true,
        indentWithTabs: true,
        smartIndent: true,        
        mode: 'text/x-sql'
    };
    $scope.reportGroups = ReportGroup.query();
    $scope.params = getParams();
    $scope.gearTypes = getGearTypes();
    $scope.checkSql = function () { checkSql($scope.item, $scope.params); $scope.isOrderByOk = isOrderByOk($scope.item.reportQuery) };
    $scope.checkSqlParameter = function (p) { checkSqlParameter($scope.item, p) };
    $scope.toggleGearSelection = function (gear) { toggleGearSelection($scope.gears, gear) };
    $scope.item = {};
    $scope.isColumnCountOk = true;
    $scope.isOrderByOk = true;
    $scope.checkColumnCountOk = function () { $scope.isColumnCountOk = isColumnCountOk($scope.item.columnSqlNames, $scope.item.columnTitles) };
    $scope.params.forEach(function (entry) {
        $scope.item[entry.key] = 0;
    });

    $scope.save = function () {
        if ($scope.gears != undefined) {
            $scope.item.optGear = $scope.gears.join();
        }
        ReportDef.save($scope.item, function () {
            $location.path('/admin');
        }, function () { toastr.error("Failed!"); }
        );
    };
    $scope.validateForm = function () {
        var result = true;
        $scope.params.forEach(function (entry) {
           result = (result && entry.isValid)
        });
        return result;
    }
});
