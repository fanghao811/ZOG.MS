(function () {
    appModule.controller('common.views.BD.reciveOrder.order', [        //TODO：  在app.js 中添加路由 done
        '$scope', '$state', '$stateParams', 'abp.services.app.receive', 'abp.services.app.unit',
        function ($scope, $state, $stateParams, receiveService, unitService) {        //TODO 1.0 更改服务名 done
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;

            var Id_FromState = $stateParams.orderId; //从路由处获取Id

            $scope.units = [];     //TODO: 1.0  $此处必须使用 $scope

            vm.selectedUnit = {};

            vm.order = {
                id: Id_FromState,
                unitName: "",
                unit_ID: 0,
                number: "20181226",
                device_Num: 0,
                address: "",
                contact: "",
                contactTel: "",
                expressDelivery: ""
            };


            //$scope.selected = { value: $scope.itemArray[2] };

            vm.changeUnit = function () {
                vm.order.unit_ID = vm.selectedUnit.id;
                vm.order.unitName = vm.selectedUnit.unitName;
                vm.order.address = vm.selectedUnit.address;
                vm.order.contact = vm.selectedUnit.contact;
                vm.order.contactTel = vm.selectedUnit.contactTel;
            };

            vm.getUnits = function () {     //TODO:     4.4.1 WebAPI查询方法
                vm.loading = true;
                unitService.getAll() //TODO: ???
                    .then(function (result) {
                        $scope.units = result.data;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            vm.getCureentReceive = function (orderId) {
                if (!angular.equals(orderId, '')) {
                    vm.loading = true;
                    receiveService.getReceiveById({ Id: orderId }) //TODO: ???
                        .then(function (result) {
                            vm.selectedUnit = result.data;
                        }).finally(function () {
                            vm.loading = false;
                        });
                }
            };

            vm.save = function () {
                vm.loading = true;
                vm.order.unit_ID = vm.selectedUnit.id;
                //vm.order.address = vm.selectedUnit.address;
                receiveService.createOrUpdateReveice(vm.order) //TODO: ???
                    .then(function (result) {
                        abp.notify.info("登记单：" + app.localize('SavedSuccessfully'));
                        $state.go("reOrder.regist.ordItems", { orderId: result.data });
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            vm.goPrint = function () {
                $state.go("reOrder.regist.ordItems", { orderId: 4 });
            };

            // =========================================================================
            // Page Initial Function
            // =========================================================================
            vm.initial = function () {
                vm.loading = true;
                unitService.getAll()    //TODO: ???
                    .then(function (result) {
                        $scope.units = result.data;
                        receiveService.getReceiveById({ Id: $stateParams.orderId })    //TODO: ???
                            .then(function (result) {
                                vm.order = result.data;
                                vm.selectedUnit = _.find($scope.units, function (unit) { return unit.id == vm.order.unit_ID });
                            }).finally(function () {
                                vm.loading = false;
                            });
                    });
            };
            vm.initial();
        }
    ]);
})();