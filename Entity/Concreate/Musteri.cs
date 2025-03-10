using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public bool kayitlimi { get; set; }
        public string Sifre { get; set; }

        public ICollection<Siparis> Siparis { get; set; }
    }
}
