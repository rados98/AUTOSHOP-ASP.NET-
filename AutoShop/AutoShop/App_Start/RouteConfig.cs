﻿namespace AutoShop
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Defines the <see cref="RouteConfig" />
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// The RegisterRoutes
        /// </summary>
        /// <param name="routes">The routes<see cref="RouteCollection"/></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
       name: "Login",
       url: "login",
       defaults: new { controller = "Registracija", action = "Index"}
   );
                   routes.MapRoute(
       name: "Registration",
       url: "registration",
       defaults: new { controller = "Registracija", action = "NewUser"}
   );

         

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pocetna", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
