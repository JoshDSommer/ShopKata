angular.module("ShopKata")
.service("ApiDataService", ["$http", function ($http) {
    var baseUrl = "/api/Product";
    
    this.get = function () {
        return $http.get(baseUrl);
    }

    this.getTotal = function(cartItems){
        return $http.post(baseUrl + "/GetTotal", cartItems);
    }
}]);