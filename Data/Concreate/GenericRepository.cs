using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Concreate
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        Context db = new Context();
        DbSet<T> _obje;

        public GenericRepository()
        {
            _obje = db.Set<T>();
        }

        public void Delete(T entity)
        {
            var sonuc = db.Entry(entity);
            sonuc.State = EntityState.Deleted;
            db.SaveChanges();
        }
        public void Insert(T entity)
        {
            var sonuc = db.Entry(entity);
            sonuc.State = EntityState.Added;
            db.SaveChanges();
        }
        public void Update(T entity)
        {
            var sonuc = db.Entry(entity);
            sonuc.State = EntityState.Modified;
            db.SaveChanges();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _obje.SingleOrDefault(filter);
        }
        public List<T> List()
        {
            return _obje.ToList();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _obje.Where(filter).ToList();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _obje.FirstOrDefault(filter);
        }
    }
}
