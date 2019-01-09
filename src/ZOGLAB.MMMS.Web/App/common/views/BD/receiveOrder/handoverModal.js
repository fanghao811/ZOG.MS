(function () {
    appModule.controller('common.views.handover.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.receive', 'enumService',
        function ($scope, $uibModalInstance, receiveService, enumService) {
            var vm = this;

            vm.loading = true;
            vm.saving = false;
            vm.handoverOrder = null;

            vm.dateRangeOptions = {
                locale: {
                    format: 'L',
                    applyLabel: app.localize('Apply'),
                    cancelLabel: app.localize('Cancel'),
                    customRangeLabel: app.localize('CustomRange')
                },
                min: moment('2019-01-01'),
                minDate: moment('2019-01-01'),
                max: moment('2022-05-01'),
                maxDate: moment('2022-05-01'),
                ranges: {}
            };

            vm.dateRangeOptions.ranges[app.localize('Last7Days')] = [moment().startOf('day'), moment().add(6, 'days').endOf('day')];
            vm.dateRangeOptions.ranges[app.localize('Last30Days')] = [moment().startOf('day'), moment().add(29, 'days').endOf('day')];
            vm.dateRangeOptions.ranges[app.localize('ThisMonth')] = [moment().startOf('day'), moment().endOf('month')];

            vm.dateRangeModel = {
                startDate: moment().startOf('day'),
                endDate: moment().endOf('day')
            };


            vm.test = {        //TODO: 2.0  配置查询对象 GetStandardsInput done
                "check_Num": "",
                "mark": "",
                "vocationalWorkType": 0,
                "installation_ID": 0,
                "meteorType_ID": 0,
                "instrumentTestIds":[]
            };

            vm.getInstrumentTests = function () {     //TODO:     4.4.1 WebAPI查询方法
                vm.loading = true;
                receiveService.getInstrumentTestsForHandOver(vm.requestParams) //TODO: ???
                    .then(function (result) {
                        vm.gridOptions.totalItems = result.data.totalCount;
                        vm.gridOptions.data = result.data.items;
                        vm.items = result.data.items;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };


            vm.vMTypes = enumService.test_VMType;       // VocationalWork_Type 业务类型 ==> 7# BD_Test 

            //vm.getUnits = function () {     //TODO:     4.4.1 WebAPI查询方法
            //    vm.loading = true;
            //    unitService.getAll() //TODO: ???
            //        .then(function (result) {
            //            $scope.units = result.data;
            //        }).finally(function () {
            //            vm.loading = false;
            //        });
            //};

            vm.save = function () {
                vm.saving = true;
            };


            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

        }
    ]);
})();