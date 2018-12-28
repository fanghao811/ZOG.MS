(function () {
    appModule.controller('common.views.BD.reciveOrder.checkItems', ['$scope', '$state', '$stateParams',
        'abp.services.app.checkType', 'abp.services.app.receive',
        function ($scope, $state, $stateParams, checkTypeService, receiveService) {        //TODO 1.0 更改服务名 done
            var vm = this;
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            // =========================================================================
            // Begin.定义变量
            // =========================================================================

            //var Id_FromState = $stateParams.orderId;        //从路由处获取current_receive_Id

            vm.order = {        //InstrumentTest_order
                receiveInstrument_ID: 1,
                checkType_ID: 0,
                number: "0811",
                caliValidateDate: "11",
                caliU: "08",
                address: "ZOGLAB 实验室",
                strFlag: true
            }

            vm.selectedMeteor = {};
            vm.meteors = [];
            vm.checkTypes = [];
            vm.instrumentTests = [];

            vm.receive = {};

            // =========================================================================
            // getCheckTypes 获取检测项目列表，左侧
            // =========================================================================
            vm.getCheckTypes = function () {     //获取 ViewModal
                vm.loading = true;
                checkTypeService.getAll()
                    .then(function (result) {
                        vm.checkTypes = result.data;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            // =========================================================================
            // getCureentReceive 获取表头，右侧 receive.registedInstruments
            // =========================================================================
            vm.getCureentReceive = function (orderId) {     //获取 ViewModal
                if (!angular.equals(orderId, '')) {
                    vm.loading = true;
                    receiveService.getReceiveWithItems({ Id: orderId })
                        .then(function (result) {
                            vm.receive = result.data;
                        }).finally(function () {
                            vm.loading = false;
                        });
                }
            };

            // =========================================================================
            // getInstrumentTestsByReInId 获取检测项目列表
            // =========================================================================
            vm.getInTsts = function (reInId) {     //获取 reInId:receiveInstrumentId
                vm.loading = true;
                receiveService.getInstrumentTestsByReInId({ id: reInId })
                    .then(function (result) {
                        vm.instrumentTests = result.data;
                        abp.notify.success("成功获得：" + vm.instrumentTests.length + "条检测项目！");
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            // =========================================================================
            // cUInstrumentTestF 新增，
            // =========================================================================
            vm.save = function () {     //获取 ViewModal
                vm.loading = true;
                receiveService.cUInstrumentTestF(vm.order)
                    .then(function () {
                        abp.notify.info("检测项目：" + vm.order.number + "新增成功");                       
                    }).finally(function () {
                        vm.getInTsts(1);
                    });
            };


            // =========================================================================
            // Page Initial Function
            // =========================================================================
            vm.initial = function () {
                vm.loading = true;

                checkTypeService.getAll()
                    .then(function (result) {
                        vm.checkTypes = result.data;
                        vm.meteors = _.uniq(_.pluck(vm.checkTypes, 'meteor'));
                    }).finally(function () {
                        vm.loading = false;
                    });

                vm.getInTsts(1);
            };

            //Begin
            vm.initial();
        }
    ]);
})();