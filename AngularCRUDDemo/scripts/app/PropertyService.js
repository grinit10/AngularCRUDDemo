var PropertyService = angular.module("PropertyService", [])

.factory('PropertyService', ['$http', function ($http) {
    var fac = {};

    fac.Getproperties = function () {
        return $http.get("/Property/GetProperties");
    }

    fac.GetpropertyById = function (id) {
        return $http.get("/Property/GetPropertyById", { params: { id: id } });
    }

    fac.addproperty = function (property) {
        return $http.post("/Property/AddProperty", property);
    }

    fac.updateproperty = function (property) {
        return $http.post("/Property/UpdateProperty", property);
    }

    fac.delproperty = function (id) {
        return $http.post("/Property/DeleteProperty", { id: id })
    }
    return fac;
}])