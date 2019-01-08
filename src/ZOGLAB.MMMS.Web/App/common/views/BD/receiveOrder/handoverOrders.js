(function () {
    appModule.controller('common.views.BD.handoverOrder.index', [        //TODO：  在app.js 中添加路由 done
        '$scope', '$uibModal', 'uiGridConstants', 'abp.services.app.receive',
        function ($scope, $uibModal, uiGridConstants, receiveService) {        //TODO 1.0 更改服务名 done
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.items = {};
            vm.loading = false;
            vm.advancedFiltersAreShown = false;

            vm.requestParams = {        //TODO: 2.0  配置查询对象 GetStandardsInput done
                "check_Num": "",
                "meteorType_ID": null,
                "startDate": "1900-01-07",
                "finishDate": "2900-02-07",
                "vocationalWorkType": 1,
                "skipCount": 0,
                "maxResultCount": app.consts.grid.defaultPageSize,
                "sorting": null
            };

            vm.gridOptions = {      //TODO: 4.0  设置表格参数 
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                paginationPageSizes: app.consts.grid.defaultPageSizes,
                paginationPageSize: app.consts.grid.defaultPageSize,
                useExternalPagination: true,
                useExternalSorting: true,

                enableRowSelection: true,
                enableFullRowSelection: true,
                enableSelectAll: true,
                selectionRowHeaderWidth: 35,
                rowHeight: 35,

                appScopeProvider: vm,
                columnDefs: [       //TODO: 4.1  设置列参数 done
                    {
                        name: '检测单号',
                        field: 'check_Num',
                        minWidth: 50
                    },
                    {
                        name: '要素类型',
                        field: 'meteorType',
                        minWidth: 50
                    },
                    {
                        name: '业务类型',
                        field: 'vocationalWorkType',
                        minWidth: 50
                    },
                    {
                        name: '领样人',
                        field: 'user',
                        minWidth: 50
                    },
                    {
                        name: '开始时间',
                        field: 'startDate',
                        cellFilter: 'momentFormat: \'YYYY-MM-DD HH:mm:ss\'',
                        minWidth: 50
                    },
                    {
                        name: '结束时间',
                        field: 'finishDate',
                        cellFilter: 'momentFormat: \'YYYY-MM-DD\'',
                        minWidth: 50
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

                        vm.getTests();      //TODO:    4.3.1    use 4.4.1
                    });

                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {//TODO:  #通用，无特需不改动
                        vm.requestParams.skipCount = (pageNumber - 1) * pageSize;
                        vm.requestParams.maxResultCount = pageSize;

                        vm.getTests();      //TODO:    4.3.2    use 4.4.2
                    });
                },
                data: []
            };

            vm.getTests = function () {     //TODO:     4.4.1 WebAPI查询方法
                vm.loading = true;
                receiveService.getTests(vm.requestParams) //TODO: ???
                    .then(function (result) {
                        vm.gridOptions.totalItems = result.data.totalCount;
                        vm.gridOptions.data = result.data.items;
                        vm.items = result.data.items;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            vm.openCreateModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/common/views/BD/receiveOrder/handoverModal.cshtml',
                    controller: 'common.views.handover.createModal as vm',
                    backdrop: 'static',
                    size: 'lg'
                    //resolve: {
                    //    instruments: function () {
                    //        return $scope.gridApi.selection.getSelectedRows();
                    //    }
                    //}
                });

                modalInstance.result.then(function () {
                    vm.getTests();
                });
            };

            vm.createTest = function () {
                var selectedIds = _.pluck($scope.gridApi.selection.getSelectedRows(), 'id');
                if (selectedIds.length > 0) {
                    abp.notify.info(selectedIds);
                }
                else {
                    abp.notify.error("请选择仪器！");
                };
            };

            vm.getTests();
        }
    ]);
})();