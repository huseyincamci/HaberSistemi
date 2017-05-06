using HaberiSistemi.Data.Model;
using HaberSistemi.Core.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace HaberSistemi.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IKullaniciRepository _kullaniciRepository;

        public AccountController(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciVarmi = _kullaniciRepository.GetMany(x => x.Email == kullanici.Email && x.Sifre == kullanici.Sifre && x.Aktif == true).SingleOrDefault();
            if (kullaniciVarmi !=null)
            {
                if (kullaniciVarmi.Rol .RolAdi == "Admin")
                {
                    Session["KullaniciEmail"] = kullaniciVarmi.Email;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Yetkisiz kullanıcı";
                return View();
            }
            ViewBag.Message = "Kullanıcı bulunamadı.";
            return View();
        }
    }
}