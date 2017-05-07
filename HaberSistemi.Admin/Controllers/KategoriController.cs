using HaberiSistemi.Data.Model;
using HaberSistemi.Admin.Class;
using HaberSistemi.Core.Infrastructure;
using System;
using System.Linq;
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
            return View(_kategoriRepository.GetAll().ToList());
        }

        public ActionResult Ekle()
        {
            SetKategoriListele();
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

        public ActionResult Sil(int id)
        {
            Kategori kategori = _kategoriRepository.GetById(id);
            if (kategori == null) return View();
            _kategoriRepository.Delete(id);
            _kategoriRepository.Save();
            return RedirectToAction("Index", "Kategori");
        }

        public void SetKategoriListele()
        {
            var kategoriler = _kategoriRepository.GetMany(x => x.ParentId == 0).ToList();
            ViewBag.Kategoriler = kategoriler;
        }
    }
}