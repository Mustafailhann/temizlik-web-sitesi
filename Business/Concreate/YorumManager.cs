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
    public class YorumManager : IYorumService
    {
        IYorumDal _yorumDal;

        public YorumManager(IYorumDal yorumDal)
        {
            _yorumDal = yorumDal;
        }

        public void Delete(Yorum y)
        {
            _yorumDal.Delete(y);
        }

        public void Insert(Yorum y)
        {
            _yorumDal.Insert(y);
        }

        public List<Yorum> YorumListele()
        {
            return _yorumDal.List();
        }

        public void Update(Yorum y)
        {
            _yorumDal.Update(y);
        }
    }
}
