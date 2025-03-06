using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISiparisService
    {
        Siparis GetById(int id);
        List<Siparis> SiparisListele();
        void Insert(Siparis s);
        void Delete(Siparis s);
        void Update(Siparis s);
    }
}
