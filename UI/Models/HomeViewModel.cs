using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.Concreate;

namespace UI.Models
{
    public class HomeViewModel
    {
        public List<Hizmet> Hizmetler { get; set; }
        public List<Siparis> Siparisler { get; set; }
        public List<Musteri> Musteriler { get; set; }
        public List<Personel> Personeller { get; set; }
        public List<Yorum> Yorumlar { get; set; }
        public int? secilihizmetid { get; set; }
    }
    public class YorumViewModel
    {
        public int YorumID { get; set; }
        public string YorumAciklama { get; set; }
        public string MusteriAdi { get; set; }  // MusteriAd bilgisini buraya ekliyoruz
    }
}