using Data.Abstract;
using Data.Concreate;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework
{
    public class EFYorumDal : GenericRepository<Yorum>, IYorumDal
    {
        public List<Yorum> YorumListele()
        {
            using (var context = new Context())
            {
                return context.Yorumlar
                              .Include("Siparis") 
                              .Include("Siparis.Musteri") 
                              .ToList();
            }
        }
    }
}
