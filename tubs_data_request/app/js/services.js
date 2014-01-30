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
var services = angular.module('tubsdatarequest.services', ['ngResource']);

services.value('AppBaseUrl', '..');

services.factory('Shared',function() {
    return {
        params : {},
        reportGroup : {}
	};
});

services.factory('RequestHeader', function($resource, AppBaseUrl) {
    var RequestHeader = $resource(AppBaseUrl + '/api/RequestHeader/:action/:id',
        {},
        {
            list: { method: 'GET', params: { action: 'list' }, cache: false, isArray: true },
            getCount: { method: 'GET', params: { action: 'getcount' }, cache: false, isArray: false },
            update: { method: 'PUT', params: { action: undefined }, cache: false, isArray: false }
        });
    return RequestHeader;
});

services.factory('DataForms', function ($resource, AppBaseUrl) {
    var DataForms = $resource(AppBaseUrl + '/api/DataForms/:action/:code',
        {},
        {
            lookup: { method: 'GET', params: {action: 'lookup'}, cache: false, isArray: true}
        });
    return DataForms;
});
services.factory('FieldStaff', function ($resource, AppBaseUrl) {
    var FieldStaff = $resource(AppBaseUrl + '/api/FieldStaff/:action/:code',
        {},
        {
            lookup: { method: 'GET', params: { action: 'lookup' }, cache: false, isArray: true }
        });
    return FieldStaff;
});
services.factory('FormStatus', function ($resource, AppBaseUrl) {
    var FormStatus = $resource(AppBaseUrl + '/api/FormStatus/:action/:code',
        {},
        {
            lookup: { method: 'GET', params: { action: 'lookup' }, cache: false, isArray: true }
        });
    return FormStatus;
});
services.factory('FormType', function ($resource, AppBaseUrl) {
    var FormType = $resource(AppBaseUrl + '/api/FormType/:action/:code',
        {},
        {
            lookup: { method: 'GET', params: { action: 'lookup' }, cache: false, isArray: true }
        });
    return FormType;
});
services.factory('Gears', function ($resource, AppBaseUrl) {
    var Gears = $resource(AppBaseUrl + '/api/Gears/:action/:code',
        {},
        {
            lookup: { method: 'GET', params: { action: 'lookup' }, cache: false, isArray: true }
        });
    return Gears;
});
services.factory('Ports', function ($resource, AppBaseUrl) {
    var Ports = $resource(AppBaseUrl + '/api/Ports/:action/:code',
        {},
        {
            lookup: { method: 'GET', params: { action: 'lookup' }, cache: false, isArray: true }
        });
    return Ports;
});
services.factory('Programs', function ($resource, AppBaseUrl) {
    var Programs = $resource(AppBaseUrl + '/api/Programs/:action/:code',
        {},
        {
            lookup: { method: 'GET', params: { action: 'lookup' }, cache: false, isArray: true }
        });
    return Programs;
});
services.factory('Vessels', function ($resource, AppBaseUrl) {
    var Vessels = $resource(AppBaseUrl + '/api/Vessels/:action/:code',
        {},
        {
            lookup: { method: 'GET', params: { action: 'lookup' }, cache: false, isArray: true }
        });
    return Vessels;
});



