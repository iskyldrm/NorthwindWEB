using System.Linq.Expressions;

namespace Northwind.DAL.Abstract
{
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        public int Add(TEntity input);
        public int Update(TEntity input);
        public int Delete(TEntity input);

        public TEntity Find(int id);

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        public IQueryable GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include);


    }
}