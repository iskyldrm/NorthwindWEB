using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.Entities.Models;
using System.Linq.Expressions;

namespace Northwind.DAL.Concrete
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
         where TEntity : class, new()
    {
        NorthwindContext db;
        public RepositoryBase()
        {
            db = new NorthwindContext();
        }
        public int Add(TEntity input)
        {
            db.Set<TEntity>().Add(input);
            return db.SaveChanges();
        }

        public int Delete(TEntity input)
        {
            db.Set<TEntity>().Remove(input);
            return db.SaveChanges();
        }

        public TEntity Find(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return db.Set<TEntity>().ToList();
            }
            else
            {
                return db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public IQueryable GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {
            var query = db.Set<TEntity>().Where(filter);

            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public int Update(TEntity input)
        {
            var result = db.Entry<TEntity>(input);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
