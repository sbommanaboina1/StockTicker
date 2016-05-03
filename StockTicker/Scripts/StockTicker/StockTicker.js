var StockTickerApp = angular.module('StockTickerApp', [])
StockTickerApp.controller('StockTickerController', function ($scope,$interval, $filter, StockTickerService) {
    //Initiate the Timer object.
    $scope.Timer = null;
    //Timer start function.
    $scope.StartTimer = function () {
        //Initialize the Timer to run every 10000 milliseconds i.e. ten seconds.
        $scope.Timer = $interval(function () {
            getStocks();
        }, 10000);
    };
    $scope.StartTimer();
    getStocks();
    function getStocks() {
        StockTickerService.getStocks()
            .success(function (stockValues) {
                //$scope.date = 'yyyy-MM-ddTHH:mm:ss';
                $scope.stocks = stockValues;
                console.log($scope.stocks);
            })
            .error(function (error) {
                alert(error);
                $scope.status = 'Unable to load stock data: ' + error.message;
                console.log($scope.status);
            });
    }
});

StockTickerApp.factory('StockTickerService', ['$http', function ($http) {
    var StockTickerService = {};
    StockTickerService.getStocks = function () {
        return $http.get('/StockTicker/GetStocks');
    };
    return StockTickerService;
}]);