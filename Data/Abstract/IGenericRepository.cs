using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Abstract
{
    public interface IGenericRepository<T>
    {
        List<T> List();
        T Get(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> List(Expression<Func<T, bool>> filter);
        T GetById(Expression<Func<T, bool>> filter);
        
    }
}
