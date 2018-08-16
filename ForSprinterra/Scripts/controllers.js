'use strict';

var app = angular.module('myApp');

var tokenAdded = false;

app.controller('storeToken', function ($scope, $http, $route) {
    $scope.clientId = "q29b92xr1xo0lerx8jnvpwver9esv82";
    $scope.token = "2qnkreg8fdszfxtgso32ntgajq78to7";
    $scope.baseUrl = "https://api.bigcommerce.com/stores/7nlbfko0rv/v3/";
    $scope.added = tokenAdded;

    $scope.check = function () {
        $http.get("http://localhost:51236/api/token/" + $scope.clientId + "/" + $scope.token + "?baseUrl=" + $scope.baseUrl).then(
            function (response) {
                tokenAdded = true;
                $route.reload();
            },
            function (response) {
                $scope.showWarningMessage = true;
                if (!response.data.Message.includes('No HTTP resource was found') &&
                    !response.data.Message.includes('The request is invalid')) $scope.warningMessage = response.data.Message;
                else $scope.warningMessage = "Correct your entered data!"
            }
        );
    }

});

var keyword = "";
app.controller('productsView', function ($scope, $http, $route) {
    $scope.added = tokenAdded;
    $scope.show = true;
    $scope.words = keyword;


    if (keyword == "") {
        $http.get("http://localhost:51236/api/products").then(function (response) {
            var data = response.data;
            data.forEach(function (item, i, data) {
                item.description = item.description.replace(/<\/?[^>]+>/g, '');
            });
            $scope.products = data;
        });
    }
    else {
        $http.get("http://localhost:51236/api/products/find/" + keyword).then(function (response) {
            var data = response.data;
            data.forEach(function (item, i, data) {
                item.description = item.description.replace(/<\/?[^>]+>/g, '');
            });
            $scope.products = data;
        });
    }

    $scope.description = function () {
        if ($scope.show == true)
            $scope.show = false;
        else $scope.show = true;
    }

    $scope.search = function () {
        keyword = $scope.words;
        $route.reload();
    }

    $scope.reset = function () {
        keyword = "";
        $route.reload();
    }

    var arrIds = [];

    $scope.deleteBox = function (id) {
        var coincidence = false;
        for (var i = 0; i <= arrIds.length; i++) {
            if (arrIds[i] == id) {
                coincidence = true;
                arrIds.splice(i, 1);
                i--;
            }
        }
        if (!coincidence) {
            arrIds.push(id);
        }
    }

    $scope.delete = function () {
        arrIds.forEach(function (item, i, arrIds) {
            $http.delete('http://localhost:51236/api/products/delete/' + item);
        });
        $route.reload();
    }
});


app.controller('concreteProduct', function ($scope, $http, $routeParams) {
    $scope.added = tokenAdded;

    $http.get("http://localhost:51236/api/products/images/" + $routeParams.id).then(function (response) {
        $scope.mainImage = response.data[0].url_standard;
    });

    $http.get("http://localhost:51236/api/products/" + $routeParams.id).then(function (response) {
        var data = response.data;
        data.description = data.description.replace(/<\/?[^>]+>/g, '');
        $scope.product = data;
    });

});
