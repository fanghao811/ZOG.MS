(function () {
    appModule.controller('common.views.BD.standard.index', [        //TODO：  在app.js 中添加路由 done
        '$scope', '$uibModal', 'uiGridConstants', 'abp.services.app.standard',
        function ($scope, $uibModal, uiGridConstants, standardService) {        //TODO 1.0 更改服务名 done
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;
            vm.advancedFiltersAreShown = false;

            vm.permissions = {
                create: abp.auth.hasPermission('Pages.BD.Standard.Create'),
                edit: abp.auth.hasPermission('Pages.BD.Standard.Edit'),
                'delete': abp.auth.hasPermission('Pages.BD.Standard.Delete')
            };

            vm.requestParams = {        //TODO: 2.0  配置查询对象 GetStandardsInput done
                validateDate: '2000-12-02',
                strType: true,
                installation_ID: 0,
                factoryNum: '',
                strName: '',
                strSpec: '',
                skipCount: 0,
                maxResultCount: app.consts.grid.defaultPageSize,
                sorting: null
            };

            vm.dateRangeOptions = app.createDateRangePickerOptions();       //TODO: 3.0  设置日期范围对象 done
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
                        name: 'Actions',
                        enableSorting: false,
                        width: 50,
                        headerCellTemplate: '<span></span>',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents text-center\">' +
                                '  <button class="btn btn-default btn-xs" ng-click="grid.appScope.editStandard(row.entity)"><i class="fa fa-search"></i></button>' +
                                '</div>'
                    },
                    {
                        name: '出厂编号',
                        field: 'factoryNum',
                        minWidth: 30
                    },
                    {
                        name: '标准器名称',
                        field: 'strName',
                        minWidth: 30
                    },
                    {
                        name: '标准器型号',
                        field: 'strSpec',
                        minWidth: 50
                    },
                    {
                        name: '制造商',
                        field: 'manufactor',
                        enableCellEdit: true,
                        minWidth: 200
                    },
                    //{
                    //    name: '厂家电话',
                    //    field: 'manufactorTel'
                    //},
                    {
                        name: '检定单位',
                        field: 'caliFactory',
                        minWidth: 60
                    },
                    //{
                    //    name: '检定单位联系人',
                    //    field: 'caliFactoryMan'
                    //},
                    //{
                    //    name: '检定单位电话',
                    //    field: 'caliFactoryTel',
                    //    minWidth: 30
                    //},
                    {
                        name: '所属计量装置',
                        field: 'installation',
                        minWidth: 30
                    },
                    //{
                    //    name: '责任人',
                    //    field: 'responsibleMan',
                    //    minWidth: 30
                    //},
                    {
                        name: '有效日期',
                        field: 'validateDate',
                        cellFilter: 'momentFormat: \'YYYY-MM-DD\'',
                        minWidth: 50
                    },
                    {
                        name: '测量范围',
                        field: 'testRange',
                        minWidth: 50
                    },
                    //{
                    //    name: '准确度',
                    //    field: 'accurate',
                    //    minWidth: 30
                    //},
                    //{
                    //    name: '校准系数',
                    //    field: 'strK'
                    //},
                    {
                        name: '标准器类型',
                        field: 'strType',
                        cellTemplate: '<div class="ngCellText">{{row.getProperty(col.field)?"标准器":"辅助器"}}</div>'
                    },
                    {
                        name: '管理',
                        enableSorting: false,
                        minWidth: 80,
                        //headerCellTemplate: '<span></span>',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents text-center\">' +
                            '  <button class="btn btn-default green btn-xs" ng-click="grid.appScope.editStandard(row.entity)"><i class="fa fa-check"></i></button>' +
                            '  <button class="btn btn-default  red btn-xs" ng-click="grid.appScope.deleteStandard(row.entity)"><i class="fa fa-trash"></i></button>' +
                            '</div>'
                            //'< div class=\"ui-grid-cell-contents btn-group btn-group text-center\">' +
                            //'    <button class="btn btn-outline green btn-sm"ng-click="grid.appScope.editStandard(row.entity)">编辑</button>' +
                            //'    <button class="btn btn-outline red btn-sm" ng-click="grid.appScope.deleteStandard(row.entity)">删除</button>' +
                            //'</div>'
                    }
                    //{
                    //    name: '标准器类型', field: 'strType', editableCellTemplate: 'ui-grid/dropdownEditor', 
                    //    cellFilter: 'mapGender', editDropdownValueLabel: 'strType', editDropdownOptionsArray: [
                    //        { id: 1, strType: true },
                    //        { id: 2, strType: false }
                    //    ]
                    //}
  
                ],
                onRegisterApi: function (gridApi) {     //TODO:  4.2 注册表格API
                    $scope.gridApi = gridApi;
                    $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                        if (!sortColumns.length || !sortColumns[0].field) {
                            vm.requestParams.sorting = null;
                        } else {
                            vm.requestParams.sorting = sortColumns[0].field + ' ' + sortColumns[0].sort.direction;
                        }

                        vm.getStandards();      //TODO:    4.3.1    use 4.4.1
                    });
                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {
                        vm.requestParams.skipCount = (pageNumber - 1) * pageSize;
                        vm.requestParams.maxResultCount = pageSize;

                        vm.getStandards();      //TODO:    4.3.2    use 4.4.2
                    });
                },
                data: []
            };

            vm.getStandards = function () {     //TODO:     4.4.1 WebAPI查询方法
                vm.loading = true;
                standardService.getStandards(vm.requestParams) //TODO: ???
                    .then(function (result) {
                        vm.gridOptions.totalItems = result.data.totalCount;
                        vm.gridOptions.data = result.data.items;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            //vm.exportToExcel = function () {      //TODO:     Excel 导出功能
            //    auditLogService.getAuditLogsToExcel($.extend({}, vm.requestParams, vm.dateRangeModel))
            //        .then(function (result) {
            //            app.downloadTempFile(result.data);
            //        });
            //};

            vm.editStandard = function (standard) {
                openCreateOrEditModal(standard.id);
            };

            vm.createStandard = function () {
                openCreateOrEditModal(null);
            };

            function openCreateOrEditModal(id) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/common/views/BD/standard/createOrEditModal.cshtml',
                    controller: 'common.views.standard.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        standardId: function () {
                            return id;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    vm.getStandards();
                });
            }


            vm.deleteStandard = function (standard) {
                abp.message.confirm(
                    app.localize('UserDeleteWarningMessage', standard.strName),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            standardService.deleteStandard({
                                id: standard.id
                            }).then(function () {
                                vm.getStandards();
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                        }
                    }
                );
            };

            vm.getStandards();
        }
    ]);
})();