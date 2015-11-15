angular.module("ShopKata", [])
.controller("ProductsCntrl", ["$scope", "ApiDataService", function ($scope, ApiDataService) {
    $scope.products = [];
    $scope.availableQty = [0, 1, 2, 3, 4, 5, 6];
    $scope.totalCost = 0;
    $scope.cartItem = 0;

    ApiDataService.get()
       .success(function (data) {
           $scope.products = data;
           $scope.products.forEach(function (product, index) {
               product.cartItem = $scope.availableQty[0];
           });
       });

    $scope.cartItems = [];


    $scope.addItem = function (producutId, qty) {
        var updated = false;
        //check to see if item already is in cart.
        $.each($scope.cartItems, function () {
            //updated item qty if it already exists
            if (this.productId == producutId) {
                this.qty = qty;
                updated = true;
            }
        });
        //if we didn't update a cart item. add it to the array.
        if(!updated)
            $scope.cartItems.push({
                productId: producutId,
                qty: qty
            });

        //get new totals
        ApiDataService.getTotal($scope.cartItems)
        .success(function (data) {
            $scope.totalCost = data;
        });
    };
}]);