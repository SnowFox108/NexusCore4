using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;

namespace TravelCentreClapham.FlyAfricaDirect.WebApi.Infrastructure
{
    public class LoggingActionFilter : IAutofacActionFilter
    {
        public void OnActionExecuting(HttpActionContext actionContext)
        {
            //TODO add logging here
            // _logger.Write(actionContext.ActionDescriptor.ActionName);
        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //TODO add logging here
            // _logger.Write(actionExecutedContext.ActionContext.ActionDescriptor.ActionName);
        }
    }
}