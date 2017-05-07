using HaberiSistemi.Data.Model;
using HaberSistemi.Core.Infrastructure;
using System.Web.Mvc;

namespace HaberSistemi.Admin.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriRepository _kategoriRepository;

        public KategoriController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Ekle(Kategori kategori)
        {
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}