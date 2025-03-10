using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Business.Concreate;
using Data.EntityFramework;
using Entity.Concreate; 
using UI.Models;

namespace UI.Controllers
{
    public class AnasayfaController : Controller
    {
        HizmetManager hm = new HizmetManager(new EFHizmetDal());
        SiparisManager sm = new SiparisManager(new EFSiparisDal());
        MusteriManager mm = new MusteriManager(new EFMusteriDal());
        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        YorumManager ym = new YorumManager(new EFYorumDal());

        public ActionResult Index(int ? hizmetId)
        {

            
            var siparisler = sm.SiparisListele();
            var musteriler = mm.MusteriListele();
            var hizmetler = hm.HizmetListele();
            var yorumlar = ym.YorumListele();
            var personeller = pm.PersonelListele();
            
            var viewModel = new HomeViewModel
            {
                Hizmetler = hizmetler, 
                Siparisler = siparisler, 
                Musteriler = musteriler, 
                Personeller = personeller,
                Yorumlar =  yorumlar,

            };

            return View(viewModel);
        }
        public ActionResult Siparisolustur()
        { var siparisler = sm.SiparisListele();
            var musteriler = mm.MusteriListele();
            var hizmetler = hm.HizmetListele();
            var yorumlar = ym.YorumListele();
            var personeller = pm.PersonelListele();

            var viewModel = new HomeViewModel
            {
                Hizmetler = hizmetler,
                Siparisler = siparisler,
                Musteriler = musteriler,
                Personeller = personeller,
                Yorumlar = yorumlar,

            };
           

            var sonuc = from x in hm.HizmetListele()
                        select new SelectListItem
                        {
                            Text = x.HizmetAdi,
                            Value = x.HizmetId.ToString()

                        };
            ViewBag.d = sonuc;
            return View(viewModel);
        }
   
        [HttpPost]
        public ActionResult Siparisolustur(Musteri musteri, Siparis siparis)
        {
           
            mm.Insert(musteri);
            var yensiparis = new Siparis
            {
                MusteriId = musteri.MusteriId,
                MusteriAdi = musteri.MusteriAdi,
                MusteriSoyadi = musteri.MusteriSoyadi,
                Adres = siparis.Adres,
                teslimTarih = siparis.teslimTarih < new DateTime(1753, 1, 1) ? DateTime.Now : siparis.teslimTarih,
                siparisTarih = DateTime.Now,
                PersonelId = siparis.PersonelId,
            };
 
         //   siparis.MusteriId = yeniMusteri.MusteriId;
            sm.Insert(yensiparis);
            return RedirectToAction("Index");
        }
        public  ActionResult Kayitol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayitol(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                musteri.kayitlimi = true; // Yeni müşteri kaydında KayitliMi alanını true yap
                mm.Insert(musteri);
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        //----------------------------
        // Giriş yap sayfası
        public ActionResult Login()
        {
            return View();
        }

        // Giriş yap POST işlemi
        // Giriş yap POST işlemi
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = ValidateUser(model.PhoneNumber, model.Password);

                if (user != null)
                {
                    // Kullanıcı bilgilerini Session'a kaydedelim
                    Session["MusteriId"] = user.MusteriId;
                    Session["MusteriAdi"] = user.MusteriAdi;

                    // Başarıyla giriş yaptı, Anasayfa'ya yönlendir
                    return RedirectToAction("Index", "Anasayfa");
                }
                else
                {
                    // Kullanıcı hatalı, hata mesajı göster
                    ModelState.AddModelError("", "Telefon numarası veya şifre hatalı.");
                }
            }

            return View(model);
        }
        // Kullanıcı doğrulaması yapan metod (Musteri tablosundan sorgu yapıyor)
        private Musteri ValidateUser(string phoneNumber, string password)
        {
            // Telefon numarasına göre kullanıcıyı çek
            var musteri = mm.MusteriListele()
                .FirstOrDefault(m => m.Telefon == phoneNumber && m.Sifre == password);

            return musteri; // Kullanıcı varsa döndür, yoksa null döner
        }
        // Kullanıcı doğrulaması yapan metod
        public ActionResult yenisayfa ()
        {
            return View();
        }
    }
}


