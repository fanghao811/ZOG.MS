(function () {
    appModule.controller('common.views.BD.reciveOrder.orderItems', [        //TODO：  在app.js 中添加路由 done
        '$scope', '$state', '$stateParams', 'abp.services.app.receive', 'abp.services.app.instrument',
        function ($scope, $state, $stateParams, receiveService, instrumentService) {        //TODO 1.0 更改服务名 done
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;

            var Id_FromState = $stateParams.orderId; //从路由处获取current_receive_Id
            vm.instruments = [];    //左侧仪器列表，ALL
            vm.receive = {};        //登记单，复合对象， ViewModal， **包含右侧已登记
            //vm.receive.registedInstruments

            // =========================================================================
            // getCureentReceive 获取表头，receive （orderHeader）
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
            // getAllInstruments 左侧-获取所有仪器 TODO:加载后，做差集，排除已经登记仪器
            // =========================================================================
            vm.getAllInstruments = function () {
                vm.loading = true;
                instrumentService.getAll()
                    .then(function (result) {
                        var idArr = _.pluck(vm.receive.registedInstruments, 'id');
                        vm.instruments = _.filter(result.data, function (item) { return !_.contains(idArr, item.id) });
                        abp.notify.success("共获取了" + vm.instruments.length + "件仪器！");
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            // =========================================================================
            // addInstrumentToReceive 右侧-添加仪器，如果已经存在,则...
            // =========================================================================
            vm.addInstrumentToReceive = function (instrument) {
                var instrumentToAdd = _.find(vm.receive.registedInstruments, function (item) { return item.id == instrument.id; });
                console.log(instrumentToAdd);

                if (instrumentToAdd != null) {
                    abp.notify.warn("编号：" + instrument.sn + "的仪器已经登记！");
                    vm.instruments.splice(_.findIndex(vm.instruments, function (item) { return item.id == instrument.id; }), 1);
                    return
                }

                vm.loading = true;
                receiveService.addInstrumentToReceive(instrument.id, Id_FromState)
                    .then(function () {
                        //1.左侧ALl列表中定位addedItem.index 2.左侧删除此元素 3.右侧增加元素
                        vm.instruments.splice(_.findIndex(vm.instruments, function (item) { return item.id == instrument.id; }), 1);
                        vm.receive.registedInstruments.push(instrument);
                        abp.notify.info("成功添加编号为：" + instrument.sn + "的仪器！");
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            // =========================================================================
            // removeInstrumentFromReceive 右侧-删除仪器，左侧添加,则...
            // =========================================================================
            vm.removeInstrumentFromReceive = function (instrument) {
                vm.loading = true;
                receiveService.removeInstrumentFromReceive(instrument.id, Id_FromState)
                    .then(function () {
                        //1.左侧ALl列表中定位addedItem.index 2.左侧删除此元素 3.右侧增加元素
                        vm.instruments.push(instrument);
                        vm.receive.registedInstruments.splice(_.findIndex(vm.receive.registedInstruments, function (item) { return item.id == instrument.id; }), 1);
                        abp.notify.error("已删除编号为：" + instrument.sn + "的仪器！");
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            // =========================================================================
            // goOrder 上一步... 返回修改 OrderHeader信息
            // =========================================================================
            vm.goOrder = function () {
                $state.go("reOrder.regist.order", { orderId: Id_FromState });
            }

            //var different = function (arrA, arrB) {//       TODO:实现基于ID的通用过滤方法
            //    var idArr = _.pluck(arrB, 'id');
            //    return _.filter(arrA, function (item) { return !_.contains(idArr, item.id) });
            //};

            // =========================================================================
            // Page Initial Function
            // =========================================================================
            vm.initial = function () {
                receiveService.getReceiveWithItems({ Id: $stateParams.orderId })
                    .then(function (result) {
                        vm.receive = result.data;

                        instrumentService.getAll()
                            .then(function (result) {
                                var idArr = _.pluck(vm.receive.registedInstruments, 'id');
                                vm.instruments = _.filter(result.data, function (item) { return !_.contains(idArr, item.id) });
                                abp.notify.success("共获取了" + vm.instruments.length + "件仪器！");
                            });
                    });
            };
            vm.initial();
        }
    ]);
})();