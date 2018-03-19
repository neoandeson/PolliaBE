using System.Web;
using System.Web.Optimization;

namespace Pollia
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Admin/css").Include(
                      "~/Content/adminAsset/css/google-font.css",
                      "~/Content/adminAsset/icon/icofont/css/icofont.css",
                      "~/Content/adminAsset/icon/simple-line-icons/css/simple-line-icons.css",
                      "~/Content/adminAsset/css/bootstrap.min.css",
                      "~/Content/adminAsset/plugins/charts/chartlist/css/chartlist.css",
                      "~/Content/adminAsset/css/svg-weather.css",
                      "~/Content/adminAsset/css/main.css",
                      "~/Content/adminAsset/css/responsive.css",
                      "~/Content/adminAsset/css/color/inverse.css"
                      ));
            bundles.Add(new ScriptBundle("~/Admin/js").Include(
                      "~/Content/adminAsset/js/jquery-3.1.1.min.js",
                      "~/Content/adminAsset/js/jquery-ui.min.js",
                      "~/Content/adminAsset/js/tether.min.js",
                      "~/Content/adminAsset/js/bootstrap.min.js",
                      "~/Content/adminAsset/plugins/waves/js/waves.min.js",
                      "~/Content/adminAsset/plugins/slimscroll/js/jquery.slimscroll.js",
                      "~/Content/adminAsset/plugins/slimscroll/js/jquery.nicescroll.min.js",
                      "~/Content/adminAsset/plugins/search/js/classie.js",
                      "~/Content/adminAsset/plugins/notification/js/bootstrap-growl.min.js",
                      "~/Content/adminAsset/plugins/charts/sparkline/js/jquery.sparkline.js",
                      "~/Content/adminAsset/plugins/countdown/js/jquery.countdown.js",
                      "~/Content/adminAsset/plugins/countdown/js/jquery.counterup.js",
                      "~/Content/adminAsset/plugins/countdown/js/waypoints.min.js",
                      "~/Content/adminAsset/plugins/charts/echarts/js/echarts-all.js",
                      "~/Content/adminAsset/plugins/data-table/js/jquery.dataTables.min.js",
                      "~/Content/adminAsset/plugins/data-table/js/dataTables.bootstrap4.min.js",
                      "~/Content/adminAsset/plugins/data-table/js/dataTables.responsive.min.js",
                      "~/Content/adminAsset/plugins/data-table/js/responsive.bootstrap4.min.js",
                      "~/Content/adminAsset/js/main.js",
                      "~/Content/adminAsset/pages/elements.js",
                      "~/Content/adminAsset/js/menu.js"
                      //"~/Content/adminAsset/pages/dashboard.js",
                      ));
        }
    }
}
