using Business.Abstract;
using Data.Abstract;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public void Delete(Personel p)
        {
            _personelDal.Delete(p);
        }

        public void Insert(Personel p)
        {
            _personelDal.Insert(p);
        }

        public List<Personel> PersonelListele()
        {

            return _personelDal.List();
        }

        public void Update(Personel p)
        {
            _personelDal.Update(p);
        }
    }
}
