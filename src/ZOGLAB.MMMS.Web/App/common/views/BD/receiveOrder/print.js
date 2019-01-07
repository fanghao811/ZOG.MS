(function () {
    appModule.controller('common.views.BD.receiveOrder.index', ['$scope',
        function ($scope) {        //TODO 1.0 更改服务名 done
            var vm = this;
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });
        }
    ]);
})();