using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IYorumService
    {
        List<Yorum> YorumListele();
        void Insert(Yorum y);
        void Delete(Yorum y);
        void Update(Yorum y);
    }
}
