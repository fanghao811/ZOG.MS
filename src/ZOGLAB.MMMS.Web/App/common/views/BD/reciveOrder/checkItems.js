(function () {
    appModule.controller('common.views.BD.reciveOrder.checkItems', ['$scope', '$state', '$stateParams',
        'abp.services.app.checkType', 'abp.services.app.receive',
        function ($scope, $state, $stateParams, checkTypeService, receiveService) {        //TODO 1.0 更改服务名 done
            var vm = this;
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            // =========================================================================
            // Begin.初始化变量
            // =========================================================================

            vm.receiveId = $stateParams.orderId;        //从路由处获取current_receive_Id

            vm.order = {        //InstrumentTest_order
                receiveInstrument_ID: 0,
                checkType_ID: 0,
                number: "",
                caliValidateDate: "",
                caliU: "",
                address: "",
                strFlag: true
            }
            vm.tyCount_1 = 0;
            vm.tyCount_0 = 0;
            vm.selectedMeteor = {};
            vm.meteors = [];
            vm.checkTypes = [];
            vm.instrumentTests = [];
            vm.instrumentsWithTCount = [];

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
            // getInstrumentsWithCount 右侧仪器列表(数据源)
            // =========================================================================
            vm.getInstrumentsWithCount = function (receiveId) {     //获取 ViewModal
                if (angular.equals(receiveId, '')) {
                    return
                }
                vm.loading = true;
                receiveService.getInstrumentWithTCountByReId({ Id: receiveId })
                    .then(function (result) {
                        vm.instrumentsWithTCount = result.data;
                        if (null != vm.instrumentsWithTCount) {
                            vm.tyCount_1 = _.filter(result.data, function (item) { return item.checkTypeCount > 0 }).length;
                            vm.tyCount_0 = vm.instrumentsWithTCount.length - vm.tyCount_1;
                        }

                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            // =========================================================================
            // getInstrumentTestsByReInId 获取检测项目列表
            // =========================================================================
            vm.getInTsts = function (reInId) {     //获取 reInId:receiveInstrumentId
                vm.loading = true;
                receiveService.getInstrumentTestsByReInId({ id: reInId })
                    .then(function (result) {
                        vm.instrumentTests = result.data;
                        vm.order.receiveInstrument_ID = reInId;
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
                        vm.getInTsts(vm.order.receiveInstrument_ID);
                        vm.getInstrumentsWithCount(vm.receiveId);
                    });
            };

            // =========================================================================
            // Page Filter Function
            // =========================================================================
            $scope.countFilter = function (item) {
                return (item.checkTypeCount > 0);
            }

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

                vm.getInstrumentsWithCount(vm.receiveId);
            };

            //Begin
            vm.initial();
        }
    ]);
})();