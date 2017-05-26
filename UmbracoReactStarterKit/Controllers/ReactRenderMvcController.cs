using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace UmbracoReactStarterKit.Controllers
{
    public class ReactRenderMvcController : RenderMvcController
    {
        public ViewResult ViewFromContentId(int id)
        {
            var result = Umbraco.ContentQuery.TypedContent(id);
            var renderModel = ViewExtensions.CreateRenderModel(result, RouteData);

            return View(renderModel.Content.GetTemplateAlias(), renderModel);
        }

    }
}