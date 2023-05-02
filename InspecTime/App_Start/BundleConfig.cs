﻿using System.Web;
using System.Web.Optimization;

namespace InspecTime
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

            // Has to be a bundle because bootstrap 5 is not compatible
            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                        //"~/Scripts/umd/popper.js",
                      "~/Scripts/bootstrap.bundle.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      //"~/Content/bootstrap.css",
                      "~/Content/Site.css"));
        }
    }
}
