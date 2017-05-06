using System.Web.Mvc;
using System.Web.Routing;

namespace HaberSistemi.Admin.CustomFilter
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session?["KullaniciEmail"];
            if (session != null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new System.NotImplementedException();
        }
    }
}