using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlloyTraining
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "RegisterAlloyTraining",                                              // Route name
                "hejsan/{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "RegisterAlloyTraining", action = "Index", id = "" }  // Parameter defaults
                /*, new[] { "AlloyTraining.Controllers" }*/
            );
        }
    }
}