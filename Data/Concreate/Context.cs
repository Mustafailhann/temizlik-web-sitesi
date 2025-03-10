using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concreate;

namespace Data.Concreate
{
    public class Context : DbContext
    {
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Rol> Roller { get; set; }
    }
}
