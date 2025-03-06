using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Yorum
    {
        public int YorumId { get; set; }

        public string YorumAciklamasi { get; set; }
        public int SiparisId { get; set; }
        public int Puan { get; set; }
        public int MusteriId { get; set; }
        public virtual Siparis Siparis { get; set; }
    }
}
