using System;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        void Add(T t);

        void Update(T t);

        void Delete(T t);

        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda = null);

        IQueryable<T> GetModelsByPage<type>(int pageIndex, int pageSize, bool isAsc,
            Expression<Func<T, bool>> orderByLambda, Expression<Func<T, bool>> whereLambda);

        IQueryable<T> GetModelsBySql(string sql);

        bool SaveChanges();
    }
}
