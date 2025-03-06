using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Hizmet
    {
        public int HizmetId { get; set; }
        public string HizmetAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string Foto { get; set; }

        public ICollection<Personel> Personeller { get; set; }
    }
}
