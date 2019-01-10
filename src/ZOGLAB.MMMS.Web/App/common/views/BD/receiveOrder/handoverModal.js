(function () {
    appModule.controller('common.views.handover.createModal', [
        '$scope', '$uibModalInstance',
        'abp.services.app.receive',
        'abp.services.app.meteorType',
        'abp.services.app.installation',
        'enumService',
        function ($scope, $uibModalInstance, receiveService, meteorService, installationService, enumService) {

            // =========================================================================
            // 变量初始化
            // =========================================================================
            var vm = this;
            vm.loading = true;
            vm.saving = false;
            vm.handoverOrder = null;
            vm.meteors = [];
            $scope.installations = [];
            vm.instrumentTests = [];

            vm.test = {        //TODO: 2.0  配置查询对象 GetStandardsInput done
                "id": null,
                "check_Num": moment().format("YYYYMMDDHHmm"),
                "mark": "",
                "vocationalWorkType": 0,
                "installation_ID": 0,
                "meteorType_ID": 0,
                "startDate": null,
                "finishDate": null,
                "instrumentTestIds": []
            };



            // =========================================================================
            // 日期范围设置
            // =========================================================================
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

            // =========================================================================
            // 获取 InstrumentTests ==> 6# BD_InstrumentTest
            // =========================================================================
            vm.getInstrumentTests = function () {
                receiveService.getInstrumentTestsForSelection()
                    .then(function (result) {
                        vm.instrumentTests = result.data;
                    });
            };

            // =========================================================================
            // 获取 VocationalWork_Type 业务类型 ==> 7# BD_Test
            // =========================================================================
            vm.vMTypes = enumService.test_VMType;

            // =========================================================================
            // 获取 MeteorTypes
            // =========================================================================
            vm.getInstallations = function () {
                installationService.getList()
                    .then(function (result) {
                        $scope.installations = result.data;
                    });
            }

            // =========================================================================
            // 获取 MeteorTypes
            // =========================================================================
            vm.getMeteors = function () {
                meteorService.getAll()
                    .then(function (result) {
                        vm.meteors = result.data;
                    });
            };

            vm.save = function () {
                vm.saving = true;
                $("#optgroup :checked").each(function (i, item) {
                    vm.test.instrumentTestIds.push(Number($(item).attr("value")));
                });

                vm.test.startDate = vm.dateRangeModel.startDate;
                vm.test.finishDate = vm.dateRangeModel.endDate;

                receiveService.createOrUpdateTest(vm.test)
                    .then(function () {
                        abp.notify.info("检测单：" + app.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

            // =========================================================================
            // Page Initial Function
            // =========================================================================
            vm.initial = function () {
                vm.getMeteors();
                vm.getInstallations();
                vm.getInstrumentTests();
            };

            vm.initial();
        }
    ]);
})();