(function () {
    appModule.controller('common.views.BD.reciveOrder.index', ['$scope',
        function ($scope) {        //TODO 1.0 更改服务名 done
            var vm = this;
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });
        }
    ]);
})();