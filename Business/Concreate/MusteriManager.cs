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
    public class MusteriManager : IMusteriService
    {
        IMusteriDal _musteriDal;

        public MusteriManager(IMusteriDal musteriDal)
        {
            _musteriDal = musteriDal;
        }

        public void Delete(Musteri m)
        {
            _musteriDal.Delete(m);
        }

        public void Insert(Musteri m)
        {
            _musteriDal.Insert(m);
        }

        public List<Musteri> MusteriListele()
        {
            return _musteriDal.List();
        }

        public void Update(Musteri m)
        {
            _musteriDal.Update(m);
        }
    }
}
