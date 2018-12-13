using Abp.Application.Navigation;
using Abp.Localization;
using ZOGLAB.MMMS.Authorization;
using ZOGLAB.MMMS.Web.Navigation;

namespace ZOGLAB.MMMS.Web.App.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class AppNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Tenants,
                    L("Tenants"),
                    url: "host.tenants",
                    icon: "icon-globe",
                    requiredPermissionName: AppPermissions.Pages_Tenants
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Editions,
                    L("Editions"),
                    url: "host.editions",
                    icon: "icon-grid",
                    requiredPermissionName: AppPermissions.Pages_Editions
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("Dashboard"),
                    url: "tenant.dashboard",
                    icon: "icon-check",
                    requiredPermissionName: AppPermissions.Pages_Tenant_Dashboard
                    )
                ).AddItem(new MenuItemDefinition(       //2018/12/12  新增加11个主菜单
                    PageNames.App.Tenant.Dashboard,
                    L("实时监控"),
                     icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("区域监控"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("站点管理"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("仪器收发"),
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("送检登记"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("仪器交接"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("仪器返样"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("检定校准"),
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("仪器挑选"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("数据登记"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("数据变更"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("数据审核"),
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("审核"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("证书批准"),
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("批准"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("证书打印"),
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("证书打印"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("证书修改"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("原始记录"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("查询统计"),
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("证书统计"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("鉴定率统计"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("业务量统计"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("标准器查询"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("仪器状态查询"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("到检预警"),                   
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("站点预警"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("标准器预警"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("计量业务预警"),
                        icon: "icon-ban"
                        )
                    )//     TODO: 继续增加子菜单 12:05
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("质量管理"),
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("模板管理"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("流程管理"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("文档提醒"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("质控文件"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("计量机构"),                    
                    icon: "icon-ban"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("仪器管理"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("送检单位"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("标准器管理"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("计量装置管理"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("规程管理"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("计量机构基本信息"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("机构授权信息"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("人员调查信息"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("检定服务收入"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("年度经费收支"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("标准器信息"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("实验室专用设备"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("实验室能力"),
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("工作任务量信息"),
                        icon: "icon-ban"
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Common.Administration,
                    L("Administration"),
                    icon: "icon-wrench"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("OrganizationUnits"),
                        url: "organizationUnits",
                        icon: "icon-layers",
                        requiredPermissionName: AppPermissions.Pages_Administration_OrganizationUnits
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Roles,
                        L("Roles"),
                        url: "roles",
                        icon: "icon-briefcase",
                        requiredPermissionName: AppPermissions.Pages_Administration_Roles
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Users,
                        L("Users"),
                        url: "users",
                        icon: "icon-users",
                        requiredPermissionName: AppPermissions.Pages_Administration_Users
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Users,
                        L("USBKey"),
                        url: "",
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Users,
                        L("电子签名"),
                        url: "",
                        icon: "icon-ban"
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Languages,
                        L("Languages"),
                        url: "languages",
                        icon: "icon-flag",
                        requiredPermissionName: AppPermissions.Pages_Administration_Languages
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.AuditLogs,
                        L("AuditLogs"),
                        url: "auditLogs",
                        icon: "icon-lock",
                        requiredPermissionName: AppPermissions.Pages_Administration_AuditLogs
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Maintenance,
                        L("Maintenance"),
                        url: "host.maintenance",
                        icon: "icon-wrench",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Maintenance
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Settings,
                        L("Settings"),
                        url: "host.settings",
                        icon: "icon-settings",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Settings
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Tenant.Settings,
                        L("Settings"),
                        url: "tenant.settings",
                        icon: "icon-settings",
                        requiredPermissionName: AppPermissions.Pages_Administration_Tenant_Settings
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MMMSConsts.LocalizationSourceName);
        }
    }
}
