(function () {
    appModule.controller('common.views.standard.createOrEditModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.standard', 'standardId',
        function ($scope, $uibModalInstance, standardService, standardId) {
            var vm = this;

            vm.saving = false;
            vm.standard = null;

            vm.save = function () {
                vm.saving = true;
                standardService.createOrUpdateStandard(vm.standar)
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