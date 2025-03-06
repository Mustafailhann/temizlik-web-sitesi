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
        public DateTime Tarih {  get; set; }
        public virtual Musteri Musteri { get; set; }
        public virtual Personel Personel { get; set; }
        public ICollection<Yorum> Yorum { get; set; }
    }
}
