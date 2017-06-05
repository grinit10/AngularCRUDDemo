/// <reference path="C:\Users\CriticalRiver\Desktop\New folder\AngularCRUDDemo\AngularCRUDDemo\scripts/angular.js" />
/// <reference path="C:\Users\CriticalRiver\Desktop\New folder\AngularCRUDDemo\AngularCRUDDemo\scripts/angular-mocks.js" />
/// <reference path="C:\Users\CriticalRiver\Desktop\New folder\AngularCRUDDemo\AngularCRUDDemo\scripts/jasmine/jasmine.js" />
/// <reference path="C:\Users\CriticalRiver\Desktop\New folder\AngularCRUDDemo\AngularCRUDDemo\scripts/app/controller.js" />

//Arrnage
//Act
//Assert

describe("PropertyControllerModule", function () {
    beforeEach(module('PropControllers'));

    describe('SumController', function () {

        var scope, controller;
        //Arrnage
        //Mocking and DI
        beforeEach(inject(function ($rootScope,$controller) {
            scope = $rootScope.$new();

            controller = $controller('SumController', function () {
                $scope = scope;
            });
        }));

        it('It should return the sum of two values', function () {
            var result = $scope.sum(2, 3);
            expect(result).toEqual(5);
        })
    })
})