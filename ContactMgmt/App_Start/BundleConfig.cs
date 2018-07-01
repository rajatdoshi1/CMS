using System.Web.Optimization;

namespace ContactMgmt.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery_minified")
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular_minified")
                .Include("~/Scripts/angular.min.js")
                .Include("~/Scripts/angular-ui-router.min.js")
                .Include("~/Scripts/angular-ui/ui-bootstrap-tpls.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app_minified")
                .IncludeDirectory("~/Scripts/app", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/Styles/css_minified")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/Site.css")
                .Include("~/Content/App.css"));
        }
    }
}