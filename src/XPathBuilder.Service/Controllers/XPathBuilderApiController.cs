namespace XPathBuilder.Service.Controllers
{
    using Sitecore.Configuration;
    using Sitecore.Services.Infrastructure.Web.Http;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using XPathBuilder.Service.Models;

    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class XPathBuilderApiController : ServicesApiController
    {
        public XPathBuilderApiController()
        {
        }

        [HttpPost]
        public XPathResponse Query([FromBody]XPathRequest request)
        {
            var response = new XPathResponse();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var database = Factory.GetDatabase(request.Database);

            if (request.Query.StartsWith("."))
            {
                var contextItem = database.GetItem(new Sitecore.Data.ID(request.ContextItemId));
                response.Items = contextItem.Axes.SelectItems(request.Query).Select(t => new ItemResponse(t)).ToList(); ;
            }
            else
            {
                response.Items = database.SelectItems(request.Query).Select(t => new ItemResponse(t)).ToList();
            }

            sw.Stop();
            response.Elapsed = sw.ElapsedMilliseconds;
            response.ResultCount = response.Items.Count;
            return response;
        }
    }
}