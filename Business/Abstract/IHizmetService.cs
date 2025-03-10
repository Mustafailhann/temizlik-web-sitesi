using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHizmetService
    {
        List<Hizmet> HizmetListele();
        void Insert(Hizmet h);
        void Delete(Hizmet h);
        void Update(Hizmet h);
        Hizmet GetById(Expression<Func<Hizmet, bool>> filter);
    }
}
