(function () {
    appModule.controller('common.views.handover.createOrEditModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.receive', 'enumService','instruments',
        function ($scope, $uibModalInstance, receiveService, enumService, instruments) {
            var vm = this;

            vm.loading = true;
            vm.saving = false;
            vm.handoverOrder = null;
            vm.instruments = instruments;

            vm.instrumentTests = instrumentTests;       //被选中的仪器列表
            vm.vMTypes = enumService.test_VMType;       // VocationalWork_Type 业务类型 ==> 7# BD_Test 

            vm.save = function () {

                vm.saving = true;
                receiveService.createOrUpdateStandard(vm.standar)
                    .then(function () {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

            function init() {
                standardService.getStandardForEdit({
                    id: standardId
                }).then(function (result) {
                    vm.standard = result.data;
                    vm.loading = false;
                });
            }

            init();
        }
    ]);
})();