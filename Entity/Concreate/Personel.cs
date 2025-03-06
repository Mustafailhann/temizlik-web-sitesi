using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public int RolId { get; set; }
        public string Telefon { get; set; }
        public int HizmetId { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual Hizmet Hizmet { get; set; }
        public ICollection<Siparis> Siparis { get; set; }
    }
}
