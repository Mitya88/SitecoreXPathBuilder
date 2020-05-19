namespace XPathBuilder.Service
{
    using Sitecore.Pipelines;
    using System.Web.Http;
    using System.Web.Routing;

    public class RegisterHttpRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            RegisterRoute(RouteTable.Routes);
        }

        protected virtual void RegisterRoute(RouteCollection routes)
        {
            RouteTable.Routes.MapHttpRoute("XPathBuilderApi",
                "sitecore/api/ssc/xpathbuilderspeak/{action}",
                new { controller = "XPathBuilderApi" });
        }
    }
}