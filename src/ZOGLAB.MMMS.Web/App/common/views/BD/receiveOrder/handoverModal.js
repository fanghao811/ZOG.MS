(function () {
    appModule.controller('common.views.handover.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.receive', 'enumService',
        function ($scope, $uibModalInstance, receiveService, enumService) {
            var vm = this;

            vm.loading = true;
            vm.saving = false;
            vm.handoverOrder = null;
            //vm.instruments = instruments;

            vm.requestParams = {        //TODO: 2.0  配置查询对象 GetStandardsInput done
                "checkTypeId": 0,
                "intHandover": false,
                "userId": 0,
                "number": "",
                "address": "",
                "skipCount": 0,
                "maxResultCount": app.consts.grid.defaultPageSize,
                "sorting": null
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

            //vm.instrumentTests = instrumentTests;       //被选中的仪器列表
            vm.vMTypes = enumService.test_VMType;       // VocationalWork_Type 业务类型 ==> 7# BD_Test 

            vm.save = function () {
                vm.saving = true;
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

        }
    ]);
})();