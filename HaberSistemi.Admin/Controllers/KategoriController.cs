using HaberiSistemi.Data.Model;
using HaberSistemi.Admin.Class;
using HaberSistemi.Admin.CustomFilter;
using HaberSistemi.Core.Infrastructure;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HaberSistemi.Admin.Controllers
{
    [LoginFilter]
    public class KategoriController : Controller
    {
        private readonly IKategoriRepository _kategoriRepository;

        public KategoriController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        // GET: Kategori
        public ActionResult Index(int sayfa = 1)
        {
            return View(_kategoriRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, 10));
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
                return Json(new ResultJson { Success = true, Message = "Kategori ekleme işleminiz başarılı." });
            }
            catch (Exception)
            {
                return Json(new ResultJson { Success = false, Message = "Kategori eklerken hata oluştu" });
            }
        }

        public JsonResult Sil(int id)
        {
            Kategori kategori = _kategoriRepository.GetById(id);
            if (kategori == null) return Json(new ResultJson { Success = false, Message = "Kategori bulunamadı" });
            _kategoriRepository.Delete(id);
            _kategoriRepository.Save();
            return Json(new ResultJson { Success = true, Message = "Kategori silme işlemi başarılı." });
        }

        public ActionResult Duzenle(int id)
        {
            Kategori kategori = _kategoriRepository.GetById(id);
            if (kategori == null) throw new Exception("Kategori bulunamadı.");
            SetKategoriListele();
            return View(kategori);
        }

        [HttpPost]
        public JsonResult Duzenle(Kategori kategori)
        {
            Kategori kat = _kategoriRepository.GetById(kategori.Id);
            kat.Aktif = kategori.Aktif;
            kat.KategoriAdi = kategori.KategoriAdi;
            if (kategori.ParentId != 0) kat.ParentId = kategori.ParentId;
            kat.Url = kategori.Url;
            _kategoriRepository.Save();
            return Json(new ResultJson() { Success = true, Message = "Düzenleme işlemi başarılı." });

            //return Json(new ResultJson() { Success = false, Message = "Hata oluştu." });
        }

        public void SetKategoriListele()
        {
            var kategoriler = _kategoriRepository.GetMany(x => x.ParentId == 0).ToList();
            ViewBag.Kategoriler = kategoriler;
        }
    }
}