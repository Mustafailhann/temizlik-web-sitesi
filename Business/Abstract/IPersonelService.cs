using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        List<Personel> PersonelListele();
        void Insert(Personel p);
        void Delete(Personel p);
        void Update(Personel p);
    }
}
