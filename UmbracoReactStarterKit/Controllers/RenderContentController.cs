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
        private readonly ITypedPublishedContentQuery _contentQuery;

        public RenderContentController(ExamineManager examineManager, ITypedPublishedContentQuery contentQuery)
        {
            _examineManager = examineManager;
            _contentQuery = contentQuery;
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
            var renderModel = ViewExtensions.CreateRenderModel(result.First(), RouteData);

            return Json(new
            {
                Name = renderModel.Content.Name,
                Content = View(renderModel.Content.GetTemplateAlias(), renderModel).RenderToString()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}