var PropControllers = angular.module("PropControllers", ['angularUtils.directives.dirPagination', 'PropertyService']);
// this controller call the api method and display the list of employees  
// in list.html  
PropControllers.controller("ListController", ['$scope', '$http','PropertyService',
    function ($scope, $http,PropertyService) {
        PropertyService.Getproperties().then(function (resp) {
            $scope.properties = resp.data;
            $scope.sortColumn = "Name";
            $scope.reverseSort = false;

            $scope.sortData=function(column){
                $scope.reverseSort = ($scope.sortColumn === column) ? !$scope.reverseSort : false;
                $scope.sortColumn = column;
            }

            $scope.getSortClass = function (column) {

                if ($scope.sortColumn == column) {
                    return $scope.reverseSort? 'arrow-down': 'arrow-up';
                }
                return '';
            }
        });
    }
]);

// this controller call the api method and display the record of selected employee  
// in delete.html and provide an option for delete  
PropControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location', 'PropertyService',
    function ($scope, $http, $routeParams, $location, PropertyService) {
        $scope.id = $routeParams.id;
        PropertyService.GetpropertyById($scope.id).then(function (resp) {
            $scope.Name = resp.data.Name;
            $scope.BoundsLatA = resp.data.BoundsLatA;
            $scope.BoundsLngA = resp.data.BoundsLngA;
            $scope.BoundsLatB = resp.data.BoundsLatB;
            $scope.BoundsLngB = resp.data.BoundsLngB;
            $scope.CompanyName = resp.data.CompanyName;
        });
        $scope.delete = function () {
            PropertyService.delproperty($scope.id).then(function (resp) {
                if (resp.data.message != null)
                    alert(resp.data.message);
                else
                    alert("You don't have access to delete this property!!");
                $location.path('/list');
            });
        };
    }
]);
// this controller call the api method and display the record of selected employee  
// in edit.html and provide an option for create and modify the employee and save the employee record  
PropControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location', 'PropertyService',
    function ($scope, $filter, $http, $routeParams, $location, PropertyService) {
        
        $scope.save = function () {
            var prop = {
                Id: $scope.id,
                Name: $scope.Name,
                BoundsLatA: $scope.BoundsLatA,
                BoundsLngA: $scope.BoundsLngA,
                BoundsLatB: $scope.BoundsLatB,
                BoundsLngB: $scope.BoundsLngB,
                CompanyName: $scope.CompanyName
            };
            if ($scope.id == 0) {
                PropertyService.addproperty(prop).then(function (resp) {
                    if (resp.data.message != null)
                        alert(resp.data.message);
                    else
                        alert("You don't have access to update this property!!");
                    $location.path('/list');
                });
            }
            else {
                PropertyService.updateproperty(prop).then(function (resp) {
                    if (resp.data.message != null)
                        alert(resp.data.message);
                    else
                        alert("You don't have access to update this property!!");
                    $location.path('/list');
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit property";
            $http.get('/Property/GetPropertyById/' + $routeParams.id).then(function (resp) {
                $scope.Name = resp.data.Name;
                $scope.BoundsLatA = resp.data.BoundsLatA;
                $scope.BoundsLngA = resp.data.BoundsLngA;
                $scope.BoundsLatB = resp.data.BoundsLatB;
                $scope.BoundsLngB = resp.data.BoundsLngB;
                $scope.CompanyName = resp.data.CompanyName;
            });
        }
        else {
            $scope.id = 0
            $scope.title = "Create New property";
        }
    }
]);
//AddController for testing purposes only
PropControllers.controller("SumController",function($scope){
    $scope.sum = function (a1, a2) {
        return a1 + a2;
    };
})