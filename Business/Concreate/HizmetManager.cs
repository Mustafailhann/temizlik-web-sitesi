using Business.Abstract;
using Data.Abstract;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class HizmetManager : IHizmetService
    {
        IHizmetDal _hizmetDal;

        public HizmetManager(IHizmetDal hizmetDal)
        {
            _hizmetDal = hizmetDal;
        }

        public void Delete(Hizmet h)
        {
            _hizmetDal.Delete(h);
        }

        public List<Hizmet> HizmetListele()
        {
            return _hizmetDal.List();
        }

        public void Insert(Hizmet h)
        {
            _hizmetDal.Insert(h);
        }

        public void Update(Hizmet h)
        {
            _hizmetDal.Update(h);
        }
    }
}
