using System.Data;
using System.Web;
using System.Web.DynamicData;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Bundle creados

            bundles.Add(new StyleBundle("~/plugin/css").Include(
                     "~/Content/datatable/css/dataTables.jqueryui.min.css",
                     "~/Content/fontawesome/css/all.css",
                     "~/Content/datatable/css/buttons.dataTables.min.css"
                     ));

            bundles.Add(new StyleBundle("~/plugin/js").Include(
                    "~/Content/datatable/js/dataTables.jqueryui.min.js",
                    "~/Content/fontawesome/js/all.js",
                    "~/Content/datatable/js/dataTables.buttons.min.js"
                    ));
        

        }
    }
}
