﻿(function () {
    appModule.controller('common.views.BD.handoverOrder.index', [        //TODO：  在app.js 中添加路由 done
        '$scope', '$uibModal', 'uiGridConstants',
        'abp.services.app.receive',
        'abp.services.app.meteorType',
        'enumService',
        function ($scope, $uibModal, uiGridConstants, receiveService, meteorService, enumService) {          //TODO 1.0 更改服务名 done
            var vm = this;
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.items = {};
            vm.meteors = [];
            vm.checkTypes = [];
            vm.loading = false;
            vm.advancedFiltersAreShown = false;

            vm.requestParams = {        //TODO: 2.0  配置查询对象 GetStandardsInput done
                "check_Num": "",
                "meteorType_ID": null,
                "vocationalWorkType": null,
                "skipCount": 0,
                "maxResultCount": app.consts.grid.defaultPageSize,
                "sorting": null
            };

            vm.dRangeOptions = app.createDateRangePickerOptions();
            vm.dRangeModel = {
                startDate: moment().subtract(30, 'days').startOf('day'),
                endDate: moment().add(2,'days').endOf('day')
            };

            vm.gridOptions = {      //TODO: 4.0  设置表格参数 
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                paginationPageSizes: app.consts.grid.defaultPageSizes,
                paginationPageSize: app.consts.grid.defaultPageSize,
                useExternalPagination: true,
                useExternalSorting: true,

                //enableRowSelection: false,
                //enableFullRowSelection: true,
                //enableSelectAll: true,
                //selectionRowHeaderWidth: 35,
                rowHeight: 30,

                appScopeProvider: vm,
                columnDefs: [       //TODO: 4.1  设置列参数 done                  
                    {
                        name: '序号 ',
                        enableSorting: false,
                        maxWidth: 50,
                        cellTemplate: '<div style="text-align:center">{{rowRenderIndex + 1}}</div>'
                    },
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
                        name: '编辑',
                        enableSorting: false,
                        minWidth: 80,
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents text-center\">' +
                            '  <button class="btn btn-default btn-xs" ng-click="grid.appScope.showDetails(row.entity)">查看详情</button>' +
                            '  <button class="btn btn-default green btn-xs" ng-click="grid.appScope.openCreateOrUpdateModal(row.entity.id)"><i class="icon-settings"></i> 修改</button>' +
                            '  <button class="btn btn-default  red btn-xs " ng-click="grid.appScope.deleteTest(row.entity)"><i class="fa fa-trash"></i> 删除</button>' +
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

            // =========================================================================
            // Tests CRUD ==> 7# BD_Test
            // =========================================================================
            vm.openCreateOrUpdateModal = function (entityId) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/common/views/BD/receiveOrder/handoverModal.cshtml',
                    controller: 'common.views.handover.createModal as vm',
                    backdrop: 'static',
                    resolve: {
                        testId: function () {
                            return entityId;
                        }
                    },
                    size: 'lg'
                });

                modalInstance.result.then(function () {
                    vm.getTests();
                });
            };

            vm.showDetails = function (test) {
                alert('rowEntity:' + test.id);
                //$uibModal.open({
                //    templateUrl: '~/App/common/views/auditLogs/detailModal.cshtml',
                //    controller: 'common.views.auditLogs.detailModal as vm',
                //    backdrop: 'static',
                //    resolve: {
                //        test: function () {
                //            return test;
                //        }
                //    }
                //});
            };



            // =========================================================================
            // 获取 MeteorTypes  ==> 7# BD_Test
            // =========================================================================
            vm.getMeteors = function () {
                meteorService.getAll()
                    .then(function (result) {
                        vm.meteors = result.data;
                    });
            };

            // =========================================================================
            // 获取 VocationalWork_Type 业务类型 ==> 7# BD_Test
            // =========================================================================
            vm.vMTypes = enumService.test_VMType;

            // =========================================================================
            // 获取 Tests  ==> 7# BD_Test
            // =========================================================================
            vm.getTests = function () {
                vm.loading = true;
                receiveService.getTests($.extend({}, vm.requestParams, vm.dRangeModel))
                    .then(function (result) {
                        vm.gridOptions.totalItems = result.data.totalCount;
                        vm.gridOptions.data = result.data.items;
                        vm.items = result.data.items;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };


            // =========================================================================
            // Page Initial Function
            // =========================================================================
            vm.initial = function () {
                vm.getMeteors();
                vm.getTests();
            };

            vm.initial();

        }
    ]);
})();