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
                id: 0,
                receiveInstrument_ID: 0,
                checkName: '',
                checkType_ID: 0,
                number: "",
                caliValidate: "",
                caliU: "",
                address: "",
                strFlag: true
            }
            vm.tyCount_1 = 0;
            vm.tyCount_0 = 0;
            vm.selectedInstrument = "检测项目登记";
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
                checkTypeService.getAll()
                    .then(function (result) {
                        vm.checkTypes = result.data;
                    });
            };

            // =========================================================================
            // getInstrumentsWithCount 右侧仪器列表(数据源)
            // =========================================================================
            vm.getInstrumentsWithCount = function (receiveId) {     //获取 ViewModal
                if (angular.equals(receiveId, '')) {
                    return
                }
                receiveService.getInstrumentWithTCountByReId({ Id: receiveId })
                    .then(function (result) {
                        vm.instrumentsWithTCount = result.data;
                        if (null != vm.instrumentsWithTCount) {
                            vm.tyCount_1 = _.filter(result.data, function (item) { return item.checkTypeCount > 0 }).length;
                            vm.tyCount_0 = vm.instrumentsWithTCount.length - vm.tyCount_1;
                        }
                    });
            };

            // =========================================================================
            // getInstrumentTestsByReInId 获取检测项目列表
            // =========================================================================
            vm.getInTsts = function (reInId) {     //获取 reInId:receiveInstrumentId
                receiveService.getInstrumentTestsByReInId({ id: reInId })
                    .then(function (result) {
                        vm.instrumentTests = result.data;
                    });
            };

            // =========================================================================
            // cUInstrumentTestF 新增，
            // =========================================================================
            vm.save = function () {     //获取 ViewModal
                vm.loading = true;
                receiveService.cUInstrumentTestF(vm.order)
                    .then(function (result) {
                        if (null != vm.order.id) {
                            abp.notify.info("更新成功! 检测编号：" + vm.order.sn);
                        } else {
                            abp.notify.success("新增成功! 新增ID：" + result);
                        }
                        //vm.order.id = result.id; 新增后继续新增使用
                        vm.getInTsts(vm.order.receiveInstrument_ID);
                        vm.getInstrumentsWithCount($stateParams.orderId);
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            // =========================================================================
            // delInstrumentTest 删除
            // =========================================================================
            vm.delInstrumentTest = function (order) {     //获取 ViewModal
                vm.loading = true;
                receiveService.delInstrumentTest({ id: order.id })
                    .then(function () {
                        abp.notify.danger("检测项目删除成功！");
                    }).finally(function () {
                        vm.getInTsts(vm.order.receiveInstrument_ID);
                        vm.getInstrumentsWithCount(vm.receiveId);
                        vm.loading = false;
                    });
            };

            // =========================================================================
            // Page Filter & Click Functions
            // =========================================================================
            vm.selectCheckItem = function (item) {          //选择检查项目Click
                vm.order = {};
                var query = _.find(vm.checkTypes, function (q) { return q.checkName == item.checkName });
                vm.selectedMeteor = query.meteor;
                vm.order = item;
            };

            vm.selectInstrumentItem = function (item) {     //选择已分配仪器Click
                vm.order = {};
                vm.order.receiveInstrument_ID = item.id;
                vm.getInTsts(item.id);
                vm.selectedInstrument = item.name + item.sn;
            };

            $scope.countFilter = function (item) {
                return (item.checkTypeCount > 0);
            };

            // =========================================================================
            // Page Initial Function
            // =========================================================================
            vm.initial = function () {
                checkTypeService.getAll()
                    .then(function (result) {
                        vm.checkTypes = result.data;
                        vm.meteors = _.uniq(_.pluck(vm.checkTypes, 'meteor'));
                    });

                vm.getInstrumentsWithCount(vm.receiveId);
            };

            //Begin
            vm.initial();
        }
    ]);
})();