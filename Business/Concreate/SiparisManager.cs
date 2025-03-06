using Business.Abstract;
using Data.Abstract;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class SiparisManager : ISiparisService
    {
        ISiparisDal _siparisDal;

        public SiparisManager(ISiparisDal siparisDal)
        {
            _siparisDal = siparisDal;
        }

        public void Delete(Siparis s)
        {
            _siparisDal.Delete(s);
        }

        public Siparis GetById(int id)
        {
            return _siparisDal.Get(x => x.SiparisId == id);
        }

        public void Insert(Siparis s)
        {
            _siparisDal.Insert(s);
        }

        public List<Siparis> SiparisListele()
        {
            return _siparisDal.List();
        }

        public void Update(Siparis s)
        {
            _siparisDal.Update(s);
        }
    }
}
