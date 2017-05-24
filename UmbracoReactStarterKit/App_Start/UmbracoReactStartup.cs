using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Examine;
using Umbraco.Core;
using Umbraco.Core.Configuration;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;

namespace UmbracoReactStarterKit
{
    public class UmbracoReactStartup : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // This project uses dependency injection
            // Read more about umbraco and dependency injection here:
            // https://glcheetham.name/2016/05/27/implementing-ioc-in-umbraco-unit-testing-like-a-boss/
            // https://glcheetham.name/2017/01/29/mocking-umbracohelper-using-dependency-injection-the-right-way/


            var umbracoContext = umbracoApplication.Context.GetUmbracoContext();

            var builder = new ContainerBuilder();

            var umbracoHelper = new Umbraco.Web.UmbracoHelper(umbracoContext);

            // Register our controllers from this assembly with Autofac
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // Register controllers from the Umbraco assemblies with Autofac
            builder.RegisterControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);
            // Register the types we need to resolve with Autofac
            builder.RegisterInstance(ExamineManager.Instance).As<ExamineManager>();
            builder.RegisterInstance(umbracoHelper.ContentQuery).As<ITypedPublishedContentQuery>();

            // Set up MVC to use Autofac as a dependency resolver
            var container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // And WebAPI
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            // Register catch all route
            RouteTable.Routes.MapUmbracoRoute(
                "ReactRoutes",
                "{*.}",
                new
                {
                    controller = "ReactRoutes",
                    action = "Master"
                }, new ReactUmbracoVirtualNodeRouteHandler());

        }
    }

    public class ReactRouteHandler : IRouteHandler
    {
        #region Implementation of IRouteHandler

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            // init umbraco context
            var httpContext = new HttpContextWrapper(HttpContext.Current);

            UmbracoContext.EnsureContext(
                httpContext,
                ApplicationContext.Current,
                new WebSecurity(httpContext, ApplicationContext.Current),
                UmbracoConfig.For.UmbracoSettings(),
                UrlProviderResolver.Current.Providers,
                false);

            var handler = new ReactUmbracoVirtualNodeRouteHandler();
            return handler.GetHttpHandler(requestContext);
        }

        #endregion
    }

    public class ReactUmbracoVirtualNodeRouteHandler : UmbracoVirtualNodeRouteHandler
    {
        protected override UmbracoContext GetUmbracoContext(RequestContext requestContext)
        {
            var ctx = base.GetUmbracoContext(requestContext);
            //check if context is null, we know it will be null if we are dealing with a request that
            //has an extension and by default no Umb ctx is created for the request
            if (ctx == null)
            {
                //TODO: Here you can EnsureContext , please note that the requestContext is passed in 
                //therefore your should refrain from using other singletons like HttpContext.Current since
                //you will already have a reference to it. Also if you need an ApplicationContext you should
                //pass this in via a ctor instead of using the ApplicationContext.Current singleton.
                // init umbraco context

                ctx = UmbracoContext.EnsureContext(
                    requestContext.HttpContext,
                    ApplicationContext.Current,
                    new WebSecurity(requestContext.HttpContext, ApplicationContext.Current),
                    UmbracoConfig.For.UmbracoSettings(),
                    UrlProviderResolver.Current.Providers,
                    false);
                
            }

            return ctx;
        }

        protected override IPublishedContent FindContent(RequestContext requestContext,
                UmbracoContext umbracoContext)
        {
            var umbracoHelper = new UmbracoHelper(umbracoContext);
            return umbracoHelper.TypedContentAtRoot().First();
        }
    }

}