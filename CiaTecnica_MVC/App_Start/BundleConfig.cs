using System.Web;
using System.Web.Optimization;

namespace CiaTecnica_MVC
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            

            // plugins | icheck
            bundles.Add(new ScriptBundle("~/admin-lte/plugins/icheck/js").Include(
                "~/admin-lte/plugins/icheck/js/icheck.min.js"));

            bundles.Add(new StyleBundle("~/admin-lte/plugins/icheck/css").Include(
                "~/admin-lte/plugins/icheck/css/all.css"));

            bundles.Add(new StyleBundle("~/admin-lte/plugins/icheck/css/flat").Include(
                "~/admin-lte/plugins/icheck/css/flat/flat.css"));
            
            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                "~/admin-lte/js/adminlte.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/admin-lte/css/AdminLTE.css",
                    "~/admin-lte/css/skins/skin-blue.css",
                    "~/Content/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/help").Include(
               "~/Scripts/loadingoverlay.js",
               "~/Scripts/loadingoverlay.min.js"));

            bundles.Add(new ScriptBundle(
                "~/admin-lte/plugins/daterangepicker/js").Include(
                    "~/admin-lte/plugins/daterangepicker/js/moment.min.js",
                    "~/admin-lte/plugins/daterangepicker/js/daterangepicker.js"));

            
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js",
            "~/Scripts/jquery-ui-i18n.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            "~/Scripts/inputmask/inputmask.js",
            "~/Scripts/inputmask/jquery.inputmask.js",
            "~/Scripts/inputmask/inputmask.extensions.js",
            "~/Scripts/inputmask/inputmask.date.extensions.js",
            "~/Scripts/inputmask/inputmask.numeric.extensions.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            "~/Content/themes/base/all.css"));


            bundles.Add(new StyleBundle("~/admin-lte/plugins/icheck/css/sqare/blue").Include(
                "~/admin-lte/plugins/icheck/css/sqare/blue.css"));


            bundles.Add(new StyleBundle("~/admin-lte/plugins/ionicons/css").Include(
                 "~/admin-lte/plugins/ionicons/css/ionicons.min.css"));

            bundles.Add(new StyleBundle("~/admin-lte/plugins/daterangepicker/css").Include(
                                        "~/admin-lte/plugins/daterangepicker/css/daterangepicker.css"));
        }
    }
}
