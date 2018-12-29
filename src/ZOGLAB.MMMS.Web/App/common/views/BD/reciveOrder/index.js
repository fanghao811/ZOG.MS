(function () {
    appModule.controller('common.views.BD.reciveOrder.index', ['$scope', '$state', '$stateParams',
        function ($scope, $state, $stateParams) {        //TODO 1.0 更改服务名 done
            var vm = this;
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            //vm.orderId = $stateParams.orderId;
            console.log("vm.orderId:" + vm.orderId);
        }
    ]);
})();