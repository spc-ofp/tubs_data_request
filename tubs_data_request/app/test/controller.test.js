describe("Unit Testing Examples", function () {
    var element;
    var element2;
    var $scope;
    beforeEach(inject(function ($compile, $rootScope){
        $scope = $rootScope;
        element = angular.element("<div>{{2+2}}</div>");
        element = $compile(element)($rootScope)
        element2 = angular.element("<div>{{3+2}}</div>");
        element2 = $compile(element2)($rootScope)
    }))
    it("should equal 4", function () {
        $scope.$digest()
        expect(element.html()).toBe("4");
    })
    it("should equal 6", function () {
        $scope.$digest()
        expect(element2.html()).toBe("6");
    })
});