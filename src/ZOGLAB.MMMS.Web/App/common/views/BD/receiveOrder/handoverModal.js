(function () {
    appModule.controller('common.views.handover.createModal', [
        '$scope', '$uibModalInstance',
        'abp.services.app.receive',
        'abp.services.app.meteorType',
        'abp.services.app.installation',
        'enumService',
        'testId',
        function (
            $scope, $uibModalInstance,
            receiveService, meteorService, installationService,
            enumService, testId) {
            // =========================================================================
            // 变量初始化
            // =========================================================================
            var vm = this;
            vm.loading = true;
            vm.saving = false;
            $scope.test_Id = testId;
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
                "creatorUserId":null,
                "instrumentTestIds": []
            };

            // =========================================================================
            // 日期范围设置
            // =========================================================================
            vm.dateRangeOptions = {
                min: moment('1900-01-01'),
                minDate: moment('1900-01-01'),
                max: moment('2022-05-01'),
                maxDate: moment('2022-05-01'),
                ranges: {}
            };

            vm.dateRangeOptions.ranges[app.localize('Last7Days')] = [moment().startOf('day'), moment().add(6, 'days').endOf('day')];
            vm.dateRangeOptions.ranges[app.localize('Last30Days')] = [moment().startOf('day'), moment().add(29, 'days').endOf('day')];
            vm.dateRangeOptions.ranges[app.localize('ThisMonth')] = [moment().startOf('day'), moment().endOf('month')];

            vm.dateRangeModel = {};

            // =========================================================================
            // 获取 VocationalWork_Types
            // =========================================================================
            vm.vMTypes = enumService.test_VMType;

            // =========================================================================
            // 获取 Installations
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

            // =========================================================================
            // 提交 & 取消
            // =========================================================================
            vm.save = function () {
                //vm.saving = true;
                //vm.test.instrumentTestIds = [];
                vm.test.instrumentTestIds = $("#optgroup").val();
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

                if (null != testId) {
                    receiveService.getTestForEdit({
                        id: testId
                    }).then(function (result) {
                        vm.test = result.data;
                        vm.dateRangeModel.startDate = vm.test.startDate ? vm.test.startDate: moment().startOf('day');
                        vm.dateRangeModel.endDate = vm.test.finishDate ? vm.test.endDate : moment().endOf('day');
                        
                        $('#dRDate').daterangepicker({
                            locale: {
                                format: 'L',
                                applyLabel: app.localize('Apply'),
                                cancelLabel: app.localize('Cancel'),
                                customRangeLabel: app.localize('CustomRange')
                            },
                            startDate: vm.dateRangeModel.startDate,
                            endDate: vm.dateRangeModel.endDate
                        });
                    });
                };
            };

            vm.initial();
        }
    ]);
})();