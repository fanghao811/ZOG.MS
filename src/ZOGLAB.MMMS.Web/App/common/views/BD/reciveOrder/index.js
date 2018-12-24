(function () {
    appModule.controller('common.views.BD.reciveOrder.index', [        //TODO：  在app.js 中添加路由 done
        '$scope', 'abp.services.app.unit',
        function ($scope, unitService) {        //TODO 1.0 更改服务名 done
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;

            ////vm.permissions = {
            ////    create: abp.auth.hasPermission('Pages.BD.Standard.Create'),
            ////    edit: abp.auth.hasPermission('Pages.BD.Standard.Edit'),
            ////    'delete': abp.auth.hasPermission('Pages.BD.Standard.Delete')
            ////};
            vm.selectedUnit = {};
            
            vm.order={
                unit_ID: "",
                address: "",
                contact: "",
                contactTel:"",
                device_Num:0,
                expressDelivery:"",
                model:""
            };

            $scope.units = [{ "unitName": "ZOGLAB", "address": "杭州西溪", "contact": "Admin", "contactTel": "1990579", "email": "ZOGLAB@Gmail.com", "faxNumber": "123456", "mark": null, "isDeleted": false, "creationTime": "2018-12-22T22:50:53.77Z", "creatorUserId": null, "id": 1 }];     //TODO: 1.0  配置查询对象 GetStandardsInput don

            vm.getUnits = function () {     //TODO:     4.4.1 WebAPI查询方法
                vm.loading = true;
                unitService.getAll() //TODO: ???
                    .then(function (result) {
                        $scope.units = result.data;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            vm.getUnits();
        }
    ]);
})();