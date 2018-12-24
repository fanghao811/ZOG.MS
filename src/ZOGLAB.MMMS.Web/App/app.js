/* 'app' MODULE DEFINITION */
var appModule = angular.module("app", [
    "ui.router",
    "ui.bootstrap",
    'ui.utils',
    "ui.jq",
    'ui.grid',
    'ui.grid.pagination',
    "oc.lazyLoad",
    "ngSanitize",
    "ngSelect",
    'ncy-angular-breadcrumb',
    'angularFileUpload',
    'daterangepicker',
    'angularMoment',
    'frapontillo.bootstrap-switch',
    'abp'
]);

/* LAZY LOAD CONFIG */

/* This application does not define any lazy-load yet but you can use $ocLazyLoad to define and lazy-load js/css files.
 * This code configures $ocLazyLoad plug-in for this application.
 * See it's documents for more information: https://github.com/ocombe/ocLazyLoad
 */
appModule.config(['$ocLazyLoadProvider', function ($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({
        cssFilesInsertBefore: 'ng_load_plugins_before', // load the css files before a LINK element with this ID.
        debug: false,
        events: true,
        modules: []
    });
}]);
appModule.config(['$breadcrumbProvider', function ($breadcrumbProvider) {
    $breadcrumbProvider.setOptions({
        prefixStateName: 'tenant',
        template: 'bootstrap3',
        includeAbstract: true
    });
}]);

/* THEME SETTINGS */
App.setAssetsPath(abp.appPath + 'metronic/assets/');
appModule.factory('settings', ['$rootScope', function ($rootScope) {
    var settings = {
        layout: {
            pageSidebarClosed: false, // sidebar menu state
            pageContentWhite: false, // set page content layout
            pageBodySolid: false, // solid body color state
            pageAutoScrollOnLoad: 1000 // auto scroll to top on page load
        },
        layoutImgPath: App.getAssetsPath() + 'admin/layout/img/',
        layoutCssPath: App.getAssetsPath() + 'admin/layout/css/',
        assetsPath: abp.appPath + 'metronic/assets',
        globalPath: abp.appPath + 'metronic/assets/global',
        layoutPath: abp.appPath + 'metronic/assets/layouts/layout'
    };

    $rootScope.settings = settings;

    return settings;
}]);

/* ROUTE DEFINITIONS */

appModule.config(['$stateProvider', '$urlRouterProvider', '$qProvider', 
    function ($stateProvider, $urlRouterProvider, $qProvider) {
        // Default route (overrided below if user has permission)
        $urlRouterProvider.otherwise("/welcome");

        //Welcome page
        $stateProvider.state('welcome', {
            url: '/welcome',
            templateUrl: '~/App/common/views/welcome/index.cshtml',
            ncyBreadcrumb: {
                label: '首页'
            }
        });

        //COMMON routes

        if (abp.auth.hasPermission('Pages.Administration.Roles')) {
            $stateProvider.state('roles', {
                url: '/roles',
                templateUrl: '~/App/common/views/roles/index.cshtml',
                ncyBreadcrumb: {
                    label: '角色'
                }
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Users')) {
            $stateProvider.state('users', {
                url: '/users?filterText',
                templateUrl: '~/App/common/views/users/index.cshtml',
                ncyBreadcrumb: {
                    label: '用户'
                }
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Languages')) {
            $stateProvider.state('languages', {
                url: '/languages',
                templateUrl: '~/App/common/views/languages/index.cshtml',
                ncyBreadcrumb: {
                    label: '语言管理'
                }
            });

            if (abp.auth.hasPermission('Pages.Administration.Languages.ChangeTexts')) {
                $stateProvider.state('languageTexts', {
                    url: '/languages/texts/:languageName?sourceName&baseLanguageName&targetValueFilter&filterText',
                    templateUrl: '~/App/common/views/languages/texts.cshtml',
                    ncyBreadcrumb: {
                        label: '语言文本'
                    }
                });
            }
        }

        if (abp.auth.hasPermission('Pages.Administration.AuditLogs')) {
            $stateProvider.state('auditLogs', {
                url: '/auditLogs',
                templateUrl: '~/App/common/views/auditLogs/index.cshtml',
                ncyBreadcrumb: {
                    label: '日志管理'
                }
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.OrganizationUnits')) {
            $stateProvider.state('organizationUnits', {
                url: '/organizationUnits',
                templateUrl: '~/App/common/views/organizationUnits/index.cshtml',
                ncyBreadcrumb: {
                    label: '组织管理'
                }
            });
        }

        $stateProvider.state('notifications', {
            url: '/notifications',
            templateUrl: '~/App/common/views/notifications/index.cshtml',
            ncyBreadcrumb: {
                label: '消息通知'
            }
        });

        //HOST routes

        $stateProvider.state('host', {
            'abstract': true,
            url: '/host',
            template: '<div ui-view class="fade-in-up"></div>',
            ncyBreadcrumb: {
                label: '租主'
            }
        });

        if (abp.auth.hasPermission('Pages.Tenants')) {
            $urlRouterProvider.otherwise("/host/tenants"); //Entrance page for the host
            $stateProvider.state('host.tenants', {
                url: '/tenants?filterText',
                templateUrl: '~/App/host/views/tenants/index.cshtml',
                ncyBreadcrumb: {
                    label: '租户管理'
                }
            });
        }

        if (abp.auth.hasPermission('Pages.Editions')) {
            $stateProvider.state('host.editions', {
                url: '/editions',
                templateUrl: '~/App/host/views/editions/index.cshtml',
                ncyBreadcrumb: {
                    label: '版本管理'
                }
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Host.Maintenance')) {
            $stateProvider.state('host.maintenance', {
                url: '/maintenance',
                templateUrl: '~/App/host/views/maintenance/index.cshtml',
                ncyBreadcrumb: {
                    label: '维护'
                }
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Host.Settings')) {
            $stateProvider.state('host.settings', {
                url: '/settings',
                templateUrl: '~/App/host/views/settings/index.cshtml',
                ncyBreadcrumb: {
                    label: '全局设置'
                }
            });
        }

        //TENANT routes

        $stateProvider.state('tenant', {
            'abstract': true,
            url: '/tenant',
            template: '<div ui-view class="fade-in-up"></div>',
            ncyBreadcrumb: {
                label: '首页'
            }
        });

        if (abp.auth.hasPermission('Pages.Tenant.Dashboard')) {
            $urlRouterProvider.otherwise("/tenant/dashboard"); //Entrance page for a tenant
            $stateProvider.state('tenant.dashboard', {
                url: '/dashboard',
                templateUrl: '~/App/tenant/views/dashboard/index.cshtml',
                ncyBreadcrumb: {
                    label: '我的工作'
                }
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Tenant.Settings')) {
            $stateProvider.state('tenant.settings', {
                url: '/settings',
                templateUrl: '~/App/tenant/views/settings/index.cshtml'
            });
        }

        //BD routes
        //reciveOrder
        $stateProvider.state('reOrder', {
            'abstract': true,
            url: '/reOrder',
            template: '<div ui-view class="fade-in-up"></div>',
            ncyBreadcrumb: {
                label: '仪器收发'
            }
        });

        $stateProvider.state('reOrder.regist', {
            url: '/regist',
            templateUrl: '~/App/common/views/BD/reciveOrder/index.cshtml',
            ncyBreadcrumb: {
                label: '送检登记'
            }
        });


        //query statistics
        $stateProvider.state('qs', {
            'abstract': true,
            url: '/qs',
            template: '<div ui-view class="fade-in-up"></div>',
            ncyBreadcrumb: {
                label: '查询统计'
            }
        });

        $stateProvider.state('qs.standard', {
            url: '/standard',
            templateUrl: '~/App/common/views/BD/standard/index.cshtml',
            ncyBreadcrumb: {
                label: '标准器查询'
            }
        });

        $stateProvider.state('qs.workload', {
            url: '/workload',
            templateUrl: '~/App/common/views/BD/workload/index.cshtml',
            ncyBreadcrumb: {
                label: '业务量统计'
            }
        });

        //SD routes
        $stateProvider.state('menuTree', {
            url: '/menuTree',
            templateUrl: '~/App/common/views/menuTree/index.cshtml'
        });

        //$qProvider settings
        $qProvider.errorOnUnhandledRejections(false);
    }
]);

appModule.run(["$rootScope", "settings", "$state", 'i18nService', '$uibModalStack', function ($rootScope, settings, $state, i18nService, $uibModalStack) {
    $rootScope.$state = $state;
    $rootScope.$settings = settings;

    $rootScope.$on('$stateChangeSuccess', function () {
        $uibModalStack.dismissAll();
    });

    //Set Ui-Grid language
    if (i18nService.get(abp.localization.currentCulture.name)) {
        i18nService.setCurrentLang(abp.localization.currentCulture.name);
    } else {
        i18nService.setCurrentLang("zh-CN");
    }

    $rootScope.safeApply = function (fn) {
        var phase = this.$root.$$phase;
        if (phase == '$apply' || phase == '$digest') {
            if (fn && (typeof (fn) === 'function')) {
                fn();
            }
        } else {
            this.$apply(fn);
        }
    };
}]);