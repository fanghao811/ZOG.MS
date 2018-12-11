(function () {
    appModule.controller('common.views.menuTree.index', [
        '$scope', '$q', 'uiGridConstants', '$state', 'abp.services.app.menuTreeUnit',
        function ($scope, $q, uiGridConstants, $state, menuTreeUnitService, ) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });
            //1.辅助变量

            //2.2 jsTree 的构造
            vm.menuTree = {

                $tree: null,

                unitCount: 0,

                setUnitCount: function (unitCount) {
                    $scope.safeApply(function () {
                        vm.menuTree.unitCount = unitCount;
                    });
                },  //done 2.2.1

                refreshUnitCount: function () {
                    vm.menuTree.setUnitCount(vm.menuTree.$tree.jstree('get_json').length);
                },  //done

                selectedOu: {       
                    id: null,
                    displayName: null,
                    code: null,

                    set: function (ouInTree) {      //done 2.2.5.1
                        if (!ouInTree) {
                            vm.menuTree.selectedOu.id = null;
                            vm.menuTree.selectedOu.displayName = null;
                            vm.menuTree.selectedOu.code = null;
                        } else {
                            vm.menuTree.selectedOu.id = ouInTree.id;
                            vm.menuTree.selectedOu.displayName = ouInTree.original.displayName;
                            vm.menuTree.selectedOu.code = ouInTree.original.code;
                        }

                        vm.members.load();
                    }
                },      //done 2.2.6    被选节点    selectedOu

                contextMenu: function (node) {

                    var items = {
                        editUnit: {
                            label: app.localize('Edit'),
                            _disabled: !vm.permissions.manageOrganizationTree,
                            action: function (data) {
                                var instance = $.jstree.reference(data.reference);

                                vm.menuTree.openCreateOrEditUnitModal({
                                    id: node.id,
                                    displayName: node.original.displayName
                                }, function (updatedOu) {
                                    node.original.displayName = updatedOu.displayName;
                                    instance.rename_node(node, vm.menuTree.generateTextOnTree(updatedOu));
                                });
                            }
                        },

                        addSubUnit: {
                            label: app.localize('AddSubUnit'),
                            _disabled: !vm.permissions.manageOrganizationTree,
                            action: function () {
                                vm.menuTree.addUnit(node.id);
                            }
                        },

                        addMember: {
                            label: app.localize('AddMember'),
                            _disabled: !vm.permissions.manageMembers,
                            action: function () {
                                vm.members.openAddModal();
                            }
                        },

                        'delete': {
                            label: app.localize("Delete"),
                            _disabled: !vm.permissions.manageOrganizationTree,
                            action: function (data) {
                                var instance = $.jstree.reference(data.reference);

                                abp.message.confirm(
                                    app.localize('OrganizationUnitDeleteWarningMessage', node.original.displayName),
                                    function (isConfirmed) {
                                        if (isConfirmed) {
                                            menuTreeUnitService.deleteOrganizationUnit({
                                                id: node.id
                                            }).then(function () {
                                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                                                instance.delete_node(node);
                                                vm.menuTree.refreshUnitCount();
                                            });
                                        }
                                    }
                                );
                            }
                        }
                    }

                    return items;
                }, 

                addUnit: function (parentId) {
                    var instance = $.jstree.reference(vm.menuTree.$tree);
                    vm.menuTree.openCreateOrEditUnitModal({
                        parentId: parentId
                    }, function (newOu) {
                        instance.create_node(
                            parentId ? instance.get_node(parentId) : '#',
                            {
                                id: newOu.id,
                                parent: newOu.parentId ? newOu.parentId : '#',
                                code: newOu.code,
                                displayName: newOu.displayName,
                                text: vm.menuTree.generateTextOnTree(newOu),
                                state: {
                                    opened: true
                                }
                            });

                        vm.menuTree.refreshUnitCount();
                    });
                },

                openCreateOrEditUnitModal: function (organizationUnit, closeCallback) {
                    var modalInstance = $uibModal.open({
                        templateUrl: '~/App/common/views/menuTree/createOrEditUnitModal.cshtml',
                        controller: 'common.views.menuTree.createOrEditUnitModal as vm',
                        backdrop: 'static',
                        resolve: {
                            menuTreeUnit: function () {
                                return menuTreeUnit;
                            }
                        }
                    });

                    modalInstance.result.then(function (result) {
                        closeCallback && closeCallback(result);
                    });
                },

                generateTextOnTree: function (ou) {
                    //var itemClass = ou.memberCount > 0 ? ' ou-text-has-members' : ' ou-text-no-members';
                    var itemClass =  ' ou-text-no-members';
                    return '<span title="' + ou.code + '" class="ou-text' + itemClass + '" data-ou-id="' + ou.id + '">' + ou.displayName ;
                },//done 2.2.3    生成子节点TXT

                getTreeDataFromServer: function (callback) {
                    menuTreeUnitService.getMenuTreeUnits({}).then(function (result) { //Exp: ({})中间的{}不能省略
                        //Check: error, result.data --> result.data.items
                        //object 而非 array
                        //treeData 格式错 --> 修改后台返回类型 menuTreeUnitService.getMenuTreeUnits({})
                        var treeData = _.map(result.data.items, function (item) { //TODO: 2.2.2 -> 前后端数据匹配
                            return {
                                id: item.id,
                                parent: item.parentId ? item.parentId : '#',
                                code: item.code,
                                displayName: item.displayName,
                                //memberCount: item.memberCount,                               
                                text: vm.menuTree.generateTextOnTree(item),  //TODO: 2.2.3 -> TEXT生成
                                state: {
                                    opened: true
                                }
                            };
                        });                    
                        callback(treeData);
                    });
                },      //done 2.2.2    从服务端获取数据

                init: function () {
                    vm.menuTree.getTreeDataFromServer(function (treeData) {
                        vm.menuTree.setUnitCount(treeData.length);      //use 2.2.1

                        vm.menuTree.$tree = $('#MenuUnitEditTree');     //done 2.2.4.1 changName

                        var jsTreePlugins = [       //Exp: jsTree 功能模块
                            'types',
                            'contextmenu',
                            'wholerow',
                            'sort'
                        ];
                        //Exp: ！！！jsTree启动点 --> 加载 .jstree 中定义的模块 （如果注释掉或没有权限，则jstree 不渲染）
                        //if (vm.permissions.manageOrganizationTree) {
                        //    jsTreePlugins.push('dnd');
                        //}
                        jsTreePlugins.push('dnd');

                        vm.menuTree.$tree
                            .on('changed.jstree', function (e, data) {      //Exp: jsTree 事件模块 -- changed
                                $scope.safeApply(function () {      //Learning： $scope.safeApply ？
                                    if (data.selected.length != 1) {
                                        vm.menuTree.selectedOu.set(null);
                                    } else {
                                        var selectedNode = data.instance.get_node(data.selected[0]);
                                        vm.menuTree.selectedOu.set(selectedNode);       //use 2.2.5.1
                                    }
                                });

                            })
                            .on('move_node.jstree', function (e, data) {        //Exp: jsTree 事件模块 -- move_node

                                if (!vm.permissions.manageOrganizationTree) {
                                    vm.menuTree.$tree.jstree('refresh'); //rollback
                                    return;
                                }

                                var parentNodeName = (!data.parent || data.parent == '#')       //设置新的父节点名称--> 提供给弹窗使用
                                    ? app.localize('Root')
                                    : vm.menuTree.$tree.jstree('get_node', data.parent).original.displayName;

                                abp.message.confirm(
                                    app.localize('OrganizationUnitMoveConfirmMessage', data.node.original.displayName, parentNodeName),
                                    function (isConfirmed) {
                                        if (isConfirmed) {
                                            menuTreeUnitService.moveOrganizationUnit({      //TODO：2.2.4.1 --> update_menuTreeUnitService.moveMenuUnit 
                                                id: data.node.id,
                                                newParentId: data.parent
                                            }).then(function () {
                                                abp.notify.success(app.localize('SuccessfullyMoved'));
                                                vm.menuTree.reload();       //use: 2.2.5   
                                            }).catch(function (err) {       //Exp: catch --> err, setTimeout, abp.message.error
                                                vm.menuTree.$tree.jstree('refresh'); //rollback
                                                setTimeout(function () { abp.message.error(err.data.message); }, 500);
                                            });
                                        } else {
                                            vm.menuTree.$tree.jstree('refresh'); //rollback
                                        }
                                    }
                                );
                            })
                            .jstree({       //Exp: jsTree 核心模块
                                'core': {
                                    data: treeData,     ////Exp: jsTree 核心模块 -- 数据源
                                    multiple: false,
                                    check_callback: function (operation, node, node_parent, node_position, more) {
                                        return true;
                                    }
                                },
                                types: {        //Exp: jsTree 核心模块 -- 节点样式
                                    "default": {
                                        "icon": "fa fa-folder tree-item-icon-color icon-lg"
                                    },
                                    "file": {
                                        "icon": "fa fa-file tree-item-icon-color icon-lg"
                                    }
                                },
                                contextmenu: {      //Exp: jsTree 核心模块 -- 右键菜单
                                    items: vm.menuTree.contextMenu
                                },
                                sort: function (node1, node2) {     //Exp: jsTree 核心模块 -- 初始化排序， orderBy--> displayName
                                    if (this.get_node(node2).original.displayName < this.get_node(node1).original.displayName) {
                                        return 1;
                                    }

                                    return -1;
                                },
                                plugins: jsTreePlugins      //Exp: jsTree 核心模块 -- 加载的插件
                            });

                        vm.menuTree.$tree.on('click', '.ou-text .fa-caret-down', function (e) {     //弹出辅助菜单
                            e.preventDefault();

                            var ouId = $(this).closest('.ou-text').attr('data-ou-id');
                            setTimeout(function () {
                                vm.menuTree.$tree.jstree('show_contextmenu', ouId);
                            }, 100);
                        });
                    }); //use 2.2.2
                },      //done: 2.2.4   启动

                reload: function () {         
                    vm.menuTree.getTreeDataFromServer(function (treeData) {
                        vm.menuTree.setUnitCount(treeData.length);
                        vm.menuTree.$tree.jstree(true).settings.core.data = treeData;       //Exp: jsTree 核心模块 -- 数据源 -- 加载数据
                        vm.menuTree.$tree.jstree('refresh');
                    });
                }       //done: 2.2.5   reload-->   vm.menuTree.getTreeDataFromServer()   
            };

            //end --> init()
            vm.menuTree.init();
        }
    ]);
})();