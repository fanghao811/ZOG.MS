(function () {
    appModule.controller('common.views.menuTree.createOrEditUnitModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.menuTreeUnit', 'menuTreeUnit',
        function ($scope, $uibModalInstance, menuTreeUnitService, menuTreeUnit) {
            var vm = this;

            vm.menuTreeUnit = menuTreeUnit;

            vm.saving = false;

            vm.save = function () {
                if (vm.menuTreeUnit.id) {
                    menuTreeUnitService
                        .updateMenuTreeUnit(vm.menuTreeUnit)
                        .then(function (result) {
                            abp.notify.info(app.localize('SavedSuccessfully'));
                            $uibModalInstance.close(result.data);
                        });
                } else {
                    menuTreeUnitService
                        .createMenuTreeUnit(vm.menuTreeUnit)
                        .then(function (result) {
                            abp.notify.info(app.localize('SavedSuccessfully'));
                            $uibModalInstance.close(result.data);
                        });
                }
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();