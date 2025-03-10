using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public int MusteriId { get; set; }
        public int PersonelId { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi {  get; set; }
        public string Adres { get; set; }
        public DateTime teslimTarih {  get; set; }
        public DateTime siparisTarih { get; set; }
        public bool siparisDurum { get; set; } // iletişime geçilip geçilmemesi
        public virtual Musteri Musteri { get; set; }
        public virtual Personel Personel { get; set; }
        public ICollection<Yorum> Yorum { get; set; }

    }
}
