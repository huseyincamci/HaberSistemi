using HaberiSistemi.Data.Model;
using HaberSistemi.Admin.Class;
using HaberSistemi.Core.Infrastructure;
using System;
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
            try
            {
                _kategoriRepository.Insert(kategori);
                _kategoriRepository.Save();
                return Json(new ResultJson {Success = true, Message = "Kategori ekleme işleminiz başarılı."});
            }
            catch (Exception)
            {
                return Json(new ResultJson {Success = false, Message = "Kategori eklerken hata oluştu"});
            }
        }
    }
}