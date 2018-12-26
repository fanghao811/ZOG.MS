(function () {
    appModule.controller('common.views.BD.reciveOrder.order', [        //TODO：  在app.js 中添加路由 done
        '$scope', '$state', '$stateParams', 'abp.services.app.receive', 'abp.services.app.unit',
        function ($scope, $state, $stateParams, receiveService, unitService) {        //TODO 1.0 更改服务名 done
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;

            ////vm.permissions = {
            ////    create: abp.auth.hasPermission('Pages.BD.Standard.Create'),
            ////    edit: abp.auth.hasPermission('Pages.BD.Standard.Edit'),
            ////    'delete': abp.auth.hasPermission('Pages.BD.Standard.Delete')
            ////};
            var Id_FromState = $stateParams.orderId; //从路由处获取Id

            vm.selectedUnit = {};
            $scope.units = [{ "unitName": "ZOGLAB", "address": "杭州西溪", "contact": "Admin", "contactTel": "1990579", "email": "ZOGLAB@Gmail.com", "id": 1 }];     //TODO: 1.0  $此处必须使用 $scope

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
                var order = {
                    id: Id_FromState,
                    unitName: vm.selectedUnit.unitName,
                    unit_ID: vm.selectedUnit.id,
                    number: "20181226",
                    device_Num: 0,
                    address: vm.selectedUnit.address,
                    contact: vm.selectedUnit.contact,
                    contactTel: vm.selectedUnit.contactTel,
                    expressDelivery: vm.selectedUnit.expressDelivery
                }
                receiveService.createOrUpdateReveice(order) //TODO: ???
                    .then(function (result) {
                        abp.notify.info("登记单：" + app.localize('SavedSuccessfully'));
                        $state.go("reOrder.regist.ordItems", { orderId: result.Id });
                    }).finally(function () {
                        vm.loading = false;
                    });
            }

            vm.goPrint = function () {
                $state.go("reOrder.regist.ordItems", { orderId: 4 });
            }

            //Page Initial Func
            vm.getUnits();
            vm.getCureentReceive(Id_FromState);
        }
    ]);
})();