﻿using System.Web.Optimization;
using ZOGLAB.MMMS.Web.Bundling;

namespace ZOGLAB.MMMS.Web.App.Startup
{
    public static class AppBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //LIBRARIES

            AddAppCssLibs(bundles, isRTL: false);
            AddAppCssLibs(bundles, isRTL: true);

            bundles.Add(
                new ScriptBundle("~/Bundles/App/libs/js")
                    .Include(
                        ScriptPaths.Json2,
                        ScriptPaths.JQuery,
                        ScriptPaths.JQuery_Migrate,
                        ScriptPaths.Bootstrap,
                        ScriptPaths.Bootstrap_Hover_Dropdown,
                        ScriptPaths.Bootstrap_DatePicker,
                        ScriptPaths.JQuery_Slimscroll,
                        ScriptPaths.JQuery_BlockUi,
                        ScriptPaths.Js_Cookie,
                        ScriptPaths.JQuery_Uniform,
                        ScriptPaths.SignalR,
                        ScriptPaths.LocalForage,
                        ScriptPaths.Morris,
                        ScriptPaths.Morris_Raphael,
                        ScriptPaths.JQuery_Sparkline,
                        ScriptPaths.JQuery_Color,
                        ScriptPaths.JQuery_Jcrop,
                        ScriptPaths.JQuery_Timeago,
                        ScriptPaths.JsTree,
                        ScriptPaths.JQuery_MultiSelect,
                        ScriptPaths.Bootstrap_Switch,
                        ScriptPaths.SpinJs,
                        ScriptPaths.SpinJs_JQuery,
                        ScriptPaths.SweetAlert,
                        ScriptPaths.PushJs,
                        ScriptPaths.Toastr,
                        ScriptPaths.MomentJs,
                        ScriptPaths.MomentTimezoneJs,
                        ScriptPaths.Bootstrap_DateRangePicker,
                        ScriptPaths.Bootstrap_Select,
                        ScriptPaths.Bootstrap_DatePicker,   //20190108
                        ScriptPaths.Underscore,
                        ScriptPaths.Angular,
                        ScriptPaths.Angular_Sanitize,
                        ScriptPaths.Angular_Touch,
                        ScriptPaths.Angular_Ui_Router,
                        ScriptPaths.Angular_Ui_Utils,
                        ScriptPaths.Angular_Ui_Bootstrap_Tpls,
                        ScriptPaths.Angular_Ui_Grid,
                        ScriptPaths.Angular_Ui_Select,
                        ScriptPaths.Angular_OcLazyLoad,
                        ScriptPaths.Angular_BreadCrumb,
                        ScriptPaths.Angular_File_Upload,
                        ScriptPaths.Angular_DateRangePicker,
                        ScriptPaths.Angular_Moment,
                        ScriptPaths.Angular_Bootstrap_Switch,
                        ScriptPaths.Abp,
                        ScriptPaths.Abp_JQuery,
                        ScriptPaths.Abp_Toastr,
                        ScriptPaths.Abp_BlockUi,
                        ScriptPaths.Abp_SpinJs,
                        ScriptPaths.Abp_SweetAlert,
                        ScriptPaths.Abp_Moment,
                        ScriptPaths.Abp_Angular
                    ).ForceOrdered()
                );

            //METRONIC      2018/12/20 切换 Metronic 4.X

            AddAppMetronicCss(bundles, isRTL: false);
            AddAppMetronicCss(bundles, isRTL: true);
            bundles.Add(
                new ScriptBundle("~/Bundles/App/metronic/js")
                    .Include(
                        "~/metronic/assets/global/scripts/app.js",
                        "~/metronic/assets/admin/layout/scripts/layout.js",      
                        "~/metronic/assets/layouts/global/scripts/quick-sidebar.js"
                    ).ForceOrdered()
                );

            //APPLICATION

            bundles.Add(
                new StyleBundle("~/Bundles/App/css")
                    .IncludeDirectory("~/App", "*.css", true)
                    .ForceOrdered()
                );

            bundles.Add(
                new ScriptBundle("~/Bundles/App/js")
                    .IncludeDirectory("~/App", "*.js", true)
                    .ForceOrdered()
                );
        }

        private static void AddAppCssLibs(BundleCollection bundles, bool isRTL)
        {
            bundles.Add(        //12/20 切换 Metronic 4.X
                new StyleBundle("~/Bundles/App/libs/css" + (isRTL ? "RTL" : ""))
                    .Include(StylePaths.FontAwesome, new CssRewriteUrlWithVirtualDirectoryTransform())      //1
                    .Include(StylePaths.Simple_Line_Icons, new CssRewriteUrlWithVirtualDirectoryTransform())        //2
                    .Include(StylePaths.FamFamFamFlags, new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include(isRTL ? StylePaths.BootstrapRTL : StylePaths.Bootstrap, new CssRewriteUrlWithVirtualDirectoryTransform())      //3
                    .Include(StylePaths.JQuery_Uniform, new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include(StylePaths.Morris)
                    .Include(StylePaths.JsTree, new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include(StylePaths.MultiSelect)
                    .Include(StylePaths.SweetAlert)
                    .Include(StylePaths.Toastr)
                    .Include(StylePaths.Angular_Ui_Grid, new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include(StylePaths.Angular_Ui_Select)
                    .Include(StylePaths.Bootstrap_DateRangePicker)
                    .Include(StylePaths.Bootstrap_Select)
                    .Include(StylePaths.Bootstrap_Switch)       //4
                    .Include(StylePaths.Bootstrap_DatePicker)   //20190108
                    .Include(StylePaths.JQuery_Jcrop)
                    .ForceOrdered()
                );
        }

        private static void AddAppMetronicCss(BundleCollection bundles, bool isRTL)
        {
            isRTL = false;

            bundles.Add(        //12/20 切换 Metronic 4.X
                new StyleBundle("~/Bundles/App/metronic/css" + (isRTL ? "RTL" : ""))        
                    .Include("~/metronic/assets/global/css/components.min" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include("~/metronic/assets/global/css/invoice-2.min.css")
                    .Include("~/metronic/assets/global/css/plugins.min" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include("~/metronic/assets/admin/layout/css/layout.min" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include("~/metronic/assets/admin/layout/css/themes/darkblue.min" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
                    .Include("~/metronic/assets/admin/layout/css/custom.min" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
                    .ForceOrdered()
                );

            //bundles.Add(
            //    new StyleBundle("~/Bundles/App/metronic/css" + (isRTL ? "RTL" : ""))
            //        .Include("~/metronic/assets/global/css/components-md" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
            //        .Include("~/metronic/assets/global/css/plugins-md" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
            //        .Include("~/metronic/assets/admin/layout4/css/layout" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
            //        .Include("~/metronic/assets/admin/layout4/css/themes/light" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlWithVirtualDirectoryTransform())
            //        .ForceOrdered()
            //    );
        }
    }
}
