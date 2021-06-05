using System.Web.Optimization;

namespace Forum.App_Start
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Content/main.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/*.css"));
        }
    }
}