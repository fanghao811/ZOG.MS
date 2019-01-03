(function () {
    appModule.controller('common.views.BD.handoverOrder.index', [        //TODO：  在app.js 中添加路由 done
        '$scope', '$uibModal', 'uiGridConstants', 'abp.services.app.receive',
        function ($scope, $uibModal, uiGridConstants, receiveService) {        //TODO 1.0 更改服务名 done
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;
            vm.advancedFiltersAreShown = false;

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

            vm.dateRangeOptions = app.createDateRangePickerOptions();       //TODO: 3.0  设置日期范围对 done
            vm.dateRangeModel = {
                startDate: moment().startOf('day'),
                endDate: moment().endOf('day')
            };

            vm.gridOptions = {      //TODO: 4.0  设置表格参数 
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                paginationPageSizes: app.consts.grid.defaultPageSizes,
                paginationPageSize: app.consts.grid.defaultPageSize,
                useExternalPagination: true,
                useExternalSorting: true,
                appScopeProvider: vm,
                columnDefs: [       //TODO: 4.1  设置列参数 done
                    {
                        name: '仪器名称',
                        field: 'instrumentName',
                        minWidth: 50
                    },
                    {
                        name: '仪器类型',
                        field: 'checkType',
                        minWidth: 30
                    },
                    {
                        name: '修改',
                        enableSorting: false,
                        minWidth: 80,
                        //headerCellTemplate: '<span></span>',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents text-center\">' +
                            '  <button class="btn btn-default btn-xs" ng-click="grid.appScope.editStandard(row.entity)"><i class="fa fa-search"></i></button>' +
                            '  <button class="btn btn-default green btn-xs" ng-if="!vm.permissions.edit" ng-click="grid.appScope.editStandard(row.entity)"><i class="icon-settings"></i></button>' +
                            '  <button class="btn btn-default  red btn-xs " ng-click="grid.appScope.deleteStandard(row.entity)"><i class="fa fa-trash"></i></button>' +
                            '</div>'
                    }
                ],

                onRegisterApi: function (gridApi) {     //TODO:  4.2 注册表格API  #通用，无特需不改动
                    $scope.gridApi = gridApi;
                    $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                        if (!sortColumns.length || !sortColumns[0].field) {
                            vm.requestParams.sorting = null;
                        } else {
                            vm.requestParams.sorting = sortColumns[0].field + ' ' + sortColumns[0].sort.direction;
                        }

                        vm.getInstrumentTests();      //TODO:    4.3.1    use 4.4.1
                    });

                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {//TODO:  #通用，无特需不改动
                        vm.requestParams.skipCount = (pageNumber - 1) * pageSize;
                        vm.requestParams.maxResultCount = pageSize;

                        vm.getInstrumentTests();      //TODO:    4.3.2    use 4.4.2
                    });
                },
                data: []
            };

            vm.getInstrumentTests = function () {     //TODO:     4.4.1 WebAPI查询方法
                vm.loading = true;
                receiveService.getInstrumentTestsForHandOver(vm.requestParams) //TODO: ???
                    .then(function (result) {
                        vm.gridOptions.totalItems = result.data.totalCount;
                        vm.gridOptions.data = result.data.items;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            vm.exportToExcel = function () {      //TODO:     Excel 导出功能
                standardService.getStandardsToExcel(vm.requestParams)
                    .then(function (result) {
                        app.downloadTempFile(result.data.items);
                    });
            };

            //vm.editStandard = function (standard) {
            //    openCreateOrEditModal(standard.id);
            //};

            //vm.createStandard = function () {
            //    openCreateOrEditModal(null);
            //};

            //function openCreateOrEditModal(id) {
            //    var modalInstance = $uibModal.open({
            //        templateUrl: '~/App/common/views/BD/standard/createOrEditModal.cshtml',
            //        controller: 'common.views.standard.createOrEditModal as vm',
            //        backdrop: 'static',
            //        resolve: {
            //            standardId: function () {
            //                return id;
            //            }
            //        }
            //    });

            //    modalInstance.result.then(function (result) {
            //        vm.getStandards();
            //    });
            //}


            //vm.deleteStandard = function (standard) {
            //    abp.message.confirm(
            //        app.localize('UserDeleteWarningMessage', standard.strName),
            //        function (isConfirmed) {
            //            if (isConfirmed) {
            //                standardService.deleteStandard({
            //                    id: standard.id
            //                }).then(function () {
            //                    vm.getStandards();
            //                    abp.notify.success(app.localize('SuccessfullyDeleted'));
            //                });
            //            }
            //        }
            //    );
            //};

            vm.getInstrumentTests();
        }
    ]);
})();