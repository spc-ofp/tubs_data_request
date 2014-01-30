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

var directives = angular.module('tubsdatarequest.directives', []);

directives.directive('onBlurChange', function ($parse) {
  return function (scope, element, attr) {
    var fn = $parse(attr['onBlurChange']);
    var hasChanged = false;
    element.on('change', function (event) {
      hasChanged = true;
    });
 
    element.on('blur', function (event) {
      if (hasChanged) {
        scope.$apply(function () {
          fn(scope, {$event: event});
        });
        hasChanged = false;
      }
    });
  };
});

directives.directive('onEnterBlur', function() {
  return function(scope, element, attrs) {
    element.bind("keydown keypress", function(event) {
      if(event.which === 13) {
        element.blur();
        event.preventDefault();
      }
    });
  };
});

directives.directive('sortBy', function () {
  return {
    template: '<a ng-click="sort(sortvalue)"><span ng-transclude=""></span><span ng-show="sortedby == sortvalue"> <i ng-class="{true: \'fa fa-sort-asc\', false: \'fa fa-sort-desc\'}[sortdir == \'asc\']"></i></span></a>',
    restrict: 'E',
    transclude: true,
    replace: true,
    scope: {
      sortdir: '=',
      sortedby: '=',
      sortvalue: '@',
      onsort: '='
    },
    link: function (scope, element, attrs) {
      scope.sort = function () {
        if (scope.sortedby === scope.sortvalue) {
          scope.sortdir = ((scope.sortdir === 'asc') ? 'desc' : 'asc');
        } else {
          scope.sortedby = scope.sortvalue;
          scope.sortdir = 'asc';
        }
        scope.onsort(scope.sortedby, scope.sortdir);
      };
    }
  };
});

directives.directive('gisExport', function(dischargePoints, wmsLayers) { 
  return { 
    require: '^gisMap', 
    template: '<input type=button value="{{label}}" ng-click="createAndSubmitForm()">', 
    scope: {label: '@gisExport'}, 
    link: function(scope, elem, attrs, gisMapController) { 
      scope.createAndSubmitForm = function() { 
        var map = gisMapController.map, 
            bbox = map.getExtent().toBBOX(), 
            pixels = dischargePoints.asPixelString(map), 
            layers = wmsLayers.toString(); 
        elem.append('<form action=gis-export target=_blank method=post>' 
          + '<input type=hidden name=pixels value="' + pixels + '">' 
          + '<input type=hidden name=bbox   value="' + bbox + '">' 
          + '<input type=hidden name=layers value="' + layers + '">' 
          + '</form>'); 
        elem.find('form').submit().remove(); 
      }; 
    } 
  }; 
});
