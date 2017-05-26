using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoReactStarterKit.Controllers
{
    public class ReactRoutesController : RenderMvcController
    {
        public ActionResult Master(RenderModel model)
        {

            var mainNavigationView = View("Partials/MainNavigation", model);
            var bottomNavigationView = View("Partials/BottomNavigation", model);

            ViewBag.mainNavigation = mainNavigationView.RenderToString();
            ViewBag.bottomNavigation = bottomNavigationView.RenderToString();

            return base.Index(model);
        }
    }
}
