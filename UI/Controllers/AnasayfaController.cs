using System;
using System.Collections.Generic;
using System.Linq;
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
            var personeller2 = hizmetId.HasValue
                ? pm.PersonelListele().Where(p => p.HizmetId == hizmetId).ToList()
                : new List<Personel>();
            

          
            var viewModel = new HomeViewModel
            {
                Hizmetler = hizmetler, 
                Siparisler = siparisler, 
                Musteriler = musteriler, 
                Personeller = personeller,
                Yorumlar =  yorumlar,
                secilihizmetid = hizmetId
            };




            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Siparisolustur(Siparis siparis)
        {
            sm.Insert(siparis);
            return View();
        }

        




    }
}