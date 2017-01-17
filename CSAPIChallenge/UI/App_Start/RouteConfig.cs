using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //        name: "PostedDate",
            //        url: "Posted/{day}-{month}-{year}",
            //        defaults: new { controller = "Post", action = "DateSearch" },
            //        constraints: new { day = @"\d{2}", month = @"\d{2}", year = @"\d{4}" }
            //    );

            //routes.MapRoute(
            //     name: "Tags",
            //     url: "Tagged/{tag}",
            //     defaults: new { controller = "Post", action = "TagSearch", tag = UrlParameter.Optional }
            //    );

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
