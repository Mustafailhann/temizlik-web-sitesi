using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
   public class Rol
    {
        public int Id { get; set; }
        public string RolName { get; set; }

        public ICollection<Personel> Personel { get; set; }

    }
}
