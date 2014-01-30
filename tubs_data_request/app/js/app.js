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
var module = angular.module('tubsdatarequest', ['tubsdatarequest.filters', 'tubsdatarequest.services', 'tubsdatarequest.directives', 'tubsdatarequest.controllers',
     'ngRoute', 'ngAnimate', 'ui.directives', 'ui.bootstrap'
     ]).config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/', {controller: 'IndexCtrl', templateUrl: 'views/index.tpl.html'});
    $routeProvider.when('/report/:area',   {
        controller: 'ReportCtrl', templateUrl: 'views/reports-general.tpl.html',
        resolve: {
            CurrentReportGroup: function($route, ReportGroup) {
                // returns a promise
                return ReportGroup.get({code: $route.current.params.area});
            }
        }
    });
    $routeProvider.when('/report/:area/:id',   {
        controller: 'ReportViewCtrl', templateUrl: 'views/reports-view.tpl.html',
    });
    $routeProvider.when('/admin', {
        controller: 'ReportAdminListCtrl', templateUrl: 'views/reports-admin-list.tpl.html',
    });
    $routeProvider.when('/admin/edit/:id', {
        controller: 'ReportAdminEditCtrl', templateUrl: 'views/reports-admin-edit.tpl.html',
    });
    $routeProvider.when('/admin/new/', {
        controller: 'ReportAdminCreateCtrl', templateUrl: 'views/reports-admin-edit.tpl.html',
    });
    $routeProvider.otherwise({redirectTo: '/'});
  }]);

  


