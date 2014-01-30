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

controllers.controller("IndexCtrl", function ($q, $scope, $location, $routeParams, filterFilter, ReportDef, ReportGroup) {
    return $scope;
});

controllers.controller("ReportViewCtrl", function ($q, $scope, $location, $routeParams, filterFilter, ReportDef, ReportGroup, Country, AppBaseUrl, Shared, ReportAction) {

    $scope.params = Shared.params;
    $scope.reportGroup = Shared.reportGroup;
    $scope.report = Shared.report;

    $scope.isLoading = true;
    $scope.totalItems = 0;
    $scope.data = [];
    $scope.headers = [];

    //default criteria that will be sent to the server
    $scope.filterCriteria = {
        pageNumber: 1,
        pageSize: 50,
        // offset: 0,
        reportId: $routeParams.id
    };
    jQuery.extend($scope.filterCriteria, $scope.params);
    //called when navigate to another page in the pagination
    $scope.selectPage = function (page) {
        console.log("Loading Page");
        $scope.filterCriteria.page = page;
        $scope.fetchResult();
        console.log("Loading Page Complete");
    };

    //The function that is responsible of fetching the result from the server and setting the grid to the new result
    $scope.fetchResult = function () {
        $scope.isLoading = true;
        //$scope.filterCriteria.offset = ($scope.filterCriteria.pageNumber - 1) * $scope.filterCriteria.pageSize;
        console.log($scope.filterCriteria);
        return $q.all([
            ReportAction.list($scope.filterCriteria).$promise,
            ReportAction.listCount($scope.filterCriteria).$promise
        ]).then(function (data) {
            $scope.data = data[0];
            console.log("fetch result succes:", data);
            $scope.totalItems = data[1].Count;
            $scope.isLoading = false;
        }, function () {
            $scope.data = [];
            console.log("fetch result failed");
            $scope.totalItems = 0;
            $scope.isLoading = false;
        });
    };

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

    // Initialise Headers
    $scope.headers = ReportAction.header({ reportId: $routeParams.id });

    if (!$scope.report) {
        //console.log("Report parameters lost, please resubmit /report/" + $routeParams.area);
        $location.path('/report/' + $routeParams.area);
    } else {
        //manually select a page to trigger an ajax request to populate the grid on page load
        $scope.selectPage(1);
    };

    $scope.exportToCsv = function () {
        window.open('../api/reportdef/runfullreport/'+$scope.report.id+'?' + $.param($scope.filterCriteria));
    };

    return $scope;
});

controllers.controller("ReportCtrl", function ($q, $scope, $location, $routeParams, filterFilter, ReportDef, ReportGroup, CurrentReportGroup, Country, AppBaseUrl, Shared) {
    var self = this;
    $scope.currentYear = new Date().getFullYear();
    //Will make an ajax call 
    //$scope.reportGroup = ReportGroup.get({code: $routeParams.area});
    $scope.reportGroup = CurrentReportGroup;
    $scope.params = Shared.params;
    $scope.months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    $scope.prevOptGear = "";
    $scope.gearTypes = [
        { id: 'A', name: 'All' },
        { id: 'L', name: 'Longline' },
        { id: 'P', name: 'Poll and Line' },
        { id: 'S', name: 'Purse Siene' },
        { id: 'R', name: 'Ringnet/Baby PS' },
        { id: 'N', name: 'Gillnet' }
    ];

    $scope.gears = [];
    $scope.appBaseUrl = AppBaseUrl;
    $scope.resetParams = function () {
        $scope.params = {
            year: $scope.currentYear,
            dateTo: moment().format("YYYY-MM-DDTHH:mm:ssZ")
        };
        if ($scope.gears.length > 0) {
            $scope.params.gear = $scope.gears[0].id;
        }
        $scope.eez = undefined;
    };

    $scope.updateAvailableGearTypes = function (optGear) {
        if (optGear) {
            if (optGear !== $scope.prevOptGear) {
                $scope.prevOptGear = optGear;
                $scope.gears = [];
                var gear = optGear.split(",");
                for (var i = 0; i < gear.length; i++) {
                    var element = _.findWhere($scope.gearTypes, { id: gear[i] });
                    if (element) {
                        $scope.gears.push(element);
                    } else {
                        console.log("Unknown gear type " + gear[i]);
                    }
                }
                if ($scope.gears.length > 0) {
                    $scope.params.gear = $scope.gears[0].id;
                }
            } else {
                console.log("Gear Types not changed");
            }
        }
    };

    $scope.countryTypeAhead = function (viewValue) {
        if (viewValue.length < 15) {
            return Country.lookup({ code: viewValue }).$promise;
        } else {
            console.log("not searching for value:", viewValue);
            return "";
        }
    };

    $scope.onSelectedReportChange = function () {
        console.log("Report Changed");
        if ($scope.report) {
            $scope.updateAvailableGearTypes($scope.report.optGear);
        }
    };

    $scope.generateReport = function () {
        if (!$scope.report) {
            toastr.warning('Report not selected correctly.');
            return;
        }
        if ($scope.report.optFlag && $scope.flag) {
            $scope.params.flag = $scope.flag.ctyCode;
        }
        console.log("Generate Report", $scope.params);
        var url = $scope.report.reportURL;
        var data = $scope.params;
        var method = 'post';
        if (!url) {
            toastr.warning('Report not defined correctly. URL missing');
        } else if ($scope.report.reportType === undefined) {
            toastr.warning('Report not defined correctly. ReportType missing');
        } else if ($scope.report.reportType === 1) {
            console.log("Do it JSON /" + $scope.reportGroup.code + '/' + $scope.report.id);
            Shared.params = $scope.params;
            if ($scope.eez && $scope.report.optEEZ) {
                Shared.params.eez = $scope.eez.code;
            }
            else if (Shared.params.eez) {
                Shared.params.eez = undefined;
            }

            Shared.reportGroup = $scope.reportGroupCode;
            Shared.report = $scope.report;
            $location.path('/report/' + $scope.reportGroup.Code + '/' + $scope.report.id);
        } else {
            console.log("Do it Clasically");
            // derived from 
            // http://filamentgroup.com/lab/jquery_plugin_for_requesting_ajax_like_file_downloads/
            //data can be string of parameters or array/object
            data = typeof data === 'string' ? data : jQuery.param(data);
            //split params into form inputs
            var inputs = '';
            jQuery.each(data.split('&'), function () {
                var pair = this.split('=');
                inputs += '<input type="hidden" name="' + pair[0] + '" value="' + pair[1] + '" />';
            });
            //send request
            jQuery('<form action="' + url + '" method="' + (method || 'post') + '">' + inputs + '</form>')
                    .appendTo('body').submit().remove();
        }
    };

    $q.all([
        ReportDef.list({ reportId: $routeParams.area }).$promise
    ]).then(function (data) {
        $scope.reports = data[0];
        $scope.report = $scope.reports[0];
        $scope.onSelectedReportChange();
    }, function () {
        $scope.reports = [];
        $scope.report = undefined;
    });

    $scope.reportDblClick = function () {
        if ($scope.report) {
            if (!$scope.myForm.$invalid) {
                $scope.generateReport();
            }
            else {
                toastr.warning("Please complete parameters");
            }
        }
    };

    $scope.resetParams();
    return $scope;
});

controllers.controller("NavCtrl", function ($q, $scope, $location, $routeParams, filterFilter, ReportDef, ReportGroup) {
    var self = this;

    $scope.selectedGroup = undefined;
    // 
    $q.all([
        ReportGroup.query().$promise
    ]).then(function (data) {
        $scope.reportGroups = data[0];
    }, function () {
        $scope.reportGroups = [];
        $scope.selectedGroup = undefined;
    });


    return $scope;
});

controllers.controller("ReportAdminListCtrl", function ($q, $scope, $location, $routeParams, ReportDef, ReportGroup) {
    $scope.reportGroups = ReportGroup.query();
    $scope.items = [];
    $scope.isLoading = false;
    $scope.filterCriteria = {
        pageNumber: 1,
        pageSize: 50
    };

    $scope.headers = [
        { title: 'Report Group', value: 'ReportGroupCode' },
        { title: 'Title', value: 'Title' },
        { title: 'Description', value: 'Narrative' },
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
            ReportDef.query($scope.filterCriteria).$promise,
            ReportDef.getCount($scope.filterCriteria).$promise
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

    $scope.askDelete = function (item) {
        if (item != undefined) {
            bootbox.confirm("Confirm delete?", function ( result) {
                if (result === true) {
                    $scope.delete(item);
                    $scope.$apply();
                }
            });
        }
    }

    $scope.delete = function (item) {
        if (item != undefined) {
            ReportDef.delete({ id: item.id }, function () {
                $("#item_" + item.id).fadeOut();
                toastr.success("Report deleted!");
            }, function () {
                toastr.error("Failed!");
            }
            );

        }
    }

    $scope.fetchResult();
});

controllers.controller("ReportAdminEditCtrl", function ($q, $scope, $location, $routeParams, ReportDef, ReportGroup) {
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

controllers.controller("ReportAdminCreateCtrl", function ($q, $scope, $location, $routeParams, ReportDef, ReportGroup)
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

function getParams(){
    return [{ key: 'optEEZ', value: 'EEZ', isValid: true, sqlCode: 'eez_code' }, { key: 'optSpecies', value: 'Species', isValid: true, sqlCode: 'sp_code' }, { key: 'optSource', value: 'Source', isValid: true },
    { key: 'optFlag', value: 'Flag', isValid: true }, { key: 'optYear', value: 'Year', isValid: true }, { key: 'optMonth', value: 'Month', isValid: true },
    { key: 'optArea', value: 'Area', isValid: true }, { key: 'optCompany', value: 'Company', isValid: true }, { key: 'optTrip', value: 'Trip', isValid: true },
    { key: 'optVessel', value: 'Vessel', isValid: true }, { key: 'optDateFrom', value: 'Date From', isValid: true }, { key: 'optDateTo', value: 'Date To', isValid: true },
    { key: 'optCPUE', value: 'CPUE', isValid: true }, { key: 'optLicense', value: 'License', isValid: true }, { key: 'optGear', value: 'Gear', isValid: true, sqlCode: 'gear_code' }
    ];
}

function getGearTypes() {
    return [{ key: 'L', value: 'Longline' }, { key: 'P', value: 'Poll and Line' }, { key: 'S', value: 'Purse Seine' }];
}

function checkSqlParameter(item,p) {
    if (p === undefined)
        return;

    if (item[p.key] === undefined)
        return;
    
    if (item.reportQuery == undefined)
        return;

    var result = item.reportQuery.match(/:[a-zA-Z0-9_]*\w/g);
    if (result == undefined)
        result = [];
    for (var i = 0; i < result.length; i++) {
        result[i] = result[i].substring(1);
    }
    var isParamInSql = (result.indexOf(p.sqlCode) > -1);
    if (item[p.key] == 0) {
        p.isValid = !isParamInSql;
    }
    else {
        p.isValid = isParamInSql;
    }
}

function checkSql(item, params) {
    if (item == undefined || item.reportQuery == undefined)
        return;
    var result = item.reportQuery.match(/:[a-zA-Z0-9_]*\w/g);
    if (result == undefined)
        result = [];
    for (var i = 0; i < result.length; i++) {
        result[i] = result[i].substring(1);
    }
    var paramSet = [];
    result.forEach(function (entry) {
        var param = _.findWhere(params, { sqlCode: entry });
        if (param) {
            paramSet.push(param);
            param.isValid = (item[param.key] !== undefined && item[param.key] > 0);
        }
        else {
            toastr.error("Unknown parameter: " + entry);
        }
    });
    params.forEach(function (entry) {
        var test = paramSet.indexOf(entry) > -1;
        if (!test) {
            if (item[entry.key] && item[entry.key] > 0) {

                var param = _.findWhere(result, entry.sqlCode);
                entry.isValid = (entry.isValid && param !== undefined);
            }
            else {
                entry.isValid = true;
            }
        }
    });

}

function toggleGearSelection(gears,gear) {
    var idx = gears.indexOf(gear);
    if (idx > -1) {
        // is currently selected
        gears.splice(idx, 1);
    } else {
        // is newly selected
        gears.push(gear);
    }
};

function isColumnCountOk(sqlColumns, reportColumns) {
    if (sqlColumns == undefined)
        return false;
    if (reportColumns == undefined)
        return false;
    return (sqlColumns.split(",").length == reportColumns.split(",").length);
};

function isOrderByOk(sqlQuery) {
    
    if (sqlQuery == undefined)
        return false;
    return (sqlQuery.toUpperCase().indexOf("ORDER BY") == -1);
};