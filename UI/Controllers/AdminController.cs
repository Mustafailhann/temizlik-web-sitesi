using Business.Concreate;
using Data.EntityFramework;
using Entity.Concreate;
//using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using Data.Concreate;
using System.Web.Security;


namespace UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        HizmetManager hm = new HizmetManager(new EFHizmetDal());
        SiparisManager sm = new SiparisManager(new EFSiparisDal());
        MusteriManager mm = new MusteriManager(new EFMusteriDal());
        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        YorumManager ym = new YorumManager(new EFYorumDal());
        private Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminGiris()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminGiris(Personel personel)
        {
            var personelBilgi = pm.PersonelListele()
                                       .Where(x => x.kullaniciAdi == personel.kullaniciAdi && x.sifre == personel.sifre)
                                       .FirstOrDefault();

            if (personelBilgi != null)
            {
                if (ModelState.IsValid)
                {
                    Session["KullaniciAdi"] = personel.kullaniciAdi; // Kullanıcı adını session’a kaydediyoruz
                    Session["RolId"] = personelBilgi.RolId; // Rol bilgisini session’a kaydediyoruz

                    if (personelBilgi.RolId == 1)
                    {
                        // Yönetici sayfasına yönlendir
                        return RedirectToAction("YoneticiAnasayfa", "Admin");
                        // Yonetici controller ve YoneticiSayfasi view'sine yönlendirme
                    }
                    else if (personelBilgi.RolId == 2)
                    {
                        // Personel sayfasına yönlendir
                        return RedirectToAction("PersonelAnasayfa", "Admin"); // Personel controller ve PersonelSayfasi view'sine yönlendirme
                    }
                }
            }
            else
            {
                // Eğer rolId 1 veya 2 değilse, başka bir işlem yapılabilir
                return RedirectToAction("GirisHatasi", "Hata"); // Örneğin hata sayfasına yönlendirme
            }


            return View(personelBilgi);
        }

        public ActionResult YoneticiAnasayfa()
        {

            return View();
        }


        public ActionResult PersonelAnasayfa()
        {
            var siparisler = sm.SiparisListele();  // Siparişler null ise boş liste ver

            var model = new HomeViewModel
            {
                Siparisler = siparisler  // ViewModel'e verileri aktar
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult PersonelAnasayfa(Personel personel)
        {
            // Kullanıcı giriş yapmadıysa, giriş sayfasına yönlendir
            if (Session["RolId"] == null)
            {
                return RedirectToAction("AdminGiris", "Admin");
            }
            else
            {

                // Giriş yapan kullanıcının siparişlerini getir
                var personelId = (int)Session["RolId"];  // Giriş yapan kişinin ID'si
                var siparisler = sm.SiparisListele();

                // Modeli döndürüyoruz
                var model = new HomeViewModel
                {
                    Siparisler = siparisler
                };

                return View(model);
            }
        }


        public ActionResult HizmetGoruntule()
        {
            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return RedirectToAction("AdminGiris", "Admin");
            }

            var hizmetListesi = hm.HizmetListele() ?? new List<Hizmet>();
            var model = new HomeViewModel
            {
                Hizmetler = hizmetListesi
            };
            return View(model);
        }

        // Hizmet Silme İşlemi
        // Hizmet Silme İşlemi (Ajax İle Sayfa Yenilenmeden)
        [HttpPost]
        public JsonResult HizmetSil(int id)
        {
            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return Json(new { success = false, message = "Yetkiniz yok!" });
            }

            var hizmet = hm.GetById(x => x.HizmetId == id);
            if (hizmet != null)
            {
                hm.Delete(hizmet);
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Hizmet bulunamadı!" });
        }

        // Hizmet Ekleme Sayfası
        // Hizmet Ekleme Sayfası
        public ActionResult HizmetEkle()
        {
            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return RedirectToAction("AdminGiris", "Admin");
            }
            return View();
        }

        // Hizmet Ekleme İşlemi
        [HttpPost]
        public ActionResult HizmetEkle(Hizmet yeniHizmet)
        {
            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return RedirectToAction("AdminGiris", "Admin");
            }

            if (ModelState.IsValid)
            {
                hm.Insert(yeniHizmet);  // Generic Repository kullanarak ekle
                return RedirectToAction("HizmetGoruntule");
            }
            return View(yeniHizmet);
        }
        public ActionResult PersonelGoruntule()
        {

            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return RedirectToAction("AdminGiris", "Admin");

            }

            var personelListesi = pm.PersonelListele() ?? new List<Personel>(); // Personel listesini al
            var model = new HomeViewModel
            {
                Personeller = personelListesi // Personel listesini ViewModel'e aktar
            };
            return View(model); // View'a HomeViewModel gönder
        }
        [HttpPost]
        public JsonResult PersonelSil(int id)
        {
            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return Json(new { success = false, message = "Yetkiniz yok!" });
            }

            var personel = pm.GetById(x => x.PersonelId == id); // pm: Personel yönetimi için repository
            if (personel != null)
            {
                pm.Delete(personel); // Personel silme işlemi
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Personel bulunamadı!" });
        }
        // Personel Ekleme Sayfası
        public ActionResult PersonelEkle()
        {
            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return RedirectToAction("AdminGiris", "Admin");  // Giriş yapmamışsa admin login sayfasına yönlendir
            }
            var rolListesi = db.Roller.Select(r => new SelectListItem
            {
                Text = r.RolName,  // Dropdown'da görünen isim
                Value = r.Id.ToString()  // Dropdown'un değeri (RolId)
            }).ToList();

            // ViewBag'e SelectList aktarılıyor
            ViewBag.RolListesi = new SelectList(rolListesi, "Value", "Text");


            return View();
        }
        // Personel Ekleme İşlemi
        [HttpPost]
        public ActionResult PersonelEkle(Personel yeniPersonel)
        {
            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return RedirectToAction("AdminGiris", "Admin");
            }

            if (ModelState.IsValid)
            {
                pm.Insert(yeniPersonel); // Generic Repository kullanarak personel ekle
                return RedirectToAction("PersonelGoruntule"); // Ekleme işlemi başarılıysa personel listeleme sayfasına yönlendir
            }
            return View(yeniPersonel); // Eğer model geçerli değilse aynı sayfayı tekrar göster
        }

        public ActionResult SiparisGoruntule()
        {
            if (Session["RolId"] == null || (int)Session["RolId"] != 1)
            {
                return RedirectToAction("AdminGiris", "Admin");

            }

            var siparisler = sm.SiparisListele() ?? new List<Siparis>();  // Siparişler null ise boş liste ver

            var model = new HomeViewModel
            {
                Siparisler = siparisler  // ViewModel'e verileri aktar
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SiparisGoruntule(Siparis siparis)
        {
            var siparisler = sm.SiparisListele() ?? new List<Siparis>();  // Siparişler null ise boş liste ver

            var model = new HomeViewModel
            {
                Siparisler = siparisler  // ViewModel'e verileri aktar
            };
            return View(model);

        }


    }
}