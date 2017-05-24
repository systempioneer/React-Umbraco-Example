using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoReactStarterKit.Controllers
{
    // All hail shazwazza https://shazwazza.com/post/Custom-MVC-routing-in-Umbraco
    public class RenderContentController : SurfaceController
    {
        private readonly ExamineManager _examineManager;

        public RenderContentController(ExamineManager examineManager)
        {
            _examineManager = examineManager;
        }

        public ActionResult ById(string id)
        {
            var criteria = _examineManager.DefaultSearchProvider
                .CreateSearchCriteria("content");
            var filter = criteria.Id(Convert.ToInt32(id));
            var result = Umbraco.TypedSearch(filter.Compile()).ToArray();
            if (!result.Any())
            {
                return HttpNotFound();
            }
            var renderModel = CreateRenderModel(result.First());

            return View(renderModel.Content.GetTemplateAlias(), renderModel);
        }

        private RenderModel CreateRenderModel(IPublishedContent content)
        {
            var model = new RenderModel(content, CultureInfo.CurrentUICulture);

            //add an umbraco data token so the umbraco view engine executes
            RouteData.DataTokens["umbraco"] = model;

            return model;
        }
    }
}