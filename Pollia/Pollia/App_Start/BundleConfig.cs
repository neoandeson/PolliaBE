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
                      "~/Content/assets/plugins/jquery-ui/jquery-ui.min.css",
                      "~/Content/assets/plugins/bootstrap/4.0.0/css/bootstrap.min.css",
                      "~/Content/assets/plugins/font-awesome/5.0/css/fontawesome-all.min.css",
                      "~/Content/assets/plugins/animate/animate.min.css",
                      "~/Content/assets/css/default/style.min.css",
                      "~/Content/assets/css/default/style-responsive.min.css",
                      "~/Content/assets/css/font/google-font.css"
                      ));
            bundles.Add(new ScriptBundle("~/Admin/js").Include(
                      "~/Content/assets/plugins/jquery/jquery-3.2.1.min.js",
                      "~/Content/assets/plugins/jquery-ui/jquery-ui.min.js",
                      "~/Content/assets/plugins/bootstrap/4.0.0/js/bootstrap.bundle.min.js",
                      "~/Content/assets/plugins/slimscroll/jquery.slimscroll.min.js",
                      "~/Content/assets/plugins/js-cookie/js.cookie.js",
                      "~/Content/assets/js/theme/default.min.js",
                      "~/Content/assets/js/apps.min.js",
                      "~/Content/assets/plugins/gritter/js/jquery.gritter.js",
                      "~/Content/assets/plugins/flot/jquery.flot.min.js",
                      "~/Content/assets/plugins/flot/jquery.flot.time.min.js",
                      "~/Content/assets/plugins/flot/jquery.flot.resize.min.js",
                      "~/Content/assets/plugins/flot/jquery.flot.pie.min.js",
                      "~/Content/assets/plugins/sparkline/jquery.sparkline.js",
                      "~/Content/assets/plugins/jquery-jvectormap/jquery-jvectormap.min.js",
                      "~/Content/assets/plugins/jquery-jvectormap/jquery-jvectormap-world-mill-en.js",
                      "~/Content/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js",
                      "~/Content/assets/js/demo/dashboard.min.js"
                      ));
        }
    }
}
