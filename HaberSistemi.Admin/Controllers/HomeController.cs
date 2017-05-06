using HaberSistemi.Admin.CustomFilter;
using System.Web.Mvc;

namespace HaberSistemi.Admin.Controllers
{
    [LoginFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}