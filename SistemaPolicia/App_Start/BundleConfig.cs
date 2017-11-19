using System.Web;
using System.Web.Optimization;

namespace SistemaPolicia
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js", "~/Scripts/Funcoes.js"));

            bundles.Add(new ScriptBundle("~/bundles/PM").Include(
                     "~/Scripts/pnotify.js", "~/Scripts/pnotify.buttons.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css", "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/PM").Include(
                    "~/Content/pnotify.css",
                    "~/Content/pnotify.buttons.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
