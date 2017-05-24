using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoReactStarterKit.Controllers
{
    public class ReactRoutesController : RenderMvcController
    {
        public ActionResult Master(RenderModel model)
        {
            return base.Index(model);
        }
    }
}
