using System.Web.Optimization;

namespace Ravioli.Web.UI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/js").Include("~/Assets/Js/jQueryMin.js", "~/Assets/Js/Validate.js", "~/Assets/Js/BootstrapMin.js","~/Assets/Js/Main.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Assets/Css/BootstrapMin.css", "~/Assets/Css/Site.css"));
            //BundleTable.EnableOptimizations = true;
        }
    }
}